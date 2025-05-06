Imports System.IO
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Ipc
Imports System
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports ZStack.RegionTracking
Imports ZStack.MainWindow
Imports ZStackUnsafeProcessing.Unmanaged


Public Class Process


    '***********************************************************************
    '***********************************************************************
    Public Const NbTrackMax As Long = 100000     ' Nb Track max par fichier
    Public Const NbPointsMax As Long = 1000000   ' Nb Points max par fichier
    Public Const MaxDensityPerPixel As Double = 0.02 ' Densité max=0 .5 mol/micron^2 = 0.02 mol/pixel (5 pix/microns)
    '  Public Const MaxDensityPerPixel As Double = 0.01 ' COREY 2016.05.02 reduce density per pixel to avoid out of memory warnings 

    Public Const NbSegParams As Long = 13 '12  New DLLs 2016.04.07
    Public Const NbTrackParams As Long = 9 '7  New DLLs 2016.04.07

    Public MM As MMAppLib.UserCall64
    Private MW As MainWindow
    Private CXX_3D() As Double
    Private CYY_3D() As Double
    Public src As Long
    Public srcHeight As Integer
    Public srcWidth As Integer
    Public srcDepth As Integer
    Public NbMaxPtsPerImage As Double
    Public LocalizationMode As String = "Wavelet"
    Public RealNbSegParams As Integer = 13
    Public RegistrationDist As Double = 3.0# ' Rayon max pour tracking

    Public ROIPreviewHdl_Tab As Long()
    Public ListZlog As New List(Of Double)
    '***********************************************************************
    '***********************************************************************

    Structure ROI_track
        Dim height As Integer
        Dim width As Integer
        Dim Px As Integer
        Dim Py As Integer
        Dim hdlROI As Long
        Dim WT As Double
        Dim plane As Integer
        Dim Z As Double
    End Structure

    Public Structure detection_data
        Public CentroidX As Double
        Public CentroidY As Double
        Public CentroidZ As Double
        Public Intensity As Double
        Public IntensityGauss As Double
        Public Surface As Double
        Public SigmaX As Double
        Public SigmaY As Double
        Public SigmaGoodness As Double
        Public circularity As Double
        Public scoreAutoDetection As Integer
    End Structure

    Public Structure Coord
        Dim coordX As Double
        Dim coordY As Double
        Dim coordZ As Double
    End Structure

    Public Structure AutomaticBeadDetection
        Public plane As Integer
        Public WTthresh As Double
        Public ROIdetectionArea As ROI_track
        Public listDetectedBead As List(Of detection_data)
    End Structure

    Structure MIAMorpho
        Dim Index As Long
        Dim Mean As Double
        Dim Surface As Integer
        Dim Intensity As Double
        Dim Perimeter As Double
        Dim Morpho As Double
        'Dim Channel As Integer 'maxX As Double
        Dim Channel As Double 'Update COREY 2015.11.27 for Spectral - uses channel for pair distance
        Dim Intensity_Gauss As Double 'maxY As Double
        Dim chi2 As Double 'valMax As Double
        Dim CentroidX As Double
        Dim CentroidY As Double
        Dim CentroidZ As Double
        Dim BinaryCentroidX As Double
        Dim Zerror As Double    ' As Double
        Dim sigmaX As Double
        Dim sigmaY As Double
        Dim AngleRad As Double
        Dim AngleDeg As Double
        Dim plane As Long
        Dim LocalizationIndex As Integer 'Added COREY 2016.04.22 new DLL
        Dim PairDistance As Double 'Added COREY 2016.11.22 for spectral 'TODO Add Pair Distance (px) here and convert Channel to wavelength in nm
        Dim Dinst As Double
    End Structure

    Sub New(ByRef _MainFrame As MainWindow, ByRef _meta As MMAppLib.UserCall64)
        MW = _MainFrame
        MM = _meta
    End Sub

    Public Sub ReadRawImage(ByVal MM As MMAppLib.UserCall64)

        '*******************MM**********************
        Dim nb_planes As Integer
        MM.GetCurrentImage(src)
        MM.GetWidth(src, srcWidth)
        MM.GetHeight(src, srcHeight)
        MM.GetNumberOfPlanes(src, nb_planes)
        '*************Detection**********************

        '*************Detection**********************
        NbMaxPtsPerImage = CLng(CDbl(srcWidth) * CDbl(srcHeight) * MaxDensityPerPixel)
        Dim NbMaxPtsPerROI = CLng(CDbl(MW.roiTracking.width) * CDbl(MW.roiTracking.height) * MaxDensityPerPixel)
        'Dim Nb_Val = nb_planes * NbSegParams * NbMaxPtsPerImage
        Dim Nb_Val = NbSegParams * NbMaxPtsPerImage
        Dim nb_Val_ROI = NbSegParams * NbMaxPtsPerROI
        Dim Points(nb_Val_ROI - 1) As Double
        Dim Points_all(nb_Val_ROI * nb_planes - 1) As Double
        Dim IsGPUAcceleration = False
        Dim IsWatershed = False
        Dim Wavelet_WatershedRatio As Double
        Dim WaveletThreshold = CInt(MW.TXTBX_WT_Threshold.Text)
        Dim pointsNumberCurrentFrame, PointsNumber As Integer
        Dim index As Integer = 0
        Dim buffer(MW.roiTracking.width * MW.roiTracking.height - 1) As UShort
        Dim Gauss_Fit_Calibration As Integer = 6
        Dim SigmaGauss_Fit = 1.0#
        Dim ThetaGauss_Fit = 0.0#
        '********************************************

        '*************tracking**********************
        Dim Decrease = 10
        Dim CostBirth = 0.5#
        Dim MaxDistance = 5
        Dim MinLength = 2
        Dim trcList(PointsNumber * NbTrackParams - 1) As Double
        '*******************************************

        If IsWatershed Then
            Wavelet_WatershedRatio = 0.0#
        Else
            Wavelet_WatershedRatio = 10.0#
        End If


        Dim ret_val As Integer
        If IsGPUAcceleration = True Then

            ret_val = ZStackUnsafeProcessing.Unmanaged.LiveProcessing(True, MM, src, CUShort(Nb_Val - 1), CUShort(nb_planes), Points, CUInt(NbMaxPtsPerImage * NbSegParams), CUInt(srcWidth), CUInt(srcHeight), 1, WaveletThreshold, Wavelet_WatershedRatio, 4.0#, 0.0#, LocalizationMode, CUShort(9), 1.0#, 0.0#, 0.0#, CUShort(7))

        Else
            index = 0
            For i = 1 To nb_planes


                MM.SetActivePlane(src, i)

                'UnsafeProcessing.Unmanaged.ReadImage(MM, src, MW.roiTracking.Px, MW.roiTracking.Py, MW.roiTracking.width, MW.roiTracking.height, buffer)
                '********Sans fit*************'
                'ret_val = UnsafeProcessing.Unmanaged.CPUProcessing(False, MM, src, Points, CUInt(Nb_Val), CUInt(srcWidth), CUInt(srcHeight), 1, WaveletThreshold, Wavelet_WatershedRatio, 4.0#, 0.0#, CUShort(0), 1.0#, 0.0#, 0.0#, CUShort(7))
                'ret_val = UnsafeProcessing.Unmanaged.CPUProcessing(False, MM, MW.roiTracking.hdlROI, Points, CUInt(nb_Val_ROI), CUInt(MW.roiTracking.width), CUInt(MW.roiTracking.height), 1, WaveletThreshold, Wavelet_WatershedRatio, 4.0#, 0.0#, CUShort(0), 1.0#, 0.0#, 0.0#, CUShort(7))

                '***********avec fit************'
                'ret_val = UnsafeProcessing.Unmanaged.CPUProcessing(False, MM, src, Points, CUInt(Nb_Val), CUInt(srcWidth), CUInt(srcHeight), 1, WaveletThreshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(7))
                ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessingROI(False, MM, src, Points, CUInt(nb_Val_ROI), CUInt(MW.roiTracking.width), CUInt(MW.roiTracking.height), CUInt(MW.roiTracking.Px), CUInt(MW.roiTracking.Py), 1, WaveletThreshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(7))

                pointsNumberCurrentFrame = ((ret_val) / NbSegParams) - 1
                PointsNumber = pointsNumberCurrentFrame + PointsNumber


                For li = 0 To (pointsNumberCurrentFrame - 1)
                    For ind = 0 To NbSegParams - 1
                        Points_all(index + ind) = Points(li * NbSegParams + ind)
                    Next ind
                    index = index + NbSegParams
                Next li

                For ind = 0 To NbSegParams - 1
                    Points_all(index + ind) = -1
                Next ind
                index = index + NbSegParams
            Next

            ReDim Preserve Points_all((nb_planes + PointsNumber) * NbSegParams - 1)

        End If

        ReDim trcList(PointsNumber * NbTrackParams - 1)

        'Dim trcNumber = UnsafeProcessing.Unmanaged.TrackingProcessing(Points_all, CUInt((nb_planes + PointsNumber) * NbSegParams), trcList, PointsNumber * NbTrackParams, MaxDistance, 2.0#, MinLength, Decrease, CUInt(0), CostBirth, CUInt(2), CUInt(2), CUInt(nb_planes))
        'MM.PrintMsg("Track number : " + trcNumber.ToString())

        Dim drift = RegistrationOffLine(Points_all, PointsNumber, nb_planes, MW.roiTracking.Px + (MW.roiTracking.width / 2), MW.roiTracking.Py + (MW.roiTracking.height / 2), MM)
        MM.PrintMsg("Track number : " + drift(2).ToString())
        MM.PrintMsg("Drift X : " + drift(0).ToString() + "  -  Drift Y : " + drift(1).ToString())


    End Sub

    'Public Sub FindBead(ByVal MM As MMAppLib.UserCall64, ByRef Nb_Val As Integer)
    '    Dim plane, lk, lm, XP, YP As Integer
    '    Dim LRXoffset = 0
    '    Dim LRYoffset = 0
    '    Dim RPoints As Double() = _parameterslist(0)
    '    Dim SRPoints As Double() = _parameterslist(1)

    '    Dim RegistrationDist As Double  ' Rayon max pour tracking
    '    Dim p As Long

    '    RegistrationDist = CDbl(0.6) ' 0.6

    '    Dim nf As Integer = CInt(_parameterslist(2)(0))


    '    If Nb_Val > 0 Then
    '        MM.PrintMsg("[Background] Automatic Registration with " + Str(RegistrationDist) + "pixel radius")
    '        'meta.PrintMsg ("Offset: " + str(LRXoffset) + " : " + str(LRYoffset))
    '        lm = 0  ' Comptage Nb Objets/plan
    '        lk = 0  ' Indice début de plan
    '        plane = 0
    '        'MsgBox (Nb_Val)
    '        'meta.PrintMsg (Nb_Val)

    '        For li = 0 To (Nb_Val - 1)
    '            XP = RPoints(li * NbSegParams + 3) + LRXoffset 'RPoints(li * 4)
    '            YP = RPoints(li * NbSegParams + 4) + LRYoffset 'RPoints(li * 4 + 1)
    '            'meta.PrintMsg (str(plane) & " : " & str(li) & ": " & str(XP) & " ; " & str(YP) & " ; " & str(lm))

    '            If (XP - LRXoffset) <> -1 And (YP - LRYoffset) <> -1 Then

    '                'meta.PrintMsg ("----" + str(plane) & " : " & str(li) & ": " & str(XP) & " ; " & str(YP) & " ; " & str(lm))
    '                ' Filtrage des structures détectées
    '                Dim StructureFilter = True
    '                If (filteringChecked) Then
    '                    If (filteringPlaneChecked) Then
    '                        If plane < CInt(filteringPlaneMin) - 1 Or plane >= CInt(filteringPlaneMax) Then
    '                            StructureFilter = False
    '                        End If
    '                    End If

    '                    If (filteringROIChecked) Then
    '                        'Vérification appartenance point dans le masque
    '                        'meta.PrintMsg(Str(CInt(XP) + LRXoffset) + " ; " + Str(CInt(YP) + LRYoffset))
    '                        'meta.PrintMsg(LRMask(CInt(XP) + LRXoffset, CInt(YP) + LRYoffset))
    '                        ' If LRMask(CInt(XP) + LRXoffset, CInt(YP) + LRYoffset) = 0 Then
    '                        ' Try
    '                        If (XP > 0 AndAlso YP > 0 AndAlso XP < (LRDX + LRXoffset) AndAlso YP < (LRDY + LRYoffset)) Then
    '                            If LRMask(CInt(XP), CInt(YP)) = 0 Then
    '                                StructureFilter = False
    '                            End If
    '                        End If


    '                        'Catch ex As Exception
    '                        'Catches out of bounds exception from transformed coordinates
    '                        'meta.PrintMsg("[Automatic Registration] LR ROI Error at pixel " + Str(CInt(XP)) + " ; " + Str(CInt(YP)))
    '                        ' StructureFilter = False
    '                        'End Try
    '                    End If
    '                End If
    '                If StructureFilter = True Then
    '                    If plane > 0 Then
    '                        ' Comparaison avec toutes les coordonnées. Conserve les coordonnées la plus proche dans un voisinnage < RegistrationDist
    '                        d1 = 1.1 * (RegistrationDist) ^ 2 ' Initialisation dmin
    '                        'meta.PrintMsg (NTrackReg)
    '                        For i = 0 To NTrackReg - 1
    '                            d = (XP - AutoRegisterTab_2D(i, plane - 1).CentroidX) ^ 2 + (YP - AutoRegisterTab_2D(i, plane - 1).CentroidY) ^ 2
    '                            'meta.PrintMsg ("*   " + str(plane - 1) + " : " + str(i) + " : " + str(d) + " : " + str(AutoRegisterTab(i, plane - 1).CentroidX) & " ; " & str(AutoRegisterTab(i, plane - 1).CentroidY) & " ; " & str(AutoRegisterTab(i, plane - 1).intensity) & " ; " & str(AutoRegisterTab(i, plane - 1).Surface))
    '                            'meta.PrintMsg (d)
    '                            ' Calcule la distance la plus proche d'une molécule
    '                            If d < d1 Then
    '                                d1 = d
    '                                ii = i
    '                            End If
    '                        Next i

    '                        'meta.PrintMsg("li: " + li.ToString() + " plane: " + (plane + 1).ToString() + " (" + XP.ToString() + "," + YP.ToString() + ")" + " Passed Filter. Min d: " + d.ToString())

    '                        'meta.PrintMsg ("d= " + str(d1))
    '                        ' Garde la plus proche distance dans une distance < RegistrationDist
    '                        If (d1 <= RegistrationDist ^ 2) Then

    '                            If (AutoRegisterTab_2D(ii, plane).CentroidX = -1) Then ' Nouvelle molecule de voisinage
    '                                'meta.PrintMsg("new neighbor - keeping molecule")
    '                                AutoRegisterTab_2D(ii, plane).CentroidX = RPoints(li * NbSegParams + 3) + LRXoffset 'RPoints(li * 4)
    '                                AutoRegisterTab_2D(ii, plane).CentroidY = RPoints(li * NbSegParams + 4) + LRYoffset 'RPoints(li * 4 + 1)
    '                                AutoRegisterTab_2D(ii, plane).Intensity = RPoints(li * NbSegParams + 8) 'RPoints(li * 4 + 2)
    '                                AutoRegisterTab_2D(ii, plane).Surface = RPoints(li * NbSegParams + 9) 'RPoints(li * 4 + 3)

    '                            Else    ' Déjà une molécule candidate, conserve la plus proche
    '                                'meta.PrintMsg("existing neighbor")
    '                                If d1 < ((AutoRegisterTab_2D(ii, plane).CentroidX - AutoRegisterTab_2D(ii, plane - 1).CentroidX) ^ 2 + (AutoRegisterTab_2D(ii, plane).CentroidY - AutoRegisterTab_2D(ii, plane - 1).CentroidY) ^ 2) Then
    '                                    'meta.PrintMsg("keeping molecule")
    '                                    AutoRegisterTab_2D(ii, plane).CentroidX = RPoints(li * NbSegParams + 3) + LRXoffset 'RPoints(li * 4)
    '                                    AutoRegisterTab_2D(ii, plane).CentroidY = RPoints(li * NbSegParams + 4) + LRYoffset 'RPoints(li * 4 + 1)
    '                                    AutoRegisterTab_2D(ii, plane).Intensity = RPoints(li * NbSegParams + 8) 'RPoints(li * 4 + 2)
    '                                    AutoRegisterTab_2D(ii, plane).Surface = RPoints(li * NbSegParams + 9) 'RPoints(li * 4 + 3)
    '                                End If
    '                            End If

    '                            'meta.PrintMsg ("*=> " + str(plane) + " : " + str(ii) + " : " + str(d) + " : " + str(AutoRegisterTab(ii, plane).CentroidX) & " ; " & str(AutoRegisterTab(ii, plane).CentroidY) & " ; " & str(AutoRegisterTab(ii, plane).intensity) & " ; " & str(AutoRegisterTab(ii, plane).Surface))
    '                        End If
    '                    End If
    '                    lm = lm + 1
    '                End If
    '            Else ' Changement de plan (-1,-1,-1,-1)
    '                'meta.PrintMsg("NB molecules plan " + Str(plane) + " : " + Str(lm))
    '                If plane = 0 Then ' Initialisation des RPoints de trajectoires potentielles
    '                    NTrackReg = lm 'li - lk
    '                    ' meta.PrintMsg("Nb Trajectoires max:" + Str(NTrackReg))
    '                    ' Allocation Memoire Tableau recalage 2D
    '                    ReDim AutoRegisterTab_2D(NTrackReg - 1, LRDZ - 1)
    '                    ' Initialisation du tableau à -1, -1, -1, -1
    '                    For lm = 0 To NTrackReg - 1
    '                        For lj = 0 To LRDZ - 1
    '                            AutoRegisterTab_2D(lm, lj).CentroidX = -1
    '                            AutoRegisterTab_2D(lm, lj).CentroidY = -1
    '                            AutoRegisterTab_2D(lm, lj).Intensity = -1
    '                            AutoRegisterTab_2D(lm, lj).Surface = -1
    '                        Next lj
    '                    Next lm
    '                    'meta.PrintMsg ("OK")
    '                    ' Enregistrement des RPoints
    '                    lm = 0
    '                    For lj = lk To li - 1
    '                        XP = RPoints(lj * NbSegParams + 3) + LRXoffset 'RPoints(li * 4)
    '                        YP = RPoints(lj * NbSegParams + 4) + LRYoffset 'RPoints(li * 4 + 1)

    '                        StructureFilter = True
    '                        If (filteringChecked) Then
    '                            If (filteringPlaneChecked) Then
    '                                If plane < CInt(filteringPlaneMin) - 1 Or plane >= CInt(filteringPlaneMax) Then
    '                                    StructureFilter = False
    '                                End If
    '                            End If

    '                            If (filteringROIChecked) Then
    '                                ' Vérification appartenance point dans le masque
    '                                'If LRMask(CInt(RPoints(lj * 4)) + LRXoffset, CInt(RPoints(lj * 4 + 1)) + LRYoffset) = 0 Then
    '                                'Try
    '                                If (XP > 0 AndAlso YP > 0 AndAlso XP < (LRDX + LRXoffset) AndAlso YP < (LRDY + LRYoffset)) Then
    '                                    If LRMask(CInt(XP), CInt(YP)) = 0 Then
    '                                        StructureFilter = False
    '                                    End If
    '                                End If
    '                                'Catch ex As Exception
    '                                '    meta.PrintMsg("[Automatic Registration] LR ROI problem in register track generation at plane " + plane.ToString() + " and lj=" + lj.ToString())
    '                                '    StructureFilter = False
    '                                'End Try

    '                            End If
    '                        End If

    '                        If (StructureFilter = True) Then
    '                            AutoRegisterTab_2D(lm, plane).CentroidX = RPoints(lj * NbSegParams + 3) + LRXoffset 'RPoints(lj * 4)
    '                            AutoRegisterTab_2D(lm, plane).CentroidY = RPoints(lj * NbSegParams + 4) + LRYoffset 'RPoints(lj * 4 + 1)
    '                            AutoRegisterTab_2D(lm, plane).Intensity = RPoints(lj * NbSegParams + 8) 'RPoints(lj * 4 + 2)
    '                            AutoRegisterTab_2D(lm, plane).Surface = RPoints(lj * NbSegParams + 9) 'RPoints(lj * 4 + 3)
    '                            'meta.PrintMsg (str(plane) + " : " + str(lm) + " : " + str(RPoints(lj * NbSegParams + 3)) & " ; " & str(RPoints(lj * NbSegParams + 4)) & " ; " & str(RPoints(lj * NbSegParams + 8)) & " ; " & str(RPoints(lj * NbSegParams + 9)))
    '                            lm = lm + 1
    '                        End If
    '                    Next lj
    '                    lm = 0
    '                Else    ' Décalage pour ne retenir que RPoints correctement trackés
    '                    'meta.PrintMsg (plane)
    '                    lm = 0
    '                    i = 0
    '                    While i < NTrackReg
    '                        If (AutoRegisterTab_2D(i, plane).CentroidX = -1) And (AutoRegisterTab_2D(i, plane).CentroidX = -1) Then
    '                            ' Décalage DE TOUS LES PLANS
    '                            For p = 0 To plane
    '                                For j = i + 1 To NTrackReg - 1
    '                                    'AutoRegisterTab(j - 1, plane) = AutoRegisterTab(j, plane)
    '                                    AutoRegisterTab_2D(j - 1, p) = AutoRegisterTab_2D(j, p)
    '                                Next j
    '                            Next p
    '                            NTrackReg = NTrackReg - 1
    '                            'meta.PrintMsg ("Track " + Str(i) + " Ends")
    '                        Else
    '                            i = i + 1
    '                        End If
    '                    End While
    '                End If
    '                lk = li
    '                plane = plane + 1

    '                If NTrackReg = 0 Then
    '                    Exit For
    '                End If
    '            End If

    '            'ToolStripProgressBar1.Value = li

    '        Next li

    '        If NTrackReg > 0 Then
    '            ' Création du fichier de Recalage Automatique (trajectoire de longueur égale au nombre de plans)
    '            If Not NewFileFormat_Chk.Checked Then
    '                DestFileName = Mid(srcPath, 1, Len(srcPath) - 4) + ".MIA\"
    '                If (Dir(DestFileName, vbDirectory) = "") Then ' Repertoire inexistant
    '                    meta.PrintMsg("Create " + DestFileName)
    '                    MkDir(DestFileName)
    '                End If

    '                DestFileName = Mid(srcPath, 1, Len(srcPath) - 4) + ".MIA\tracking\"
    '                If (Dir(DestFileName, vbDirectory) = "") Then ' Repertoire inexistant
    '                    meta.PrintMsg("Create " + DestFileName)
    '                    MkDir(DestFileName)
    '                End If

    '                AutoRegisterFileName = Mid(srcPath, 1, Len(srcPath) - 4) + ".MIA\tracking\" + srcName + "_MIA-Register.trc"
    '            Else 'NewFileFormat_Chk.checked
    '                DestFileName = Mid(srcPath, 1, Len(srcPath) - 4) + ".PT\"
    '                If (Dir(DestFileName, vbDirectory) = "") Then ' Repertoire inexistant
    '                    meta.PrintMsg("Create " + DestFileName)
    '                    MkDir(DestFileName)
    '                End If

    '                AutoRegisterFileName = Mid(srcPath, 1, Len(srcPath) - 4) + ".PT\Register.txt"
    '            End If


    '            'Open AutoRegisterFileName For Output As AutoRegisterFileNum
    '            AutoRegisterFileNum = New StreamWriter(AutoRegisterFileName)

    '            If NewFileFormat_Chk.Checked Then
    '                tmp_str = "Width" + vbTab + "Height" + vbTab + "nb_Planes" + vbTab + "nb_Tracks" + vbTab + "Pixel_Size(um)" + vbTab + "Frame_Duration(s)" + vbTab + "Gaussian_Fit" + vbTab + "Spectral"
    '                AutoRegisterFileNum.WriteLine(tmp_str)
    '                tmp_str = srcWidth.ToString("F0") + vbTab + srcHeight.ToString("F0") + vbTab + nb_planes.ToString("F0") + vbTab + lj.ToString("F0") + vbTab + Calibration_XY_Txt.Text() + vbTab + Calibration_T_Txt.Text() + vbTab + GaussFitParam_List.Text() + vbTab + Spectral_Chk.Checked.ToString()
    '                AutoRegisterFileNum.WriteLine(tmp_str)
    '                tmp_str = "Track" + vbTab + "Plane" + vbTab + "CentroidX(px)" + vbTab + "CentroidY(px)" + vbTab + "CentroidZ(um)" + vbTab + "Integrated_Intensity"
    '                AutoRegisterFileNum.WriteLine(tmp_str)
    '            End If

    '            meta.PrintMsg("Automatic registration file: " + AutoRegisterFileName + " : " + Str(NTrackReg) + " track(s) found.")
    '            'ToolStripStatusLabel1.Text = Str(NTrackReg) + " register track(s) found."
    '            batchNumRegTracks(nf) = NTrackReg

    '            Dim NTrackRegS As Integer = NTrackReg
    '            For lm = 0 To NTrackReg - 1
    '                For lj = 0 To LRDZ - 1
    '                    If Not (filteringChecked And filteringROIChecked And filteringROICropChecked) Then
    '                        If Spectral_Chk.Checked And (SpectralMode_List.Text <> "2 Colors") Or Channel_Chk.Checked Then
    '                            'if the localization is on the left side, ignore it in the "normal" register
    '                            'it will get picked up in 2C register
    '                            If AutoRegisterTab_2D(lm, lj).CentroidX > LRDX Then
    '                                If Morph.plane = LRDZ - 1 Then
    '                                    NTrackRegS = NTrackRegS - 1
    '                                End If
    '                                Continue For
    '                            End If
    '                        End If
    '                    End If
    '                    'tmp_str = Str(lm + 1) + vbTab + Str(lj + 1) + vbTab + Str(AutoRegisterTab_2D(lm, lj).CentroidX + LRXoffset) + vbTab + Str(AutoRegisterTab_2D(lm, lj).CentroidY + LRYoffset) + vbTab + Str(AutoRegisterTab_2D(lm, lj).Surface) + vbTab + Str(AutoRegisterTab_2D(lm, lj).Intensity)
    '                    If Not NewFileFormat_Chk.Checked Then
    '                        tmp_str = Str(lm + 1) + vbTab + Str(lj + 1) + vbTab + Str(AutoRegisterTab_2D(lm, lj).CentroidX) + vbTab + Str(AutoRegisterTab_2D(lm, lj).CentroidY) + vbTab + Str(AutoRegisterTab_2D(lm, lj).Surface) + vbTab + Str(AutoRegisterTab_2D(lm, lj).Intensity)
    '                    Else
    '                        tmp_str = Str(lm + 1) + vbTab + Str(lj + 1) + vbTab + Str(AutoRegisterTab_2D(lm, lj).CentroidX) + vbTab + Str(AutoRegisterTab_2D(lm, lj).CentroidY) + vbTab + Str(AutoRegisterTab_2D(lm, lj).CentroidZ) + vbTab + Str(AutoRegisterTab_2D(lm, lj).Intensity)
    '                    End If

    '                    'Print #AutoRegisterFileNum, tmp_str
    '                    AutoRegisterFileNum.WriteLine(tmp_str)
    '                Next (lj)
    '            Next lm
    '            If Spectral_Chk.Checked And (SpectralMode_List.Text <> "2 Colors") Or Channel_Chk.Checked Then
    '                meta.PrintMsg("Automatic registration: 2C Registration " + Str(NTrackRegS) + " track(s) saved.")
    '                batchNumRegTracks(nf) = NTrackRegS
    '            End If
    '            'Close(AutoRegisterFileNum)
    '            AutoRegisterFileNum.Close()
    '        Else
    '            meta.PrintMsg("Automatic registration failed. No track found. Last track stops at plane: " + Str(plane))
    '            batchNumRegTracks(nf) = 0
    '            'Added COREY 2016.06.22
    '            'Shows the frame where the registration stopped
    '            meta.SetActivePlane(src, plane)
    '            'ToolStripStatusLabel1.Text = "Automatic registration failed at frame " + Str(plane)
    '            If (Batch_Chk.Checked And NbFiles2Process > 1) Then
    '                'If no track found and in batch mode, stop
    '                'Exit Sub
    '            End If
    '        End If  ' Ntrack >0
    '    End If 'If Nb_Val > 0 Then 

    'End Sub

    Public Function RegistrationOffLine(ByRef Points() As Double, ByVal nb_points As Integer, ByVal nb_planes As Integer, ByRef xPosReg As Double, ByRef yPosReg As Double, ByVal MM As MMAppLib.UserCall64) As Double()

        ' Automatic extraction of beads
        Dim p As Integer
        Dim drift(7) As Double
        Dim lm As Integer = 0  ' Comptage Nb Objets/plan
        Dim lk As Integer = 0  ' Indice début de plan
        Dim plane As Integer = 0

        Dim XP, YP, d, d1, CentroidX, CentroidY As Double

        Dim NTrackReg, regionSizeX, regionSizeY, i, ii As Integer

        Dim AutoRegisterTab(,) As detection_data
        Dim FirstPlanePoints(NbMaxPtsPerImage - 1) As detection_data
        Dim FirstPlanePointsCount As Integer = 0

        Dim ActiveRegionBead = MW.roiTracking.hdlROI
        Dim IsUseActiveRegionBead = True
        Dim IsTracking = True

        'Dim activeRegion As detection_data
        'Dim regionSizeX, regionSizeY As Integer
        If IsUseActiveRegionBead Then
            'MM.GetActiveRegion(src, ActiveRegionBead)
            If ActiveRegionBead <> 0 Then
                'MM.GetRegionPosition(ActiveRegionBead, MW.roiTracking.Px + (MW.roiTracking.width / 2), MW.roiTracking.Py + (MW.roiTracking.height / 2))

                'MM.GetRegionSize(ActiveRegionBead, MW.roiTracking.width, MW.roiTracking.height)

                CentroidX = MW.roiTracking.Px '+ (MW.roiTracking.width / 2)
                CentroidY = MW.roiTracking.Py '+ (MW.roiTracking.height / 2)
                regionSizeX = MW.roiTracking.width
                regionSizeY = MW.roiTracking.height
            End If
        Else
            CentroidX = 0.0#
            CentroidY = 0.0#
            regionSizeX =
            regionSizeY = srcHeight
        End If

        'MsgBox("X: " + Str(activeRegion.CentroidX) + ", " + "Y: " + Str(activeRegion.CentroidY))
        'MsgBox("regionSizeX: " + Str(regionSizeX) + ", " + "regionSizeY: " + Str(regionSizeY))

        For li = 0 To (nb_points - 1)

            If (LocalizationMode = "Wavelet") And (IsTracking = False) Then
                XP = Points(li * RealNbSegParams + 1)
                YP = Points(li * RealNbSegParams + 0)
            Else
                XP = Points(li * NbSegParams + 4)
                YP = Points(li * NbSegParams + 3)
            End If

            'MM.PrintMsg("XP: " + Str(XP) + vbTab + "YP: " + Str(YP))

            If (XP <> -1) And (YP <> -1) Then

                If (XP >= CentroidX) And (XP <= CentroidX + regionSizeX) And (YP >= CentroidY) And (YP <= CentroidY + regionSizeY) Then
                    ' Filtrage des structures détectées
                    'MM.PrintMsg("li: " + Str(li))
                    'MM.PrintMsg("XP: " + Str(XP) + vbTab + "YP: " + Str(YP))

                    If plane > 0 Then
                        ' Comparaison avec toutes les coordonnées. Conserve les coordonnées la plus proche dans un voisinnage < RegistrationDist
                        d1 = (2.0# * RegistrationDist) ^ 2 ' Initialisation dmin

                        For i = 0 To NTrackReg - 1
                            d = (XP - AutoRegisterTab(i, plane - 1).CentroidX) ^ 2 + (YP - AutoRegisterTab(i, plane - 1).CentroidY) ^ 2

                            ' Calcule la distance la plus proche d'une molécule
                            If d < d1 Then
                                d1 = d
                                ii = i
                            End If
                        Next i
                        'meta.PrintMsg ("d= " + str(d1))
                        ' Garde la plus proche distance dans une distance < RegistrationDist
                        If (d1 <= RegistrationDist ^ 2) Then
                            If (LocalizationMode = "Wavelet") And (IsTracking = False) Then
                                AutoRegisterTab(ii, plane).CentroidX = Points(li * RealNbSegParams + 1)
                                AutoRegisterTab(ii, plane).CentroidY = Points(li * RealNbSegParams + 0)
                                AutoRegisterTab(ii, plane).Intensity = Points(li * RealNbSegParams + 2)
                                AutoRegisterTab(ii, plane).Surface = Points(li * RealNbSegParams + 3)
                            Else
                                AutoRegisterTab(ii, plane).CentroidX = Points(li * NbSegParams + 4)
                                AutoRegisterTab(ii, plane).CentroidY = Points(li * NbSegParams + 3)
                                AutoRegisterTab(ii, plane).Intensity = Points(li * NbSegParams + 8)
                                AutoRegisterTab(ii, plane).Surface = Points(li * NbSegParams + 9)
                                AutoRegisterTab(ii, plane).SigmaX = Points(li * NbSegParams + 0)
                                AutoRegisterTab(ii, plane).SigmaY = Points(li * NbSegParams + 1)
                            End If

                        End If

                    ElseIf plane = 0 Then

                        If (LocalizationMode = "Wavelet") And (IsTracking = False) Then
                            FirstPlanePoints(FirstPlanePointsCount).CentroidX = Points(li * RealNbSegParams + 1)
                            FirstPlanePoints(FirstPlanePointsCount).CentroidY = Points(li * RealNbSegParams + 0)
                            FirstPlanePoints(FirstPlanePointsCount).Intensity = Points(li * RealNbSegParams + 2)
                            FirstPlanePoints(FirstPlanePointsCount).Surface = Points(li * RealNbSegParams + 3)
                        Else
                            FirstPlanePoints(FirstPlanePointsCount).CentroidX = Points(li * NbSegParams + 4)
                            FirstPlanePoints(FirstPlanePointsCount).CentroidY = Points(li * NbSegParams + 3)
                            FirstPlanePoints(FirstPlanePointsCount).Intensity = Points(li * NbSegParams + 8)
                            FirstPlanePoints(FirstPlanePointsCount).Surface = Points(li * NbSegParams + 9)
                            FirstPlanePoints(FirstPlanePointsCount).SigmaX = Points(li * NbSegParams + 0)
                            FirstPlanePoints(FirstPlanePointsCount).SigmaY = Points(li * NbSegParams + 1)
                        End If
                        FirstPlanePointsCount = FirstPlanePointsCount + 1

                    End If
                    lm = lm + 1
                End If
                'lm = lm + 1
            Else ' Changement de plan (-1,-1,-1,-1)

                If plane = 0 Then ' Initialisation des Points de trajectoires potentielles
                    NTrackReg = lm 'li - lk

                    ' Allocation Memoire Tableau recalage 2D
                    ReDim AutoRegisterTab(NTrackReg - 1, nb_planes - 1)
                    ' Initialisation du tableau à -1, -1, -1, -1
                    For lm = 0 To NTrackReg - 1
                        For lj = 0 To nb_planes - 1
                            AutoRegisterTab(lm, lj).CentroidX = -1
                            AutoRegisterTab(lm, lj).CentroidY = -1
                            AutoRegisterTab(lm, lj).Intensity = -1
                            AutoRegisterTab(lm, lj).Surface = -1
                            AutoRegisterTab(lm, lj).SigmaX = -1
                            AutoRegisterTab(lm, lj).SigmaY = -1
                        Next lj
                    Next lm

                    ' Enregistrement des points
                    lm = 0
                    'For lj = lk To li - 1
                    For lj = lk To NTrackReg - 1

                        AutoRegisterTab(lm, plane).CentroidX = FirstPlanePoints(lj).CentroidX
                        AutoRegisterTab(lm, plane).CentroidY = FirstPlanePoints(lj).CentroidY
                        AutoRegisterTab(lm, plane).Intensity = FirstPlanePoints(lj).Intensity
                        AutoRegisterTab(lm, plane).Surface = FirstPlanePoints(lj).Surface
                        AutoRegisterTab(lm, plane).SigmaX = FirstPlanePoints(lj).SigmaX
                        AutoRegisterTab(lm, plane).SigmaY = FirstPlanePoints(lj).SigmaY

                        lm = lm + 1
                    Next lj
                    lm = 0

                Else    ' Décalage pour ne retenir que points correctement trackés

                    lm = 0
                    i = 0

                    While i < NTrackReg

                        If (AutoRegisterTab(i, plane).CentroidX = -1) And (AutoRegisterTab(i, plane).CentroidX = -1) Then
                            ' Décalage DE TOUS LES PLANS
                            For p = 0 To plane
                                For j = i + 1 To NTrackReg - 1

                                    AutoRegisterTab(j - 1, p) = AutoRegisterTab(j, p)
                                Next j
                            Next p
                            NTrackReg = NTrackReg - 1
                        Else
                            i = i + 1
                        End If

                    End While

                End If

                lk = li
                plane = plane + 1

                If NTrackReg = 0 Then
                    'MM.PrintMsg("Plane: " + Str(plane))
                    Exit For
                End If
            End If

next_loop: Next li

        MM.PrintMsg("** Registration **")
        MM.PrintMsg("Number of detected beads: " + Str(NTrackReg))

        If (NTrackReg <> 0) Then

            Dim RegisterTab(nb_planes - 1) As detection_data
            For plane = 0 To nb_planes - 1
                RegisterTab(plane).CentroidX = AutoRegisterTab(0, plane).CentroidX
                RegisterTab(plane).CentroidY = AutoRegisterTab(0, plane).CentroidY
                RegisterTab(plane).SigmaX = AutoRegisterTab(0, plane).SigmaX
                RegisterTab(plane).SigmaY = AutoRegisterTab(0, plane).SigmaY
                RegisterTab(plane).Intensity = AutoRegisterTab(0, plane).Intensity

                ''MM.PrintMsg(Str(RegisterTab(plane).CentroidX) + "  " + Str(RegisterTab(plane).CentroidY))
            Next plane

            Dim RegisterTabDest(nb_planes - 1) As detection_data

            MedianFilter(RegisterTab, RegisterTabDest, nb_planes)

            'Dim strm As StreamWriter = New StreamWriter("C:\reg.txt")

            lm = -1
            Dim reg_ref_X As Double = RegisterTabDest(0).CentroidX
            Dim reg_ref_Y As Double = RegisterTabDest(0).CentroidY

            xPosReg = RegisterTabDest(0).CentroidX
            yPosReg = RegisterTabDest(0).CentroidY
            'Dim reg_ref_X As Double = RegisterTab(0).CentroidX
            'Dim reg_ref_Y As Double = RegisterTab(0).CentroidY

            If (LocalizationMode = "Wavelet") And (IsTracking = False) Then

                For plane = 0 To nb_planes - 1
                    Dim reg_plane_X As Double = RegisterTabDest(plane).CentroidX
                    Dim reg_plane_Y As Double = RegisterTabDest(plane).CentroidY

                    'Dim reg_plane_X As Double = RegisterTab(plane).CentroidX
                    'Dim reg_plane_Y As Double = RegisterTab(plane).CentroidY

                    'strm.WriteLine(Str(plane) + "    " + Str(reg_plane_X) + "    " + Str(reg_plane_Y))
                    lm = lm + 1
                    While (Points(lm * RealNbSegParams + 1) <> -1) And (Points(lm * RealNbSegParams + 0) <> -1)
                        Points(lm * RealNbSegParams + 1) = Points(lm * RealNbSegParams + 1) - (reg_plane_X - reg_ref_X)
                        Points(lm * RealNbSegParams + 0) = Points(lm * RealNbSegParams + 0) - (reg_plane_Y - reg_ref_Y)

                        lm = lm + 1
                    End While

                Next plane

            Else

                For plane = 0 To nb_planes - 1
                    Dim reg_plane_X As Double = RegisterTabDest(plane).CentroidX
                    Dim reg_plane_Y As Double = RegisterTabDest(plane).CentroidY

                    'strm.WriteLine(Str(plane) + "    " + Str(reg_plane_X) + "    " + Str(reg_plane_Y))
                    lm = lm + 1
                    While (Points(lm * NbSegParams + 4) <> -1) And (Points(lm * NbSegParams + 3) <> -1)
                        Points(lm * NbSegParams + 4) = Points(lm * NbSegParams + 4) - (reg_plane_X - reg_ref_X)
                        Points(lm * NbSegParams + 3) = Points(lm * NbSegParams + 3) - (reg_plane_Y - reg_ref_Y)

                        lm = lm + 1
                    End While

                Next plane

            End If

            For i = 0 To RegisterTabDest.Count - 1
                'If RegisterTabDest(i).CentroidX = -1 Or RegisterTabDest(i).CentroidY = -1 Then
                '    drift(0) = RegisterTabDest(0).CentroidX - RegisterTabDest(i - 1).CentroidX
                '    drift(1) = RegisterTabDest(0).CentroidY - RegisterTabDest(i - 1).CentroidY
                '    drift(2) = NTrackReg
                '    drift(3) = RegisterTabDest(i - 1).SigmaX
                '    drift(4) = RegisterTabDest(i - 1).SigmaY
                '    drift(5) = RegisterTabDest(i - 1).Intensity
                '    Exit For
                If RegisterTabDest(i).CentroidX <> -1 And RegisterTabDest(i).CentroidY <> -1 And RegisterTabDest(i).SigmaX <> -1 And RegisterTabDest(i).SigmaY <> -1 And RegisterTabDest(i).Intensity <> -1 Then
                    drift(0) = RegisterTabDest(i).CentroidX - MW.beadRef.CentroidX
                    drift(1) = RegisterTabDest(i).CentroidY - MW.beadRef.CentroidY
                    drift(2) = NTrackReg
                    drift(3) = RegisterTabDest(i).SigmaX
                    drift(4) = RegisterTabDest(i).SigmaY
                    drift(5) = RegisterTabDest(i).Intensity
                End If
            Next


            'strm.Close()

            'If useActiveRegionBead = False Then
            '    Dim regionId As Integer
            '    Dim ROIsize As Integer = 16
            '    MM.CreateRectRegion(src, CShort(RegisterTabDest(0).CentroidX) - ROIsize \ 2, CShort(RegisterTabDest(0).CentroidY) - ROIsize \ 2, CShort(RegisterTabDest(0).CentroidX) + ROIsize \ 2, CShort(RegisterTabDest(0).CentroidY) + ROIsize \ 2, regionId)
            '    MM.SetActiveRegion(src, regionId)
            'End If
        Else
            MM.PrintMsg("Automatic registration failed. No track found. Last track stops at plane: " + Str(plane))
        End If

        'Dim stream As StreamWriter = New StreamWriter("C:\registration.txt")
        'For plane = 0 To nb_planes - 1
        '    stream.WriteLine(Str(RegisterTab(plane).CentroidX) + "  " + Str(RegisterTabDest(plane).CentroidX) + "  " + Str(RegisterTab(plane).CentroidY) + "  " + Str(RegisterTabDest(plane).CentroidY))
        'Next plane
        'stream.Close()

        'Dim stream As StreamWriter = New StreamWriter("C:\registration.txt")
        'For plane = 0 To nb_planes - 1
        '    For i = 0 To NTrackReg - 1
        '        stream.WriteLine(Str(plane) + "  " + Str(AutoRegisterTab(i, plane).CentroidX) + "  " + Str(AutoRegisterTab(i, plane).CentroidY) + "  " + Str(Math.Sqrt(Math.Pow(AutoRegisterTab(i, plane).CentroidX - AutoRegisterTab(0, 0).CentroidX, 2) + Math.Pow(AutoRegisterTab(i, plane).CentroidY - AutoRegisterTab(0, 0).CentroidY, 2))))
        '    Next i
        'Next plane
        'stream.Close()

        Return drift
    End Function

    Private Sub MedianFilter(ByRef RegisterTab() As detection_data, ByRef RegisterTabDest() As detection_data, ByVal NbPts As Long)

        If NbPts >= 5 Then
            ' Lissage par Median de taille 5x du fichier de trajectoires
            Dim i As Integer, j As Integer
            Dim Xarray() As Double, Yarray() As Double

            ' Initialisation conditions aux bords
            ReDim Xarray(2)
            ReDim Yarray(2)
            For i = 0 To 2
                Xarray(i) = RegisterTab(i).CentroidX
                Yarray(i) = RegisterTab(i).CentroidY
            Next i
            RegisterTabDest(0).CentroidX = u_median(Xarray)
            RegisterTabDest(0).CentroidY = u_median(Yarray)

            For i = 0 To 2
                Xarray(i) = RegisterTab(NbPts - 3 + i).CentroidX
                Yarray(i) = RegisterTab(NbPts - 3 + i).CentroidY
            Next i
            RegisterTabDest(NbPts - 1).CentroidX = u_median(Xarray)
            RegisterTabDest(NbPts - 1).CentroidY = u_median(Yarray)

            ReDim Xarray(3)
            ReDim Yarray(3)
            For i = 0 To 3
                Xarray(i) = RegisterTab(i).CentroidX
                Yarray(i) = RegisterTab(i).CentroidY
            Next i
            RegisterTabDest(1).CentroidX = u_median(Xarray)
            RegisterTabDest(1).CentroidY = u_median(Yarray)
            For i = 0 To 3
                Xarray(i) = RegisterTab(NbPts - 4 + i).CentroidX
                Yarray(i) = RegisterTab(NbPts - 4 + i).CentroidY
            Next i
            RegisterTabDest(NbPts - 2).CentroidX = u_median(Xarray)
            RegisterTabDest(NbPts - 2).CentroidY = u_median(Yarray)

            ' Calcul du Médian sur le reste du tableau
            ReDim Xarray(4)
            ReDim Yarray(4)
            For j = 2 To NbPts - 3
                For i = -2 To 2
                    Xarray(i + 2) = RegisterTab(j + i).CentroidX
                    Yarray(i + 2) = RegisterTab(j + i).CentroidY
                Next i
                RegisterTabDest(j).CentroidX = u_median(Xarray)
                RegisterTabDest(j).CentroidY = u_median(Yarray)

                'MM.PrintMsg(Str(RegisterTabDest(j).CentroidX))

            Next j

        Else

            For i = 0 To NbPts - 1
                RegisterTabDest(i).CentroidX = RegisterTab(i).CentroidX
                RegisterTabDest(i).CentroidY = RegisterTab(i).CentroidY
            Next i

        End If

        For i = 0 To NbPts - 1
            RegisterTabDest(i).SigmaX = RegisterTab(i).SigmaX
            RegisterTabDest(i).SigmaY = RegisterTab(i).SigmaY
            RegisterTabDest(i).Intensity = RegisterTab(i).Intensity

        Next i

    End Sub


    Function u_median(ByVal Arr() As Double)

        'If the total elements in the array is an odd number (defined by Ubound(Arr) Mod = 1),
        'then the median is the middle number (defined by Arr(Int(Ubound(Arr) / 2)) ).
        'If the total elements in the array is an even number then take the average of the two middle numbers.

        Array.Sort(Arr)

        If UBound(Arr) Mod 2 = 0 Then
            u_median = Arr(Int(UBound(Arr) / 2))
        Else
            u_median = (Arr(UBound(Arr) / 2) + Arr(Int(UBound(Arr) / 2) + 1)) / 2
        End If

    End Function

    Sub loadRegionFromPath(ByVal mm As MMAppLib.IUserCall64)


    End Sub

    '                FPoints(i * MainWindow.NbSegParams + 0) = Morph.sigmaX
    '                FPoints(i * MainWindow.NbSegParams + 1) = Morph.sigmaY
    '                FPoints(i * MainWindow.NbSegParams + 2) = Morph.AngleRad
    '                FPoints(i * MainWindow.NbSegParams + 3) = Morph.CentroidX
    '                FPoints(i * MainWindow.NbSegParams + 4) = Morph.CentroidY
    '                FPoints(i * MainWindow.NbSegParams + 5) = Morph.Intensity_Gauss
    '                FPoints(i * MainWindow.NbSegParams + 6) = 0 'What is this?
    '                FPoints(i * MainWindow.NbSegParams + 7) = Morph.chi2
    '                FPoints(i * MainWindow.NbSegParams + 8) = Morph.Intensity
    '                FPoints(i * MainWindow.NbSegParams + 9) = Morph.Surface
    '                FPoints(i * MainWindow.NbSegParams + 10) = Morph.CentroidZ
    '                FPoints(i * MainWindow.NbSegParams + 11) = Morph.Channel
    '                FPoints(i * MainWindow.NbSegParams + 12) = Morph.LocalizationIndex

    Public Function RegistrationOneBead(ByRef Points() As Double, ByRef beadRef As detection_data, ByVal refX As Double, ByVal refY As Double) As Double()
        Dim bead_end As detection_data
        Dim drift(9) As Double
        bead_end.CentroidX = Points(4) + refX
        bead_end.CentroidY = Points(3) + refY
        bead_end.CentroidZ = Points(10)
        bead_end.IntensityGauss = Points(5)
        bead_end.Intensity = Points(8)
        bead_end.Surface = Points(9)
        bead_end.SigmaX = Points(0)
        bead_end.SigmaY = Points(1)
        bead_end.SigmaGoodness = Points(7)

        If bead_end.CentroidX <> -1 And bead_end.CentroidY <> -1 And bead_end.SigmaGoodness <> -1 Then
            drift(0) = bead_end.CentroidX
            drift(1) = bead_end.CentroidY
            drift(2) = bead_end.CentroidZ
            drift(3) = bead_end.SigmaX
            drift(4) = bead_end.SigmaY
            drift(5) = bead_end.IntensityGauss
            drift(6) = bead_end.SigmaGoodness
        End If

        Return drift

    End Function

    Public Function RegistrationOneBead_PointsAll(ByRef Point_all() As Double, ByRef beadRef As detection_data, ByVal refX As Double, ByVal refY As Double) As Double()
        Dim bead_end As detection_data
        Dim drift(7) As Double
        Dim id_end = Point_all.Length - NbSegParams * 2

        'bead_t1.CentroidX = Point_all(4) + refX
        'bead_t1.CentroidY = Point_all(3) + refY
        'bead_t1.Intensity = Point_all(8)
        'bead_t1.Surface = Point_all(9)
        'bead_t1.SigmaX = Point_all(0)
        'bead_t1.SigmaY = Point_all(1)

        bead_end.CentroidX = Point_all(id_end + 4) + refX
        bead_end.CentroidY = Point_all(id_end + 3) + refY
        bead_end.Intensity = Point_all(id_end + 8)
        bead_end.Surface = Point_all(id_end + 9)
        bead_end.SigmaX = Point_all(id_end)
        bead_end.SigmaY = Point_all(id_end + 1)
        bead_end.SigmaGoodness = Point_all(id_end + 7)

        If bead_end.CentroidX <> -1 And bead_end.CentroidY <> -1 And bead_end.SigmaX <> -1 And bead_end.SigmaY <> -1 And bead_end.Intensity <> -1 Then
            drift(0) = MW.beadRef.CentroidX - bead_end.CentroidX
            drift(1) = MW.beadRef.CentroidY - bead_end.CentroidY
            drift(2) = 1
            drift(3) = bead_end.SigmaX
            drift(4) = bead_end.SigmaY
            drift(5) = bead_end.Intensity
            drift(6) = bead_end.SigmaGoodness
        End If

        Return drift

    End Function

    Public Function AutoThreshold(ByVal MM As MMAppLib.IUserCall64) As Double

        Dim i As Integer, j As Integer, k As Integer
        Dim moyenne As Double = 0, StD As Double = 0
        Dim gLine16() As UShort ' Tableau 16bits contenant une ligne de l'image Ã  lire(LR)/Ã©crire(HR)

        ' For Segmentation
        Dim Points() As Double  ' Tableau de coordonnées de la segmentation
        'Dim gImage() As Integer     ' Tableau contenant l'image 16 bits en 3D
        Dim gImage() As UShort
        Dim Mask(,) As Integer ' Mask pour seuillage auto iteratif
        Dim nb_planes_preview As Long, Nb_Val As Long, size As Long
        'Dim NbSegParams As Long ' Nombre de paramètres retournée par la segmentation
        Dim Ratio_Intensity As Double, Wavelet_Threshold As Double, Wavelet_WatershedRatio As Double
        Dim val As Integer, ret_val As Long, value As Integer
        Dim ROIsize As Integer, NbROI As Integer
        Dim X As Integer, Y As Integer, n As Long, NbIt As Integer
        Dim tmp_str As String
        Dim x0 As Double

        'If (Ret_Nb_Src(MM) > -1) Then
        'src = Image_List(Ret_Nb_Src(MM)).handleB
        'Else    ' Aucune Image sélectionnée
        MM.GetCurrentImage(src)
        'End If

        If src <= 0 Then
            Exit Function
        End If

        MM.GetHeight(src, srcHeight)
        MM.GetWidth(src, srcWidth)
        MM.GetDepth(src, srcDepth)

        x0 = 0
        'If Channel_Chk.Checked OrElse Spectral_Chk.Checked Then
        '    srcWidth = srcWidth / 2
        '    x0 = srcWidth
        'End If

        size = CLng(srcWidth) * CLng(srcHeight)
        ReDim gLine16(srcWidth - 1)
        ReDim gImage(size - 1)
        ReDim Mask(srcWidth - 1, srcHeight - 1)

        ' Calcul de la moyenne de toute l'image
        ' Lecture de l'image source
        '        UnsafeProcessing.Unmanaged.ReadImage(MM, src, 0, 0, srcWidth, srcHeight, gImage)
        ZStackUnsafeProcessing.Unmanaged.ReadImage(MM, src, x0, 0, srcWidth, srcHeight, gImage)

        For j = 0 To srcHeight - 1
            ' Copie de la ligne courante
            'MM.ReadRowEx2(src, 0, j, srcWidth, srcDepth, 0, 0, gLine16)
            'tmp_str = ""
            ' Remplissage du tableau 1D en row major order
            For i = 0 To srcWidth - 1
                'val = gLine16(i)
                'gImage((CLng(j) + CLng(srcHeight) * CLng(i))) = val
                moyenne = moyenne + CDbl(gImage((CLng(j) + CLng(srcHeight) * CLng(i))))
                Mask(i, j) = 0
            Next i
        Next j

        moyenne = moyenne / (CLng(srcWidth) * CLng(srcHeight))
        'MM.PrintMsg ("Average 1st iteration= " + CStr(moyenne))

        ' Calcul de l'Ecart type sur toute l'image
        ' Lecture de l'image source
        For j = 0 To srcHeight - 1
            ' Copie de la ligne courante
            'MM.ReadRowEx2(src, 0, j, srcWidth, srcDepth, 0, 0, gLine16)
            'tmp_str = ""
            ' Remplissage du tableau 1D en row major order
            For i = 0 To srcWidth - 1
                StD = StD + (moyenne - CDbl(gImage((CLng(j) + CLng(srcHeight) * CLng(i))))) ^ 2
                'gImage((CLng(j) + CLng(srcHeight) * CLng(i))) = gLine16(i)
            Next i
        Next j

        StD = Math.Sqrt(StD / (CLng(srcWidth) * CLng(srcHeight)))
        'MM.PrintMsg ("StD 1st iteration= " + CStr(StD))

        ' Segmentation en utilisant StD comme threshold
        ROIsize = CInt(7) '7
        nb_planes_preview = 1

        NbMaxPtsPerImage = CLng(CDbl(srcWidth) * CDbl(srcHeight) * MaxDensityPerPixel)
        'Nb_Val = CLng(nb_planes_preview) * NbSegParams * NbMaxPtsPerImage  ' Nbre de points max: 0.5 mol/pixel et NbSegParams paramètres par point (SigmaX , SigmaY, Theta, x, y, Intensity, Offset, Error, i, S), 4 paramètres dans le cas des ondelettes standards (x, y, Intensity, Surface)
        'ReDim Points(Nb_Val)

        Dim Gauss_Fit = 0   ' Segmentation Wavelets
        Wavelet_WatershedRatio = 0.0#

        For NbIt = 1 To 4
            Wavelet_Threshold = StD

            Nb_Val = CLng(nb_planes_preview) * NbSegParams * NbMaxPtsPerImage  ' Nbre de points max: 0.5 mol/pixel et NbSegParams paramètres par point (SigmaX , SigmaY, Theta, x, y, Intensity, Offset, Error, i, S), 4 paramètres dans le cas des ondelettes standards (x, y, Intensity, Surface)
            ReDim Points(Nb_Val - 1)
            'MM.PrintMsg (Nb_Val)

            ZStackUnsafeProcessing.Unmanaged.CPU_OpenPALMProcessing(gImage, Points, Nb_Val, CLng(srcWidth), CLng(srcHeight), 1, Wavelet_Threshold, Wavelet_WatershedRatio, 4.0#, 0.0#, Gauss_Fit, 1.0#, 1.0#, 3.14 / 4.0#, CLng(7))

            'On Error GoTo Error
            ' Lecture de l'image source
            'For j = 0 To srcHeight - 1
            '    ' Copie de la ligne courante
            '    MM.ReadRowEx src, 0, j, srcWidth, srcDepth, 0, 0, gLine16()
            '
            '    ' Remplissage du tableau 1D en row major order
            '    For i = 0 To srcWidth - 1
            '        val = gLine16(i)
            '        gImage((CLng(j) + CLng(srcHeight) * CLng(i))) = val
            '        Mask(i, j) = 0
            '    Next i
            'Next j

            ret_val = ZStackUnsafeProcessing.Unmanaged.CPU_PALMProcessing()
            ZStackUnsafeProcessing.Unmanaged.CPU_closePALMProcessing()
            'MM.PrintMsg (ret_val)

            'Nb_Val = (ret_val \ NbSegParams) - 1
            'NbROI = Nb_Val
            NbROI = (ret_val \ NbSegParams) - 1

            'MM.PrintMsg ("Nb of Detected Spots: " + str(NbROI))

            ' MAJ du mask
            For k = 0 To NbROI - 1
                X = CInt(Points(k * NbSegParams + 3))
                Y = CInt(Points(k * NbSegParams + 4))
                'MM.PrintMsg (str(k) + ": " + str(X) + " ; " + str(Y))
                For j = Y - ROIsize \ 2 To Y + ROIsize \ 2
                    For i = X - ROIsize \ 2 To X + ROIsize \ 2
                        If i >= 0 And i < srcWidth And j >= 0 And j < srcHeight Then
                            Mask(i, j) = 1
                        End If
                    Next i
                Next j
            Next k
            'MM.PrintMsg ("End Mask")
            ' Calcul de la moyenne sur image hors segmentation
            ' Lecture de l'image source
            moyenne = 0.0#
            n = 0
            For j = 0 To srcHeight - 1
                ' Copie de la ligne courante
                'MM.ReadRowEx2(src, 0, j, srcWidth, srcDepth, 0, 0, gLine16)
                'tmp_str = ""
                ' Remplissage du tableau 1D en row major order
                For i = 0 To srcWidth - 1
                    If Mask(i, j) = 0 Then
                        moyenne = moyenne + CDbl(gImage((CLng(j) + CLng(srcHeight) * CLng(i))))
                        n = n + 1
                    End If
                    'gImage((CLng(j) + CLng(srcHeight) * CLng(i))) = gLine16(i)
                Next i
            Next j
            'MM.PrintMsg (N)
            moyenne = moyenne / CDbl(n)
            'MM.PrintMsg ("Average iteration " + str(NbIt) + "= " + CStr(moyenne))

            ' Calcul de l'Ecart type sur image hors segmentation
            StD = 0.0#
            ' Lecture de l'image source
            For j = 0 To srcHeight - 1
                ' Copie de la ligne courante
                'MM.ReadRowEx2(src, 0, j, srcWidth, srcDepth, 0, 0, gLine16)
                'tmp_str = ""
                ' Remplissage du tableau 1D en row major order
                For i = 0 To srcWidth - 1
                    If Mask(i, j) = 0 Then
                        StD = StD + (moyenne - CDbl(gImage((CLng(j) + CLng(srcHeight) * CLng(i))))) ^ 2
                    End If
                    'gImage((CLng(j) + CLng(srcHeight) * CLng(i))) = gLine16(i)
                Next i
            Next j

            StD = Math.Sqrt(StD / CDbl(n))
            'MM.PrintMsg ("StD iteration " + str(NbIt) + "= " + CStr(StD))

        Next NbIt

        'For j = 0 To srcHeight - 1
        '    For i = 0 To srcWidth - 1
        '        gLine16(i) = Mask(i, j)
        '    Next i
        '    MM.WriteRowEx src, 0, j, srcWidth, 16, 0, 0, gLine16()
        'Next j


        ' Creation des ROI autour des points détectés
        'Dim ROIPreviewHdl_Tab(), NbROIPreview, ROIActiveHdl As Integer
        'NbROIPreview = Nb_Val
        'ReDim ROIPreviewHdl_Tab(NbROIPreview - 1)
        'If NbROI > 0 Then
        '    For j = 0 To NbROI - 1
        '        MM.CreateRectRegion(src, CShort(Points(j * NbSegParams + 4)) - ROIsize \ 2, CShort(Points(j * NbSegParams + 3)) - ROIsize \ 2, CShort(Points(j * NbSegParams + 4)) + ROIsize \ 2, CShort(Points(j * NbSegParams + 3)) + ROIsize \ 2, ROIPreviewHdl_Tab(j))
        '        MM.SetActiveRegion(src, ROIPreviewHdl_Tab(j))

        '        MM.SetMMVariable("Region.ColorRed", 0)
        '        MM.SetMMVariable("Region.ColorGreen", 255)
        '        MM.SetMMVariable("Region.ColorBlue", 0)
        '    Next j
        'End If
        'MM.SetActiveRegion(src, ROIActiveHdl)

        AutoThreshold = StD

        'MM.PrintMsg (StD)
        '    End Function
        ' Error:
        '    MsgBox ("Real Time Preview Error")

    End Function

    Public Function SetThreshold(ByVal MM As MMAppLib.IUserCall64) As Double

        Dim i As Integer, j As Integer, k As Integer
        Dim moyenne As Double = 0, StD As Double = 0
        Dim gLine16() As UShort ' Tableau 16bits contenant une ligne de l'image Ã  lire(LR)/Ã©crire(HR)

        ' For Segmentation
        Dim Points() As Double  ' Tableau de coordonnées de la segmentation
        'Dim gImage() As Integer     ' Tableau contenant l'image 16 bits en 3D
        Dim gImage() As UShort
        Dim Mask(,) As Integer ' Mask pour seuillage auto iteratif
        Dim nb_planes_preview As Long, Nb_Val As Long, size As Long
        'Dim NbSegParams As Long ' Nombre de paramètres retournée par la segmentation
        Dim Ratio_Intensity As Double, Wavelet_Threshold As Double, Wavelet_WatershedRatio As Double
        Dim val As Integer, ret_val As Long, value As Integer
        Dim ROIsize As Integer, NbROI As Integer
        Dim X As Integer, Y As Integer, n As Long, NbIt As Integer
        Dim tmp_str As String
        Dim x0 As Double

        MM.GetCurrentImage(src)


        Wavelet_Threshold = CDbl(WT_Threshold)

        If Wavelet_Threshold >= 10 Then

            If src <= 0 Then
                Exit Function
            End If

            MM.GetHeight(src, srcHeight)
            MM.GetWidth(src, srcWidth)
            MM.GetDepth(src, srcDepth)

            size = CLng(srcWidth) * CLng(srcHeight)
            ReDim gLine16(srcWidth - 1)
            ReDim gImage(size - 1)
            ReDim Mask(srcWidth - 1, srcHeight - 1)

            ' Calcul de la moyenne de toute l'image
            ' Lecture de l'image source
            '        UnsafeProcessing.Unmanaged.ReadImage(MM, src, 0, 0, srcWidth, srcHeight, gImage)
            ZStackUnsafeProcessing.Unmanaged.ReadImage(MM, src, x0, 0, srcWidth, srcHeight, gImage)


            ' Segmentation en utilisant StD comme threshold
            ROIsize = CInt(7) '7
            nb_planes_preview = 1

            NbMaxPtsPerImage = CLng(CDbl(srcWidth) * CDbl(srcHeight) * MaxDensityPerPixel)

            Dim Gauss_Fit = 0   ' Segmentation Wavelets
            Wavelet_WatershedRatio = 0.0#

            Nb_Val = CLng(nb_planes_preview) * NbSegParams * NbMaxPtsPerImage  ' Nbre de points max: 0.5 mol/pixel et NbSegParams paramètres par point (SigmaX , SigmaY, Theta, x, y, Intensity, Offset, Error, i, S), 4 paramètres dans le cas des ondelettes standards (x, y, Intensity, Surface)
            ReDim Points(Nb_Val - 1)
            'MM.PrintMsg (Nb_Val)

            ZStackUnsafeProcessing.Unmanaged.CPU_OpenPALMProcessing(gImage, Points, Nb_Val, CLng(srcWidth), CLng(srcHeight), 1, Wavelet_Threshold, Wavelet_WatershedRatio, 4.0#, 0.0#, Gauss_Fit, 1.0#, 1.0#, 3.14 / 4.0#, CLng(7))

            ret_val = ZStackUnsafeProcessing.Unmanaged.CPU_PALMProcessing()
            ZStackUnsafeProcessing.Unmanaged.CPU_closePALMProcessing()

            NbROI = (ret_val \ NbSegParams) - 1

            ' Creation des ROI autour des points détectés
            Dim NbROIPreview, ROIActiveHdl As Integer
            NbROIPreview = Nb_Val
            ReDim ROIPreviewHdl_Tab(NbROIPreview - 1)
            If NbROI > 0 Then
                For j = 0 To NbROI - 1
                    MM.CreateRectRegion(src, CShort(Points(j * NbSegParams + 4)) - ROIsize \ 2, CShort(Points(j * NbSegParams + 3)) - ROIsize \ 2, CShort(Points(j * NbSegParams + 4)) + ROIsize \ 2, CShort(Points(j * NbSegParams + 3)) + ROIsize \ 2, ROIPreviewHdl_Tab(j))
                    MM.SetActiveRegion(src, ROIPreviewHdl_Tab(j))

                    MM.SetMMVariable("Region.ColorRed", 0)
                    MM.SetMMVariable("Region.ColorGreen", 255)
                    MM.SetMMVariable("Region.ColorBlue", 0)
                Next j
            End If
            MM.SetActiveRegion(src, ROIActiveHdl)
        End If
    End Function

    'Z Assignment using 3D Astigmatism 
    Public Function AssignThreeDValuesToPoints(ByRef MM As MMAppLib.UserCall64, ByRef Points() As Double, ByVal Nb_Val As Integer, Optional UseMaxIntensity As Boolean = False) As Boolean
        Dim success As Boolean = True
        Dim ThreeDSampling As Double, ThreeDThickness As Double, ThreeDNbPlanes As Integer, ThreeDProcessSampling As Double, Calibration_XY As Double
        Dim i As Long, j As Long, k As Long, l As Long, ii As Long, jj As Long, li As Long, lj As Long, lk As Long, lm As Long, ln As Long, kA As Long, lt As Long, slm As Long, sln As Long, slk As Long, sli As Long, slj As Long, slt As Long
        Dim XP, YP As Double
        Dim sigmaX, sigmaY As Double
        Dim zValues(Nb_Val - 1), zErrors(Nb_Val - 1) As Double

        Load3DCalibrationFile(MM) 'Loaded into CXX_3D(), CYY_3D()

        Dim SigmaXCoefs(CXX_3D.Length - 1), SigmaYCoefs(CYY_3D.Length - 1) As Double
        Array.Copy(CXX_3D, SigmaXCoefs, CXX_3D.Length)
        Array.Copy(CYY_3D, SigmaYCoefs, CYY_3D.Length)


        'ThreeDSampling = CDbl(ZSampling_Txt.Text)
        ThreeDThickness = CDbl(MW.NUD_3DThickness.Value)
        'ThreeDNbPlanes = CInt(ThreeDThickness / ThreeDSampling)
        ThreeDProcessSampling = CDbl(MW.NUD_3DThicknessProcess.Value)
        Calibration_XY = CDbl(MW.TXTBX_CalibrationXYumpxl.Text)

        Dim zAssignmentTimer As Double = Microsoft.VisualBasic.DateAndTime.Timer()

        'If multithreading enabled, calculate all 
        ' logMesage("Multithreading 3D Assignment on CPU...")


        lm = 0 ' Comptage Nb Objets/plan
        lk = 0 ' Indice début de plan
        lt = 0 ' Indice pour le nouveau tableau de coordonnées TPoints

        slm = 0 ' Comptage Nb Objets/plan
        slk = 0 ' Indice début de plan
        slt = 0 ' Indice pour le nouveau tableau de coordonnées TPoints

        'meta.PrintMsg (Nb_Val)
        Dim zTasks(Nb_Val - 1) As System.Threading.Tasks.Task
        For li = 0 To (Nb_Val - 1)
            XP = Points(li * NbSegParams + 3) 'Points(li * 4)
            YP = Points(li * NbSegParams + 4) 'Points(li * 4 + 1)

            sigmaX = Points(li * NbSegParams)
            sigmaY = Points(li * NbSegParams + 1)

            If XP <> -1 And YP <> -1 Then
                Dim parametersList(2) As Double
                parametersList(0) = li
                parametersList(1) = sigmaX
                parametersList(2) = sigmaY

                zTasks(li) = New System.Threading.Tasks.Task(Sub(_parametersList)
                                                                 Dim _Zval, _Zerror, _delta, _ZYfunc, _ZXfunc, _a, _val, _sigmaX, _sigmaY As Double
                                                                 Dim zli As Integer

                                                                 zli = _parametersList(0)
                                                                 _sigmaX = _parametersList(1)
                                                                 _sigmaY = _parametersList(2)

                                                                 _Zval = -10.0#
                                                                 _Zerror = 1000.0#
                                                                 For _delta = -CInt(ThreeDThickness * 500) To CInt(ThreeDThickness * 500) Step CInt(ThreeDProcessSampling * 1000) ' Delta en nm pour valeurs entières: Recherche tous les ThreeDProcessSampling nms - Corey UPDATE 2015.10.17
                                                                     _val = _delta / 1000.0# ' Retour en µm pour calibration

                                                                     _ZYfunc = SigmaXCoefs(4) * Math.Sqrt(1.0# + ((_val - SigmaXCoefs(0)) / SigmaXCoefs(1)) ^ 2 + SigmaXCoefs(2) * ((_val - SigmaXCoefs(0)) / SigmaXCoefs(1)) ^ 3 + SigmaXCoefs(3) * ((_val - SigmaXCoefs(0)) / SigmaXCoefs(1)) ^ 4)
                                                                     _ZXfunc = SigmaYCoefs(4) * Math.Sqrt(1.0# + ((_val - SigmaYCoefs(0)) / SigmaYCoefs(1)) ^ 2 + SigmaYCoefs(2) * ((_val - SigmaYCoefs(0)) / SigmaYCoefs(1)) ^ 3 + SigmaYCoefs(3) * ((_val - SigmaYCoefs(0)) / SigmaYCoefs(1)) ^ 4)
                                                                     _a = ((_sigmaX * Calibration_XY - _ZXfunc) ^ 2 + (_sigmaY * Calibration_XY - _ZYfunc) ^ 2) / (_ZXfunc ^ 2 + _ZYfunc ^ 2)

                                                                     If (_a < _Zerror) Then
                                                                         _Zerror = _a
                                                                         _Zval = _val
                                                                     End If
                                                                 Next _delta
                                                                 'Points(zli * NbSegParams + 10) = _Zval
                                                                 zValues(zli) = _Zval
                                                                 zErrors(zli) = _Zerror
                                                             End Sub, parametersList)

                zTasks(li).Start()
            Else
                zTasks(li) = New System.Threading.Tasks.Task(Sub() Return)
                zTasks(li).Start()
            End If
        Next li
        Tasks.Task.WaitAll(zTasks)

        For li = 0 To (Nb_Val - 1)
            Points(li * NbSegParams + 10) = zValues(li)
        Next

        '  MM.PrintMsg("3D Calculation Time: " + (Microsoft.VisualBasic.DateAndTime.Timer() - zAssignmentTimer).ToString("F6") + "s")

        Return success
    End Function

    'Load3DCalibrationFile() 
    Public Function Load3DCalibrationFile(ByRef MM As MMAppLib.UserCall64, Optional logInfo As Boolean = False, Optional set3DThickness As Boolean = False) As Boolean
        'Dim ThreeDFileName As String
        'Dim ThreeDFileNum As StreamReader
        'Dim CXX() As Double, CYY() As Double
        'Dim strTab() As String
        'Dim inter As String

        Dim sucess = True
        Dim ThreeDFileName2, tmp_str2, inter2, strTab2() As String
        Dim ThreeDFileNum2 As StreamReader
        'Dim ThreeDSampling, ThreeDNbPlanes As Integer
        Dim ThreeDThickness As Double, ThreeDProcessSampling As Double, Calibration_XY As Double
        Dim SigmaXCoefs(4) As Double
        Dim SigmaYCoefs(4) As Double
        ' Dim delta, val2 As Double
        Dim ret_val As Integer
        'Dim Zval, Zerror, ZYfunc, ZXfunc, a As Double

        Dim reWriteCalibration As Boolean = False
        Dim calibrationFileLines(3) As String

        Dim AFD As Double ' Astigmatic Focal distance = 2*distance between 0 order coefficients

        If MW.path3DCalib IsNot Nothing Then


            Try

                ReDim CXX_3D(4)
                ReDim CYY_3D(4)

                MM.GetMMVariable("CoefficientCalibrationX", Calibration_XY)
                If Calibration_XY = 0 Then
                    sucess = False
                End If

                'ThreeDSampling = CDbl(ZSampling_Txt.Text)
                ThreeDThickness = CDbl(MW.NUD_3DThickness.Text)
                'ThreeDNbPlanes = CInt(ThreeDThickness / ThreeDSampling)
                'ThreeDNbPlanes = CInt(ThreeDThickness / ThreeDSampling) + 1 ' Corey UPDATE 2016.02.15 - Prevents bug when localizations = max
                ThreeDProcessSampling = CDbl(MW.NUD_3DThicknessProcess.Text) 'Corey UPDATE 2015.10.17

                ThreeDFileName2 = MW.path3DCalib '+ "3DFit.txt"
                If (Dir(ThreeDFileName2) <> "") Then


                    'Open ThreeDFileName For Input As ThreeDFileNum
                    ThreeDFileNum2 = New StreamReader(ThreeDFileName2)

                    'Line Input #ThreeDFileNum, tmp_str  'Header
                    tmp_str2 = ThreeDFileNum2.ReadLine()
                    calibrationFileLines(0) = tmp_str2

                    'Input #ThreeDFileNum, ret_val   ' Angle
                    ret_val = CInt(ThreeDFileNum2.ReadLine())
                    calibrationFileLines(1) = ret_val

                    'meta.PrintMsg (ret_val)
                    'Input #ThreeDFileNum, CXX_3D(1), CXX_3D(2), CXX_3D(3), CXX_3D(4), CXX_3D(5)   ' SigmaX
                    inter2 = ThreeDFileNum2.ReadLine()
                    strTab2 = inter2.Split(vbTab)
                    CXX_3D(0) = CDbl(strTab2(0))
                    CXX_3D(1) = CDbl(strTab2(1))
                    CXX_3D(2) = CDbl(strTab2(2))
                    CXX_3D(3) = CDbl(strTab2(3))
                    CXX_3D(4) = CDbl(strTab2(4))
                    calibrationFileLines(2) = tmp_str2

                    'Input #ThreeDFileNum, CYY_3D(1), CYY_3D(2), CYY_3D(3), CYY_3D(4), CYY_3D(5)   ' SigmaY
                    inter2 = ThreeDFileNum2.ReadLine()
                    strTab2 = inter2.Split(vbTab)
                    CYY_3D(0) = CDbl(strTab2(0))
                    CYY_3D(1) = CDbl(strTab2(1))
                    CYY_3D(2) = CDbl(strTab2(2))
                    CYY_3D(3) = CDbl(strTab2(3))
                    CYY_3D(4) = CDbl(strTab2(4))
                    calibrationFileLines(3) = tmp_str2

                    If Math.Abs(CXX_3D(0)) > 100 OrElse Math.Abs(CYY_3D(0)) > 100 Then
                        reWriteCalibration = False

                        'Wavetracer files are not centered around 0, but rather with absolute 
                        If logInfo Then
                            MM.PrintMsg("WaveTracer 3D File detected, centered at z=" + ((CXX_3D(0) + CYY_3D(0)) / 2).ToString() + "um")
                        End If

                        Dim newZ As Double = (Math.Abs(CXX_3D(0)) - Math.Abs(CYY_3D(0))) / 2

                        If CXX_3D(0) > CYY_3D(0) Then
                            CXX_3D(0) = -newZ
                            CYY_3D(0) = newZ

                        Else
                            CXX_3D(0) = newZ
                            CYY_3D(0) = -newZ
                        End If

                    End If

                    'For i = 1 To 5
                    '    meta.PrintMsg (str(i) + " : " + str(CXX_3D(i)) + ";" + str(CYY_3D(i)))
                    'Next i
                    'Close(ThreeDFileNum)
                    ThreeDFileNum2.Close()
                    If logInfo Then

                        AFD = (Math.Abs(CXX_3D(0)) + Math.Abs(CYY_3D(0)))
                        MM.PrintMsg("3D Calibration file loaded from " + ThreeDFileName2 + ". Astigmatic Focal Distance = " + AFD.ToString("F4") + " um")

                        If set3DThickness Then
                            MW.NUD_3DThickness.Value = AFD * 2
                        End If
                    End If

                    If reWriteCalibration Then
                        Dim ThreeDFileNum3 As StreamWriter = New StreamWriter(ThreeDFileName2)
                        ThreeDFileNum3.WriteLine(calibrationFileLines(0))
                        ThreeDFileNum3.WriteLine(calibrationFileLines(1))
                        tmp_str2 = CXX_3D(0).ToString("F12") + vbTab + CXX_3D(1).ToString("F12") + vbTab + CXX_3D(2).ToString("F12") + vbTab + CXX_3D(3).ToString("F12") + vbTab + CXX_3D(4).ToString("F12") + vbTab
                        ThreeDFileNum3.WriteLine(tmp_str2)
                        tmp_str2 = CYY_3D(0).ToString("F12") + vbTab + CYY_3D(1).ToString("F12") + vbTab + CYY_3D(2).ToString("F12") + vbTab + CYY_3D(3).ToString("F12") + vbTab + CYY_3D(4).ToString("F12") + vbTab
                        ThreeDFileNum3.WriteLine(tmp_str2)
                        ThreeDFileNum3.Close()
                        MM.PrintMsg("3D Calibration file updated to be centered at z=0um: " + ThreeDFileName2)
                    End If

                Else
                    MM.PrintMsg("3D Calibration file doesn't exist. No 3D extraction")
                    sucess = False
                End If

            Catch ex As Exception
                MM.PrintMsg("Cannot load 3D calibration file: " + ThreeDFileName2)
                sucess = False
            End Try
        Else
            sucess = False
        End If
        Return sucess
    End Function

    Public Sub findBeadAutomaticStack_test(ByRef MM As MMAppLib.IUserCall64)

        '************MM**************************
        MM.GetCurrentImage(src)
        MM.GetWidth(src, srcWidth)
        MM.GetHeight(src, srcHeight)
        Dim nb_planes As Integer
        MM.GetNumberOfPlanes(src, nb_planes)
        Dim ROIarea As New ROI_track
        MM.GetActiveRegion(src, ROIarea.hdlROI)
        MM.GetRegionPosition(ROIarea.hdlROI, ROIarea.Px, ROIarea.Py)
        MM.GetRegionSize(ROIarea.hdlROI, ROIarea.width, ROIarea.height)
        '*******************************************

        '*************Detection**********************
        Dim Points(), Points_all(), Wavelet_WatershedRatio, trcList(), driftTab(0, 0), driftTabY() As Double
        NbMaxPtsPerImage = CLng(CDbl(srcWidth * CDbl(srcHeight * MaxDensityPerPixel)))
        'Dim NbPointsMaxPerPlane = CInt(MaxDensity * srcWidth * srcHeight * pixelSize * pixelSize)
        Dim Nb_Val = NbSegParams * NbMaxPtsPerImage * CLng(nb_planes)
        ReDim Points(Nb_Val - 1)
        ReDim Points_all(Nb_Val - 1)
        Dim IsGPUAcceleration = False
        Dim IsWatershed = False
        Dim GaussFit = MainWindow.GaussFitSize
        Dim Index = 0
        Dim ListAutomaticdetectedBead As New List(Of AutomaticBeadDetection)
        '********************************************

        '*************tracking**********************
        Dim Decrease = 10
        Dim CostBirth = 0.5#
        Dim MaxDistance = 5
        Dim MinLength = 2
        'ReDim trcList(nb_planes * 2)
        'ReDim driftTab(nb_planes + 1, 18)
        Dim Gauss_Fit_Calibration = 1
        Dim SigmaGauss_Fit = 1.0#
        Dim ThetaGauss_Fit = 0.0#
        Dim ret_val As Integer
        Dim pointsNumber As Integer = 0
        '*******************************************

        If IsWatershed Then
            Wavelet_WatershedRatio = 0.0#
        Else
            Wavelet_WatershedRatio = 10.0#
        End If

        If ROIarea.hdlROI <> 0 Then

            For k = 0 To nb_planes - 1

                MM.SetActivePlane(src, k) 'It's very important


                If MW.is3DAstig Then
                    Gauss_Fit_Calibration = 3
                    'ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessingROI(True, MM, NumImage - 1, Points, CUInt(Nb_Val), CUInt(MW.listRoi(currentPlane - 1).width), CUInt(MW.listRoi(currentPlane - 1).height), CUInt(MW.listRoi(currentPlane - 1).Px), CUInt(MW.listRoi(currentPlane - 1).Py), 1, WaveletThreshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
                    ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessing(False, MM, src, Points, CUInt(Nb_Val), CUInt(srcWidth), CUInt(srcHeight), 1, WT_Threshold, Wavelet_WatershedRatio, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))

                Else
                    Gauss_Fit_Calibration = 2
                    ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessing(False, MM, src, Points, CUInt(Nb_Val), CUInt(srcWidth), CUInt(srcHeight), 1, WT_Threshold, Wavelet_WatershedRatio, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit, ThetaGauss_Fit, CUShort(GaussFitSize))

                End If

                If MW.is3DRegistration Then
                    AssignThreeDValuesToPoints(MM, Points, CUInt(NbMaxPtsPerImage))
                End If

                Dim pointsNumberCurrentFrame As Integer = (ret_val / NbSegParams) - 1

                'If (GPU_Chk.Checked = True) Then
                '    ret_val = StreamProcessingUnsafe.Unmanaged.LiveProcessing(False, TMP, MM, src, CUShort(k), CUShort(nb_planes), Points, CUInt(NbPointsMaxPerPlane * NbSegParams), CUInt(srcWidth), CUInt(srcHeight), 1, Wavelet_Threshold, Wavelet_WatershedRatio, 4.0#, 0.0#, computing, CUShort(Gauss_Fit), 1.0#, 0.0#, 0.0#, CUShort(7))
                'Else
                '    ret_val = StreamProcessingUnsafe.Unmanaged.CPUProcessing(False, MM, src, Points, CUInt(NbSegParams * NbPointsMaxPerPlane), CUInt(srcWidth), CUInt(srcHeight), 1, Wavelet_Threshold, Wavelet_WatershedRatio, 4.0#, 0.0#, CUShort(Gauss_Fit), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(ROISize_NumericUpDown.Value))
                'End If

                '-------------------------------------------------------------------------
                Dim DetectionBead_plane As New AutomaticBeadDetection
                Dim listtmp As New List(Of detection_data)

                For i = 0 To pointsNumberCurrentFrame - 1

                    Dim newdetectedBead As New detection_data

                    newdetectedBead.CentroidX = Points(4 + NbSegParams * i)
                    newdetectedBead.CentroidY = Points(3 + NbSegParams * i)
                    newdetectedBead.CentroidZ = Points(10 + NbSegParams * i)
                    newdetectedBead.Intensity = Points(8 + NbSegParams * i)
                    newdetectedBead.Surface = Points(9 + NbSegParams * i)
                    newdetectedBead.SigmaX = Points(0 + NbSegParams * i)
                    newdetectedBead.SigmaY = Points(1 + NbSegParams * i)
                    newdetectedBead.SigmaGoodness = Points(7 + NbSegParams * i)
                    newdetectedBead.circularity = Math.Abs(newdetectedBead.SigmaX / newdetectedBead.SigmaY)


                    If (newdetectedBead.CentroidX < ROIarea.Px Or newdetectedBead.CentroidX > (ROIarea.Px + ROIarea.width)) Or (newdetectedBead.CentroidY < ROIarea.Py Or newdetectedBead.CentroidY > (ROIarea.Py + ROIarea.height)) Then
                        listtmp.Add(newdetectedBead)
                    End If

                Next


                If listtmp.Count <> 0 Then
                    DetectionBead_plane.plane = k + 1
                    DetectionBead_plane.ROIdetectionArea = ROIarea
                    DetectionBead_plane.WTthresh = WT_Threshold
                    DetectionBead_plane.listDetectedBead = listtmp
                    ListAutomaticdetectedBead.Add(DetectionBead_plane)
                End If


                '----------------------------------------------------------------
                pointsNumber = pointsNumberCurrentFrame + pointsNumber

                ' copy data from 'points' to 'points_all

                For li = 0 To (pointsNumberCurrentFrame - 1)
                    For ind = 0 To NbSegParams - 1
                        Points_all(Index + ind) = Points(li * NbSegParams + ind)
                    Next ind
                    Index = Index + NbSegParams
                Next li

                For ind = 0 To NbSegParams - 1
                    Points_all(Index + ind) = -1
                Next ind
                Index = Index + NbSegParams
                '----------------------------------------------------------------






            Next k

        Else
            MsgBox("Create a ROI around the well to extract bead only in the polymer.", MsgBoxStyle.OkOnly)
        End If

        '---------------Trouver la meilleur billes pour chaques plan-------------------------------
        'Dim FinalListBead = ListAutomaticdetectedBead
        Dim FinalListBead = New List(Of detection_data)
        Dim previousBead As New detection_data
        'Dim Chi2(), circularity(), Intensity()

        'For i = 0 To nb_planes - 1
        For Each planeBead In ListAutomaticdetectedBead
            'If list.plane = i + 1 Then
            If planeBead.listDetectedBead.Count > 1 Then

                'sigma goodness
                Dim chi2 = planeBead.listDetectedBead.OrderByDescending(Function(p) p.SigmaGoodness)
                'circularity
                Dim circ = planeBead.listDetectedBead.OrderByDescending(Function(p) p.circularity)
                'intensity
                Dim intens = planeBead.listDetectedBead.OrderByDescending(Function(p) p.Intensity)

                'definir score meilleur bille

                For i = 0 To planeBead.listDetectedBead.Count - 1
                    Dim tmpbead As New detection_data
                    Dim score As Integer = 0
                    tmpbead = planeBead.listDetectedBead(i)
                    For j = 0 To planeBead.listDetectedBead.Count - 1

                        If planeBead.listDetectedBead(i).CentroidX = chi2(j).CentroidX Then
                            score = score + j + 1
                        End If

                        If MW.is3DAstig Then
                            If planeBead.listDetectedBead(i).CentroidX = circ(j).CentroidX Then
                                score = score + j + 1
                            End If
                        End If


                        If planeBead.listDetectedBead(i).CentroidX = intens(j).CentroidX Then
                            score = score + j + 1
                        End If
                    Next
                    tmpbead.scoreAutoDetection = score
                    planeBead.listDetectedBead(i) = tmpbead
                Next


                'intensity
                Dim scoreList = planeBead.listDetectedBead.OrderBy(Function(p) p.scoreAutoDetection)
                FinalListBead.Add(scoreList(0))

                'ReDim Chi2(list.listDetectedBead.Count)
                'ReDim circularity(list.listDetectedBead.Count)
                'ReDim Intensity(list.listDetectedBead.Count)

                'For Each bead In list.listDetectedBead

                'circularity
                'intensity 
                'Next

                'If bead.SigmaGoodness > previousBead.SigmaGoodness Then
                '    previousBead = bead
                'End If
            ElseIf planeBead.listDetectedBead.Count = 1 Then
                FinalListBead.Add(planeBead.listDetectedBead(0))
            Else
                'FinalListBead.Add(New detection_data)
            End If
        Next




        '------------------------------------------------------------------------------------------




        MM.PrintMsg("** Detection **")
        MM.PrintMsg("Nb of detected spots: " + Str(pointsNumber))
        'MM.PrintMsg("Processing time: " + Format(Microsoft.VisualBasic.DateAndTime.Timer() - d, "0.00") + "s")
        MM.PrintMsg(" ")
        For k = 0 To ListAutomaticdetectedBead.Count - 1
            MM.PrintMsg("  - Plane : " + ListAutomaticdetectedBead(k).plane.ToString() + "  -  Beads : " + ListAutomaticdetectedBead(k).listDetectedBead.Count.ToString() + " - after optimization : " + FinalListBead(k).Intensity.ToString("0.00") + " - " + FinalListBead(k).SigmaGoodness.ToString("0.000") + " - " + FinalListBead(k).scoreAutoDetection.ToString())
        Next


    End Sub


    Public Function findBeadAutomaticStack(ByRef MM As MMAppLib.IUserCall64) As List(Of detection_data)

        '************MM**************************
        MM.GetCurrentImage(src)
        MM.GetWidth(src, srcWidth)
        MM.GetHeight(src, srcHeight)
        Dim nb_planes As Integer
        MM.GetNumberOfPlanes(src, nb_planes)
        Dim ROIarea As New ROI_track
        MM.GetActiveRegion(src, ROIarea.hdlROI)
        MM.GetRegionPosition(ROIarea.hdlROI, ROIarea.Px, ROIarea.Py)
        MM.GetRegionSize(ROIarea.hdlROI, ROIarea.width, ROIarea.height)
        '*******************************************

        '*************Detection**********************
        Dim Points(), Points_all(), Wavelet_WatershedRatio As Double
        NbMaxPtsPerImage = CLng(CDbl(srcWidth * CDbl(srcHeight * MaxDensityPerPixel)))
        'Dim NbPointsMaxPerPlane = CInt(MaxDensity * srcWidth * srcHeight * pixelSize * pixelSize)
        Dim Nb_Val = NbSegParams * NbMaxPtsPerImage * CLng(nb_planes)
        ReDim Points(Nb_Val - 1)
        ReDim Points_all(Nb_Val - 1)
        Dim IsGPUAcceleration = False
        Dim IsWatershed = False
        Dim GaussFit = MainWindow.GaussFitSize
        Dim Index = 0
        Dim ListAutomaticdetectedBead As New List(Of AutomaticBeadDetection)
        Dim chi2ThreshMin = CDbl(MW.TXTBX_BeadAUto_Chi2Min.Text)
        Dim chi2ThreshMax = CDbl(MW.TXTBX_BeadAUto_Chi2Max.Text)
        Dim SigmaXThreshMin = CDbl(MW.TXTBX_BeadAuto_SigmaXMin.Text)
        Dim SigmaXThreshMax = CDbl(MW.TXTBX_BeadAuto_SigmaXMax.Text)
        Dim SigmaYThreshMin = CDbl(MW.TXTBX_BeadAuto_SigmaYMin.Text)
        Dim SigmaYThreshMax = CDbl(MW.TXTBX_BeadAuto_SigmaYMax.Text)
        Dim IntThreshMin = CDbl(MW.TXTBX_BeadAuto_IntensityMin.Text)
        Dim IntThreshMax = CDbl(MW.TXTBX_BeadAuto_IntensityMax.Text)
        '********************************************

        '*************tracking**********************
        Dim Decrease = 10
        Dim CostBirth = 0.5#
        Dim MaxDistance = 5
        Dim MinLength = 2
        'ReDim trcList(nb_planes * 2)
        'ReDim driftTab(nb_planes + 1, 18)
        Dim Gauss_Fit_Calibration = 1
        Dim SigmaGauss_Fit = 1.0#
        Dim ThetaGauss_Fit = 0.0#
        Dim ret_val As Integer
        Dim pointsNumber As Integer = 0
        '*******************************************

        If IsWatershed Then
            Wavelet_WatershedRatio = 0.0#
        Else
            Wavelet_WatershedRatio = 10.0#
        End If

        If MW.roiWell.hdlROI <> 0 Then

            For k = 0 To nb_planes - 1

                MM.SetActivePlane(src, k) 'It's very important


                If MW.is3DAstig Then
                    Gauss_Fit_Calibration = 3
                    ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessing(False, MM, src, Points, CUInt(Nb_Val), CUInt(srcWidth), CUInt(srcHeight), 1, WT_Threshold, Wavelet_WatershedRatio, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))

                Else
                    Gauss_Fit_Calibration = 2
                    ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessing(False, MM, src, Points, CUInt(Nb_Val), CUInt(srcWidth), CUInt(srcHeight), 1, WT_Threshold, Wavelet_WatershedRatio, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit, ThetaGauss_Fit, CUShort(GaussFitSize))

                End If

                If MW.is3DRegistration Then
                    AssignThreeDValuesToPoints(MM, Points, CUInt(NbMaxPtsPerImage))
                End If

                Dim pointsNumberCurrentFrame As Integer = (ret_val / NbSegParams) - 1

                '-------------------------------------------------------------------------
                Dim DetectionBead_plane As New AutomaticBeadDetection
                Dim listtmp As New List(Of detection_data)

                For i = 0 To pointsNumberCurrentFrame - 1

                    Dim newdetectedBead As New detection_data

                    newdetectedBead.CentroidX = Points(4 + NbSegParams * i)
                    newdetectedBead.CentroidY = Points(3 + NbSegParams * i)
                    newdetectedBead.CentroidZ = Points(10 + NbSegParams * i)
                    newdetectedBead.Intensity = Points(8 + NbSegParams * i)
                    newdetectedBead.Surface = Points(9 + NbSegParams * i)
                    newdetectedBead.SigmaX = Points(0 + NbSegParams * i)
                    newdetectedBead.SigmaY = Points(1 + NbSegParams * i)
                    newdetectedBead.SigmaGoodness = Points(7 + NbSegParams * i)
                    newdetectedBead.circularity = Math.Abs(newdetectedBead.SigmaX / newdetectedBead.SigmaY)


                    'seuil bord image, ROI et puits soSPIM 
                    If (newdetectedBead.CentroidX < MW.roiWell.Px - 10 Or newdetectedBead.CentroidX > (MW.roiWell.Px + MW.roiWell.width + 10)) Or (newdetectedBead.CentroidY < MW.roiWell.Py - 10 Or newdetectedBead.CentroidY > (MW.roiWell.Py + MW.roiWell.height + 10)) Then
                        If newdetectedBead.CentroidX > 15 And newdetectedBead.CentroidY > 15 And newdetectedBead.CentroidX < srcWidth - 15 And newdetectedBead.CentroidY < srcHeight - 15 Then
                            'seuils chi2, SigmaX et sigmaY
                            If chi2ThreshMin <> 0 And chi2ThreshMax <> 0 And SigmaXThreshMin <> 0 And SigmaXThreshMax <> 0 And SigmaYThreshMin <> 0 And SigmaYThreshMax <> 0 Then
                                If newdetectedBead.SigmaGoodness > chi2ThreshMin And newdetectedBead.SigmaGoodness < chi2ThreshMax And newdetectedBead.SigmaX > SigmaXThreshMin And newdetectedBead.SigmaX < SigmaXThreshMax And newdetectedBead.SigmaY > SigmaYThreshMin And newdetectedBead.SigmaY < SigmaYThreshMax Then
                                    listtmp.Add(newdetectedBead)
                                End If
                            Else
                                'si les seuils sont mis à Zero, les filtres ne sont pas appliqués.
                                listtmp.Add(newdetectedBead)
                            End If
                        End If
                    End If

                Next





                If listtmp.Count <> 0 Then
                    DetectionBead_plane.plane = k + 1
                    DetectionBead_plane.ROIdetectionArea = ROIarea
                    DetectionBead_plane.WTthresh = WT_Threshold
                    DetectionBead_plane.listDetectedBead = listtmp
                    ListAutomaticdetectedBead.Add(DetectionBead_plane)
                Else
                    Dim tmp As New AutomaticBeadDetection
                    tmp.listDetectedBead = New List(Of detection_data)
                    ListAutomaticdetectedBead.Add(tmp)
                End If
            Next k

        Else
            MsgBox("Create a ROI around the well to extract bead only in the polymer.", MsgBoxStyle.OkOnly)
        End If

        '---------------Trouver la meilleur billes pour chaques plan-------------------------------
        Dim FinalListBead = New List(Of detection_data)

        For Each planeBead In ListAutomaticdetectedBead
            If planeBead.listDetectedBead.Count > 1 Then

                'sigma goodness
                Dim chi2 = planeBead.listDetectedBead.OrderByDescending(Function(p) p.SigmaGoodness)
                'circularity
                Dim circ = planeBead.listDetectedBead.OrderByDescending(Function(p) p.circularity)
                'intensity
                Dim intens = planeBead.listDetectedBead.OrderByDescending(Function(p) p.Intensity)

                'definir score meilleur bille
                For i = 0 To planeBead.listDetectedBead.Count - 1
                    Dim tmpbead As New detection_data
                    Dim score As Integer = 0
                    tmpbead = planeBead.listDetectedBead(i)
                    For j = 0 To planeBead.listDetectedBead.Count - 1

                        If planeBead.listDetectedBead(i).CentroidX = chi2(j).CentroidX Then
                            score = score + j + 1
                        End If

                        If MW.is3DAstig Then
                            If planeBead.listDetectedBead(i).CentroidX = circ(j).CentroidX Then
                                score = score + j + 1
                            End If
                        End If

                        If planeBead.listDetectedBead(i).CentroidX = intens(j).CentroidX Then
                            score = score + j + 1
                        End If
                    Next
                    tmpbead.scoreAutoDetection = score
                    planeBead.listDetectedBead(i) = tmpbead
                Next


                'intensity
                Dim scoreList = planeBead.listDetectedBead.OrderBy(Function(p) p.scoreAutoDetection)
                FinalListBead.Add(scoreList(0))
            ElseIf planeBead.listDetectedBead.Count = 1 Then
                FinalListBead.Add(planeBead.listDetectedBead(0))
            Else
                FinalListBead.Add(New detection_data)
            End If
        Next

        '------------------------------------------------------------------------------------------

        MM.PrintMsg("** Detection **")
        MM.PrintMsg("Nb of detected spots: " + Str(pointsNumber))
        'MM.PrintMsg("Processing time: " + Format(Microsoft.VisualBasic.DateAndTime.Timer() - d, "0.00") + "s")
        MM.PrintMsg(" ")
        For k = 0 To ListAutomaticdetectedBead.Count - 1
            MM.PrintMsg("  - Plane : " + ListAutomaticdetectedBead(k).plane.ToString() + "  -  Beads : " + ListAutomaticdetectedBead(k).listDetectedBead.Count.ToString() + " - after optimization : " + FinalListBead(k).Intensity.ToString("0.00") + " - " + FinalListBead(k).SigmaGoodness.ToString("0.000") + " - " + FinalListBead(k).scoreAutoDetection.ToString())
        Next

        Return FinalListBead
    End Function


    Public Function findBeadAutomaticPerPlane(ByRef MM As MMAppLib.IUserCall64, ByVal currentPlane As Integer) As detection_data

        '************MM**************************


        MM.GetCurrentImage(src)
        MM.GetWidth(src, srcWidth)
        MM.GetHeight(src, srcHeight)
        '*******************************************

        '*************Detection**********************
        Dim Points(), Wavelet_WatershedRatio As Double
        NbMaxPtsPerImage = CLng(CDbl(srcWidth * CDbl(srcHeight * MaxDensityPerPixel)))
        'Dim NbPointsMaxPerPlane = CInt(MaxDensity * srcWidth * srcHeight * pixelSize * pixelSize)
        Dim Nb_Val = NbSegParams * NbMaxPtsPerImage
        ReDim Points(Nb_Val - 1)
        Dim IsGPUAcceleration = False
        Dim IsWatershed = False
        Dim GaussFit = MainWindow.GaussFitSize
        Dim Index = 0
        Dim DetectionBead_plane As New List(Of detection_data)
        Dim chi2ThreshMin = CDbl(MW.TXTBX_BeadAUto_Chi2Min.Text)
        Dim chi2ThreshMax = CDbl(MW.TXTBX_BeadAUto_Chi2Max.Text)
        Dim SigmaXThreshMin = CDbl(MW.TXTBX_BeadAuto_SigmaXMin.Text)
        Dim SigmaXThreshMax = CDbl(MW.TXTBX_BeadAuto_SigmaXMax.Text)
        Dim SigmaYThreshMin = CDbl(MW.TXTBX_BeadAuto_SigmaYMin.Text)
        Dim SigmaYThreshMax = CDbl(MW.TXTBX_BeadAuto_SigmaYMax.Text)
        Dim IntThreshMin = CDbl(MW.TXTBX_BeadAuto_IntensityMin.Text)
        Dim IntThreshMax = CDbl(MW.TXTBX_BeadAuto_IntensityMax.Text)
        '********************************************

        '*************tracking**********************
        Dim Decrease = 10
        Dim CostBirth = 0.5#
        Dim MaxDistance = 5
        Dim MinLength = 2
        Dim Gauss_Fit_Calibration = 1
        Dim SigmaGauss_Fit = 1.0#
        Dim ThetaGauss_Fit = 0.0#
        Dim ret_val As Integer
        Dim pointsNumber As Integer = 0
        '*******************************************



        If IsWatershed Then
            Wavelet_WatershedRatio = 0.0#
        Else
            Wavelet_WatershedRatio = 10.0#
        End If

        If MW.roiWell.hdlROI <> 0 Then

            If MW.is3DAstig Then
                Gauss_Fit_Calibration = 3
                ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessing(False, MM, src, Points, CUInt(Nb_Val), CUInt(srcWidth), CUInt(srcHeight), 1, WT_Threshold, Wavelet_WatershedRatio, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
            Else
                Gauss_Fit_Calibration = 2
                ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessing(False, MM, src, Points, CUInt(Nb_Val), CUInt(srcWidth), CUInt(srcHeight), 1, WT_Threshold, Wavelet_WatershedRatio, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit, ThetaGauss_Fit, CUShort(GaussFitSize))
            End If

            If MW.is3DRegistration Then
                AssignThreeDValuesToPoints(MM, Points, CUInt(NbMaxPtsPerImage))
            End If

            Dim pointsNumberCurrentFrame As Integer = (ret_val / NbSegParams) - 1

            '-------------------------------------------------------------------------
            For i = 0 To pointsNumberCurrentFrame - 1

                Dim newdetectedBead As New detection_data

                newdetectedBead.CentroidX = Points(4 + NbSegParams * i)
                newdetectedBead.CentroidY = Points(3 + NbSegParams * i)
                newdetectedBead.CentroidZ = Points(10 + NbSegParams * i)
                newdetectedBead.Intensity = Points(8 + NbSegParams * i)
                newdetectedBead.Surface = Points(9 + NbSegParams * i)
                newdetectedBead.SigmaX = Points(0 + NbSegParams * i)
                newdetectedBead.SigmaY = Points(1 + NbSegParams * i)
                newdetectedBead.SigmaGoodness = Points(7 + NbSegParams * i)
                newdetectedBead.circularity = Math.Abs(newdetectedBead.SigmaX / newdetectedBead.SigmaY)


                'seuil bord image, ROI et puits soSPIM 
                If (newdetectedBead.CentroidX < MW.roiWell.Px - 10 Or newdetectedBead.CentroidX > (MW.roiWell.Px + MW.roiWell.width + 10)) Or (newdetectedBead.CentroidY < MW.roiWell.Py - 10 Or newdetectedBead.CentroidY > (MW.roiWell.Py + MW.roiWell.height + 10)) Then
                    If newdetectedBead.CentroidX > 15 And newdetectedBead.CentroidY > 15 And newdetectedBead.CentroidX < srcWidth - 15 And newdetectedBead.CentroidY < srcHeight - 15 Then
                        'seuils chi2, SigmaX et sigmaY
                        If chi2ThreshMin <> 0 And chi2ThreshMax <> 0 And SigmaXThreshMin <> 0 And SigmaXThreshMax <> 0 And SigmaYThreshMin <> 0 And SigmaYThreshMax <> 0 Then
                            If newdetectedBead.SigmaGoodness > chi2ThreshMin And newdetectedBead.SigmaGoodness < chi2ThreshMax And newdetectedBead.SigmaX > SigmaXThreshMin And newdetectedBead.SigmaX < SigmaXThreshMax And newdetectedBead.SigmaY > SigmaYThreshMin And newdetectedBead.SigmaY < SigmaYThreshMax Then
                                DetectionBead_plane.Add(newdetectedBead)
                            End If
                        Else
                            'si les seuils sont mis à Zero, les filtres ne sont pas appliqués.
                            DetectionBead_plane.Add(newdetectedBead)
                        End If
                    End If
                End If
            Next

            ''filtrer si plusieurs billes dans la meme ROI. 
            'Dim tmp_detectionbead_plane = DetectionBead_plane
            'For i = 0 To DetectionBead_plane.Count - 1
            '    For j = 0 To DetectionBead_plane.Count - 1
            '        If (DetectionBead_plane(i).CentroidX + 15 > DetectionBead_plane(j).CentroidX And DetectionBead_plane(j).CentroidX < DetectionBead_plane(i).CentroidX + 15) And (DetectionBead_plane(i).CentroidY + 15 > DetectionBead_plane(j).CentroidY And DetectionBead_plane(j).CentroidY < DetectionBead_plane(i).CentroidY + 15) Then
            '            tmp_detectionbead_plane.RemoveAt(i)
            '            tmp_detectionbead_plane.RemoveAt(j)
            '        End If
            '    Next
            'Next
            'DetectionBead_plane.Clear()
            'DetectionBead_plane = tmp_detectionbead_plane


            '---------------Trouver la meilleur bille pour chaques plan-------------------------------
            Dim FinalBead = New detection_data

            If DetectionBead_plane.Count > 1 Then

                'sigma goodness
                Dim chi2 = DetectionBead_plane.OrderByDescending(Function(p) p.SigmaGoodness)
                'circularity
                Dim circ = DetectionBead_plane.OrderByDescending(Function(p) p.circularity)
                'intensity
                Dim intens = DetectionBead_plane.OrderByDescending(Function(p) p.Intensity)

                'definir score meilleur bille
                For i = 0 To DetectionBead_plane.Count - 1
                    Dim tmpbead As New detection_data
                    Dim score As Integer = 0
                    tmpbead = DetectionBead_plane(i)
                    For j = 0 To DetectionBead_plane.Count - 1

                        If DetectionBead_plane(i).CentroidX = chi2(j).CentroidX Then
                            score = score + j + 1
                        End If

                        If MW.is3DAstig Then
                            If DetectionBead_plane(i).CentroidX = circ(j).CentroidX Then
                                score = score + j + 1
                            End If
                        End If

                        If DetectionBead_plane(i).CentroidX = intens(j).CentroidX Then
                            score = score + j + 1
                        End If
                    Next
                    tmpbead.scoreAutoDetection = score
                    DetectionBead_plane(i) = tmpbead
                Next

                'score
                Dim scoreList = DetectionBead_plane.OrderBy(Function(p) p.scoreAutoDetection)
                FinalBead = (scoreList(0))

            ElseIf DetectionBead_plane.Count = 1 Then
                FinalBead = DetectionBead_plane(0)
            Else
                FinalBead = New detection_data
            End If


            Return FinalBead
            '------------------------------------------------------------------------------------------

            MM.PrintMsg("** Detection **")
            MM.PrintMsg("Nb of detected spots: " + Str(pointsNumber))

            MM.PrintMsg("listeBead : ")
            For Each bead In DetectionBead_plane
                MM.PrintMsg("  - Plane : " + currentPlane.ToString() + "  -  Beads : " + DetectionBead_plane.Count.ToString() + " - Intensity " + bead.Intensity.ToString("0.00") + " - chi2 " + bead.SigmaGoodness.ToString("0.000") + " - score " + bead.scoreAutoDetection.ToString() + " - X " + bead.CentroidX.ToString() + " - Y " + bead.CentroidY.ToString())
            Next

            MM.PrintMsg("  - Plane : " + currentPlane.ToString() + "  -  Beads : " + DetectionBead_plane.Count.ToString() + " - after optimization : Intensity " + FinalBead.Intensity.ToString("0.00") + " - chi2 " + FinalBead.SigmaGoodness.ToString("0.000") + " - score " + FinalBead.scoreAutoDetection.ToString() + " - X " + FinalBead.CentroidX.ToString() + " - Y " + FinalBead.CentroidY.ToString())

        End If
    End Function

    Public Function CreateROI_AutomaticBeadEx(ByRef MM As MMAppLib.IUserCall64, ByVal BeadPlane As detection_data, ByVal plane As Integer) As ROI_track

        MM.GetCurrentImage(src)
        MM.GetWidth(src, srcWidth)
        MM.GetHeight(src, srcHeight)

        Dim Roi_plane As New ROI_track()

        If BeadPlane.CentroidX <> 0 Then

            'Creation ROI autour de la bille trouvée
            MM.CreateRectRegion(src, BeadPlane.CentroidX - 15, BeadPlane.CentroidY - 15, BeadPlane.CentroidX + 15, BeadPlane.CentroidY + 15, Roi_plane.hdlROI)

            Roi_plane.height = 30
            Roi_plane.width = 30
            Roi_plane.Px = BeadPlane.CentroidX - 15
            Roi_plane.Py = BeadPlane.CentroidY - 15
            Roi_plane.WT = WT_Threshold
            Roi_plane.plane = plane
            Roi_plane.Z = MW.Coordclock.coordZ

        Else
            Roi_plane.hdlROI = 0
        End If





        Return Roi_plane

    End Function


End Class
