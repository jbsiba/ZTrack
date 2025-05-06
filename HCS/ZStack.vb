Imports System.IO
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Ipc
Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports ZStack.RegionTracking
Imports ZStack.MainWindow
Imports ZStack.Process
Imports MadCity.Madlib


Public Interface IUserMethods64
    Property mm() As MMAppLib.UserCall64
    Property gParentWnd() As Integer
    Property gUserID() As Integer
    Function Startup(ByRef cmdLine As String) As Integer
    Function Docommand(ByRef cmdLin As String) As Integer
    Function Shutdown() As Integer
End Interface

<ComClass(UserMethods64.ClassId, UserMethods64.InterfaceId)> _
Public Class UserMethods64
    Implements IUserMethods64

    'Private members
    '*************************************
    Private TotalFrameCount As Integer
    Private mygParentWnd As Integer
    Private mygUserID As Integer
    '*************************************
    'Public members
    '*************Detection**********************
    Public Nb_Val, Wavelet_WatershedRatio, WaveletThreshold, Points() As Double
    Public IsGPUAcceleration, IsWatershed, isOnebead, isError As Boolean
    Public pointsNumberCurrentFrame, PointsNumber, index, GaussFit, cpt As Integer
    Public nbrRefBead As Integer
    Public nbr_BeadNotFound As Integer
    Public Gauss_Fit_Calibration As Integer = 1
    Public SigmaGauss_Fit = 1.0#
    Public ThetaGauss_Fit = 0.0#
    Public sw As StreamWriter
    Public ratioSigma As Double
    Public LocalizationMode As String = "Wavelet"
    Public RealNbSegParams As Integer = 13
    Public Const NbTrackMax As Long = 100000     ' Nb Track max par fichier
    Public Const NbPointsMax As Long = 1000000   ' Nb Points max par fichier
    Public Const MaxDensityPerPixel As Double = 0.02 ' Densité max=0 .5 mol/micron^2 = 0.02 mol/pixel (5 pix/microns)
    Public Const NbSegParams As Long = 13 '12  New DLLs 2016.04.07
    Public Const NbTrackParams As Long = 9 '7  New DLLs 2016.04.07
    Public Shared NbMaxPtsPerImage As Integer
    '  Public Const MaxDensityPerPixel As Double = 0.01 ' COREY 2016.05.02 reduce density per pixel to avoid out of memory warnings 
    '*************tracking**********************
    Public Decrease, CostBirth, trcList(), driftTab(0, 0), driftTabY() As Double
    Public MaxDistance, MinLength, binning As Integer
    Public RegistrationDist As Double = 3.0# ' Rayon max pour tracking
    '***********************************************************************

    '*******************MM**********************
    Public nb_planes, srcWidth, srcHeight, currentPlane, currentSection, NumImage As Integer
    Public src As Long
    Public Timer_All_1, Timer_All_2 As Double
    Public ZStackDirectory As String = "C:\MM\ZStack\"
    Public mymm As MMAppLib.UserCall64
    Public Const ClassId As String = "721A09B3-CDF8-41E2-87DC-7E45214A7231" '0
    Public Const InterfaceId As String = "3D8B5BA4-FB4C-5ff1-8368-13BF3BD5CF92" '1
    Public Shared nbr As Integer = 0
    Public Shared MW As MainWindow
    '**************************************************************************
    Public Const StreamEventSetup As String = "SETUP"
    Public Const StreamEventShutdown As String = "SHUTDOWN"
    Public Const StreamEventNewFrame As String = "NEWFRAME"
    Public Const StreamEventNewImage As String = "NEWIMAGE"
    '**************************************************************************
    Public Const StreamVariableTotalFrameCount As String = "Stream.RunUserProgram.TotalFrames"
    Public Const StreamVariableImageName As String = "Stream.RunUserProgram.ImageName"
    Public Const StreamVariableFrameWidth As String = "Stream.RunUserProgram.FrameWidth"
    Public Const StreamVariableFrameHeight As String = "Stream.RunUserProgram.FrameHeight"
    Public Const StreamVariableFrameDepth As String = "Stream.RunUserProgram.FrameDepth"
    Public Const StreamVariableAbort As String = "Stream.RunUserProgram.Abort"
    Public Const StreamVariableFrameNumber As String = "Stream.RunUserProgram.FrameNumber"
    '**************************************************************************

    Property mm() As MMAppLib.UserCall64 Implements IUserMethods64.mm
        Get
            Return mymm
        End Get
        Set(ByVal Value As MMAppLib.UserCall64)
            mymm = Value
        End Set
    End Property

    Property gParentWnd() As Integer Implements IUserMethods64.gParentWnd
        Get
            Return mygParentWnd
        End Get
        Set(ByVal Value As Integer)
            mygParentWnd = Value
        End Set
    End Property

    Property gUserID() As Integer Implements IUserMethods64.gUserID
        Get
            Return mygUserID
        End Get
        Set(ByVal Value As Integer)
            mygUserID = Value
        End Set
    End Property

    Public Function Startup(ByRef cmdLine As String) As Integer Implements IUserMethods64.Startup
        mm.PrintMsg("Startup")

        Docommand(cmdLine)
        Return 0
    End Function

    Public Function GetTotalFrameCount() As Long
        Dim count As Double
        Dim mymm As MMAppLib.UserCall64 = New MMAppLib.UserCall64()
        If (mymm.GetMMVariable(StreamVariableTotalFrameCount, count) = 0) Then
            count = 0
        End If

        GetTotalFrameCount = count
    End Function

    Private Function GetImageName() As String
        Dim name As String
        name = ""

        If (mymm.GetMMVariable(StreamVariableImageName, name) = 0) Then
            name = ""
        End If

        GetImageName = name
        'mm.PrintMsg("Name: " + name)
        GetImageName = "Stream Acquisition Preview"
    End Function

    Private Function GetFrameWidth() As Integer
        Dim _width As Integer

        If (mymm.GetMMVariable(StreamVariableFrameWidth, _width) = 0) Then
            _width = 0
        End If

        GetFrameWidth = _width
    End Function

    Private Function GetFrameHeight() As Integer
        Dim _height As Integer

        If (mymm.GetMMVariable(StreamVariableFrameHeight, _height) = 0) Then
            _height = 0
        End If

        GetFrameHeight = _height
    End Function

    Private Sub SetAbort(ByVal abort As Boolean)

        mymm.SetMMVariable(StreamVariableAbort, abort)

    End Sub

    Private Function GetFrameDepth() As Integer
        Dim _depth As Integer

        If (mymm.GetMMVariable(StreamVariableFrameDepth, _depth) = 0) Then
            _depth = 0
        End If

        GetFrameDepth = _depth
    End Function

    Public Function GetFrameNumber() As Long
        Dim number As Double
        Dim mymm As MMAppLib.UserCall64 = New MMAppLib.UserCall64()
        If (mymm.GetMMVariable(StreamVariableFrameNumber, number) = 0) Then
            number = 0
        End If

        GetFrameNumber = number
        'mm.PrintMsg(number.ToString())
    End Function

    Private Function GetImage() As Long
        Const kAllImages As Integer = &H7FFF

        Dim name As String
        name = GetImageName()

        Dim hImageRet As Long
        hImageRet = 0

        Dim cImages As Integer
        cImages = mymm.GetQualifiedNumberOfImages(kAllImages)

        For iImage As Integer = 0 To cImages - 1
            Dim hImage As Long
            mymm.GetQualifiedImage(kAllImages, iImage, hImage)

            Dim thisname As String
            thisname = ""
            mymm.GetImageName(hImage, thisname)

            If thisname = name Then
                hImageRet = hImage
                Exit For
            End If
        Next

        GetImage = hImageRet
    End Function

    Public Function IsCommandAllowed(ByRef cmdLine As String) As Boolean
        'Cached state of whether the command is allowed
        Static isAllowed As Boolean = False

        If (cmdLine = "" Or cmdLine = "SETUP") Then
            'SETUP and empty command line, Query MM variable values to initialize 'isAllowed'
            Dim oemVendor As Integer
            If (mymm.GetMMVariable("OEMVendor", oemVendor) = 0) Then
                oemVendor = 0
            End If

            Dim oemProduct As Integer
            If (mymm.GetMMVariable("OEMProduct", oemProduct) = 0) Then
                oemProduct = 0
            End If

            isAllowed = (oemVendor = 0) And (oemProduct = 1)
        Else
            'SHUTDOWN, NEWFRAME, NEWIMAGE
        End If

        'Return the cached state of whether the command is allowed
        Return True
        'Return isAllowed
    End Function

    Public Function Docommand(ByRef cmdLine As String) As Integer Implements IUserMethods64.Docommand

        'Early exit if the command is not allowed to run
        If Not IsCommandAllowed(cmdLine) Then
            MsgBox("ZStack is not licensed.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical)
            mm.SetMMVariable(StreamVariableAbort, True)
            Return 0
        End If

        ZStackDirectory = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\Software\IINS\ZStack", "InstallDirectory", Nothing)


        If (cmdLine = "") Then
            UserMethods64.nbr = UserMethods64.nbr + 1
            If (UserMethods64.nbr = 2) Then
                UserMethods64.nbr = UserMethods64.nbr - 1

                If Not IsNothing(MW) Then
                    MW.WindowState = FormWindowState.Normal
                    MW.Show()
                End If
            Else
                MW = New MainWindow(mm())
                MW.Show()
            End If
            mm.SetPrintMsgWindowPositionAndSize(50, 50, 350, 900)

        Else
            ' SETUP, SHUTDOWN, NEWFRAME, NEWIMAGE
            '*************************************
            '*******WT Stream emulation***********
            'If MW.isWTexist Then
            '    Dim func As Long
            '    Dim ret As Integer

            '    ret = mm.GetFunctionHandle("Run User Program", func)
            '    If (ret > 0 And func > -1) Then
            '        ret = mm.SetFunctionVariable(func, "stProgramName", "Wave_Tracer.UserMethods") '

            '        If MW.CKBX_WT.Checked Then
            '            ret = mm.SetFunctionVariable(func, "stCommandLine", cmdLine)
            '        End If
            '        ' ret = mm.SetFunctionVariable(func, 1)
            '        ret = mm.RunFunctionEx(func, 1) '1 = No user interface
            '    End If
            'End If
            '*************************************
            '*************************************
            If MW.isStackZ_streamAcq Then

                Dim currentZ As Double
                Dim stepUnit = CDbl(MW.TXTBX_unit.Text)
                Dim tabStackZ As New List(Of Double)
                Select Case cmdLine
                    Case "SETUP"
                        mm.RunJournal("C:\ZStack\soSPIM_AUTOZ0.JNL")
                        mm.PrintMsg("AutoSYNC000")
                        'currentZ = MCL_SingleReadN(3, MW.handleMCL)
                        'tabStackZ.Add(currentZ)

                    Case "NEWFRAME"

                        Thread.Sleep(MW.generalDelay)

                        currentZ = MCL_SingleReadN(3, MW.handleMCL)
                        Dim stepZ = currentZ + stepUnit
                        MCL_SingleWriteN(stepZ, 3, MW.handleMCL)

                        Thread.Sleep(MW.generalDelay)

                        currentZ = MCL_SingleReadN(3, MW.handleMCL)
                        tabStackZ.Add(currentZ)


                    Case "SHUTDOWN"
                        MW.isStackZ_streamAcq = False
                        mm.GetCurrentImage(src)
                        For z = 0 To tabStackZ.Count - 1
                            mm.SetActivePlane(src, z)
                            If z > 0 Then
                                mm.SetMMVariable("Image.Distance", stepUnit)
                            End If
                            mm.SetMMVariable("Image.ZAbsolute", tabStackZ(z))
                        Next
                        mm.RunJournal("C:\ZStack\soSPIM_AUTOZ1.JNL")
                        mm.PrintMsg("AutoSYNC111")
                End Select

            Else

                Select Case cmdLine

                    Case "NEWIMAGE"
                    '***********************************
                    'mm.RunJournal("C:\ZStack\WT_NEWIMAGE.JNL")
                    '***********************************
                    Case "SETUP"
                        '******************ZSTACK******************

                        Dim Hdl As Integer
                        Dim Points()

                        isError = False
                        Dim StrPathLog = ""
                        Dim idStrPlane = "00"
                        Dim idStrSection = "00"

                        mm.GetMMVariable("currentSection.ZTrack", currentSection)
                        mm.GetMMVariable("currentPlane.ZTrack", currentPlane)
                        mm.PrintMsg("Current Plane : " + (currentPlane).ToString() + " - Section : " + (currentSection).ToString())

                        If currentPlane > 9 Then
                            idStrPlane = "0"
                        Else
                            idStrPlane = "00"
                        End If
                        StrPathLog = MW.PathRegion + "LogFile_Z" + idStrPlane + currentPlane.ToString()


                        If MW.isSectionning Then

                            mm.GetMMVariable("currentPlane.ZTrack", currentPlane)

                            If currentSection > 9 Then
                                idStrSection = "0"
                            Else
                                idStrSection = "00"
                            End If
                            StrPathLog = StrPathLog + "_S" + idStrSection + currentSection.ToString() + ".txt"
                        Else
                            StrPathLog = StrPathLog + ".txt"
                        End If


                        If File.Exists(StrPathLog) Then
                            File.Delete(StrPathLog)
                        End If
                        sw = New StreamWriter(StrPathLog, False)


                        If MW.listRoi(currentPlane - 1).hdlROI = 0 Or currentPlane = 0 Then
                            If Not MW.isExtractionFromStack Then
                                If MW.ZStreamThread.ThreadState = ThreadState.Running Then
                                    MW.ZStreamThread.Abort()
                                    MW.BTN_StartStreamAcq.Text = "Z stream"
                                End If
                                MessageBox.Show("Error. No plane assigned or No ROI assigned for a plane.")
                            End If
                            SetAbort(True)
                            isError = True
                        End If


                        mm.RunJournal("C:\ZStack\soSPIM_AUTOZ0.JNL")
                        mm.PrintMsg("AutoSYNC000")

                    Case "NEWFRAME"
                        'mm.RunJournal("C:\ZStack\WT_NEWFRAME.JNL")

                        If Not isError Then

                            'Timer_All_1 = Microsoft.VisualBasic.DateAndTime.Timer()
                            mm.GetCurrentImage(src)
                            NumImage = GetFrameNumber() + 1
                            Dim Pk = New Process(MW, mm)

                            If NumImage = 1 Then

                                '************MM**************************
                                mm.GetCurrentImage(src)
                                mm.GetWidth(src, srcWidth)
                                mm.GetHeight(src, srcHeight)
                                '*******************************************

                                '*************Detection**********************
                                nb_planes = GetTotalFrameCount()
                                binning = CInt(MW.TXTBX_Binning.Text)
                                NbMaxPtsPerImage = CLng(CDbl(MW.listRoi(currentPlane - 1).width) * CDbl(MW.listRoi(currentPlane - 1).height) * MaxDensityPerPixel)
                                Nb_Val = NbSegParams * NbMaxPtsPerImage
                                IsGPUAcceleration = False
                                IsWatershed = False
                                WaveletThreshold = MW.listRoi(currentPlane - 1).WT
                                GaussFit = MainWindow.GaussFitSize
                                index = 0
                                'NumImage = 0
                                nbr_BeadNotFound = 0
                                ReDim Points(Nb_Val - 1)
                                cpt = 0
                                isOnebead = False
                                nbrRefBead = CInt(MW.TXTBX_ReferencesAvg.Text)
                                '********************************************

                                '*************tracking**********************
                                Decrease = 10
                                CostBirth = 0.5#
                                MaxDistance = 5
                                MinLength = 2
                                ReDim trcList(nb_planes * 2)
                                ReDim driftTab(nb_planes + 1, 18)
                                'ReDim driftTab(100, 6)
                                '*******************************************

                                If IsWatershed Then
                                    Wavelet_WatershedRatio = 0.0#
                                Else
                                    Wavelet_WatershedRatio = 10.0#
                                End If

                            End If

                            ''****************************************previous bead localization**************************************************
                            Dim ret_valPrev As Integer
                            If Not MW.isExtractionFromStack And Not MW.isExtactionBeadOnline Then

                                If (NumImage = 1 Or NumImage = nb_planes - 1) And MW.isMultiplane And currentPlane > 1 Then

                                    mm.GetMMVariable("currentPlane.ZTrack", currentPlane)
                                    Dim Nb_ValPrev = CLng(CDbl(MW.listRoi(currentPlane - 2).width) * CDbl(MW.listRoi(currentPlane - 2).height) * MaxDensityPerPixel) * NbSegParams
                                    ReDim Points(Nb_ValPrev - 1)

                                    If MW.is3DAstig Then
                                        Gauss_Fit_Calibration = 3
                                        ret_valPrev = ZStackUnsafeProcessing.Unmanaged.CPUProcessingROI(True, mm, NumImage - 1, Points, CUInt(Nb_ValPrev), CUInt(MW.listRoi(currentPlane - 2).width), CUInt(MW.listRoi(currentPlane - 2).height), CUInt(MW.listRoi(currentPlane - 2).Px), CUInt(MW.listRoi(currentPlane - 2).Py), 1, MW.listRoi(currentPlane - 2).WT, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
                                    Else
                                        Gauss_Fit_Calibration = 2
                                        ret_valPrev = ZStackUnsafeProcessing.Unmanaged.CPUProcessingROI(True, mm, NumImage - 1, Points, CUInt(Nb_ValPrev), CUInt(MW.listRoi(currentPlane - 2).width), CUInt(MW.listRoi(currentPlane - 2).height), CUInt(MW.listRoi(currentPlane - 2).Px), CUInt(MW.listRoi(currentPlane - 2).Py), 1, MW.listRoi(currentPlane - 2).WT, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit, ThetaGauss_Fit, CUShort(GaussFitSize))
                                    End If

                                    If ret_valPrev = 13 Then
                                        Dim index = 0
                                        For i = 0 To Points.Length - 1
                                            Dim a = Points(i)
                                            If a <> 0 Or a <> (-1) Then

                                                For k = 0 To Points.Length - 1
                                                    If k < NbSegParams * 2 Then
                                                        Points(k) = Points(i + k)
                                                    Else
                                                        Points(k) = 0
                                                    End If
                                                Next
                                                Exit For
                                            End If
                                        Next
                                    End If

                                    If Points(4) <> -1 And Points(3) <> -1 Then
                                        driftTab(cpt, 15) = Points(4) + MW.listRoi(currentPlane - 2).Px
                                        driftTab(cpt, 16) = Points(3) + MW.listRoi(currentPlane - 2).Py
                                    Else
                                        driftTab(cpt, 15) = 0
                                        driftTab(cpt, 16) = 0
                                    End If

                                    ReDim Points(Nb_Val - 1)
                                End If

                            End If
                            ''********************************************************************************************************************


                            ''***********************************************************
                            ''***********************************************************
                            ''***********************************************************
                            ''**************************MAIN Process*********************
                            'POINTS INIT 
                            ReDim Points(Nb_Val - 1)
                            Dim ret_val As Integer
                            If MW.is3DAstig Then
                                Gauss_Fit_Calibration = 3
                                ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessingROI(True, mm, NumImage - 1, Points, CUInt(Nb_Val), CUInt(MW.listRoi(currentPlane - 1).width), CUInt(MW.listRoi(currentPlane - 1).height), CUInt(MW.listRoi(currentPlane - 1).Px), CUInt(MW.listRoi(currentPlane - 1).Py), 1, WaveletThreshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
                            Else
                                Gauss_Fit_Calibration = 2
                                ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessingROI(True, mm, NumImage - 1, Points, CUInt(Nb_Val), CUInt(MW.listRoi(currentPlane - 1).width), CUInt(MW.listRoi(currentPlane - 1).height), CUInt(MW.listRoi(currentPlane - 1).Px), CUInt(MW.listRoi(currentPlane - 1).Py), 1, WaveletThreshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit, ThetaGauss_Fit, CUShort(GaussFitSize))
                            End If

                            If MW.is3DRegistration Then
                                Pk.AssignThreeDValuesToPoints(mm, Points, CUInt(NbMaxPtsPerImage))
                            End If

                            ''***********************************************************
                            ''***********************************************************
                            ''**************************ret_val**************************
                            If ret_val = 13 Then
                                Dim index = 0
                                For i = 0 To Points.Length - 1
                                    Dim a = Points(i)
                                    If a <> 0 Or a <> (-1) Then

                                        For k = 0 To Points.Length - 1
                                            If k < NbSegParams * 2 Then
                                                Points(k) = Points(i + k)
                                            Else
                                                Points(k) = 0
                                            End If
                                        Next
                                        Exit For
                                    End If
                                Next

                            ElseIf ret_val > 26 Then
                                If NumImage > nbrRefBead + 1 Then
                                    pointsNumberCurrentFrame = ((ret_val) / NbSegParams) - 1
                                    Dim id_detection = 0
                                    'Dim dxy0 = Math.Sqrt(Math.Pow((Points_all(NbSegParams * 2 * NumImage - 1 + 4) - Points(4)), 2) + Math.Pow((Points_all(NbSegParams * 2 * NumImage - 1 + 3) - Points(3)), 2))
                                    Dim dxy0 = Math.Sqrt(Math.Pow((MW.beadRef.CentroidX - Points(4)), 2) + Math.Pow((MW.beadRef.CentroidY - Points(3)), 2))
                                    For n = 1 To pointsNumberCurrentFrame - 1
                                        Dim dxy = Math.Sqrt(Math.Pow((MW.beadRef.CentroidX - Points(4 + n * NbSegParams)), 2) + Math.Pow((MW.beadRef.CentroidY - Points(3 + n * NbSegParams)), 2))
                                        If dxy < dxy0 Then
                                            dxy0 = dxy
                                            id_detection = n
                                        End If
                                    Next

                                    For k = 0 To Points.Length - 1
                                        If k < NbSegParams * 2 Then
                                            Points(k) = Points(id_detection * NbSegParams + k)
                                        Else
                                            Points(k) = 0
                                        End If
                                    Next

                                End If
                            End If


                            ''**************************************************************
                            ''**************************************************************
                            ''*****************Init Bead Ref information********************


                            'avec moyennage ref bead 
                            If (NumImage < (nbrRefBead + 1) And Not MW.isSectionning) Or (NumImage < (nbrRefBead + 1) And MW.isSectionning And currentSection = 1) Then
                                If (ret_val / NbSegParams) - 1 = 1 Then
                                    MW.beadRef.CentroidX = Points(4) + MW.listRoi(currentPlane - 1).Px
                                    MW.beadRef.CentroidY = Points(3) + MW.listRoi(currentPlane - 1).Py
                                    MW.beadRef.CentroidZ = Points(10)
                                    MW.beadRef.Intensity = Points(8)
                                    MW.beadRef.Surface = Points(9)
                                    MW.beadRef.SigmaX = Points(0)
                                    MW.beadRef.SigmaY = Points(1)
                                    MW.listBeadReferences.Add(MW.beadRef)

                                    driftTab(cpt, 0) = (ret_val / NbSegParams) - 1   'is retval
                                    driftTab(cpt, 1) = NumImage - 1  'plane
                                    driftTab(cpt, 2) = Points(4) + MW.listRoi(currentPlane - 1).Px  'CentroidX
                                    driftTab(cpt, 3) = Points(3) + MW.listRoi(currentPlane - 1).Py  'CentroidY
                                    driftTab(cpt, 4) = Points(10)  'CentroidZ
                                    driftTab(cpt, 5) = 0.0  'Integrated Intensity
                                    driftTab(cpt, 6) = 0.0  'sigmaX
                                    driftTab(cpt, 7) = 0.0  'SigmaY
                                    driftTab(cpt, 8) = 0.0 'sigmaGoodness
                                    driftTab(cpt, 9) = 3 'is stage displacement
                                    driftTab(cpt, 10) = 0.0 'driftX
                                    driftTab(cpt, 11) = 0.0  'driftY
                                    driftTab(cpt, 12) = 0.0  'driftZ
                                    driftTab(cpt, 13) = 0.0 'MCL X
                                    driftTab(cpt, 14) = 0.0 'MCL Y
                                    driftTab(cpt, 15) = 0.0 'curZdevice Z


                                End If
                            Else

                                If MW.listBeadReferences.Count = nbrRefBead Then

                                    ''**********************Creation reference bead******************
                                    If (NumImage = (nbrRefBead + 1) And Not MW.isSectionning) Or (NumImage = (nbrRefBead + 1) And MW.isSectionning And currentSection = 1) Then
                                        Dim avgCoord As detection_data
                                        For Each bead In MW.listBeadReferences
                                            avgCoord.CentroidX = avgCoord.CentroidX + bead.CentroidX
                                            avgCoord.CentroidY = avgCoord.CentroidY + bead.CentroidY
                                            avgCoord.CentroidZ = avgCoord.CentroidZ + bead.CentroidZ
                                            avgCoord.Intensity = avgCoord.Intensity + bead.Intensity
                                            avgCoord.Surface = avgCoord.Surface + bead.Surface
                                            avgCoord.SigmaX = avgCoord.SigmaX + bead.SigmaX
                                            avgCoord.SigmaY = avgCoord.SigmaY + bead.SigmaY
                                        Next
                                        avgCoord.CentroidX = avgCoord.CentroidX / nbrRefBead
                                        avgCoord.CentroidY = avgCoord.CentroidY / nbrRefBead
                                        avgCoord.CentroidZ = avgCoord.CentroidZ / nbrRefBead
                                        avgCoord.Intensity = avgCoord.Intensity / nbrRefBead
                                        avgCoord.Surface = avgCoord.Surface / nbrRefBead
                                        avgCoord.SigmaX = avgCoord.SigmaX / nbrRefBead
                                        avgCoord.SigmaY = avgCoord.SigmaY / nbrRefBead

                                        MW.beadRef = avgCoord
                                    End If
                                    ''**************************************************************

                                    ''***********************No bead found*************************
                                    If (ret_val / NbSegParams) - 1 = 0 Then
                                        mm.PrintMsg("Bead not found.")

                                        nbr_BeadNotFound = nbr_BeadNotFound + 1

                                        If MW.Tolerance <> 0 And nbr_BeadNotFound < 4 Then
                                            WaveletThreshold = (WaveletThreshold * MW.Tolerance) / 100
                                        End If

                                    End If
                                    ''**************************************************************



                                    ''*****************RECOVER DRIFT********************************

                                    Pk.NbMaxPtsPerImage = UserMethods64.NbMaxPtsPerImage

                                    'Si que une bille par frame 
                                    Dim drift = Pk.RegistrationOneBead(Points, MW.beadRef, MW.listRoi(currentPlane - 1).Px, MW.listRoi(currentPlane - 1).Py)
                                    '*******************************************
                                    If drift(0) <> 0 And drift(1) <> 0 Then
                                        curDrift.coordX = MW.beadRef.CentroidX - drift(0)
                                        curDrift.coordY = MW.beadRef.CentroidY - drift(1)
                                    Else
                                        curDrift.coordX = 0
                                        curDrift.coordY = 0
                                    End If

                                    Dim currentX, currentY, currentZ As Double
                                    currentX = MCL_SingleReadN(1, MW.handleMCL)
                                    currentY = MCL_SingleReadN(2, MW.handleMCL)
                                    If MW.is3DRegistration Then

                                        currentZ = MCL_SingleReadN(3, MW.handleMCL)

                                        If drift(2) <> 0 Then
                                            curDrift.coordZ = MW.beadRef.CentroidZ - drift(2)
                                        Else
                                            curDrift.coordZ = 0
                                        End If

                                    Else
                                        mm.GetMMVariable("$Device.Focus.CurPos$", currentZ)
                                        'mm.GetMMVariable("$Device.Focus.ContinuousAF.Offset$", offset)
                                    End If

                                    driftTab(cpt, 0) = (ret_val / NbSegParams) - 1   'is retval
                                    driftTab(cpt, 1) = NumImage - 1  'plane
                                    driftTab(cpt, 2) = drift(0)  'CentroidX
                                    driftTab(cpt, 3) = drift(1)  'CentroidY
                                    driftTab(cpt, 4) = drift(2)  'CentroidZ
                                    driftTab(cpt, 5) = drift(5) * drift(3) * drift(4) * 2 * Math.PI  'Integrated Intensity
                                    driftTab(cpt, 6) = drift(3)  'sigmaX
                                    driftTab(cpt, 7) = drift(4)  'SigmaY
                                    driftTab(cpt, 8) = drift(6)  'sigmaGoodness
                                    driftTab(cpt, 9) = 0 'is stage displacement
                                    driftTab(cpt, 10) = curDrift.coordX 'driftX
                                    driftTab(cpt, 11) = curDrift.coordY  'driftY
                                    driftTab(cpt, 12) = curDrift.coordZ  'driftZ
                                    driftTab(cpt, 13) = currentX 'MCL X
                                    driftTab(cpt, 14) = currentY 'MCL Y
                                    driftTab(cpt, 15) = currentZ 'curZdevice Z


                                    ReDim Points(Nb_Val - 1)




                                    ''******************************************************************
                                    ''*********************Drift registration***************************
                                    ''******************************************************************

                                    '************************ Moyennage drift **************************
                                    'ne prends pas en compte dans la moyenne si il n'a pas trouvé la bille (=drift = 0).                                  
                                    If (MW.isAcqBinning And NumImage Mod binning = 0) Or Not MW.isAcqBinning Then

                                        Dim meanX = 0.0
                                        Dim meanY = 0.0
                                        Dim meanZ = 0.0
                                        Dim slideWindow = 0
                                        Dim sumX, sumY, sumZ As Integer
                                        If MW.acq_slidewindow <> 0 Then
                                            slideWindow = MW.acq_slidewindow
                                            sumX = slideWindow
                                            sumY = slideWindow
                                            sumZ = slideWindow
                                            If slideWindow <> 0 Then
                                                If NumImage >= slideWindow Then
                                                    For i = NumImage - slideWindow To NumImage - 1
                                                        If driftTab(i, 2) = 0 Then
                                                            sumX = sumX - 1
                                                        Else
                                                            meanX = meanX + driftTab(i, 10)
                                                        End If

                                                        If driftTab(i, 3) = 0 Then
                                                            sumY = sumY - 1
                                                        Else
                                                            meanY = meanY + driftTab(i, 11)
                                                        End If
                                                        If driftTab(i, 4) = 0 Then
                                                            sumZ = sumZ - 1
                                                        Else
                                                            meanZ = meanZ + driftTab(i, 12)
                                                        End If
                                                    Next
                                                    If sumX = 0 Then
                                                        sumX = 1
                                                    ElseIf sumY = 0 Then
                                                        sumY = 1
                                                    ElseIf sumZ = 0 Then
                                                        sumZ = 1
                                                    End If
                                                    meanX = meanX / sumX
                                                    meanY = meanY / sumY
                                                    meanZ = meanZ / sumZ
                                                End If
                                            End If
                                        End If
                                        '************************Stage Discplacement***********************
                                        If MW.isStageDisplacement Then

                                            If MW.acq_slidewindow <> 0 Then
                                                If Math.Abs(meanX) > Math.Abs(MW.acq_regThreshXY) Or Math.Abs(meanY) > Math.Abs(MW.acq_regThreshXY) Then
                                                    driftTab(cpt, 9) = 1
                                                    SetPlatineShiftDrift(mm, MW.handleMCL, meanX, meanY)
                                                    ' mm.PrintMsg(" mean X < threshXY : " + Math.Abs(meanX).ToString("0.000") + " > " + Math.Abs(MW.acq_regThreshXY).ToString("0.000"))
                                                    ' mm.PrintMsg(" mean Y < threshXY : " + Math.Abs(meanY).ToString("0.000") + " > " + Math.Abs(MW.acq_regThreshXY).ToString("0.000"))
                                                End If

                                                If MW.is3DRegistration Then
                                                    If Math.Abs(meanZ) > Math.Abs(MW.acq_regThreshZ) Then
                                                        SetPlatineShiftDriftZ(mm, MW.handleMCL, meanZ)
                                                        driftTab(cpt, 9) = 1
                                                        'mm.PrintMsg(" mean Z < threshZ : " + Math.Abs(meanZ).ToString("0.000") + " > " + Math.Abs(MW.acq_regThreshXY).ToString("0.000"))
                                                    End If
                                                End If
                                            Else
                                                If Math.Abs(driftTab(cpt, 10)) > Math.Abs(MW.acq_regThreshXY) Or Math.Abs(driftTab(cpt, 11)) > Math.Abs(MW.acq_regThreshXY) Then
                                                    driftTab(cpt, 9) = 1
                                                    SetPlatineShiftDrift(mm, MW.handleMCL, driftTab(cpt, 10), driftTab(cpt, 11))
                                                    ' mm.PrintMsg(" mean X < threshXY : " + Math.Abs(driftTab(cpt, 10)).ToString("0.000") + " > " + Math.Abs(MW.acq_regThreshXY).ToString("0.000"))
                                                    'mm.PrintMsg(" mean Y < threshXY : " + Math.Abs(driftTab(cpt, 11)).ToString("0.000") + " > " + Math.Abs(MW.acq_regThreshXY).ToString("0.000"))
                                                End If

                                                If MW.is3DRegistration Then
                                                    If Math.Abs(driftTab(cpt, 12)) > Math.Abs(MW.acq_regThreshZ) Then
                                                        SetPlatineShiftDriftZ(mm, MW.handleMCL, driftTab(cpt, 12))
                                                        driftTab(cpt, 9) = 1
                                                        ' mm.PrintMsg(" mean Z < threshZ : " + Math.Abs(driftTab(cpt, 12)).ToString("0.000") + " > " + Math.Abs(MW.acq_regThreshXY).ToString("0.000"))
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                    '*******************************************************************
                                    ''******************************************************************



                                Else
                                    'sans reference valide, ne pas corriger de drift
                                    ''**************************************************************
                                    mm.PrintMsg("Bead not found for the reference. No correction will be applied for this aquisition.")
                                    MW.isRefbeadStreamGood = False
                                    'SetAbort(True)
                                    'mymm.SetMMVariable(StreamVariableTotalFrameCount, NumImage + 1)
                                    'Docommand("SHUTDOWN")
                                    isError = True
                                    ''**************************************************************
                                End If

                            End If
                            cpt = cpt + 1
                        End If


                        'Time processing
                        'Timer_All_2 = Microsoft.VisualBasic.DateAndTime.Timer()


                    Case "SHUTDOWN"

                        '***********************************
                        'mm.RunJournal("C:\ZStack\WT_SHUTDOWN.JNL")
                        '***********************************

                        'mm.PrintMsg("Time processing : " + (Timer_All_2 - Timer_All_1).ToString("0.00"))

                        If sw IsNot Nothing Then
                            Dim str = ("Width" + vbTab + "Height" + vbTab + "nb_Planes" + vbTab + "nb_Tracks" + vbTab + "Pixel_Size(um)" + vbTab + "Frame_Duration(s)" + vbTab + "Gaussian_Fit" + vbTab + "Spectral")
                            sw.WriteLine(str)
                            If MW.is3DAstig Then
                                str = (srcWidth.ToString() + vbTab + srcHeight.ToString() + vbTab + nb_planes.ToString() + vbTab + nb_planes.ToString() + vbTab + "0.108" + vbTab + "0.020" + vbTab + "X Y sigmaX sigmaY" + vbTab + "False")
                            Else
                                str = (srcWidth.ToString() + vbTab + srcHeight.ToString() + vbTab + nb_planes.ToString() + vbTab + nb_planes.ToString() + vbTab + "0.108" + vbTab + "0.020" + vbTab + "X Y sigma" + vbTab + "False")
                            End If
                            sw.WriteLine(str)
                            str = ("Track" + vbTab + "Plane" + vbTab + "CentroidX(px)" + vbTab + "CentroidY(px)" + vbTab + "CentroidZ(um)" + vbTab + "Integrated_Intensity" + vbTab + "sigmaX" + vbTab + "sigmaY" + vbTab + "sigmaGoodness" + vbTab + "isStageDisplacement" + vbTab + "driftX(pxl)" + vbTab + "driftY(pxl)" + vbTab + "driftZ(um)" + vbTab + "stageX" + vbTab + "stageY" + vbTab + "stageZ" + vbTab + "Previous_CentroidX(pxl)" + vbTab + "Previous_CentroidY(pxl)")
                            sw.WriteLine(str)
                            str = ""
                            For k = 0 To nb_planes - 1
                                For n = 0 To 18
                                    If n = 18 Then
                                        str = str + driftTab(k, n).ToString("F10")
                                    Else
                                        str = str + driftTab(k, n).ToString("F10") + vbTab
                                    End If

                                    'str = (driftTab(k, 0).ToString() + vbTab + (driftTab(k, 1).ToString() + vbTab + driftTab(k, 2).ToString() + vbTab + driftTab(k, 10).ToString() + vbTab + ((driftTab(k, 0))).ToString() + vbTab + ((driftTab(k, 1))).ToString() + vbTab + ((driftTab(k, 16))).ToString() + vbTab + driftTab(k, 17).ToString() + vbTab + driftTab(k, 3).ToString() + vbTab + driftTab(k, 4).ToString() + vbTab + driftTab(k, 13).ToString() + vbTab + driftTab(k, 5).ToString() + vbTab + driftTab(k, 6).ToString("0.000000") + vbTab + driftTab(k, 7).ToString() + vbTab + driftTab(k, 11).ToString("R") + vbTab + driftTab(k, 12).ToString("R") + vbTab + driftTab(k, 14).ToString() + vbTab + driftTab(k, 15).ToString())
                                Next
                                sw.WriteLine(str)
                                str = ""
                            Next

                            sw.Close()
                        End If

                        '''**********************************************************
                        'If MW.isSectionning Then

                        '    *******************mean*********************************
                        '    Dim meanx = 0.0
                        '    Dim meany = 0.0
                        '    Dim meanz = 0.0
                        '    Dim slidewindow = 0
                        '    Dim sumx, sumy, sumz As Integer
                        '    If MW.acq_slidewindow <> 0 Then
                        '        slidewindow = MW.acq_slidewindow
                        '        sumx = slidewindow
                        '        sumy = slidewindow
                        '        sumz = slidewindow
                        '        If slidewindow <> 0 Then
                        '            If NumImage >= slidewindow Then
                        '                For i = NumImage - slidewindow To NumImage - 1
                        '                    If driftTab(i, 2) = 0 Then
                        '                        sumx = sumx - 1
                        '                    Else
                        '                        meanx = meanx + driftTab(i, 10)
                        '                    End If

                        '                    If driftTab(i, 3) = 0 Then
                        '                        sumy = sumy - 1
                        '                    Else
                        '                        meany = meany + driftTab(i, 11)
                        '                    End If

                        '                    If driftTab(i, 4) = 0 Then
                        '                        sumz = sumz - 1
                        '                    Else
                        '                        meanz = meanz + driftTab(i, 12)
                        '                    End If
                        '                Next
                        '                If sumx = 0 Then
                        '                    sumx = 1
                        '                ElseIf sumy = 0 Then
                        '                    sumy = 1
                        '                ElseIf sumz = 0 Then
                        '                    sumz = 1
                        '                End If
                        '                curMean.coordX = meanx / sumx
                        '                curMean.coordY = meany / sumy
                        '                curMean.coordZ = meanz / sumz
                        '            End If
                        '        End If
                        '    End If

                        If Not MW.isSectionning Then
                            mm.RunJournal("C:\ZStack\soSPIM_UPDATEZPOSITION.JNL")
                            mm.PrintMsg("UPDATEZPOSITION")
                            Thread.Sleep(MW.generalDelay)
                            mm.RunJournal("C:\ZStack\soSPIM_AUTOZ1.JNL")
                            mm.PrintMsg("AutoSYNC111")
                        End If
                End Select
            End If

            '    '****************New DriftTab****************
            '    0 - retval/13 -1
            '    1 - plane 
            '    2 - X
            '    3 - Y
            '    4 - Z
            '    5 - Integrated Intensity
            '    6 - sigmaX
            '    7 - sigmaY
            '    8 - sigmaGoodness
            '    9 - stage displacement
            '   10 - driftX  'drift(0) = MW.beadRef.CentroidX - bead_end.CentroidX
            '   11 - driftY  'drift(1) = MW.beadRef.CentroidY - bead_end.CentroidY
            '   12 - driftZ  'drift(2) = MW.beadRef.CentroidZ - bead_end.CentroidZ
            '   13 - currentX
            '   14 - currentY
            '   15 - currentZ 
            '   16 - X - previous plane - bead 
            '   17 - Y - previous plane - bead 
            ''***************************************************





        End If

        Return 0
    End Function

    Public Sub Main_Ztrack(ByRef cmdline As String)



    End Sub


    Public Function Shutdown() As Integer Implements IUserMethods64.Shutdown
        '*
        Return 0
    End Function
End Class

