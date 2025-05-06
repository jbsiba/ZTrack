
Option Explicit On

Imports System.IO
Imports System.Xml
Imports System.Threading
Imports ZStackUnsafeProcessing
Imports ZStack.Process
Imports ZStackUnsafeProcessing.unmanaged
Imports Microsoft.Win32
Imports MadCity.Madlib
Imports MadCity
Imports HCS


Public Class MainWindow

    '**********Public*************
    Public MM As MMAppLib.UserCall64
    Public roiTracking As New Process.ROI_track
    Public roiWell As New Process.ROI_track
    Public beadRef As New detection_data
    Public listBeadReferences As New List(Of detection_data)
    Public Shared CalibNbr As Integer = 0
    Public PathRegion As String
    Public path3DCalib As String
    Public isStageDisplacement As Boolean
    Public isWTexist As Boolean
    Public is3DAstig As Boolean
    Public is3DRegistration As Boolean
    Public is2DRegistration As Boolean
    Public isMultiplane As Boolean
    Public isSectionning As Boolean
    Public isSinglePlane As Boolean
    Public isStackZ_streamAcq As Boolean
    Public isAcqBinning As Boolean
    Public isSingleStream As Boolean
    Public isExtractionFromStack As Boolean
    Public isExtactionBeadOnline As Boolean
    Public Tolerance As Integer
    Public listRoi As New List(Of ROI_track)
    Public handleMCL As Integer
    Public isMCLCalibrate As Boolean
    Public structdevice As Madlib.ProductInformation
    Public generalDelay As Double
    Public curCoordMCL As New Process.Coord
    Public Coordclock As New Process.Coord
    Public ZStreamThread As Thread
    Public ZStreamThreadAuto As Thread
    Public acq_slidewindow As Integer
    Public acq_regThreshXY As Double
    Public acq_regThreshZ As Double
    Public isStackZcalib3D As Boolean
    Public isRefbeadStreamGood As Boolean
    Public Shared isInvertedAxis As Boolean
    Public Shared MCL_Ref, curMean, curDrift As Coord
    Public Shared GaussFitSize As Integer
    Public Shared WT_Threshold As Double
    Public Shared DeviceMCLdirectionX, DeviceMCLdirectionY As Integer
    '*****************************

    '**********Private************
    Private PR As New Process(Me, MM)
    Private RT As New RegionTracking()
    Private CalibWindow As Calibration
    Private Gauss_Fit_Calibration As Integer = 6
    Private SigmaGauss_Fit = 1.0#
    Private ThetaGauss_Fit = 0.0#
    Private pathFocusJNL As String = ""
    Private curPlane As Integer
    Private MLCreferentiel As New Coord
    Private Multiplane_MCLOrigin As New Coord
    Private Multiplane_BeadOrigin As New detection_data
    '*****************************


    Delegate Sub InvokeDelegate()

    Sub New(ByVal _MM As MMAppLib.UserCall64)
        MM = _MM
        InitializeComponent()
    End Sub

    Private Sub MainWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '*
        isMultiplane = True
        isSinglePlane = False
        isSectionning = True
        isStageDisplacement = True
        isMCLCalibrate = False
        is3DRegistration = False
        is2DRegistration = False
        is3DAstig = False
        isWTexist = False
        isStageDisplacement = False
        isStackZ_streamAcq = False
        isAcqBinning = False
        isSingleStream = False
        isExtractionFromStack = False
        isExtactionBeadOnline = False
        isRefbeadStreamGood = True
        curPlane = 1
        'MadCity
        handleMCL = Madlib.MCL_InitHandle()
        MM.PrintMsg("hdl madcitylab : " + handleMCL.ToString())
        If handleMCL <> 0 Then
            Timer_MCL.Start()
            For c = 0 To GBX_MCL.Controls.Count - 1
                GBX_MCL.Controls.Item(c).Enabled = True
            Next
        Else
            For c = 0 To GBX_MCL.Controls.Count - 1
                GBX_MCL.Controls.Item(c).Enabled = False
            Next
            'Tabmain.TabPages.Remove(Me.TabPage5)
            'Tabmain.TabPages.Remove(Me.TabPage7)
            'Tabmain.TabPages.Remove(Me.TabPage8)
        End If

        InitFormListView()

        Tabmain.TabPages.Remove(Me.TabPage6)
        Tabmain.Refresh()

        RBTN_isMultiplane.Checked = True
        RBTN_NoDriftCorrection.Checked = True
        DeviceMCLdirectionX = 1
        DeviceMCLdirectionY = 2

    End Sub

    Private Sub MainWindow_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        UserMethods64.nbr = UserMethods64.nbr - 1
    End Sub

    Private Sub Main_Frm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        UserMethods64.nbr = UserMethods64.nbr - 1
    End Sub

    Private Sub InitFormListView()

        LW_ROIlist.View = View.Details
        LW_ROIlist.GridLines = True
        LW_ROIlist.FullRowSelect = True
        'ListView_ROIlist.Activation = ItemActivation.TwoClick
        LW_ROIlist.MultiSelect = False
        LW_ROIlist.Dock = DockStyle.Bottom

        LW_ROIlist.Columns.Add("Plane")
        LW_ROIlist.Columns.Add("Z")
        LW_ROIlist.Columns.Add("ROI")
        LW_ROIlist.Columns.Add("WT")
        LW_ROIlist.Columns.Add("Px")
        LW_ROIlist.Columns.Add("Py")


    End Sub

    Private Sub FillFormListView()


        For i = 0 To listRoi.Count - 1
            Dim roi As ROI_track
            roi = listRoi(i)
            roi.Z = i * CDbl(TXTBX_DzFocus.Text)
            listRoi(i) = roi
        Next

        LW_ROIlist.Items.Clear()

        For n = 0 To listRoi.Count - 1

            Dim listItem = LW_ROIlist.Items.Add(listRoi(n).plane.ToString())
            listItem.SubItems.Add(listRoi(n).Z.ToString())
            If listRoi(n).hdlROI <> 0 Then
                listItem.SubItems.Add("ok")
            Else
                listItem.SubItems.Add("x")
            End If
            listItem.SubItems.Add(listRoi(n).WT.ToString())
            listItem.SubItems.Add(listRoi(n).Px.ToString())
            listItem.SubItems.Add(listRoi(n).Py.ToString())

        Next

        If isMultiplane And curPlane > 0 Then
            LW_ROIlist.Items(curPlane - 1).Selected = True
            LW_ROIlist.Focus()
            LW_ROIlist.Items((curPlane) - 1).BackColor = Color.Gold
            MM.PrintMsg("curplane : " + curPlane.ToString())
        End If

    End Sub

    Public Sub DisableTabMain(ByVal disable As Integer)

        If disable = 1 Then

            For Each tabp In Tabmain.TabPages
                For c = 0 To tabp.Controls.Count - 1
                    tabp.Controls.Item(c).Enabled = False
                Next
            Next

        Else
            For Each tabp In Tabmain.TabPages
                For c = 0 To tabp.Controls.Count - 1
                    tabp.Controls.Item(c).Enabled = True
                Next
            Next

        End If


    End Sub

    Private Sub BTN_GetROI_Click(sender As System.Object, e As System.EventArgs) Handles BTN_GetROI.Click, BNT_MultiplaneGetROI.Click
        Dim hdl As Long
        Dim src As Long
        Dim ret_val As Integer
        MM.GetCurrentImage(src)
        If src <> 0 Then
            MM.GetActiveRegion(src, roiTracking.hdlROI)
            If roiTracking.hdlROI <> 0 Then
                MM.GetRegionPosition(roiTracking.hdlROI, roiTracking.Px, roiTracking.Py)
                MM.GetRegionSize(roiTracking.hdlROI, roiTracking.width, roiTracking.height)

                roiTracking.plane = curPlane
                roiTracking.WT = WT_Threshold

                Dim NbMaxPtsPerImage = CLng(CDbl(roiTracking.width) * CDbl(roiTracking.height) * MaxDensityPerPixel)
                Dim Nb_Val = NbSegParams * NbMaxPtsPerImage
                Dim Points(Nb_Val - 1) As Double

                If is3DAstig Then
                    Gauss_Fit_Calibration = 3
                    ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessingROI(False, MM, src, Points, CUInt(Nb_Val), CUInt(roiTracking.width), CUInt(roiTracking.height), CUInt(roiTracking.Px), CUInt(roiTracking.Py), 1, WT_Threshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
                Else
                    Gauss_Fit_Calibration = 2
                    ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessingROI(False, MM, src, Points, CUInt(Nb_Val), CUInt(roiTracking.width), CUInt(roiTracking.height), CUInt(roiTracking.Px), CUInt(roiTracking.Py), 1, WT_Threshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
                End If

                If is3DRegistration Then
                    PR.AssignThreeDValuesToPoints(MM, Points, CUInt(NbMaxPtsPerImage))
                End If


                If (ret_val / NbSegParams) - 1 = 1 Then
                    beadRef.CentroidX = Points(4) + roiTracking.Px
                    beadRef.CentroidY = Points(3) + roiTracking.Py

                    beadRef.CentroidZ = Points(10)
                    beadRef.Intensity = Points(8)
                    beadRef.Surface = Points(9)
                    beadRef.SigmaX = Points(0)
                    beadRef.SigmaY = Points(1)

                    MM.PrintMsg("Get ROI : CentroidX - " + beadRef.CentroidX.ToString() + " - CentroidY - " + beadRef.CentroidY.ToString() + " - CentroidZ - " + beadRef.CentroidZ.ToString())


                    If roiTracking.width <> 0 And roiTracking.height <> 0 Then

                        If isSinglePlane Then

                            'init listROI si singleplane et currentPlane
                            listRoi.Clear()
                            listRoi.Add(roiTracking)

                        ElseIf isMultiplane Then

                            If listRoi.Count = 0 Then
                                listRoi.Add(roiTracking)
                            Else
                                listRoi(curPlane - 1) = roiTracking
                            End If

                            If curPlane = 1 Then
                                Multiplane_BeadOrigin = beadRef
                                LBL_BeadOrigin.Text = "Coord O(x;y;z) :  (" + Multiplane_BeadOrigin.CentroidX.ToString() + ";" + Multiplane_BeadOrigin.CentroidY.ToString() + ";" + Multiplane_BeadOrigin.CentroidZ.ToString() + ")"
                            End If

                            FillFormListView()

                            'Configure Region saving
                            Dim hdl2 As Long
                            If PathRegion <> "" Then
                                Dim strReg = PathRegion + "ROI" + (curPlane).ToString() + ""
                                MM.GetFunctionHandle("Save Regions", hdl2)
                                MM.SetFunctionVariable(hdl2, "stFilename", strReg)
                                MM.SetFunctionVariable(hdl2, "saveImage", src)
                                MM.RunFunctionEx(hdl2, 1)
                            End If



                        End If

                    End If

                ElseIf (ret_val / NbSegParams) - 1 = 0 Then
                    beadRef.CentroidX = 0
                    beadRef.CentroidY = 0
                    MM.PrintMsg("BE CAREFUL ! - No bead found.")
                Else
                    beadRef.CentroidX = 0
                    beadRef.CentroidY = 0
                    MM.PrintMsg("BE CAREFUL ! - Several bead detected in the same ROI")
                End If


            End If

        End If

    End Sub

    Private Sub BTN_Calibration_Click(sender As System.Object, e As System.EventArgs) Handles BTN_Calibration.Click
        CalibWindow = New Calibration(MM, Me)
        CalibNbr = CalibNbr + 1
        If (CalibNbr = 2) Then
            CalibWindow.Close()
            CalibWindow.Dispose()
            CalibNbr = CalibNbr - 1
        Else
            CalibWindow.Show()
        End If
    End Sub

    Private Sub BTN_PathROI_Click(sender As System.Object, e As System.EventArgs) Handles BTN_PathROI.Click
        PathRegion = SelectFolder()
        LBL_PathROI.Text = "Path logFile :" + PathRegion
    End Sub

    ''' <summary>
    ''' Select folder recover his path
    ''' </summary>
    ''' <param name="directoryPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SelectFolder(Optional ByVal directoryPath As String = "") As String

        Dim browse As New FolderBrowserDialog
        Dim path As String = String.Empty

        With browse

            If directoryPath <> "" Then
                .SelectedPath = directoryPath
            End If

            If (.ShowDialog = Windows.Forms.DialogResult.OK) Then
                path = .SelectedPath
                path &= "\"
            End If

        End With


        Return path

    End Function

    'Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
    '    ListBox_UserPrograms.Items.Clear()

    '    Dim clsid As RegistryKey = Registry.ClassesRoot.OpenSubKey("CLSID")
    '    Dim ClsIDs() As String = clsid.GetSubKeyNames
    '    If Not clsid Is Nothing Then
    '        clsid.Close()
    '    End If

    '    Dim subkey As String = ""
    '    Dim i As Integer = 0
    '    Dim cls As RegistryKey = Nothing 'for individual subkey
    '    Dim progIdKey As RegistryKey = Nothing 'for delete key
    '    Dim progID As String = ""

    '    Do While (i < ClsIDs.Length)
    '        subkey = ClsIDs(i)
    '        cls = Registry.ClassesRoot.OpenSubKey("CLSID\" & subkey)
    '        If Not cls Is Nothing Then
    '            If subkey = "{721A09B2-CDF8-41E3-87DC-7E44216A7529}" Then
    '                'MsgBox("PALMTracer x64: " + i.ToString())
    '            End If

    '            Try
    '                Dim subkeyNames As String() = cls.GetSubKeyNames()
    '                For Each s As String In subkeyNames
    '                    If s = "ProgId" Then
    '                        progIdKey = Registry.ClassesRoot.OpenSubKey("CLSID\" & subkey & "\" & s)

    '                        Dim valueNames As String() = progIdKey.GetValueNames
    '                        For Each v As String In valueNames
    '                            progID = progIdKey.GetValue(v)
    '                            If progID.Contains(".UserMethods") Then
    '                                ListBox_UserPrograms.Items.Add(progID)
    '                            End If
    '                        Next



    '                    End If
    '                Next
    '            Catch ex As Exception
    '            End Try

    '        End If
    '        i = i + 1
    '    Loop

    '    If Not cls Is Nothing Then
    '        cls.Close()
    '    End If

    'End Sub

    'Private Sub ListBox_UserPrograms_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListBox_UserPrograms.DoubleClick
    '    Dim func As Long
    '    Dim ret As Integer

    '    ret = MM.GetFunctionHandle("Run User Program", func)
    '    If (ret > 0 And func > -1) Then
    '        ret = MM.SetFunctionVariable(func, "stProgramName", ListBox_UserPrograms.SelectedItem.ToString())

    '        If UserProgramEmulateStream_Chk.Checked Then
    '            ret = MM.SetFunctionVariable(func, "stCommandLine", UserProgramEmulateStream_ComboBox.SelectedItem.ToString())
    '        End If
    '        'ret = MM.SetFunctionVariable(func
    '        ret = MM.RunFunctionEx(func, 1) '1 = No user interface
    '    End If
    'End Sub

    Private Sub CKBX_WT_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CKBX_WT.CheckedChanged
        If CKBX_WT.Checked Then
            ListBox_UserPrograms.Items.Clear()
            Dim List_UserPrograms As New List(Of String)
            isWTexist = False
            Dim clsid As RegistryKey = Registry.ClassesRoot.OpenSubKey("CLSID")
            Dim ClsIDs() As String = clsid.GetSubKeyNames
            If Not clsid Is Nothing Then
                clsid.Close()
            End If

            Dim subkey As String = ""
            Dim i As Integer = 0
            Dim cls As RegistryKey = Nothing 'for individual subkey
            Dim progIdKey As RegistryKey = Nothing 'for delete key
            Dim progID As String = ""

            Do While (i < ClsIDs.Length)
                subkey = ClsIDs(i)
                cls = Registry.ClassesRoot.OpenSubKey("CLSID\" & subkey)
                If Not cls Is Nothing Then
                    If subkey = "{721A09B2-CDF8-41E3-87DC-7E44216A7529}" Then
                        'MsgBox("PALMTracer x64: " + i.ToString())
                    End If

                    Try
                        Dim subkeyNames As String() = cls.GetSubKeyNames()
                        For Each s As String In subkeyNames
                            If s = "ProgId" Then
                                progIdKey = Registry.ClassesRoot.OpenSubKey("CLSID\" & subkey & "\" & s)

                                Dim valueNames As String() = progIdKey.GetValueNames
                                For Each v As String In valueNames
                                    progID = progIdKey.GetValue(v)
                                    If progID.Contains(".UserMethods") Then
                                        List_UserPrograms.Add(progID)
                                        ListBox_UserPrograms.Items.Add(progID)
                                        If progID = "Wave_Tracer.UserMethods" Then
                                            isWTexist = True
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    Catch ex As Exception
                    End Try

                End If
                i = i + 1
            Loop

            If Not cls Is Nothing Then
                cls.Close()
            End If

            If Not isWTexist Then
                MessageBox.Show("WaveTracer is not installed on this computer.")
            End If


        End If
    End Sub

    Private Sub BTN_Autothreshold_Click(sender As System.Object, e As System.EventArgs) Handles BTN_Autothreshold.Click, BTN_MultiplaneAutoThresh.Click
        Dim autoThreshold = PR.AutoThreshold(MM)
        TXTBX_WT_Threshold.Text = autoThreshold.ToString()
        TXBX_Multiplane_WTThresh.Text = autoThreshold.ToString()
    End Sub

    Private Sub CKBX_3Dastig_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CKBX_3Dastig.CheckedChanged
        If CKBX_3Dastig.Checked Then
            is3DAstig = True
        Else
            is3DAstig = False
        End If
    End Sub

    Private Sub TXBX_NbrPlaneZStack_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXBX_NbrPlaneZStack.TextChanged

        Dim nbplane = CInt(TXBX_NbrPlaneZStack.Text)

        If nbplane > 1 Then

            If listRoi.Count < nbplane Then
                For i = 1 To nbplane
                    If i > listRoi.Count Then
                        Dim roi As New ROI_track
                        roi.plane = i
                        listRoi.Add(roi)
                    End If
                Next
            ElseIf listRoi.Count = nbplane Then
                '--
            Else
                listRoi.Clear()
                curPlane = 1
                For k = 1 To nbplane
                    Dim roidata As New ROI_track
                    roidata.plane = k
                    listRoi.Add(roidata)
                Next

            End If



        Else
            LW_ROIlist.Items.Clear()
        End If
        FillFormListView()

    End Sub

    Private Sub BTN_Save_Click(sender As System.Object, e As System.EventArgs) Handles BTN_Save.Click
        Dim RT As New RegionTracking()
        Dim path = RT.SelectFolder()
        If path <> Nothing Then
            Dim sw As New StreamWriter(PathRegion + "ROIlog.txt", False)
            Dim str As String
            str = "plane" + vbTab + "Z" + vbTab + "hdl" + vbTab + "WT-threshold" + vbTab + "height" + vbTab + "width" + vbTab + "Px" + vbTab + "Py"
            sw.WriteLine(str)
            For Each roi In listRoi
                str = roi.plane.ToString() + vbTab + roi.Z.ToString() + vbTab + roi.hdlROI.ToString() + vbTab + roi.WT.ToString() + vbTab + roi.height.ToString() + vbTab + roi.width.ToString() + vbTab + roi.Px.ToString() + vbTab + roi.Py.ToString()
                sw.WriteLine(str)
            Next
            sw.Close()
        End If
    End Sub

    Private Sub BTN_Load_Click(sender As System.Object, e As System.EventArgs) Handles BTN_Load.Click
        Dim RT As New RegionTracking
        Dim path = RT.SelectFile()
        If path <> Nothing Then
            Dim sr As New StreamReader(path)
            Dim str As String
            Dim ItemChar As String() = New String(8) {}
            Dim delimiterChars As Char() = {vbTab}
            listRoi.Clear()

            sr.ReadLine()
            While sr.Peek <> -1
                str = sr.ReadLine()
                ItemChar = str.Split(delimiterChars)
                Dim newRoi As ROI_track
                newRoi.plane = CInt(ItemChar(0))
                newRoi.Z = CDbl(ItemChar(1))
                newRoi.hdlROI = CLng(ItemChar(2))
                newRoi.WT = CDbl(ItemChar(3))
                newRoi.height = CInt(ItemChar(4))
                newRoi.width = CInt(ItemChar(5))
                newRoi.Px = CInt(ItemChar(6))
                newRoi.Py = CInt(ItemChar(7))


                listRoi.Add(newRoi)
            End While

            sr.Close()

            TXBX_NbrPlaneZStack.Text = listRoi.Count.ToString()

            For n = 0 To listRoi.Count - 1

                Dim listItem = LW_ROIlist.Items.Add(listRoi(n).plane.ToString())
                listItem.SubItems.Add(listRoi(n).Z.ToString())
                If listRoi(n).hdlROI <> 0 Then
                    listItem.SubItems.Add("ok")
                Else
                    listItem.SubItems.Add("x")
                End If
                listItem.SubItems.Add(listRoi(n).WT.ToString())
                listItem.SubItems.Add(listRoi(n).Px.ToString())
                listItem.SubItems.Add(listRoi(n).Py.ToString())

            Next

            If isMultiplane Then
                If curPlane <> 1 Then
                    MCL_SingleWriteN(MCL_Ref.coordZ, 3, handleMCL)
                    Coordclock.coordZ = MCL_SingleReadN(3, handleMCL)
                    MM.SetMMVariable("MadCityLab.Device.Z", Coordclock.coordZ)
                End If
                curPlane = 1
                LW_ROIlist.Items(curPlane - 1).Selected = True
                LW_ROIlist.Focus()
                LW_ROIlist.Items((curPlane) - 1).BackColor = Color.Gold
                MM.PrintMsg("curplane : " + curPlane.ToString())

            End If

        End If
    End Sub

    Private Sub BTN_CancelROIlist_Click(sender As System.Object, e As System.EventArgs) Handles BTN_CancelROIlist.Click
        Dim nbrItemSelected = LW_ROIlist.SelectedIndices.Count
        If nbrItemSelected = 1 Then
            Dim idx = LW_ROIlist.SelectedIndices(0)
            listRoi(idx) = New ROI_track
            FillFormListView()
        End If
    End Sub

    Private Sub BTN_AddROIlist_Click(sender As System.Object, e As System.EventArgs) Handles BTN_AddROIlist.Click

        TXBX_NbrPlaneZStack.Text = (CInt(TXBX_NbrPlaneZStack.Text) + 1).ToString()

    End Sub

    Private Sub BTN_StartStreamAcq_Click_1(sender As System.Object, e As System.EventArgs) Handles BTN_StartStreamAcq.Click

        'verify if all plane as a ROI
        Dim allListOk = True
        Dim is3DCalibrationOk As Boolean = True

        'LoadCalibration 3D
        If is3DRegistration Then
            is3DCalibrationOk = PR.Load3DCalibrationFile(MM, True, True)
        End If

        If Not isExtractionFromStack Then
            For Each roi In listRoi
                If roi.width = 0 Or roi.height = 0 Or roi.hdlROI = 0 Then
                    allListOk = False
                End If
            Next
        End If

        'si thread deja en cours - le stopper
        If BTN_StartStreamAcq.Text = "Stop" Then
            If ZStreamThread.ThreadState = ThreadState.Running Then
                ZStreamThread.Abort()
                BTN_StartStreamAcq.Text = "Z stream"
            End If
        Else
            If allListOk And PathRegion <> "" And is3DCalibrationOk Then 'If  And allListOk And PathRegion <> "" And is3DCalibrationOk Then
                'sinon lancer le thread principal

                'demander avec une msgbox si stream acquisition a été paramétré
                Dim result = MsgBox(" Have you launch and fill ""Stream Acquisition"" ? Do not forget to unclick ""save on image per file"". CLOSE EVERY STACK ! ", MsgBoxStyle.YesNo)

                If result = MsgBoxResult.Yes Then

                    'lancer le main thread selon le type d'acquisition : 
                    BTN_StartStreamAcq.Text = "Stop"

                    If isMultiplane Then

                        ZStreamThread = New Thread(AddressOf StreamZStack)
                        ZStreamThread.Start()

                    ElseIf isSinglePlane Then
                        MM.SetMMVariable("currentPlane.ZTrack", 1)
                        'curPlane = 1
                        If isSectionning Then
                            ZStreamThread = New Thread(AddressOf SingleStreamSectionning)
                            ZStreamThread.Start()
                        Else
                            ZStreamThread = New Thread(AddressOf SingleStream)
                            ZStreamThread.Start()
                        End If

                    End If

                    'enregistrer toutes les ROI automatiquement dans le dossier parents + la liste des ROIs. 
                    Dim sw As New StreamWriter(PathRegion + "ROIlog.txt", False)
                    Dim str As String
                    str = "plane" + vbTab + "Z" + vbTab + "hdl" + vbTab + "WT-threshold" + vbTab + "height" + vbTab + "width" + vbTab + "Px" + vbTab + "Py"
                    sw.WriteLine(str)
                    For Each roi In listRoi
                        str = roi.plane.ToString() + vbTab + roi.Z.ToString() + vbTab + roi.hdlROI.ToString() + vbTab + roi.WT.ToString() + vbTab + roi.height.ToString() + vbTab + roi.width.ToString() + vbTab + roi.Px.ToString() + vbTab + roi.Py.ToString()
                        sw.WriteLine(str)
                    Next
                    sw.Close()
                End If

            Else
                'If handleMCL = 0 Then
                '    MsgBox("MadCityLab can't be handle by ZTrack.", MsgBoxStyle.OkOnly)
                If Not allListOk Then
                    MsgBox("You have to select an ROI for EACH plane.", MsgBoxStyle.OkOnly)
                ElseIf PathRegion = "" Then
                    MsgBox("You have to select an ROI for EACH plane.", MsgBoxStyle.OkOnly)
                ElseIf Not is3DCalibrationOk Then
                    MsgBox("There is a problem with the 3D calibration", MsgBoxStyle.OkOnly)
                End If

            End If
        End If
    End Sub

    Sub StreamZStack()

        Dim nbrFrame, nbrPlane As Integer
        If isExtractionFromStack Then
            nbrPlane = listRoi.Count
        Else
            nbrPlane = CInt(TXBX_NbrPlaneZStack.Text)
        End If
        nbrFrame = CInt(TXTBX_nbrStreamFrame.Text)

        If nbrPlane > 0 Then
            For i = 0 To nbrPlane - 1

                curPlane = i + 1
                'move to the next plane - or not move if this is the first plane
                If i > 0 Then

                    MM.PrintMsg("Z step start")
                    If is3DRegistration Then
                        ZStepStageMCL(i + 1)
                    Else
                        ZStepStage()
                    End If
                    MM.PrintMsg("Z step stop")
                    Thread.Sleep(generalDelay)

                    'mettre a jour la la lightsheet 
                    MM.RunJournal("C:\ZStack\soSPIM_UPDATEZPOSITION.JNL")
                    MM.PrintMsg("UPDATEZPOSITION")
                    Thread.Sleep(generalDelay)

                End If

                'put the currentplane variable on MM
                MM.SetMMVariable("currentPlane.ZTrack", i + 1)

                If isSectionning Then
                    SingleStreamSectionning()
                Else
                    SingleStream()
                End If
            Next
        End If


        BTN_StartStreamAcq.Text = "Z stream"
    End Sub



    Sub StreamZStack_ExtractionBeadAuto()

        Dim nbrFrame, nbrPlane As Integer
        Dim srcImg As Long
        Dim ROiPlane As ROI_track
        listRoi.Clear()

        nbrPlane = CInt(TXBX_NbrPlaneZStack.Text)
        nbrFrame = CInt(TXTBX_nbrStreamFrame.Text)

        If nbrPlane > 0 Then
            For i = 0 To nbrPlane - 1

                curPlane = i + 1
                'move to the next plane - or not move if this is the first plane
                If i > 0 Then

                    Thread.Sleep(generalDelay)
                    MM.PrintMsg("Z step start")
                    If is3DRegistration Then
                        If CKBX_AxisZinverted.Checked Then
                            ZStepStageMCL(0)
                        Else
                            ZStepStageMCL(i + 1)
                        End If
                    Else
                        ZStepStage()
                    End If
                    MM.PrintMsg("Z step stop")
                    Thread.Sleep(generalDelay)

                    'mettre a jour la la lightsheet 
                    MM.RunJournal("C:\ZStack\soSPIM_UPDATEZPOSITION.JNL")
                    MM.PrintMsg("UPDATEZPOSITION")
                    Thread.Sleep(generalDelay)

                End If

                'put the currentplane variable on MM
                MM.SetMMVariable("currentPlane.ZTrack", i + 1)

                'Acquire
                MM.RunJournal("C:\ZStack\acquire.JNL")
                MM.GetCurrentImage(srcImg)


                Dim BeadPlane = PR.findBeadAutomaticPerPlane(MM, (i + 1))

                If BeadPlane.CentroidX <> 0 Then

                    'Create ROI around extracted bead
                    ROiPlane = PR.CreateROI_AutomaticBeadEx(MM, BeadPlane, (i + 1))

                    'sauvegarder la ROI dans la liste général
                    listRoi.Add(ROiPlane)

                    'Configure Region saving
                    Dim hdl2 As Long
                    If PathRegion <> "" And ROiPlane.hdlROI <> 0 Then
                        Dim strReg = PathRegion + "ROI" + ((i + 1)).ToString() + ""
                        MM.GetFunctionHandle("Save Regions", hdl2)
                        MM.SetFunctionVariable(hdl2, "stFilename", strReg)
                        MM.SetFunctionVariable(hdl2, "saveImage", PR.src)
                        MM.RunFunctionEx(hdl2, 1)
                    End If

                    'close Image acquisition
                    Dim pathImg = PathRegion + "Plane_" + (i + 1).ToString() + ".tif"
                    MM.SaveImage(srcImg, pathImg, False, 3)
                    MM.ForceCloseImage(srcImg)

                    If ROiPlane.hdlROI <> 0 Then
                        If isSectionning Then
                            SingleStreamSectionning()
                        Else
                            SingleStream()
                        End If
                    End If

                Else

                    listRoi.Add(New ROI_track)

                    MM.PrintMsg("No bead found for the plane " + (i + 1).ToString())

                    'close Image acquisition
                    Dim pathImg = PathRegion + "Plane_" + (i + 1).ToString() + ".tif"
                    MM.SaveImage(srcImg, pathImg, False, 3)
                    MM.ForceCloseImage(srcImg)
                End If

            Next

            If listRoi.Count <> 0 Then

                'remplir list mainwindow
                FillFormListView()
                'enregistrer toutes les ROI automatiquement dans le dossier parents + la liste des ROIs. 
                Dim sw As New StreamWriter(PathRegion + "ROIlog.txt", False)
                Dim str As String
                str = "plane" + vbTab + "Z" + vbTab + "hdl" + vbTab + "WT-threshold" + vbTab + "height" + vbTab + "width" + vbTab + "Px" + vbTab + "Py"
                sw.WriteLine(str)
                For Each roi In listRoi
                    str = roi.plane.ToString() + vbTab + roi.Z.ToString() + vbTab + roi.hdlROI.ToString() + vbTab + roi.WT.ToString() + vbTab + roi.height.ToString() + vbTab + roi.width.ToString() + vbTab + roi.Px.ToString() + vbTab + roi.Py.ToString()
                    sw.WriteLine(str)
                Next
                sw.Close()
            End If

        End If


        BTN_StartStreamBeadAuto.Text = "Z stream AutoBead"
    End Sub

    Sub SingleStreamSectionning()

        Dim Handle As Long = 0
        Dim nbrFrame, nbrSection, curZplane As Integer
        Dim pathSSD As String

        nbrSection = CInt(TXTBX_nbrBinning.Text)
        nbrFrame = CInt(TXTBX_StreamBinning.Text)

        If CKBX_JNL.Checked Then
            MM.RunJournal(pathFocusJNL)
        End If


        Thread.Sleep(generalDelay)

        beadRef = New detection_data

        If nbrSection > 0 Then
            For i = 0 To nbrSection - 1

                If isRefbeadStreamGood Then


                    Dim idStrPlane = "00"
                    Dim idStrSection = "00"

                    If i > 8 Then
                        idStrSection = "0"
                    Else
                        idStrSection = "00"
                    End If

                    If isMultiplane Then
                        MM.GetMMVariable("currentPlane.ZTrack", curZplane)
                        If curZplane > 9 Then
                            idStrPlane = "0"
                        Else
                            idStrPlane = "00"
                        End If
                        pathSSD = PathRegion + "Stream_Z" + idStrPlane + (curZplane).ToString() + "_S" + idStrSection + (i + 1).ToString() + ".smf"
                    Else
                        pathSSD = PathRegion + "Stream_S" + idStrSection + (i + 1).ToString() + ".smf"
                    End If



                    If Not CKBX_StreamToRAM.Checked Then
                        'Configure Stream
                        MM.GetFunctionHandle("Stream Acquisition", Handle)
                        MM.SetFunctionVariable(Handle, "nStreamFrames", nbrFrame)
                        MM.SetFunctionVariable(Handle, "bStreamRunUserPrograms", True)
                        MM.SetFunctionVariable(Handle, "stProgramNameForAcquire", "ZStack.UserMethods64")
                        MM.SetFunctionVariable(Handle, "nStreamToHardDisk", 2)
                        MM.SetFunctionVariable(Handle, "stDiskFilename", pathSSD)
                        MM.SetFunctionVariable(Handle, "bSaveDuringAcquire", True)
                        MM.SetFunctionVariable(Handle, "bOverwriteFile", True)
                        MM.SetFunctionVariable(Handle, "bPreviewShow ", True)
                        MM.SetFunctionVariable(Handle, "bStreamUsesFocusMotor", False)
                        MM.SetFunctionVariable(Handle, "bSaveOneImagePerFile ", False)
                        MM.SetFunctionVariable(Handle, "cPreviewFrameInterval", 40)
                        MM.RunFunctionEx(Handle, 1)



                        'put the currentSection variable on MM
                        MM.SetMMVariable("currentSection.ZTrack", i + 1)

                        'Begin Stream Acquisition
                        MM.GetFunctionHandle("Start Stream Acquisition", Handle)
                        MM.RunFunctionEx(Handle, 1)

                    Else

                        Dim scrStream As Long

                        MM.GetFunctionHandle("Stream Acquisition", Handle)
                        MM.SetFunctionVariable(Handle, "nStreamFrames", nbrFrame)
                        MM.SetFunctionVariable(Handle, "bStreamRunUserPrograms", True)
                        MM.SetFunctionVariable(Handle, "stProgramNameForAcquire", "ZStack.UserMethods64")
                        MM.SetFunctionVariable(Handle, "nStreamToHardDisk", 1)
                        'MM.SetFunctionVariable(Handle, "stDiskFilename", pathSSD)
                        'MM.SetFunctionVariable(Handle, "bSaveDuringAcquire", True)
                        MM.SetFunctionVariable(Handle, "bOverwriteFile", True)
                        MM.SetFunctionVariable(Handle, "bPreviewShow ", True)
                        MM.SetFunctionVariable(Handle, "bStreamUsesFocusMotor", False)
                        MM.SetFunctionVariable(Handle, "bSaveOneImagePerFile ", False)
                        MM.SetFunctionVariable(Handle, "cPreviewFrameInterval", 40)
                        MM.RunFunctionEx(Handle, 1)

                        'put the currentSection variable on MM
                        MM.SetMMVariable("currentSection.ZTrack", i + 1)

                        'Begin Stream Acquisition
                        MM.GetFunctionHandle("Start Stream Acquisition", Handle)
                        MM.RunFunctionEx(Handle, 1)
                        'MM.PrintMsg("Stream Started")
                        'MM.GetCurrentImage(scrStream)
                        MM.GetNamedImage("Stream", scrStream)
                        'MM.PrintMsg("Stream getName")
                        MM.SaveImage(scrStream, pathSSD, False, 3)
                        MM.PrintMsg("Stream savec")
                        MM.CloseImage(scrStream)

                    End If


                    'Thread.Sleep(500)
                    'moveToSectionning()
                    'Thread.Sleep(500)

                End If

            Next

            Thread.Sleep(generalDelay)

        End If

        listBeadReferences.Clear()
        isRefbeadStreamGood = True
        MM.RunJournal("C:\ZStack\soSPIM_UPDATEZPOSITION.JNL")
        MM.PrintMsg("UPDATEZPOSITION")
        Thread.Sleep(generalDelay)
        MM.RunJournal("C:\ZStack\soSPIM_AUTOZ1.JNL")
        MM.PrintMsg("AutoSYNC111")

        If isSinglePlane Then
            BTN_StartStreamAcq.Text = "Z stream"
        End If


    End Sub

    Sub SingleStream()
        Dim Handle As Long = 0
        Dim nbrFrame, curZplane As Integer
        Dim pathSSD, idStrPlane As String

        If CKBX_JNL.Checked Then
            MM.RunJournal(pathFocusJNL)
        End If

        Thread.Sleep(generalDelay)

        nbrFrame = CInt(TXTBX_nbrStreamFrame.Text)

        MM.GetMMVariable("currentPlane.ZTrack", curZplane)
        MM.SetMMVariable("currentSection.ZTrack", 1)

        If (curZplane) > 9 Then
            idStrPlane = "0"
        Else
            idStrPlane = "00"
        End If

        pathSSD = PathRegion + "Stream_Z" + idStrPlane + (curZplane).ToString() + ".smf"

        beadRef = New detection_data

        If Not CKBX_StreamToRAM.Checked Then
            'Configure Stream
            MM.GetFunctionHandle("Stream Acquisition", Handle)
            MM.SetFunctionVariable(Handle, "nStreamFrames", nbrFrame)
            MM.SetFunctionVariable(Handle, "bStreamRunUserPrograms", True)
            MM.SetFunctionVariable(Handle, "stProgramNameForAcquire", "ZStack.UserMethods64")
            MM.SetFunctionVariable(Handle, "nStreamToHardDisk", 2)
            MM.SetFunctionVariable(Handle, "stDiskFilename", pathSSD)
            MM.SetFunctionVariable(Handle, "bSaveDuringAcquire", True)
            MM.SetFunctionVariable(Handle, "bOverwriteFile", True)
            MM.SetFunctionVariable(Handle, "bPreviewShow ", True)
            MM.SetFunctionVariable(Handle, "bStreamUsesFocusMotor", False)
            MM.SetFunctionVariable(Handle, "bSaveOneImagePerFile ", False)
            MM.SetFunctionVariable(Handle, "cPreviewFrameInterval", 40)
            MM.RunFunctionEx(Handle, 1)



            'Begin Stream Acquisition
            MM.GetFunctionHandle("Start Stream Acquisition", Handle)
            MM.RunFunctionEx(Handle, 1)
        Else
            Dim scrStream As Long

            MM.GetFunctionHandle("Stream Acquisition", Handle)
            MM.SetFunctionVariable(Handle, "nStreamFrames", nbrFrame)
            MM.SetFunctionVariable(Handle, "bStreamRunUserPrograms", True)
            MM.SetFunctionVariable(Handle, "stProgramNameForAcquire", "ZStack.UserMethods64")
            MM.SetFunctionVariable(Handle, "nStreamToHardDisk", 1)
            'MM.SetFunctionVariable(Handle, "nAcqMode", 1)
            'MM.SetFunctionVariable(Handle, "stDiskFilename", pathSSD)
            'MM.SetFunctionVariable(Handle, "bSaveDuringAcquire", True)
            MM.SetFunctionVariable(Handle, "bOverwriteFile", True)
            MM.SetFunctionVariable(Handle, "bPreviewShow ", True)
            MM.SetFunctionVariable(Handle, "bStreamUsesFocusMotor", False)
            MM.SetFunctionVariable(Handle, "bSaveOneImagePerFile ", False)
            MM.SetFunctionVariable(Handle, "cPreviewFrameInterval", 40)
            MM.RunFunctionEx(Handle, 1)

            'Begin Stream Acquisition
            MM.GetFunctionHandle("Start Stream Acquisition", Handle)
            MM.RunFunctionEx(Handle, 1)

            MM.PrintMsg("Stream Started")
            'MM.GetCurrentImage(scrStream)
            MM.GetNamedImage("Stream", scrStream)
            ' MM.PrintMsg("Stream getName")
            MM.SaveImage(scrStream, pathSSD, False, 3)
            MM.PrintMsg("Stream saved")
            MM.CloseImage(scrStream)

        End If


        listBeadReferences.Clear()

        If isSinglePlane Then
            BTN_StartStreamAcq.Text = "Z stream"
        End If

        Thread.Sleep(generalDelay)

    End Sub

    Sub moveToSectionning()

        '****************Stage Discplacement****************
        'MM.PrintMsg("*****************test code**********************")
        'MM.PrintMsg("slidewindows = " + acq_slidewindow.ToString())
        'MM.PrintMsg("isStageDisplacement = " + isStageDisplacement.ToString())
        'MM.PrintMsg("acq_regThreshXY = " + acq_regThreshXY.ToString())
        'MM.PrintMsg("acq_regThreshZ = " + acq_regThreshZ.ToString())
        'MM.PrintMsg("(curMeanX - curmeanY - curMeanZ) - (driftCurrentX - driftCurrentY - driftCurrentZ) ")
        'MM.PrintMsg(curMean.coordX.ToString("0.00") + " - " + curMean.coordY.ToString("0.00") + " - " + curMean.coordZ.ToString("0.00") + " - " + curDrift.coordX.ToString("0.00") + " - " + curDrift.coordY.ToString("0.00") + " - " + curDrift.coordZ.ToString("0.00"))

        If isStageDisplacement Then

            If acq_slidewindow <> 0 Then
                If Math.Abs(curMean.coordX) > Math.Abs(acq_regThreshXY) Or Math.Abs(curMean.coordY) > Math.Abs(acq_regThreshXY) Then
                    RegionTracking.SetPlatineShiftDrift(MM, handleMCL, curMean.coordX, curMean.coordY)
                End If
                If is3DRegistration Then
                    If Math.Abs(curMean.coordZ) > Math.Abs(acq_regThreshZ) Then
                        RegionTracking.SetPlatineShiftDriftZ(MM, handleMCL, curMean.coordZ)
                    End If
                End If
            Else
                If Math.Abs(curDrift.coordX) > Math.Abs(acq_regThreshXY) Or Math.Abs(curDrift.coordY) > Math.Abs(acq_regThreshXY) Then
                    RegionTracking.SetPlatineShiftDrift(MM, handleMCL, curDrift.coordX, curDrift.coordY)
                End If
                If is3DRegistration Then
                    If Math.Abs(curDrift.coordZ) > Math.Abs(acq_regThreshZ) Then
                        RegionTracking.SetPlatineShiftDriftZ(MM, handleMCL, curDrift.coordZ)
                    End If
                End If
            End If
        End If

        '***************************************************
    End Sub

    'plane = 1 = UP 
    'plane = 0 = DOWN
    Public Sub ZStepStage(Optional ByVal plane As Integer = 1)
        Dim find As Boolean = False
        Dim status As String = ""
        Dim handleFocus As Long = 0
        Dim iniZ, Zend, dZ, curZ, precision, PFS_Zstep, curOffset As Double

        dZ = CDbl(TXTBX_DzFocus.Text)
        dZ = dZ / 1000

        '********Initialisation*********
        MM.GetFunctionHandle("Select Focus Device", handleFocus)
        MM.SetFunctionVariable(handleFocus, "stNewDev", "Ti2 Z")
        MM.RunFunctionEx(handleFocus, 1)

        MM.GetMMVariable("$Device.Focus.CurPos$", iniZ)
        If plane = 1 Then
            Zend = iniZ + dZ
        Else
            Zend = iniZ - dZ
        End If


        PFS_Zstep = CDbl(TXTBX_ZStreamStep.Text)
        precision = CDbl(TXTBX_precision.Text)
        '*******************************

        curZ = iniZ
        While (Zend - precision / 2 > curZ) Or (Zend + precision / 2 < curZ)
            If (Zend - precision / 2 > curZ) Then
                MM.GetMMVariable("$Device.Focus.ContinuousAF.Status$", status)
                If (status = "Continuous AF On: In Focus") Then
                    MM.GetMMVariable("Device.Focus.ContinuousAF.Offset", curOffset)
                    MM.SetMMVariable("Device.Focus.ContinuousAF.Offset", curOffset + PFS_Zstep)
                Else
                    MM.GetFunctionHandle("Stop Continuous Focusing", handleFocus)
                    MM.RunFunctionEx(handleFocus, 1)
                    MM.GetFunctionHandle("Start Continuous Focusing", handleFocus)
                    MM.RunFunctionEx(handleFocus, 1)
                    MM.GetMMVariable("Device.Focus.ContinuousAF.Offset", curOffset)
                    MM.SetMMVariable("Device.Focus.ContinuousAF.Offset", curOffset + PFS_Zstep)
                End If
            Else
                MM.GetMMVariable("$Device.Focus.ContinuousAF.Status$", status)
                If (status = "Continuous AF On: In Focus") Then
                    MM.GetMMVariable("Device.Focus.ContinuousAF.Offset", curOffset)
                    MM.SetMMVariable("Device.Focus.ContinuousAF.Offset", curOffset - PFS_Zstep)
                Else
                    MM.GetFunctionHandle("Stop Continuous Focusing", handleFocus)
                    MM.RunFunctionEx(handleFocus, 1)
                    MM.GetFunctionHandle("Start Continuous Focusing", handleFocus)
                    MM.RunFunctionEx(handleFocus, 1)
                    MM.GetMMVariable("Device.Focus.ContinuousAF.Offset", curOffset)
                    MM.SetMMVariable("Device.Focus.ContinuousAF.Offset", curOffset - PFS_Zstep)
                End If
            End If
            MM.GetMMVariable("$Device.Focus.CurPos$", curZ)
        End While

        'ListZlog.Add(curZ)

    End Sub


    'plane = 0 down
    'plane = -1 up
    Public Sub ZStepStageMCL_ControlPanel(ByVal plane As Integer)

        Dim newZ, dZ As Double
        dZ = CDbl(TXTBX_DzFocus.Text)

        If plane = 0 Then
            newZ = MCL_Ref.coordZ - dZ * 0.001#
        ElseIf plane = -1 Then
            newZ = MCL_Ref.coordZ + dZ * 0.001#
        Else
            If Not isExtactionBeadOnline Then
                LW_ROIlist.Focus()
                LW_ROIlist.Items((plane) - 1).BackColor = Color.Gold
            End If
            newZ = Multiplane_MCLOrigin.coordZ + (plane - 1) * dZ * 0.001#
            curPlane = plane
        End If
        MCL_Ref.coordZ = newZ

        'write Z
        MCL_SingleWriteN(newZ, 3, handleMCL)
        Coordclock.coordZ = MCL_SingleReadN(3, handleMCL)
        MM.SetMMVariable("MadCityLab.Device.Z", Coordclock.coordZ)

        MM.PrintMsg("Go to the plane n° " + curPlane.ToString())
        MM.PrintMsg("currentZ : " + newZ.ToString())

    End Sub

    'plane = 0 down
    'plane = -1 up
    Public Sub ZStepStageMCL(ByVal plane As Integer)

        Dim newZ, dZ As Double
        dZ = CDbl(TXTBX_DzFocus.Text)

        If plane = 0 Then
            newZ = MCL_Ref.coordZ - dZ * 0.001#
        Else
            newZ = MCL_Ref.coordZ + dZ * 0.001#
        End If
        MCL_Ref.coordZ = newZ

        'write Z
        MCL_SingleWriteN(newZ, 3, handleMCL)
        Coordclock.coordZ = MCL_SingleReadN(3, handleMCL)
        MM.SetMMVariable("MadCityLab.Device.Z", Coordclock.coordZ)

        MM.PrintMsg("Go to the plane n° " + curPlane.ToString())
        MM.PrintMsg("currentZ : " + newZ.ToString())

    End Sub




    Private Sub CKBX_AutoThreshPreview_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CKBX_AutoThreshPreview.CheckedChanged, CKBX_MultiPlanePreviewWT.CheckedChanged, CKBX_MultiPlanePreviewWT.CheckStateChanged
        Dim src As Long
        MM.GetCurrentImage(src)
        If sender.checked Then
            Timer_Preview.Start()
        Else

            If PR.ROIPreviewHdl_Tab IsNot Nothing And src > 0 Then
                For j = 0 To PR.ROIPreviewHdl_Tab.Length - 1
                    MM.DestroyRegion(PR.ROIPreviewHdl_Tab(j))
                Next j
            End If
            Timer_Preview.Stop()
        End If
    End Sub

    Private Sub Timer_Preview_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_Preview.Tick
        Dim src As long
        MM.GetCurrentImage(src)
        If PR.ROIPreviewHdl_Tab IsNot Nothing And src > 0 Then
            For j = 0 To PR.ROIPreviewHdl_Tab.Length - 1
                MM.DestroyRegion(PR.ROIPreviewHdl_Tab(j))
            Next j
        End If
        If WT_Threshold > 5 Then
            PR.SetThreshold(MM)
        End If
    End Sub

    Private Sub CKBX_Focus_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CKBX_JNL.CheckedChanged
        If CKBX_JNL.Checked Then
            BTN_FocusJNL.Visible = True
        Else
            BTN_FocusJNL.Visible = False
        End If
    End Sub

    Private Sub BTN_FocusJNL_Click(sender As System.Object, e As System.EventArgs) Handles BTN_FocusJNL.Click
        pathFocusJNL = RT.SelectFile()
    End Sub

    Private Sub TXTBX_nbrBinning_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTBX_nbrBinning.TextChanged
        Dim total As Integer
        If TXTBX_nbrBinning.Text <> "" And TXTBX_StreamBinning.Text <> "" Then
            total = CInt(TXTBX_StreamBinning.Text) * CInt(TXTBX_nbrBinning.Text)
        Else
            total = 0
        End If

        LBL_TotalSectionning.Text = "Total of frames : " + total.ToString()

    End Sub

    Private Sub TXTBX_StreamBinning_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTBX_StreamBinning.TextChanged
        Dim total As Integer
        If TXTBX_StreamBinning.Text <> "" And TXTBX_nbrBinning.Text <> "" Then
            total = CInt(TXTBX_StreamBinning.Text) * CInt(TXTBX_nbrBinning.Text)
        Else
            total = 0
        End If

        LBL_TotalSectionning.Text = "Total of frames : " + total.ToString()
    End Sub

    Private Sub BTN_ROIPlaneUP_Click(sender As System.Object, e As System.EventArgs) Handles BTN_ROIPlaneUP.Click

        If is3DRegistration Then
            If TXTBX_DzFocus.Text <> "" And listRoi.Count <> 0 Then
                If (curPlane - 1) - 1 >= 0 Then

                    LW_ROIlist.Items((curPlane - 1) - 1).Selected = True
                    LW_ROIlist.Focus()

                    LW_ROIlist.Items((curPlane) - 1).BackColor = Color.AliceBlue
                    curPlane = curPlane - 1
                    LW_ROIlist.Items((curPlane) - 1).BackColor = Color.Gold

                    Thread.Sleep(1000)
                    ZStepStageMCL_ControlPanel(0)
                    Thread.Sleep(1000)

                    'If listRoi(curPlane - 1).hdlROI <> 0 Then
                    '    GetROI_multiplane()
                    'End If

                End If
            End If
        Else
            If TXTBX_DzFocus.Text <> "" And TXTBX_precision.Text <> "" And TXTBX_ZStreamStep.Text <> "" And listRoi.Count <> 0 Then

                If (curPlane - 1) - 1 >= 0 Then

                    LW_ROIlist.Items((curPlane - 1) - 1).Selected = True
                    LW_ROIlist.Focus()

                    LW_ROIlist.Items((curPlane) - 1).BackColor = Color.AliceBlue
                    curPlane = curPlane - 1
                    LW_ROIlist.Items((curPlane) - 1).BackColor = Color.Gold

                    Thread.Sleep(1000)
                    ZStepStage(0)
                    Thread.Sleep(1000)

                    'If listRoi(curPlane - 1).hdlROI <> 0 Then
                    '    GetROI_multiplane()
                    'End If

                End If

            End If
        End If



    End Sub

    Private Sub BTN_ROIPlane_Down_Click(sender As System.Object, e As System.EventArgs) Handles BTN_ROIPlane_Down.Click

        If is3DRegistration Then
            If TXTBX_DzFocus.Text <> "" And listRoi.Count <> 0 Then
                If (curPlane + 1) - 1 < CInt(TXBX_NbrPlaneZStack.Text) Then
                    LW_ROIlist.Items((curPlane + 1) - 1).Selected = True
                    LW_ROIlist.Focus()
                    LW_ROIlist.Items((curPlane) - 1).BackColor = Color.AliceBlue
                    curPlane = curPlane + 1
                    LW_ROIlist.Items((curPlane) - 1).BackColor = Color.Gold
                    Thread.Sleep(500)
                    ZStepStageMCL_ControlPanel(-1)
                    Thread.Sleep(500)

                    'If listRoi(curPlane - 1).hdlROI <> 0 Then
                    '    GetROI_multiplane()
                    'End If

                End If
            End If
        Else
            If TXTBX_DzFocus.Text <> "" And TXTBX_precision.Text <> "" And TXTBX_ZStreamStep.Text <> "" And listRoi.Count <> 0 Then
                If (curPlane + 1) - 1 < CInt(TXBX_NbrPlaneZStack.Text) Then
                    LW_ROIlist.Items((curPlane + 1) - 1).Selected = True
                    LW_ROIlist.Focus()
                    LW_ROIlist.Items((curPlane) - 1).BackColor = Color.AliceBlue
                    curPlane = curPlane + 1
                    LW_ROIlist.Items((curPlane) - 1).BackColor = Color.Gold
                    Thread.Sleep(500)
                    ZStepStage(1)
                    Thread.Sleep(500)

                    'If listRoi(curPlane - 1).hdlROI <> 0 Then
                    '    GetROI_multiplane()
                    'End If

                End If
            End If
        End If
    End Sub

    Private Sub Timer_MCL_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_MCL.Tick
        If handleMCL <> 0 Then

            Coordclock.coordX = MCL_SingleReadN(DeviceMCLdirectionX, handleMCL)
            Coordclock.coordY = MCL_SingleReadN(DeviceMCLdirectionY, handleMCL)
            Coordclock.coordZ = MCL_SingleReadN(3, handleMCL)

            TXTBX_X.Text = Coordclock.coordX.ToString()
            TXTBX_Y.Text = Coordclock.coordY.ToString()
            TXTBX_Z.Text = Coordclock.coordZ.ToString()

            MM.SetMMVariable("MadCityLab.Device.Z", Coordclock.coordZ)
            MM.SetMMVariable("ciao", 2)

        End If

    End Sub

    Private Sub BTN_StageX_Up_Click(sender As System.Object, e As System.EventArgs) Handles BTN_StageX_Up.Click
        If handleMCL <> 0 Then
            Dim stepUnit = CDbl(TXTBX_unit.Text)
            curCoordMCL.coordX = MCL_SingleReadN(DeviceMCLdirectionX, handleMCL)

            'verifie qu'il peut bouger d'autant de pas. 
            Dim calibX = MCL_GetCalibration(DeviceMCLdirectionX, handleMCL)
            If stepUnit < calibX Then
                curCoordMCL.coordX = MCL_SingleWriteN(curCoordMCL.coordX + stepUnit, DeviceMCLdirectionX, handleMCL)
            Else
                MsgBox("The stage can't go this far.")
            End If

        End If
    End Sub

    Private Sub BTN_StageY_Up_Click(sender As System.Object, e As System.EventArgs) Handles BTN_StageY_Up.Click
        If handleMCL <> 0 Then
            Dim stepUnit = CDbl(TXTBX_unit.Text)
            curCoordMCL.coordY = MCL_SingleReadN(DeviceMCLdirectionY, handleMCL)

            'verifie qu'il peut bouger d'autant de pas. 
            Dim calibY = MCL_GetCalibration(DeviceMCLdirectionY, handleMCL)
            If stepUnit < calibY Then
                curCoordMCL.coordY = MCL_SingleWriteN(curCoordMCL.coordY + stepUnit, DeviceMCLdirectionY, handleMCL)
            Else
                MsgBox("The stage can't go this far.")
            End If
        End If
    End Sub

    Private Sub BTN_StageZ_Up_Click(sender As System.Object, e As System.EventArgs) Handles BTN_StageZ_Up.Click
        If handleMCL <> 0 Then
            Dim stepUnit = CDbl(TXTBX_unit.Text)
            curCoordMCL.coordZ = MCL_SingleReadN(3, handleMCL)

            'verifie qu'il peut bouger d'autant de pas. 
            Dim calibZ = MCL_GetCalibration(3, handleMCL)
            If stepUnit < calibZ Then
                curCoordMCL.coordZ = MCL_SingleWriteN(curCoordMCL.coordZ + stepUnit, 3, handleMCL)
                Coordclock.coordZ = MCL_SingleReadN(3, handleMCL)
                MM.SetMMVariable("MadCityLab.Device.Z", Coordclock.coordZ)
            Else
                MsgBox("The stage can't go this far.")
            End If
        End If
    End Sub

    Private Sub BTN_StageX_Down_Click(sender As System.Object, e As System.EventArgs) Handles BTN_StageX_Down.Click
        If handleMCL <> 0 Then
            Dim stepUnit = CDbl(TXTBX_unit.Text)
            curCoordMCL.coordX = MCL_SingleReadN(DeviceMCLdirectionX, handleMCL)

            'verifie qu'il peut bouger d'autant de pas. 
            Dim calibX = MCL_GetCalibration(DeviceMCLdirectionX, handleMCL)
            If stepUnit < calibX Then
                curCoordMCL.coordX = MCL_SingleWriteN(curCoordMCL.coordX - stepUnit, DeviceMCLdirectionX, handleMCL)
            Else
                MsgBox("The stage can't go this far.")
            End If
        End If
    End Sub

    Private Sub BTN_StageY_Down_Click(sender As System.Object, e As System.EventArgs) Handles BTN_StageY_Down.Click
        If handleMCL <> 0 Then
            Dim stepUnit = CDbl(TXTBX_unit.Text)
            curCoordMCL.coordY = MCL_SingleReadN(DeviceMCLdirectionY, handleMCL)

            'verifie qu'il peut bouger d'autant de pas. 
            Dim calibY = MCL_GetCalibration(DeviceMCLdirectionY, handleMCL)
            If stepUnit < calibY Then
                curCoordMCL.coordY = MCL_SingleWriteN(curCoordMCL.coordY - stepUnit, DeviceMCLdirectionY, handleMCL)
            Else
                MsgBox("The stage can't go this far.")
            End If
        End If
    End Sub

    Private Sub BTN_StageZ_Down_Click(sender As System.Object, e As System.EventArgs) Handles BTN_StageZ_Down.Click
        If handleMCL <> 0 Then
            Dim stepUnit = CDbl(TXTBX_unit.Text)
            curCoordMCL.coordZ = MCL_SingleReadN(3, handleMCL)

            'verifie qu'il peut bouger d'autant de pas. 
            Dim calibZ = MCL_GetCalibration(3, handleMCL)
            If stepUnit < calibZ Then
                curCoordMCL.coordZ = MCL_SingleWriteN(curCoordMCL.coordZ - stepUnit, 3, handleMCL)
                Coordclock.coordZ = MCL_SingleReadN(3, handleMCL)
                MM.SetMMVariable("MadCityLab.Device.Z", Coordclock.coordZ)
            Else
                MsgBox("The stage can't go this far.")
            End If
        End If
    End Sub

    Private Sub BTN_MCLProductInfo_Click(sender As System.Object, e As System.EventArgs) Handles BTN_MCLProductInfo.Click
        If handleMCL <> 0 Then
            Dim hdlexist = MadCity.Madlib.MCL_GetProductInfo(structdevice, handleMCL)
            Dim calibX, calibY, calibZ As Double

            MM.PrintMsg("madcitylab-struct :")
            MM.PrintMsg("  Product ID " + structdevice.Product_id.ToString())
            MM.PrintMsg("  Firmware version  : " + structdevice.FirmwareVersion.ToString())
            MM.PrintMsg("  ADC resolution : " + structdevice.ADC_resolution.ToString())
            MM.PrintMsg("  DAC resolution : " + structdevice.DAC_resolution.ToString())
            MM.PrintMsg("  Firmware Profile : " + structdevice.FirmwareProfile.ToString())
            MM.PrintMsg("  axis_bitmap : " + structdevice.axis_bitmap.ToString())
            MM.PrintMsg("")

            calibX = MCL_SingleReadN(DeviceMCLdirectionX, handleMCL)
            calibY = MCL_SingleReadN(DeviceMCLdirectionY, handleMCL)
            calibZ = MCL_SingleReadN(3, handleMCL)

            MCL_Ref.coordX = calibX
            MCL_Ref.coordY = calibY
            MCL_Ref.coordZ = calibZ
            'MCL_ref0 = calibZ

            MCL_SingleWriteN(calibX, DeviceMCLdirectionX, handleMCL)
            MCL_SingleWriteN(calibY, DeviceMCLdirectionY, handleMCL)
            MCL_SingleWriteN(calibZ, 3, handleMCL)


            Coordclock.coordZ = MCL_SingleReadN(3, handleMCL)
            MM.SetMMVariable("MadCityLab.Device.Z", Coordclock.coordZ)


            MM.PrintMsg("MCL_Ref X : " + MCL_Ref.coordX.ToString())
            MM.PrintMsg("MCL_Ref Y : " + MCL_Ref.coordY.ToString())
            MM.PrintMsg("MCL_Ref Z : " + MCL_Ref.coordZ.ToString())

            If curPlane = 1 Then

                Multiplane_MCLOrigin = MCL_Ref

                MM.PrintMsg("Multiplane_Origin X : " + Multiplane_MCLOrigin.coordX.ToString())
                MM.PrintMsg("Multiplane_Origin Y : " + Multiplane_MCLOrigin.coordY.ToString())
                MM.PrintMsg("Multiplane_Origin Z : " + Multiplane_MCLOrigin.coordZ.ToString())

            End If

        End If
    End Sub

    Private Sub BTN_MCLCalibration_Click(sender As System.Object, e As System.EventArgs) Handles BTN_MCLCalibration.Click
        If handleMCL <> 0 Then
            Dim calibX, calibY, calibZ As Double
            calibX = MCL_GetCalibration(1, handleMCL)
            calibY = MCL_GetCalibration(2, handleMCL)
            calibZ = MCL_GetCalibration(3, handleMCL)

            MM.PrintMsg("Determine how far the axis can move.")
            MM.PrintMsg("madcitylab-calibration X : " + calibX.ToString())
            MM.PrintMsg("madcitylab-calibration Y : " + calibY.ToString())
            MM.PrintMsg("madcitylab-calibration Z : " + calibZ.ToString())
            MM.PrintMsg("")
            MM.PrintMsg("Move axis X and Y to its midrange")

            'MCL_Ref.coordX = calibX * 0.5
            'MCL_Ref.coordY = calibY * 0.5
            'MCL_Ref.coordZ = calibY * 0.5

            curCoordMCL.coordX = MCL_SingleWriteN(calibX * 0.5, DeviceMCLdirectionX, handleMCL)
            curCoordMCL.coordY = MCL_SingleWriteN(calibY * 0.5, DeviceMCLdirectionY, handleMCL)
            curCoordMCL.coordZ = MCL_SingleWriteN(calibZ * 0.5, 3, handleMCL)

            Thread.Sleep(100)

            curCoordMCL.coordX = MCL_SingleReadN(DeviceMCLdirectionX, handleMCL)
            curCoordMCL.coordY = MCL_SingleReadN(DeviceMCLdirectionY, handleMCL)
            curCoordMCL.coordZ = MCL_SingleReadN(3, handleMCL)

            Coordclock.coordZ = curCoordMCL.coordZ
            MM.SetMMVariable("MadCityLab.Device.Z", Coordclock.coordZ)

            MM.PrintMsg("new-current X : " + curCoordMCL.coordX.ToString())
            MM.PrintMsg("new-current Y : " + curCoordMCL.coordY.ToString())
            MM.PrintMsg("new-current Z : " + curCoordMCL.coordZ.ToString())
            MM.PrintMsg("")

        End If
    End Sub

    Private Sub TXTBX_unit_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTBX_unit.TextChanged
        If handleMCL <> 0 Then
            If CDbl(TXTBX_unit.Text) > 10 Then
                TXTBX_unit.Text = "10"
            End If
        End If
    End Sub

    Private Sub CKBX_soSPIMFOCUS_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CKBX_soSPIMFOCUS.CheckedChanged
        If CKBX_soSPIMFOCUS.Checked Then
            '***********************************
            MM.RunJournal("C:\ZStack\soSPIM_AUTOZ1.JNL")
            '***********************************
        Else
            '***********************************
            MM.RunJournal("C:\ZStack\soSPIM_AUTOZ0.JNL")
            '***********************************
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If handleMCL <> 0 Then

            Dim sw As New StreamWriter(PathRegion + "logStairsOffsetXY.txt", False)
            Dim str As String
            Dim coordX, coordY, newcoordX, newcoordY As Double
            Dim nbrStairs = CInt(TextBox3.Text)
            Dim unitStep = CInt(TextBox2.Text)

            coordX = MCL_SingleReadN(DeviceMCLdirectionX, handleMCL)
            coordY = MCL_SingleReadN(DeviceMCLdirectionY, handleMCL)

            sw.WriteLine("X Y")

            For i = 0 To nbrStairs

                newcoordX = MCL_SingleWriteN(coordX + unitStep, DeviceMCLdirectionX, handleMCL)
                newcoordY = MCL_SingleWriteN(coordY + unitStep, DeviceMCLdirectionY, handleMCL)

                Thread.Sleep(300)

                For k = 0 To 100

                    coordX = MCL_SingleReadN(DeviceMCLdirectionX, handleMCL)
                    coordY = MCL_SingleReadN(DeviceMCLdirectionY, handleMCL)

                    sw.WriteLine(coordX.ToString() + " " + coordY.ToString())
                Next
                sw.WriteLine(" ")

            Next

            sw.Close()
        End If
    End Sub

    Private Sub RBTN_isMultiplane_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RBTN_isMultiplane.CheckedChanged

        If RBTN_isMultiplane.Checked Then

            isMultiplane = True
            Tabmain.TabPages.Remove(Me.TabPage6)
            Tabmain.TabPages.Insert(2, Me.TabPage7)
            Tabmain.Refresh()

        Else
            isMultiplane = False
            Tabmain.TabPages.Remove(Me.TabPage7)
            Tabmain.TabPages.Insert(2, Me.TabPage6)
            Tabmain.Refresh()
        End If


    End Sub

    Private Sub RBTN_isSinglePlane_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RBTN_isSinglePlane.CheckedChanged
        If RBTN_isSinglePlane.Checked Then
            isSinglePlane = True
            listRoi.Clear()
            FillFormListView()
        Else
            isSinglePlane = False
        End If
    End Sub

    Private Sub RBTN_2DDriftCorrection_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RBTN_2DDriftCorrection.CheckedChanged

        If RBTN_2DDriftCorrection.Checked Then
            If Calibration.IsCalibrationValidated Then
                is2DRegistration = True
                isStageDisplacement = True
            Else
                RBTN_NoDriftCorrection.Checked = True
                MsgBox("You need to calibrate first ! ")
            End If
        Else
            is2DRegistration = False
        End If
    End Sub

    Private Sub RBTN_3DDriftCorrection_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RBTN_3DDriftCorrection.CheckedChanged
        If RBTN_3DDriftCorrection.Checked Then

            If Calibration.IsCalibrationValidated Then

                is3DRegistration = True
                isStageDisplacement = True

                TXTBX_precision.Enabled = False
                TXTBX_ZStreamStep.Enabled = False
                GB_DriftCorrectionType.Size = New System.Drawing.Size(471, 139)
                CKBX_3Dastig.Checked = True

            Else
                RBTN_NoDriftCorrection.Checked = True
                MsgBox("You need to calibrate first ! ")
            End If

        Else
            CKBX_3Dastig.Checked = False
            is3DRegistration = False
            TXTBX_precision.Enabled = True
            TXTBX_ZStreamStep.Enabled = True
            GB_DriftCorrectionType.Size = New System.Drawing.Size(211, 139)

        End If
    End Sub

    Private Sub RBTN_NoDriftCorrection_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RBTN_NoDriftCorrection.CheckedChanged
        'If Calibration.IsCalibrationValidated Then
        If RBTN_NoDriftCorrection.Checked Then
            isStageDisplacement = False
        Else
            isStageDisplacement = True
        End If
        'Else
        '    MsgBox("You have to calibrate, or load a claibration, first !")
        '    RBTN_NoDriftCorrection.Checked = True
        'End If

    End Sub

    Private Sub listviewItemClick(sender As System.Object, e As System.EventArgs) Handles LW_ROIlist.MouseDoubleClick

        Dim row = LW_ROIlist.SelectedIndices(0)

        Dim src As Long
        MM.GetCurrentImage(src)
        MM.CreateRectRegion(src, listRoi(row).Px, listRoi(row).Py, listRoi(row).Px + listRoi(row).width, listRoi(row).Py + listRoi(row).height, listRoi(row).hdlROI)


    End Sub

    Private Sub TXTBX_DzFocus_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTBX_DzFocus.TextChanged
        FillFormListView()
    End Sub

    Private Sub RBTN_SingleStream_CheckedChanged(sender As Object, e As EventArgs) Handles RBTN_SingleStream.CheckedChanged
        If RBTN_SingleStream.Checked Then
            TXTBX_nbrStreamFrame.Enabled = True
            TXTBX_StreamBinning.Enabled = False
            TXTBX_nbrBinning.Enabled = False
            isSingleStream = True
        Else
            isSingleStream = False
        End If
    End Sub

    Private Sub RBTN_RegOnlineAcq_CheckedChanged_1(sender As Object, e As EventArgs) Handles RBTN_RegOnlineAcq.CheckedChanged
        If RBTN_RegOnlineAcq.Checked Then
            TXTBX_Binning.Enabled = False
            isAcqBinning = False
        Else
            isAcqBinning = True
        End If
    End Sub
    Private Sub RBTN_Sectionning_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RBTN_Sectionning.CheckedChanged
        If RBTN_Sectionning.Checked Then
            TXTBX_nbrStreamFrame.Enabled = False
            TXTBX_StreamBinning.Enabled = True
            TXTBX_nbrBinning.Enabled = True
            isSectionning = True
        Else
            isSectionning = False
        End If
    End Sub

    Private Sub RBTN_RegBinningAcq_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RBTN_RegBinningAcq.CheckedChanged
        If RBTN_RegBinningAcq.Checked Then
            TXTBX_Binning.Enabled = True
            isAcqBinning = True
        Else
            isAcqBinning = False
        End If
    End Sub

    Private Sub TXTBX_Multiplane_GaussianfitSize_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTBX_Multiplane_GaussianfitSize.TextChanged
        GaussFitSize = CInt(TXTBX_Multiplane_GaussianfitSize.Text)
    End Sub

    Private Sub TXTBX_GaussianFitSize_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTBX_GaussianFitSize.TextChanged
        GaussFitSize = CInt(TXTBX_GaussianFitSize.Text)
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        PR.findBeadAutomaticStack_test(MM)
    End Sub

    Private Sub TXTBX_WT_Threshold_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXTBX_WT_Threshold.TextChanged
        WT_Threshold = CDbl(TXTBX_WT_Threshold.Text)
    End Sub

    Private Sub TXBX_Multiplane_WTThresh_TextChanged(sender As System.Object, e As System.EventArgs) Handles TXBX_Multiplane_WTThresh.TextChanged, TXTBX_BeadAuto.TextChanged
        WT_Threshold = CDbl(TXBX_Multiplane_WTThresh.Text)
    End Sub

    Private Sub BTN_Load3DCalibrationFile_Click(sender As System.Object, e As System.EventArgs) Handles BTN_Load3DCalibrationFile.Click
        path3DCalib = RT.SelectFile()
        PR.Load3DCalibrationFile(MM, True, True)
    End Sub


    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click

        Dim src As Long
        MM.GetCurrentImage(src)

        Dim NbMaxPtsPerImage = CLng(CDbl(roiTracking.width) * CDbl(roiTracking.height) * MaxDensityPerPixel)
        Dim Nb_Val = NbSegParams * NbMaxPtsPerImage
        Dim Points(Nb_Val - 1) As Double
        Dim ret_val As Integer
        Dim beadDriftTest As New detection_data

        If isMultiplane Then
            roiTracking = listRoi(curPlane - 1)
        End If

        If is3DAstig Then
            Gauss_Fit_Calibration = 3
            ret_val = CPUProcessingROI(False, MM, src, Points, CUInt(Nb_Val), CUInt(roiTracking.width), CUInt(roiTracking.height), CUInt(roiTracking.Px), CUInt(roiTracking.Py), 1, WT_Threshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
        Else
            Gauss_Fit_Calibration = 2
            ret_val = CPUProcessingROI(False, MM, src, Points, CUInt(Nb_Val), CUInt(roiTracking.width), CUInt(roiTracking.height), CUInt(roiTracking.Px), CUInt(roiTracking.Py), 1, WT_Threshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
        End If

        If is3DRegistration Then
            PR.AssignThreeDValuesToPoints(MM, Points, CUInt(NbMaxPtsPerImage))
        End If


        If Points(4) <> 0 And Points(3) <> 0 Then
            beadDriftTest.CentroidX = Points(4) + roiTracking.Px
            beadDriftTest.CentroidY = Points(3) + roiTracking.Py
        Else
            beadDriftTest.CentroidX = 0
            beadDriftTest.CentroidY = 0
        End If

        beadDriftTest.CentroidZ = Points(10)
        beadDriftTest.Intensity = Points(8)
        beadDriftTest.Surface = Points(9)
        beadDriftTest.SigmaX = Points(0)
        beadDriftTest.SigmaY = Points(1)

        MM.PrintMsg("Get ROI : CentroidX - " + beadDriftTest.CentroidX.ToString() + " - CentroidY - " + beadDriftTest.CentroidY.ToString() + " - CentroidZ - " + beadDriftTest.CentroidZ.ToString())

        Dim driftX = beadRef.CentroidX - beadDriftTest.CentroidX
        Dim driftY = beadRef.CentroidY - beadDriftTest.CentroidY
        Dim driftZ = beadRef.CentroidZ - beadDriftTest.CentroidZ

        MM.PrintMsg("drift ROI : CentroidX - " + driftX.ToString() + " - CentroidY - " + driftY.ToString() + " - CentroidZ - " + driftZ.ToString())

        RegionTracking.SetPlatineShiftDrift(MM, handleMCL, driftX, driftY)
        RegionTracking.SetPlatineShiftDriftZ(MM, handleMCL, driftZ)

        MM.PrintMsg("")


    End Sub


    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click

        If isMultiplane Then
            Dim MsgResult = MsgBox(" To tests the drift correction, you have to GET_ROI first for this current plane to have a reference. clik OK if you did it, else cancel.", MsgBoxStyle.OkCancel, "important")
            If MsgResult = MsgBoxResult.Ok Then

                Dim src As Long
                MM.GetCurrentImage(src)

                Dim NbMaxPtsPerImage = CLng(CDbl(roiTracking.width) * CDbl(roiTracking.height) * MaxDensityPerPixel)
                Dim Nb_Val = NbSegParams * NbMaxPtsPerImage
                Dim Points(Nb_Val - 1) As Double
                Dim ret_val As Integer
                Dim beadDriftTest As New detection_data

                If isMultiplane Then
                    roiTracking = listRoi(curPlane - 1)
                End If


                If is3DAstig Then
                    Gauss_Fit_Calibration = 3
                    ret_val = CPUProcessingROI(False, MM, src, Points, CUInt(Nb_Val), CUInt(roiTracking.width), CUInt(roiTracking.height), CUInt(roiTracking.Px), CUInt(roiTracking.Py), 1, WT_Threshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
                Else
                    Gauss_Fit_Calibration = 2
                    ret_val = CPUProcessingROI(False, MM, src, Points, CUInt(Nb_Val), CUInt(roiTracking.width), CUInt(roiTracking.height), CUInt(roiTracking.Px), CUInt(roiTracking.Py), 1, WT_Threshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
                End If

                If is3DRegistration Then
                    PR.AssignThreeDValuesToPoints(MM, Points, CUInt(NbMaxPtsPerImage))
                End If


                If Points(4) <> 0 And Points(3) <> 0 Then
                    beadDriftTest.CentroidX = Points(4) + roiTracking.Px
                    beadDriftTest.CentroidY = Points(3) + roiTracking.Py
                Else
                    beadDriftTest.CentroidX = 0
                    beadDriftTest.CentroidY = 0
                End If

                beadDriftTest.CentroidZ = Points(10)
                beadDriftTest.Intensity = Points(8)
                beadDriftTest.Surface = Points(9)
                beadDriftTest.SigmaX = Points(0)
                beadDriftTest.SigmaY = Points(1)

                MM.PrintMsg("Get ROI : CentroidX - " + beadDriftTest.CentroidX.ToString() + " - CentroidY - " + beadDriftTest.CentroidY.ToString() + " - CentroidZ - " + beadDriftTest.CentroidZ.ToString())

                Dim driftX = beadRef.CentroidX - beadDriftTest.CentroidX
                Dim driftY = beadRef.CentroidY - beadDriftTest.CentroidY
                Dim driftZ = beadRef.CentroidZ - beadDriftTest.CentroidZ

                MM.PrintMsg("drift ROI : CentroidX - " + driftX.ToString() + " - CentroidY - " + driftY.ToString() + " - CentroidZ - " + driftZ.ToString())

                RegionTracking.SetPlatineShiftDrift(MM, handleMCL, driftX, driftY)
                RegionTracking.SetPlatineShiftDriftZ(MM, handleMCL, driftZ)

                MM.PrintMsg("")

            End If
        End If
    End Sub

    Private Sub GetROI_multiplane()
        Dim hdl As Long
        Dim src As Long
        Dim ret_val As Integer
        MM.GetCurrentImage(src)

        If isMultiplane And listRoi.Count <> 0 Then
            roiTracking = listRoi(curPlane - 1)
        End If

        If roiTracking.hdlROI <> 0 Then

            Dim NbMaxPtsPerImage = CLng(CDbl(roiTracking.width) * CDbl(roiTracking.height) * MaxDensityPerPixel)
            Dim Nb_Val = NbSegParams * NbMaxPtsPerImage
            Dim Points(Nb_Val - 1) As Double

            If is3DAstig Then
                Gauss_Fit_Calibration = 3
                ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessingROI(False, MM, src, Points, CUInt(Nb_Val), CUInt(roiTracking.width), CUInt(roiTracking.height), CUInt(roiTracking.Px), CUInt(roiTracking.Py), 1, WT_Threshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
            Else
                Gauss_Fit_Calibration = 2
                ret_val = ZStackUnsafeProcessing.Unmanaged.CPUProcessingROI(False, MM, src, Points, CUInt(Nb_Val), CUInt(roiTracking.width), CUInt(roiTracking.height), CUInt(roiTracking.Px), CUInt(roiTracking.Py), 1, WT_Threshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
            End If

            If is3DRegistration Then
                PR.AssignThreeDValuesToPoints(MM, Points, CUInt(NbMaxPtsPerImage))
            End If


            If Points(4) <> 0 And Points(3) <> 0 Then
                beadRef.CentroidX = Points(4) + roiTracking.Px
                beadRef.CentroidY = Points(3) + roiTracking.Py
            Else
                beadRef.CentroidX = 0
                beadRef.CentroidY = 0
            End If
            beadRef.CentroidZ = Points(10)
            beadRef.Intensity = Points(8)
            beadRef.Surface = Points(9)
            beadRef.SigmaX = Points(0)
            beadRef.SigmaY = Points(1)

            MM.PrintMsg("Get ROI : CentroidX - " + beadRef.CentroidX.ToString() + " - CentroidY - " + beadRef.CentroidY.ToString() + " - CentroidZ - " + beadRef.CentroidZ.ToString())

        End If


    End Sub


    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Dim func As Long
        Dim ret As Integer

        ret = MM.GetFunctionHandle("Run User Program", func)
        If (ret > 0 And func > -1) Then
            ret = MM.SetFunctionVariable(func, "stProgramName", "PALMTracer.UserMethods64") 'Wave_Tracer.UserMethods

            If CKBX_WT.Checked Then
                ret = MM.SetFunctionVariable(func, "stCommandLine", "reset")
            End If
            'ret = MM.SetFunctionVariable(func
            ret = MM.RunFunctionEx(func, 1) '1 = No user interface
        End If
    End Sub

    Private Sub TXTBX_slideWindow_TextChanged(sender As Object, e As EventArgs) Handles TXTBX_slideWindow.TextChanged
        If isAcqBinning Then
            If TXTBX_slideWindow.Text < TXTBX_Binning.Text Then
                acq_slidewindow = CInt(TXTBX_slideWindow.Text)
            Else
                acq_slidewindow = 0
            End If
        Else
            acq_slidewindow = CInt(TXTBX_slideWindow.Text)
        End If

    End Sub


    Private Sub NUD__regThreshXY_Min_ValueChanged(sender As Object, e As EventArgs) Handles NUD__regThreshXY_Min.ValueChanged
        Dim Calibration_XY As Double
        If Calibration.IsCalibrationValidated Then
            'Dim n = MM.GetMMVariable("CoefficientCalibrationumPxl", Calibration_XY)
            'If n = 1 Then
            Calibration_XY = CDbl(TXTBX_CalibrationXYumpxl.Text)
            If Calibration_XY <> 0.0 Then
                If Math.Floor(CDbl(NUD__regThreshXY_Min.Value) / Calibration_XY) > 0.5 Then
                    acq_regThreshXY = Math.Floor(CDbl(NUD__regThreshXY_Min.Value) / Calibration_XY)
                    'acq_regThreshXY = CDbl(NUD__regThreshXY_Min.Value) / Calibration_XY
                Else
                    acq_regThreshXY = 0.5
            End If
        Else
            acq_regThreshXY = 0.5
            End If
        End If
    End Sub

    Private Sub NUD_TXTBX_regThreshZ_Min_ValueChanged(sender As Object, e As EventArgs) Handles NUD_TXTBX_regThreshZ_Min.ValueChanged
        'If NUD_TXTBX_regThreshZ_Min.Value > 0.05 Then
        acq_regThreshZ = CDbl(NUD_TXTBX_regThreshZ_Min.Value)
        'Else
        '    acq_regThreshZ = 0.05
        'End If
    End Sub


    Private Sub BTN_StackZ_Click(sender As Object, e As EventArgs) Handles BTN_StackZAcqu.Click

        If BTN_StackZAcqu.Text = "Stop Aquire" Then
            BTN_StackZAcqu.Text = "Stack Z - Acquire*"
            'revenir a la reference
            curCoordMCL.coordZ = MCL_SingleWriteN(MCL_Ref.coordZ, 3, handleMCL)
        Else
            If handleMCL <> 0 Then
                Dim hdl = 0
                Dim src As Long
                Dim tabZ As New List(Of Double)
                Dim stepUnit = CDbl(TXTBX_unit.Text)
                curCoordMCL.coordZ = MCL_SingleReadN(3, handleMCL)
                Dim finstack = curCoordMCL.coordZ


                If CInt(TXTBX_StackZnbrStep.Text) <> 0 Then
                    BTN_StackZAcqu.Text = "Stop Aquire"
                End If


                'step by step faire une capture et créer un stack jusuq'en haut
                For i = 0 To CInt(TXTBX_StackZnbrStep.Text) - 1

                    'Thread.Sleep(generalDelay)
                    If CKBX_AxisZinverted.Checked Then
                        MCL_SingleWriteN(MCL_Ref.coordZ - stepUnit * i, 3, handleMCL)
                    Else
                        MCL_SingleWriteN(MCL_Ref.coordZ + stepUnit * i, 3, handleMCL)
                    End If

                    curCoordMCL.coordZ = MCL_SingleReadN(3, handleMCL)
                    tabZ.Add(curCoordMCL.coordZ)

                    Thread.Sleep(generalDelay)

                    'mettre a jour la la lightsheet 
                    MM.RunJournal("C:\ZStack\soSPIM_UPDATEZPOSITION.JNL")

                    Thread.Sleep(generalDelay)
                    'Acquire
                    MM.RunJournal("C:\ZStack\acquire.JNL")


                Next

                'revenir au milieu du stack
                curCoordMCL.coordZ = MCL_SingleWriteN(finstack, 3, handleMCL)

                MM.GetCurrentImage(src)
                For z = 0 To tabZ.Count - 1
                    MM.SetActivePlane(src, z)
                    If z > 0 Then
                        MM.SetMMVariable("Image.Distance", stepUnit)
                    End If
                    MM.SetMMVariable("Image.ZAbsolute", tabZ(z))
                Next

                BTN_StackZAcqu.Text = "Stack Z - Acquire*"
            End If
        End If


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        'Dim src As Long
        'Dim strAnnotation As String = ""
        'MM.GetCurrentImage(src)
        'MM.GetImageAnnotation(src, 2, strAnnotation)
        'Dim a = 0
        ''Acquire
        MM.RunJournal("C:\ZStack\acquire.JNL")
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        'Acquire
        Dim hdl As Long = 0
        MM.GetFunctionHandle("Snap", hdl)
        MM.RunFunctionEx(hdl, 1)
    End Sub

    'Private Sub BTN_StackZStream_Click(sender As Object, e As EventArgs)
    '    If handleMCL <> 0 Then
    '        Dim hdl = 0
    '        Dim nbrstep = CInt(TXTBX_StackZnbrStep.Text) / 2
    '        Dim stepUnit = CDbl(TXTBX_unit.Text)
    '        Dim middleStackZ = MCL_SingleReadN(3, handleMCL)
    '        curCoordMCL.coordZ = MCL_SingleReadN(3, handleMCL)

    '        'aller en bas du stack
    '        Dim bottomZ = curCoordMCL.coordZ - (stepUnit * nbrstep)
    '        curCoordMCL.coordZ = MCL_SingleWriteN(bottomZ, 3, handleMCL)

    '        'lancer le stream Acq
    '        'Configure Stream
    '        MM.RunJournal("C:\ZStack\StreamStackZ.JNL")

    '        Thread.Sleep(500)
    '        'step by step bouger la platine MCL
    '        For i = 1 To CInt(TXTBX_StackZnbrStep.Text)
    '            curCoordMCL.coordZ = MCL_SingleReadN(3, handleMCL)
    '            curCoordMCL.coordZ = MCL_SingleWriteN(curCoordMCL.coordZ + stepUnit, 3, handleMCL)

    '            Thread.Sleep(100)
    '        Next

    '        'revenir au milieu du stack
    '        curCoordMCL.coordZ = MCL_SingleWriteN(middleStackZ, 3, handleMCL)

    '    End If
    'End Sub

    Private Sub BTN_StackZStream_Click_1(sender As Object, e As EventArgs) Handles BTN_StackZStream.Click

        If handleMCL <> 0 Then
            isStackZ_streamAcq = True
            Dim handle As Long = 0
            Dim stepUnit = CDbl(TXTBX_unit.Text)
            Dim finstack = MCL_SingleReadN(3, handleMCL)

            'aller en bas du stack

            'Dim currentZ = MCL_SingleReadN(3, handleMCL)
            'Dim bottomZ = currentZ - (stepUnit * (CInt(TXTBX_StackZnbrStep.Text) / 2))
            'MCL_SingleWriteN(bottomZ, 3, handleMCL)

            Thread.Sleep(generalDelay)

            Dim nbrFrame = CInt(TXTBX_StackZnbrStep.Text)
            'Dim pathSSD = PathRegion + "StackZ-3D.tif"
            'Configure Stream
            MM.GetFunctionHandle("Stream Acquisition", handle)
            MM.SetFunctionVariable(handle, "nStreamFrames", nbrFrame)
            MM.SetFunctionVariable(handle, "bStreamRunUserPrograms", True)
            MM.SetFunctionVariable(handle, "stProgramNameForAcquire", "ZStack.UserMethods64")
            MM.SetFunctionVariable(handle, "nStreamToHardDisk", 1)
            'MM.SetFunctionVariable(handle, "stDiskFilename", pathSSD)
            MM.SetFunctionVariable(handle, "bSaveDuringAcquire", True)
            MM.SetFunctionVariable(handle, "bOverwriteFile", True)
            MM.SetFunctionVariable(handle, "bPreviewShow ", True)
            MM.SetFunctionVariable(handle, "bStreamUsesFocusMotor", False)
            MM.SetFunctionVariable(handle, "bSaveOneImagePerFile ", False)
            MM.SetFunctionVariable(handle, "cPreviewFrameInterval", 5)
            MM.RunFunctionEx(handle, 1)

            Thread.Sleep(generalDelay)

            'Begin Stream Acquisition
            MM.GetFunctionHandle("Start Stream Acquisition", handle)
            MM.RunFunctionEx(handle, 1)

            Thread.Sleep(generalDelay)

            'revenir au milieu du stack
            MCL_SingleWriteN(finstack, 3, handleMCL)


        End If

    End Sub


    Private Sub Button12_Click(sender As Object, e As EventArgs)
        Dim handle As Long = 0
        Dim nbrFrame = CInt(TXTBX_StackZnbrStep.Text)
        Dim pathSSD = PathRegion + "StackZ-3D.tif"
        isStackZ_streamAcq = True
        'Configure Stream
        MM.GetFunctionHandle("Stream Acquisition", handle)
        MM.SetFunctionVariable(handle, "nStreamFrames", nbrFrame)
        MM.SetFunctionVariable(handle, "bStreamRunUserPrograms", True)
        MM.SetFunctionVariable(handle, "stProgramNameForAcquire", "ZStack.UserMethods64")
        MM.SetFunctionVariable(handle, "nStreamToHardDisk", 1)
        'MM.SetFunctionVariable(Handle, "stDiskFilename", pathSSD)
        MM.SetFunctionVariable(handle, "bSaveDuringAcquire", True)
        MM.SetFunctionVariable(handle, "bOverwriteFile", True)
        MM.SetFunctionVariable(handle, "bPreviewShow ", True)
        MM.SetFunctionVariable(handle, "bStreamUsesFocusMotor", False)
        MM.SetFunctionVariable(handle, "bSaveOneImagePerFile ", False)
        MM.SetFunctionVariable(handle, "cPreviewFrameInterval", 5)
        MM.RunFunctionEx(handle, 1)

        Thread.Sleep(200)

        'Begin Stream Acquisition
        MM.GetFunctionHandle("Start Stream Acquisition", handle)
        MM.RunFunctionEx(handle, 1)

    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        If handleMCL <> 0 Then
            'isStackZ_streamAcq = True
            Dim handle As Long = 0
            Dim stepUnit = CDbl(TXTBX_unit.Text)

            'aller en bas du stack

            Dim middleStackZ = MCL_SingleReadN(3, handleMCL)
            Dim bottomZ = middleStackZ - (stepUnit * (CInt(TXTBX_StackZnbrStep.Text) / 2))
            MCL_SingleWriteN(bottomZ, 3, handleMCL)

            Thread.Sleep(500)

            Dim nbrFrame = CInt(TXTBX_StackZnbrStep.Text)
            'Dim pathSSD = PathRegion + "StackZ-3D.tif"
            'Configure Stream
            MM.GetFunctionHandle("Stream Acquisition", handle)
            MM.SetFunctionVariable(handle, "nStreamFrames", nbrFrame)
            MM.SetFunctionVariable(handle, "bStreamRunUserPrograms", True)
            MM.SetFunctionVariable(handle, "stProgramNameForAcquire", "ZStack.UserMethods64")
            MM.SetFunctionVariable(handle, "nStreamToHardDisk", 1)
            'MM.SetFunctionVariable(handle, "stDiskFilename", pathSSD)
            MM.SetFunctionVariable(handle, "bSaveDuringAcquire", True)
            MM.SetFunctionVariable(handle, "bOverwriteFile", True)
            MM.SetFunctionVariable(handle, "bPreviewShow ", True)
            MM.SetFunctionVariable(handle, "bStreamUsesFocusMotor", False)
            MM.SetFunctionVariable(handle, "bSaveOneImagePerFile ", False)
            MM.SetFunctionVariable(handle, "cPreviewFrameInterval", 5)
            MM.RunFunctionEx(handle, 1)

            Thread.Sleep(200)

            'Begin Stream Acquisition
            MM.GetFunctionHandle("Start Stream Acquisition", handle)
            MM.RunFunctionEx(handle, 1)

            Thread.Sleep(500)

            'revenir au milieu du stack
            MCL_SingleWriteN(middleStackZ, 3, handleMCL)

        End If
    End Sub

    Private Sub BTN_GoToPlane_Click(sender As Object, e As EventArgs) Handles BTN_GoToPlane.Click
        If isMultiplane And is3DRegistration Then
            If TXTBX_DzFocus.Text <> "" Then
                LW_ROIlist.Items((curPlane) - 1).BackColor = Color.AliceBlue
                Dim plane = LW_ROIlist.SelectedIndices(0) + 1
                ZStepStageMCL_ControlPanel(plane)

                'If listRoi(curPlane - 1).hdlROI <> 0 Then
                '    GetROI_multiplane()
                'End If

            End If
        End If
    End Sub

    Private Sub Button13_Click_1(sender As Object, e As EventArgs) Handles Button13.Click
        PR.findBeadAutomaticPerPlane(MM, 1)
    End Sub

    Private Sub BTN_GetROI_well_Click(sender As Object, e As EventArgs) Handles BTN_GetROI_well.Click

        Dim src As Long
        MM.GetCurrentImage(src)
        MM.GetActiveRegion(src, roiWell.hdlROI)
        MM.GetRegionPosition(roiWell.hdlROI, roiWell.Px, roiWell.Py)
        MM.GetRegionSize(roiWell.hdlROI, roiWell.width, roiWell.height)

        If roiWell.hdlROI = 0 Then
            MsgBox("Create a ROI around the well to extract bead only in the polymer.", MsgBoxStyle.OkOnly)
        Else
            MM.PrintMsg("Get ROI Well - hdl : " + roiWell.hdlROI.ToString())
        End If
    End Sub

    Private Sub CKBX_FindBeadStack_CheckedChanged(sender As Object, e As EventArgs) Handles CKBX_FindBeadStack.CheckedChanged
        If CKBX_FindBeadStack.Checked Then
            If roiWell.hdlROI = 0 Then
                MsgBox("Create a ROI around the well to extract bead only in the polymer.", MsgBoxStyle.OkOnly)
                CKBX_FindBeadStack.CheckState = False
            Else
                isExtractionFromStack = True
                BTN_StackBeadAutoExtration.Enabled = True
                CKBX_FindBeadAutoPlane.CheckState = False
            End If
        Else
            isExtractionFromStack = False
            BTN_StackBeadAutoExtration.Enabled = False
        End If
    End Sub

    Private Sub CKBX_FindBeadAutoPlane_CheckedChanged(sender As Object, e As EventArgs) Handles CKBX_FindBeadAutoPlane.CheckedChanged

        If CKBX_FindBeadAutoPlane.Checked Then
            If roiWell.hdlROI = 0 Then
                MsgBox("Create a ROI around the well to extract bead only in the polymer.", MsgBoxStyle.OkOnly)
                CKBX_FindBeadAutoPlane.CheckState = False
            Else
                isExtactionBeadOnline = True
                BTN_StartStreamBeadAuto.Visible = True
                BTN_StartStreamAcq.Visible = False
                CKBX_FindBeadStack.CheckState = False
            End If
        Else
            isExtactionBeadOnline = False
            'BTN_StartStreamBeadAuto.Enabled = False
            BTN_StartStreamBeadAuto.Visible = False
            BTN_StartStreamAcq.Visible = True
        End If
    End Sub

    Private Sub BTN_StackBeadAutoExtration_Click(sender As Object, e As EventArgs) Handles BTN_StackBeadAutoExtration.Click


        Dim cpt = 0
        Dim listBeadStack = PR.findBeadAutomaticStack(MM)
        listRoi.Clear()

        For Each beadPlane In listBeadStack
            If beadPlane.CentroidX <> 0 Then
                Dim roiPlane = PR.CreateROI_AutomaticBeadEx(MM, beadPlane, cpt + 1)

                If roiPlane.hdlROI <> 0 Then
                    listRoi.Add(roiPlane)
                    If cpt = 0 Then
                        Multiplane_BeadOrigin = beadPlane
                        LBL_BeadOrigin.Text = "Coord O(x;y;z) :  (" + Multiplane_BeadOrigin.CentroidX.ToString() + ";" + Multiplane_BeadOrigin.CentroidY.ToString() + ";" + Multiplane_BeadOrigin.CentroidZ.ToString() + ")"
                    End If
                Else
                    listRoi.Add(New ROI_track)
                End If
            Else
                listRoi.Add(New ROI_track)
            End If
            cpt = cpt + 1
        Next

        TXTBX_DzFocus.Text = (CDbl(TXTBX_unit.Text) * 1000).ToString()

        FillFormListView()


    End Sub



    Private Sub BTN_StartStreamBeadAuto_Click(sender As Object, e As EventArgs) Handles BTN_StartStreamBeadAuto.Click

        'verify if all plane as a ROI
        Dim is3DCalibrationOk As Boolean = True

        'LoadCalibration 3D
        If is3DRegistration Then
            is3DCalibrationOk = PR.Load3DCalibrationFile(MM, True, True)
        End If

        'si thread deja en cours - le stopper
        If BTN_StartStreamBeadAuto.Text = "Stop AutoBead" Then
            If ZStreamThreadAuto.ThreadState = ThreadState.Running Then
                ZStreamThreadAuto.Abort()
                BTN_StartStreamBeadAuto.Text = "Z stream AutoBead"
            End If
        Else
            If isExtactionBeadOnline Then
                If PathRegion <> "" And is3DCalibrationOk And roiWell.hdlROI <> 0 Then 'If  And allListOk And PathRegion <> "" And is3DCalibrationOk Then
                    'sinon lancer le thread principal

                    'demander avec une msgbox si stream acquisition a été paramétré
                    Dim result = MsgBox(" Have you launch and fill ""Stream Acquisition"" ? Do not forget to unclick ""save on image per file"". CLOSE EVERY STACK ! ", MsgBoxStyle.YesNo)

                    If result = MsgBoxResult.Yes Then

                        'lancer le main thread selon le type d'acquisition : 
                        BTN_StartStreamBeadAuto.Text = "Stop AutoBead"

                        If isMultiplane Then

                            ZStreamThreadAuto = New Thread(AddressOf StreamZStack_ExtractionBeadAuto)
                            ZStreamThreadAuto.Start()

                        End If

                    End If

                Else

                    If PathRegion = "" Then
                        MsgBox("You have to select a directery folder.", MsgBoxStyle.OkOnly)
                    ElseIf Not is3DCalibrationOk Then
                        MsgBox("There is a problem with the 3D calibration", MsgBoxStyle.OkOnly)
                    ElseIf roiWell.hdlROI = 0 Then
                        MsgBox("You have to create a ROI around the well to extract bead only in the polymer.", MsgBoxStyle.OkOnly)
                    End If

                End If
            End If
        End If

    End Sub

    Private Sub TXTBX_DelayStackZ_TextChanged(sender As Object, e As EventArgs) Handles TXTBX_DelayStackZ.TextChanged
        generalDelay = CDbl(TXTBX_DelayStackZ.Text)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If isMultiplane And curPlane = 1 Then


            If Multiplane_BeadOrigin.CentroidX <> 0 Then

                Dim src As Long
                MM.GetCurrentImage(src)

                Dim NbMaxPtsPerImage = CLng(CDbl(roiTracking.width) * CDbl(roiTracking.height) * MaxDensityPerPixel)
                Dim Nb_Val = NbSegParams * NbMaxPtsPerImage
                Dim Points(Nb_Val - 1) As Double
                Dim ret_val As Integer
                Dim beadDriftTest As New detection_data

                If isMultiplane Then
                    roiTracking = listRoi(curPlane - 1)
                End If


                If is3DAstig Then
                    Gauss_Fit_Calibration = 3
                    ret_val = CPUProcessingROI(False, MM, src, Points, CUInt(Nb_Val), CUInt(roiTracking.width), CUInt(roiTracking.height), CUInt(roiTracking.Px), CUInt(roiTracking.Py), 1, WT_Threshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
                Else
                    Gauss_Fit_Calibration = 2
                    ret_val = CPUProcessingROI(False, MM, src, Points, CUInt(Nb_Val), CUInt(roiTracking.width), CUInt(roiTracking.height), CUInt(roiTracking.Px), CUInt(roiTracking.Py), 1, WT_Threshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(GaussFitSize))
                End If

                If is3DRegistration Then
                    PR.AssignThreeDValuesToPoints(MM, Points, CUInt(NbMaxPtsPerImage))
                End If


                If Points(4) <> 0 And Points(3) <> 0 Then
                    beadDriftTest.CentroidX = Points(4) + roiTracking.Px
                    beadDriftTest.CentroidY = Points(3) + roiTracking.Py
                Else
                    beadDriftTest.CentroidX = 0
                    beadDriftTest.CentroidY = 0
                End If

                beadDriftTest.CentroidZ = Points(10)
                beadDriftTest.Intensity = Points(8)
                beadDriftTest.Surface = Points(9)
                beadDriftTest.SigmaX = Points(0)
                beadDriftTest.SigmaY = Points(1)

                MM.PrintMsg("Get ROI : CentroidX - " + beadDriftTest.CentroidX.ToString() + " - CentroidY - " + beadDriftTest.CentroidY.ToString() + " - CentroidZ - " + beadDriftTest.CentroidZ.ToString())

                Dim driftX = beadRef.CentroidX - beadDriftTest.CentroidX
                Dim driftY = beadRef.CentroidY - beadDriftTest.CentroidY
                Dim driftZ = beadRef.CentroidZ - beadDriftTest.CentroidZ

                MM.PrintMsg("drift ROI : CentroidX - " + driftX.ToString() + " - CentroidY - " + driftY.ToString() + " - CentroidZ - " + driftZ.ToString())

                RegionTracking.SetPlatineShiftDrift(MM, handleMCL, driftX, driftY)
                RegionTracking.SetPlatineShiftDriftZ(MM, handleMCL, driftZ)

                MM.PrintMsg("")
            End If
        End If
    End Sub

    Private Sub Button12_Click_1(sender As Object, e As EventArgs) Handles Button12.Click
        Dim srcH As Integer
        MM.GetCurrentImage(srcH)
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim pathSSD = "D:\stream.tif"
        Dim scrStream As Long
        Dim HandleStream As Long
        'Configure Stream
        MM.GetFunctionHandle("Stream Acquisition", HandleStream)
        MM.SetFunctionVariable(Handle, "nStreamFrames", 10)
        MM.SetFunctionVariable(Handle, "bStreamRunUserPrograms", False)
        ' MM.SetFunctionVariable(Handle, "stProgramNameForAcquire", "ZStack.UserMethods64")
        MM.SetFunctionVariable(Handle, "nStreamToHardDisk", 0)
        'MM.SetFunctionVariable(Handle, "stDiskFilename", pathSSD)
        'MM.SetFunctionVariable(Handle, "bSaveDuringAcquire", True)
        MM.SetFunctionVariable(Handle, "bOverwriteFile", True)
        MM.SetFunctionVariable(Handle, "bPreviewShow ", True)
        MM.SetFunctionVariable(Handle, "bStreamUsesFocusMotor", False)
        MM.SetFunctionVariable(Handle, "bSaveOneImagePerFile ", False)
        MM.SetFunctionVariable(Handle, "cPreviewFrameInterval", 40)
        MM.RunFunctionEx(HandleStream, 1)



        'Begin Stream Acquisition
        MM.GetFunctionHandle("Start Stream Acquisition", HandleStream)
        MM.RunFunctionEx(HandleStream, 1)

        'MM.GetCurrentImage(scrStream)
        MM.GetNamedImage("Stream", scrStream)
        MM.SaveImage(scrStream, pathSSD, False, 3)
        MM.CloseImage(scrStream)

    End Sub

    Private Sub TXTBX_Binning_TextChanged(sender As Object, e As EventArgs) Handles TXTBX_Binning.TextChanged
        Try
            If CInt(TXTBX_Binning.Text) < CInt(TXTBX_ReferencesAvg.Text) Then
                MsgBox("Value cannot be inferior to the average window of the reference beads.", MsgBoxStyle.OkOnly)
                TXTBX_Binning.Text = TXTBX_ReferencesAvg.Text + 5
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TXTBX_ReferencesAvg_TextChanged(sender As Object, e As EventArgs) Handles TXTBX_ReferencesAvg.TextChanged
        Try
            If CInt(TXTBX_ReferencesAvg.Text) > CInt(TXTBX_Binning.Text) Then
                MsgBox("Value cannot be superior to the binning window of registration.", MsgBoxStyle.OkOnly)
                TXTBX_ReferencesAvg.Text = 10
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TXTBX_ToleranceWTthresh_TextChanged(sender As Object, e As EventArgs) Handles TXTBX_ToleranceWTthresh.TextChanged
        Tolerance = CInt(TXTBX_ToleranceWTthresh.Text)
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Dim func As Long
        Dim ret As Integer

        ret = MM.GetFunctionHandle("Run User Program", func)
        If (ret > 0 And func > -1) Then
            ret = MM.SetFunctionVariable(func, "stProgramName", "soSPIM.UserMethods") 'Wave_Tracer.UserMethods

            If CKBX_WT.Checked Then
                ret = MM.SetFunctionVariable(func, "stCommandLine", "AUTOSYNC000")
            End If
            'ret = MM.SetFunctionVariable(func
            ret = MM.RunFunctionEx(func, 1) '1 = No user interface
        End If
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        'Dim func As Long
        'Dim ret As Integer

        'ret = MM.GetFunctionHandle("Run User Program", func)
        'If (ret > 0 And func > -1) Then
        '    ret = MM.SetFunctionVariable(func, "stProgramName", "Wave_Tracer.UserMethods") 'Wave_Tracer.UserMethods

        '    If CKBX_WT.Checked Then
        '        ret = MM.SetFunctionVariable(func, "stCommandLine", "SETUP")
        '    End If
        '    'ret = MM.SetFunctionVariable(func
        '    ret = MM.RunFunctionEx(func, 1) '1 = No user interface
        'End If
        Dim cmdLine, nbrcmd As String
        If cmdLine = "SETUP" Then
            nbrcmd = "5"
        Else
            nbrcmd = "8"
        End If

        cmdLine = nbrcmd + " " + cmdLine
        Dim sr As New StreamReader("C:\ZStack\WT_AUTO.JNL")
        Dim sw As New StreamWriter("C:\ZStack\WT_AUTO.JNL")
        Dim Str = sr.ReadLine()
        Str = Str.Replace("<Variable Type=" + Chr(34) + "String" + Chr(34) + " Name=" + Chr(34) + "jnlRunUserProgram.stCommandLine" + Chr(34) + " NDimensions=" + Chr(34) + "0" + Chr(34) + " Override=" + Chr(34) + "" + Chr(34) + " OverrideVariable=" + Chr(34) + "" + Chr(34) + ">0 </Variable>", "<Variable Type=" + Chr(34) + "String" + Chr(34) + " Name=" + Chr(34) + "jnlRunUserProgram.stCommandLine" + Chr(34) + " NDimensions=" + Chr(34) + "0" + Chr(34) + " Override=" + Chr(34) + "" + Chr(34) + " OverrideVariable=" + Chr(34) + "" + Chr(34) + ">" + cmdLine + "</Variable>")
        sr.Close()
        sw.WriteLine(Str)
        sw.Close()


    End Sub

    Private Sub CKBX_invertAxis_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CKBX_invertAxisXY.CheckedChanged
        If CKBX_invertAxisXY.Checked Then
            DeviceMCLdirectionX = 2
            DeviceMCLdirectionY = 1
            isInvertedAxis = True
        Else
            DeviceMCLdirectionX = 1
            DeviceMCLdirectionY = 2
            isInvertedAxis = False
        End If
    End Sub
End Class
