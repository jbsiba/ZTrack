<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.TXTBX_WT_Threshold = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_GetROI = New System.Windows.Forms.Button()
        Me.BTN_Calibration = New System.Windows.Forms.Button()
        Me.BTN_PathROI = New System.Windows.Forms.Button()
        Me.LBL_PathROI = New System.Windows.Forms.Label()
        Me.TXTBX_Binning = New System.Windows.Forms.TextBox()
        Me.CKBX_StageDisplacement = New System.Windows.Forms.CheckBox()
        Me.TXTBX_slideWindow = New System.Windows.Forms.TextBox()
        Me.CKBX_WT = New System.Windows.Forms.CheckBox()
        Me.ListBox_UserPrograms = New System.Windows.Forms.ListBox()
        Me.BTN_Autothreshold = New System.Windows.Forms.Button()
        Me.CKBX_3Dastig = New System.Windows.Forms.CheckBox()
        Me.CKBX_ZStack = New System.Windows.Forms.CheckBox()
        Me.TXBX_NbrPlaneZStack = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.BTN_Load = New System.Windows.Forms.Button()
        Me.BTN_StartStreamAcq = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTBX_precision = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTBX_DzFocus = New System.Windows.Forms.TextBox()
        Me.TXTBX_ZStreamStep = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BTN_FocusJNL = New System.Windows.Forms.Button()
        Me.CKBX_JNL = New System.Windows.Forms.CheckBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.BTN_ROIPlaneUP = New System.Windows.Forms.Button()
        Me.BTN_ROIPlane_Down = New System.Windows.Forms.Button()
        Me.BTN_CancelROIlist = New System.Windows.Forms.Button()
        Me.BTN_AddROIlist = New System.Windows.Forms.Button()
        Me.TBCTRL_Stream = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.BTN_SingleStream = New System.Windows.Forms.Button()
        Me.CKBX_StreamSectionning = New System.Windows.Forms.CheckBox()
        Me.LBL_TotalSectionning = New System.Windows.Forms.Label()
        Me.TXTBX_StreamBinning = New System.Windows.Forms.TextBox()
        Me.TXTBX_nbrBinning = New System.Windows.Forms.TextBox()
        Me.CKBX_AutoThreshPreview = New System.Windows.Forms.CheckBox()
        Me.Timer_Preview = New System.Windows.Forms.Timer(Me.components)
        Me.BTN_MCLProductInfo = New System.Windows.Forms.Button()
        Me.CKBX_SingleStream = New System.Windows.Forms.CheckBox()
        Me.BTN_MCLCalibration = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTBX_unit = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXTBX_Z = New System.Windows.Forms.TextBox()
        Me.TXTBX_Y = New System.Windows.Forms.TextBox()
        Me.TXTBX_X = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Timer_MCL = New System.Windows.Forms.Timer(Me.components)
        Me.GBX_MCL = New System.Windows.Forms.GroupBox()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.CKBX_AxisZinverted = New System.Windows.Forms.CheckBox()
        Me.CKBX_invertAxisXY = New System.Windows.Forms.CheckBox()
        Me.BTN_StageZ_Up = New System.Windows.Forms.Button()
        Me.BTN_StageZ_Down = New System.Windows.Forms.Button()
        Me.BTN_StageY_Up = New System.Windows.Forms.Button()
        Me.BTN_StageY_Down = New System.Windows.Forms.Button()
        Me.BTN_StageX_Up = New System.Windows.Forms.Button()
        Me.BTN_StageX_Down = New System.Windows.Forms.Button()
        Me.CKBX_soSPIMFOCUS = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Tabmain = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TXTBX_DelayStackZ = New System.Windows.Forms.TextBox()
        Me.BTN_StackZStream = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TXTBX_StackZnbrStep = New System.Windows.Forms.TextBox()
        Me.BTN_StackZAcqu = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GB_DriftCorrectionType = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.RBTN_NoDriftCorrection = New System.Windows.Forms.RadioButton()
        Me.BTN_Load3DCalibrationFile = New System.Windows.Forms.Button()
        Me.RBTN_2DDriftCorrection = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RBTN_3DDriftCorrection = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NUD_3DThicknessProcess = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NUD_3DThickness = New System.Windows.Forms.NumericUpDown()
        Me.TXTBX_CalibrationXYumpxl = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.RBTN_isSinglePlane = New System.Windows.Forms.RadioButton()
        Me.RBTN_isMultiplane = New System.Windows.Forms.RadioButton()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TXTBX_GaussianFitSize = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.BTN_StackBeadAutoExtration = New System.Windows.Forms.Button()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.CKBX_FindBeadStack = New System.Windows.Forms.CheckBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.BTN_GetROI_well = New System.Windows.Forms.Button()
        Me.CKBX_FindBeadAutoPlane = New System.Windows.Forms.CheckBox()
        Me.TXTBX_BeadAUto_Chi2Max = New System.Windows.Forms.TextBox()
        Me.TXTBX_BeadAuto_SigmaYMax = New System.Windows.Forms.TextBox()
        Me.TXTBX_BeadAUto_Chi2Min = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TXTBX_BeadAuto_SigmaXMin = New System.Windows.Forms.TextBox()
        Me.TXTBX_BeadAuto_SigmaYMin = New System.Windows.Forms.TextBox()
        Me.TXTBX_BeadAuto_SigmaXMax = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.LW_ROIlist = New System.Windows.Forms.ListView()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.CKBX_MultiPlanePreviewWT = New System.Windows.Forms.CheckBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.BNT_MultiplaneGetROI = New System.Windows.Forms.Button()
        Me.TXTBX_Multiplane_GaussianfitSize = New System.Windows.Forms.TextBox()
        Me.BTN_MultiplaneAutoThresh = New System.Windows.Forms.Button()
        Me.TXBX_Multiplane_WTThresh = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.BTN_GoToPlane = New System.Windows.Forms.Button()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CKBX_StreamToRAM = New System.Windows.Forms.CheckBox()
        Me.RBTN_SingleStream = New System.Windows.Forms.RadioButton()
        Me.TXTBX_nbrStreamFrame = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.RBTN_Sectionning = New System.Windows.Forms.RadioButton()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.BTN_StartStreamBeadAuto = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.TXTBX_ReferencesAvg = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.RBTN_RegOnlineAcq = New System.Windows.Forms.RadioButton()
        Me.RBTN_RegBinningAcq = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.NUD_TXTBX_regThreshZ_Min = New System.Windows.Forms.NumericUpDown()
        Me.NUD__regThreshXY_Min = New System.Windows.Forms.NumericUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.TXTBX_BeadAuto = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.LBL_BeadOrigin = New System.Windows.Forms.Label()
        Me.TXTBX_BeadAuto_IntensityMax = New System.Windows.Forms.TextBox()
        Me.TXTBX_BeadAuto_IntensityMin = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.ToolTipZTrack = New System.Windows.Forms.ToolTip(Me.components)
        Me.TXTBX_ToleranceWTthresh = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TabPage1.SuspendLayout()
        Me.TBCTRL_Stream.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GBX_MCL.SuspendLayout()
        Me.Tabmain.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GB_DriftCorrectionType.SuspendLayout()
        CType(Me.NUD_3DThicknessProcess, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_3DThickness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.NUD_TXTBX_regThreshZ_Min, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD__regThreshXY_Min, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TXTBX_WT_Threshold
        '
        Me.TXTBX_WT_Threshold.Location = New System.Drawing.Point(96, 34)
        Me.TXTBX_WT_Threshold.Name = "TXTBX_WT_Threshold"
        Me.TXTBX_WT_Threshold.Size = New System.Drawing.Size(42, 20)
        Me.TXTBX_WT_Threshold.TabIndex = 1
        Me.TXTBX_WT_Threshold.Text = "100"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Threshold"
        '
        'BTN_GetROI
        '
        Me.BTN_GetROI.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BTN_GetROI.FlatAppearance.BorderSize = 3
        Me.BTN_GetROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_GetROI.Location = New System.Drawing.Point(56, 134)
        Me.BTN_GetROI.Name = "BTN_GetROI"
        Me.BTN_GetROI.Size = New System.Drawing.Size(109, 33)
        Me.BTN_GetROI.TabIndex = 3
        Me.BTN_GetROI.Text = "Get ROI"
        Me.BTN_GetROI.UseVisualStyleBackColor = True
        '
        'BTN_Calibration
        '
        Me.BTN_Calibration.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BTN_Calibration.FlatAppearance.BorderSize = 3
        Me.BTN_Calibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Calibration.Location = New System.Drawing.Point(84, 77)
        Me.BTN_Calibration.Name = "BTN_Calibration"
        Me.BTN_Calibration.Size = New System.Drawing.Size(116, 32)
        Me.BTN_Calibration.TabIndex = 6
        Me.BTN_Calibration.Text = "Calibration"
        Me.BTN_Calibration.UseVisualStyleBackColor = True
        '
        'BTN_PathROI
        '
        Me.BTN_PathROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BTN_PathROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_PathROI.Location = New System.Drawing.Point(23, 29)
        Me.BTN_PathROI.Name = "BTN_PathROI"
        Me.BTN_PathROI.Size = New System.Drawing.Size(37, 22)
        Me.BTN_PathROI.TabIndex = 7
        Me.BTN_PathROI.TabStop = False
        Me.BTN_PathROI.Text = " ..."
        Me.BTN_PathROI.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_PathROI.UseVisualStyleBackColor = True
        '
        'LBL_PathROI
        '
        Me.LBL_PathROI.AutoSize = True
        Me.LBL_PathROI.Location = New System.Drawing.Point(66, 34)
        Me.LBL_PathROI.MaximumSize = New System.Drawing.Size(0, 215)
        Me.LBL_PathROI.Name = "LBL_PathROI"
        Me.LBL_PathROI.Size = New System.Drawing.Size(71, 13)
        Me.LBL_PathROI.TabIndex = 8
        Me.LBL_PathROI.Text = "Path logFile : "
        '
        'TXTBX_Binning
        '
        Me.TXTBX_Binning.Enabled = False
        Me.TXTBX_Binning.Location = New System.Drawing.Point(295, 26)
        Me.TXTBX_Binning.Name = "TXTBX_Binning"
        Me.TXTBX_Binning.Size = New System.Drawing.Size(52, 20)
        Me.TXTBX_Binning.TabIndex = 9
        Me.TXTBX_Binning.Text = "15"
        '
        'CKBX_StageDisplacement
        '
        Me.CKBX_StageDisplacement.AutoSize = True
        Me.CKBX_StageDisplacement.Location = New System.Drawing.Point(820, 155)
        Me.CKBX_StageDisplacement.Name = "CKBX_StageDisplacement"
        Me.CKBX_StageDisplacement.Size = New System.Drawing.Size(81, 17)
        Me.CKBX_StageDisplacement.TabIndex = 11
        Me.CKBX_StageDisplacement.Text = "StageMove"
        Me.CKBX_StageDisplacement.UseVisualStyleBackColor = True
        '
        'TXTBX_slideWindow
        '
        Me.TXTBX_slideWindow.Location = New System.Drawing.Point(247, 26)
        Me.TXTBX_slideWindow.Name = "TXTBX_slideWindow"
        Me.TXTBX_slideWindow.Size = New System.Drawing.Size(55, 20)
        Me.TXTBX_slideWindow.TabIndex = 14
        Me.TXTBX_slideWindow.Text = "0"
        '
        'CKBX_WT
        '
        Me.CKBX_WT.AutoSize = True
        Me.CKBX_WT.Enabled = False
        Me.CKBX_WT.Location = New System.Drawing.Point(31, 83)
        Me.CKBX_WT.Name = "CKBX_WT"
        Me.CKBX_WT.Size = New System.Drawing.Size(86, 17)
        Me.CKBX_WT.TabIndex = 16
        Me.CKBX_WT.Text = "WaveTracer"
        Me.CKBX_WT.UseVisualStyleBackColor = True
        '
        'ListBox_UserPrograms
        '
        Me.ListBox_UserPrograms.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz
        Me.ListBox_UserPrograms.FormattingEnabled = True
        Me.ListBox_UserPrograms.Location = New System.Drawing.Point(763, 49)
        Me.ListBox_UserPrograms.Name = "ListBox_UserPrograms"
        Me.ListBox_UserPrograms.Size = New System.Drawing.Size(117, 82)
        Me.ListBox_UserPrograms.TabIndex = 18
        '
        'BTN_Autothreshold
        '
        Me.BTN_Autothreshold.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Autothreshold.Location = New System.Drawing.Point(152, 30)
        Me.BTN_Autothreshold.Name = "BTN_Autothreshold"
        Me.BTN_Autothreshold.Size = New System.Drawing.Size(47, 26)
        Me.BTN_Autothreshold.TabIndex = 19
        Me.BTN_Autothreshold.Text = "Auto"
        Me.BTN_Autothreshold.UseVisualStyleBackColor = True
        '
        'CKBX_3Dastig
        '
        Me.CKBX_3Dastig.AutoSize = True
        Me.CKBX_3Dastig.Location = New System.Drawing.Point(31, 106)
        Me.CKBX_3Dastig.Name = "CKBX_3Dastig"
        Me.CKBX_3Dastig.Size = New System.Drawing.Size(97, 17)
        Me.CKBX_3Dastig.TabIndex = 20
        Me.CKBX_3Dastig.Text = "3D astigmatism"
        Me.CKBX_3Dastig.UseVisualStyleBackColor = True
        '
        'CKBX_ZStack
        '
        Me.CKBX_ZStack.AutoSize = True
        Me.CKBX_ZStack.Location = New System.Drawing.Point(1116, 189)
        Me.CKBX_ZStack.Name = "CKBX_ZStack"
        Me.CKBX_ZStack.Size = New System.Drawing.Size(122, 17)
        Me.CKBX_ZStack.TabIndex = 25
        Me.CKBX_ZStack.Text = "ZStack/Sectionning"
        Me.CKBX_ZStack.UseVisualStyleBackColor = True
        '
        'TXBX_NbrPlaneZStack
        '
        Me.TXBX_NbrPlaneZStack.Location = New System.Drawing.Point(119, 29)
        Me.TXBX_NbrPlaneZStack.Name = "TXBX_NbrPlaneZStack"
        Me.TXBX_NbrPlaneZStack.Size = New System.Drawing.Size(47, 20)
        Me.TXBX_NbrPlaneZStack.TabIndex = 26
        Me.TXBX_NbrPlaneZStack.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "nbr of Z-planes"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Select an ROI per plane :"
        '
        'BTN_Save
        '
        Me.BTN_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Save.Location = New System.Drawing.Point(594, 222)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(42, 22)
        Me.BTN_Save.TabIndex = 32
        Me.BTN_Save.Text = "Save"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'BTN_Load
        '
        Me.BTN_Load.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Load.Location = New System.Drawing.Point(594, 194)
        Me.BTN_Load.Name = "BTN_Load"
        Me.BTN_Load.Size = New System.Drawing.Size(42, 22)
        Me.BTN_Load.TabIndex = 33
        Me.BTN_Load.Text = "Load"
        Me.BTN_Load.UseVisualStyleBackColor = True
        '
        'BTN_StartStreamAcq
        '
        Me.BTN_StartStreamAcq.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BTN_StartStreamAcq.FlatAppearance.BorderSize = 2
        Me.BTN_StartStreamAcq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_StartStreamAcq.Location = New System.Drawing.Point(52, 385)
        Me.BTN_StartStreamAcq.Name = "BTN_StartStreamAcq"
        Me.BTN_StartStreamAcq.Size = New System.Drawing.Size(163, 49)
        Me.BTN_StartStreamAcq.TabIndex = 36
        Me.BTN_StartStreamAcq.Text = "Z stream"
        Me.BTN_StartStreamAcq.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(150, 196)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Z-Stream"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(64, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "precision"
        '
        'TXTBX_precision
        '
        Me.TXTBX_precision.Location = New System.Drawing.Point(119, 109)
        Me.TXTBX_precision.Name = "TXTBX_precision"
        Me.TXTBX_precision.Size = New System.Drawing.Size(47, 20)
        Me.TXTBX_precision.TabIndex = 40
        Me.TXTBX_precision.Text = "0.05"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(70, 86)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "dZ (nm)"
        '
        'TXTBX_DzFocus
        '
        Me.TXTBX_DzFocus.Location = New System.Drawing.Point(119, 83)
        Me.TXTBX_DzFocus.Name = "TXTBX_DzFocus"
        Me.TXTBX_DzFocus.Size = New System.Drawing.Size(47, 20)
        Me.TXTBX_DzFocus.TabIndex = 38
        Me.TXTBX_DzFocus.Text = "300"
        '
        'TXTBX_ZStreamStep
        '
        Me.TXTBX_ZStreamStep.Location = New System.Drawing.Point(119, 57)
        Me.TXTBX_ZStreamStep.Name = "TXTBX_ZStreamStep"
        Me.TXTBX_ZStreamStep.Size = New System.Drawing.Size(47, 20)
        Me.TXTBX_ZStreamStep.TabIndex = 36
        Me.TXTBX_ZStreamStep.Text = "5"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(41, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Z step (offset)"
        '
        'BTN_FocusJNL
        '
        Me.BTN_FocusJNL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BTN_FocusJNL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_FocusJNL.Location = New System.Drawing.Point(121, 40)
        Me.BTN_FocusJNL.Name = "BTN_FocusJNL"
        Me.BTN_FocusJNL.Size = New System.Drawing.Size(47, 22)
        Me.BTN_FocusJNL.TabIndex = 40
        Me.BTN_FocusJNL.TabStop = False
        Me.BTN_FocusJNL.Text = " ..."
        Me.BTN_FocusJNL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_FocusJNL.UseVisualStyleBackColor = True
        Me.BTN_FocusJNL.Visible = False
        '
        'CKBX_JNL
        '
        Me.CKBX_JNL.AutoSize = True
        Me.CKBX_JNL.Location = New System.Drawing.Point(34, 45)
        Me.CKBX_JNL.Name = "CKBX_JNL"
        Me.CKBX_JNL.Size = New System.Drawing.Size(60, 17)
        Me.CKBX_JNL.TabIndex = 38
        Me.CKBX_JNL.Text = "Journal"
        Me.CKBX_JNL.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(150, 196)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Z-ROI"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'BTN_ROIPlaneUP
        '
        Me.BTN_ROIPlaneUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_ROIPlaneUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_ROIPlaneUP.Image = Global.ZStack.My.Resources.Resources.up2
        Me.BTN_ROIPlaneUP.Location = New System.Drawing.Point(606, 109)
        Me.BTN_ROIPlaneUP.Name = "BTN_ROIPlaneUP"
        Me.BTN_ROIPlaneUP.Size = New System.Drawing.Size(21, 18)
        Me.BTN_ROIPlaneUP.TabIndex = 34
        Me.BTN_ROIPlaneUP.UseVisualStyleBackColor = True
        '
        'BTN_ROIPlane_Down
        '
        Me.BTN_ROIPlane_Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_ROIPlane_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_ROIPlane_Down.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ROIPlane_Down.Image = Global.ZStack.My.Resources.Resources.down21
        Me.BTN_ROIPlane_Down.Location = New System.Drawing.Point(606, 133)
        Me.BTN_ROIPlane_Down.Name = "BTN_ROIPlane_Down"
        Me.BTN_ROIPlane_Down.Size = New System.Drawing.Size(21, 18)
        Me.BTN_ROIPlane_Down.TabIndex = 35
        Me.BTN_ROIPlane_Down.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_ROIPlane_Down.UseVisualStyleBackColor = True
        '
        'BTN_CancelROIlist
        '
        Me.BTN_CancelROIlist.BackgroundImage = Global.ZStack.My.Resources.Resources.surouge3
        Me.BTN_CancelROIlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_CancelROIlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CancelROIlist.Location = New System.Drawing.Point(606, 57)
        Me.BTN_CancelROIlist.Name = "BTN_CancelROIlist"
        Me.BTN_CancelROIlist.Size = New System.Drawing.Size(21, 18)
        Me.BTN_CancelROIlist.TabIndex = 29
        Me.BTN_CancelROIlist.UseVisualStyleBackColor = True
        '
        'BTN_AddROIlist
        '
        Me.BTN_AddROIlist.BackgroundImage = Global.ZStack.My.Resources.Resources.plu3
        Me.BTN_AddROIlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_AddROIlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_AddROIlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_AddROIlist.Location = New System.Drawing.Point(606, 81)
        Me.BTN_AddROIlist.Name = "BTN_AddROIlist"
        Me.BTN_AddROIlist.Size = New System.Drawing.Size(21, 18)
        Me.BTN_AddROIlist.TabIndex = 30
        Me.BTN_AddROIlist.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_AddROIlist.UseVisualStyleBackColor = True
        '
        'TBCTRL_Stream
        '
        Me.TBCTRL_Stream.Controls.Add(Me.TabPage2)
        Me.TBCTRL_Stream.Controls.Add(Me.TabPage1)
        Me.TBCTRL_Stream.Controls.Add(Me.TabPage3)
        Me.TBCTRL_Stream.Location = New System.Drawing.Point(1063, 274)
        Me.TBCTRL_Stream.Name = "TBCTRL_Stream"
        Me.TBCTRL_Stream.SelectedIndex = 0
        Me.TBCTRL_Stream.Size = New System.Drawing.Size(158, 222)
        Me.TBCTRL_Stream.TabIndex = 37
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.BTN_SingleStream)
        Me.TabPage3.Controls.Add(Me.CKBX_StreamSectionning)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(150, 196)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Stream"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'BTN_SingleStream
        '
        Me.BTN_SingleStream.FlatAppearance.BorderColor = System.Drawing.Color.MediumSpringGreen
        Me.BTN_SingleStream.FlatAppearance.BorderSize = 2
        Me.BTN_SingleStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_SingleStream.Location = New System.Drawing.Point(30, 159)
        Me.BTN_SingleStream.Name = "BTN_SingleStream"
        Me.BTN_SingleStream.Size = New System.Drawing.Size(84, 24)
        Me.BTN_SingleStream.TabIndex = 46
        Me.BTN_SingleStream.Text = "Single Stream"
        Me.BTN_SingleStream.UseVisualStyleBackColor = True
        '
        'CKBX_StreamSectionning
        '
        Me.CKBX_StreamSectionning.AutoSize = True
        Me.CKBX_StreamSectionning.Location = New System.Drawing.Point(12, 77)
        Me.CKBX_StreamSectionning.Name = "CKBX_StreamSectionning"
        Me.CKBX_StreamSectionning.Size = New System.Drawing.Size(118, 17)
        Me.CKBX_StreamSectionning.TabIndex = 40
        Me.CKBX_StreamSectionning.Text = "Stream Sectionning"
        Me.CKBX_StreamSectionning.UseVisualStyleBackColor = True
        '
        'LBL_TotalSectionning
        '
        Me.LBL_TotalSectionning.AutoSize = True
        Me.LBL_TotalSectionning.Location = New System.Drawing.Point(149, 111)
        Me.LBL_TotalSectionning.Name = "LBL_TotalSectionning"
        Me.LBL_TotalSectionning.Size = New System.Drawing.Size(95, 13)
        Me.LBL_TotalSectionning.TabIndex = 45
        Me.LBL_TotalSectionning.Text = "Total of frames : 0 "
        '
        'TXTBX_StreamBinning
        '
        Me.TXTBX_StreamBinning.Location = New System.Drawing.Point(108, 54)
        Me.TXTBX_StreamBinning.Name = "TXTBX_StreamBinning"
        Me.TXTBX_StreamBinning.Size = New System.Drawing.Size(51, 20)
        Me.TXTBX_StreamBinning.TabIndex = 41
        Me.TXTBX_StreamBinning.Text = "1000"
        '
        'TXTBX_nbrBinning
        '
        Me.TXTBX_nbrBinning.Location = New System.Drawing.Point(108, 80)
        Me.TXTBX_nbrBinning.Name = "TXTBX_nbrBinning"
        Me.TXTBX_nbrBinning.Size = New System.Drawing.Size(51, 20)
        Me.TXTBX_nbrBinning.TabIndex = 42
        Me.TXTBX_nbrBinning.Text = "10"
        '
        'CKBX_AutoThreshPreview
        '
        Me.CKBX_AutoThreshPreview.AutoSize = True
        Me.CKBX_AutoThreshPreview.Location = New System.Drawing.Point(37, 66)
        Me.CKBX_AutoThreshPreview.Name = "CKBX_AutoThreshPreview"
        Me.CKBX_AutoThreshPreview.Size = New System.Drawing.Size(64, 17)
        Me.CKBX_AutoThreshPreview.TabIndex = 38
        Me.CKBX_AutoThreshPreview.Text = "Preview"
        Me.CKBX_AutoThreshPreview.UseVisualStyleBackColor = True
        '
        'Timer_Preview
        '
        Me.Timer_Preview.Interval = 500
        '
        'BTN_MCLProductInfo
        '
        Me.BTN_MCLProductInfo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BTN_MCLProductInfo.FlatAppearance.BorderSize = 3
        Me.BTN_MCLProductInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_MCLProductInfo.Location = New System.Drawing.Point(78, 203)
        Me.BTN_MCLProductInfo.Name = "BTN_MCLProductInfo"
        Me.BTN_MCLProductInfo.Size = New System.Drawing.Size(119, 41)
        Me.BTN_MCLProductInfo.TabIndex = 39
        Me.BTN_MCLProductInfo.Text = "Get Reference"
        Me.BTN_MCLProductInfo.UseVisualStyleBackColor = True
        '
        'CKBX_SingleStream
        '
        Me.CKBX_SingleStream.AutoSize = True
        Me.CKBX_SingleStream.Location = New System.Drawing.Point(1104, 161)
        Me.CKBX_SingleStream.Name = "CKBX_SingleStream"
        Me.CKBX_SingleStream.Size = New System.Drawing.Size(88, 17)
        Me.CKBX_SingleStream.TabIndex = 40
        Me.CKBX_SingleStream.Text = "SingleStream"
        Me.CKBX_SingleStream.UseVisualStyleBackColor = True
        '
        'BTN_MCLCalibration
        '
        Me.BTN_MCLCalibration.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BTN_MCLCalibration.FlatAppearance.BorderSize = 2
        Me.BTN_MCLCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_MCLCalibration.Location = New System.Drawing.Point(78, 174)
        Me.BTN_MCLCalibration.Name = "BTN_MCLCalibration"
        Me.BTN_MCLCalibration.Size = New System.Drawing.Size(119, 23)
        Me.BTN_MCLCalibration.TabIndex = 41
        Me.BTN_MCLCalibration.Text = "MCL Calibration"
        Me.BTN_MCLCalibration.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 13)
        Me.Label13.TabIndex = 81
        Me.Label13.Text = "unit of steps (um)"
        '
        'TXTBX_unit
        '
        Me.TXTBX_unit.Location = New System.Drawing.Point(98, 25)
        Me.TXTBX_unit.Name = "TXTBX_unit"
        Me.TXTBX_unit.Size = New System.Drawing.Size(45, 20)
        Me.TXTBX_unit.TabIndex = 80
        Me.TXTBX_unit.Text = "1"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(58, 142)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(14, 13)
        Me.Label14.TabIndex = 72
        Me.Label14.Text = "Z"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(58, 108)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(14, 13)
        Me.Label15.TabIndex = 71
        Me.Label15.Text = "Y"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(58, 71)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(14, 13)
        Me.Label16.TabIndex = 70
        Me.Label16.Text = "X"
        '
        'TXTBX_Z
        '
        Me.TXTBX_Z.Location = New System.Drawing.Point(85, 139)
        Me.TXTBX_Z.Name = "TXTBX_Z"
        Me.TXTBX_Z.Size = New System.Drawing.Size(58, 20)
        Me.TXTBX_Z.TabIndex = 69
        '
        'TXTBX_Y
        '
        Me.TXTBX_Y.Location = New System.Drawing.Point(85, 103)
        Me.TXTBX_Y.Name = "TXTBX_Y"
        Me.TXTBX_Y.Size = New System.Drawing.Size(58, 20)
        Me.TXTBX_Y.TabIndex = 68
        '
        'TXTBX_X
        '
        Me.TXTBX_X.Location = New System.Drawing.Point(85, 68)
        Me.TXTBX_X.Name = "TXTBX_X"
        Me.TXTBX_X.Size = New System.Drawing.Size(58, 20)
        Me.TXTBX_X.TabIndex = 67
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(10, -2)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(0, 13)
        Me.Label17.TabIndex = 86
        '
        'Timer_MCL
        '
        '
        'GBX_MCL
        '
        Me.GBX_MCL.Controls.Add(Me.Button17)
        Me.GBX_MCL.Controls.Add(Me.CKBX_AxisZinverted)
        Me.GBX_MCL.Controls.Add(Me.CKBX_invertAxisXY)
        Me.GBX_MCL.Controls.Add(Me.TXTBX_unit)
        Me.GBX_MCL.Controls.Add(Me.Label17)
        Me.GBX_MCL.Controls.Add(Me.BTN_MCLProductInfo)
        Me.GBX_MCL.Controls.Add(Me.BTN_StageZ_Up)
        Me.GBX_MCL.Controls.Add(Me.BTN_MCLCalibration)
        Me.GBX_MCL.Controls.Add(Me.BTN_StageZ_Down)
        Me.GBX_MCL.Controls.Add(Me.TXTBX_X)
        Me.GBX_MCL.Controls.Add(Me.BTN_StageY_Up)
        Me.GBX_MCL.Controls.Add(Me.TXTBX_Y)
        Me.GBX_MCL.Controls.Add(Me.BTN_StageY_Down)
        Me.GBX_MCL.Controls.Add(Me.TXTBX_Z)
        Me.GBX_MCL.Controls.Add(Me.BTN_StageX_Up)
        Me.GBX_MCL.Controls.Add(Me.Label16)
        Me.GBX_MCL.Controls.Add(Me.BTN_StageX_Down)
        Me.GBX_MCL.Controls.Add(Me.Label15)
        Me.GBX_MCL.Controls.Add(Me.Label13)
        Me.GBX_MCL.Controls.Add(Me.Label14)
        Me.GBX_MCL.Location = New System.Drawing.Point(21, 167)
        Me.GBX_MCL.Name = "GBX_MCL"
        Me.GBX_MCL.Size = New System.Drawing.Size(283, 250)
        Me.GBX_MCL.TabIndex = 87
        Me.GBX_MCL.TabStop = False
        Me.GBX_MCL.Text = "MadCityLab Control Tab "
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button17.BackgroundImage = CType(resources.GetObject("Button17.BackgroundImage"), System.Drawing.Image)
        Me.Button17.FlatAppearance.BorderSize = 0
        Me.Button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button17.Location = New System.Drawing.Point(258, 39)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(11, 11)
        Me.Button17.TabIndex = 110
        Me.ToolTipZTrack.SetToolTip(Me.Button17, "Work only for Automatic Extraction Bead Option, and Zstack-Aquire option")
        Me.Button17.UseVisualStyleBackColor = False
        '
        'CKBX_AxisZinverted
        '
        Me.CKBX_AxisZinverted.AutoSize = True
        Me.CKBX_AxisZinverted.Location = New System.Drawing.Point(162, 37)
        Me.CKBX_AxisZinverted.Name = "CKBX_AxisZinverted"
        Me.CKBX_AxisZinverted.Size = New System.Drawing.Size(95, 17)
        Me.CKBX_AxisZinverted.TabIndex = 108
        Me.CKBX_AxisZinverted.Text = "Z axis inverted"
        Me.CKBX_AxisZinverted.UseVisualStyleBackColor = True
        '
        'CKBX_invertAxisXY
        '
        Me.CKBX_invertAxisXY.AutoSize = True
        Me.CKBX_invertAxisXY.Location = New System.Drawing.Point(162, 18)
        Me.CKBX_invertAxisXY.Margin = New System.Windows.Forms.Padding(2)
        Me.CKBX_invertAxisXY.Name = "CKBX_invertAxisXY"
        Me.CKBX_invertAxisXY.Size = New System.Drawing.Size(107, 17)
        Me.CKBX_invertAxisXY.TabIndex = 93
        Me.CKBX_invertAxisXY.Text = "X,Y Axis Inverted"
        Me.CKBX_invertAxisXY.UseVisualStyleBackColor = True
        '
        'BTN_StageZ_Up
        '
        Me.BTN_StageZ_Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_StageZ_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_StageZ_Up.Image = Global.ZStack.My.Resources.Resources.up51
        Me.BTN_StageZ_Up.Location = New System.Drawing.Point(162, 146)
        Me.BTN_StageZ_Up.Name = "BTN_StageZ_Up"
        Me.BTN_StageZ_Up.Size = New System.Drawing.Size(25, 13)
        Me.BTN_StageZ_Up.TabIndex = 84
        Me.BTN_StageZ_Up.UseVisualStyleBackColor = True
        '
        'BTN_StageZ_Down
        '
        Me.BTN_StageZ_Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_StageZ_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_StageZ_Down.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_StageZ_Down.Image = Global.ZStack.My.Resources.Resources.down3
        Me.BTN_StageZ_Down.Location = New System.Drawing.Point(187, 146)
        Me.BTN_StageZ_Down.Name = "BTN_StageZ_Down"
        Me.BTN_StageZ_Down.Size = New System.Drawing.Size(25, 13)
        Me.BTN_StageZ_Down.TabIndex = 85
        Me.BTN_StageZ_Down.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_StageZ_Down.UseVisualStyleBackColor = True
        '
        'BTN_StageY_Up
        '
        Me.BTN_StageY_Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_StageY_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_StageY_Up.Image = Global.ZStack.My.Resources.Resources.up51
        Me.BTN_StageY_Up.Location = New System.Drawing.Point(162, 108)
        Me.BTN_StageY_Up.Name = "BTN_StageY_Up"
        Me.BTN_StageY_Up.Size = New System.Drawing.Size(25, 13)
        Me.BTN_StageY_Up.TabIndex = 82
        Me.BTN_StageY_Up.UseVisualStyleBackColor = True
        '
        'BTN_StageY_Down
        '
        Me.BTN_StageY_Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_StageY_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_StageY_Down.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_StageY_Down.Image = Global.ZStack.My.Resources.Resources.down3
        Me.BTN_StageY_Down.Location = New System.Drawing.Point(187, 108)
        Me.BTN_StageY_Down.Name = "BTN_StageY_Down"
        Me.BTN_StageY_Down.Size = New System.Drawing.Size(25, 13)
        Me.BTN_StageY_Down.TabIndex = 83
        Me.BTN_StageY_Down.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_StageY_Down.UseVisualStyleBackColor = True
        '
        'BTN_StageX_Up
        '
        Me.BTN_StageX_Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_StageX_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_StageX_Up.Image = Global.ZStack.My.Resources.Resources.up51
        Me.BTN_StageX_Up.Location = New System.Drawing.Point(162, 71)
        Me.BTN_StageX_Up.Name = "BTN_StageX_Up"
        Me.BTN_StageX_Up.Size = New System.Drawing.Size(25, 13)
        Me.BTN_StageX_Up.TabIndex = 36
        Me.BTN_StageX_Up.UseVisualStyleBackColor = True
        '
        'BTN_StageX_Down
        '
        Me.BTN_StageX_Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_StageX_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_StageX_Down.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_StageX_Down.Image = Global.ZStack.My.Resources.Resources.down3
        Me.BTN_StageX_Down.Location = New System.Drawing.Point(187, 71)
        Me.BTN_StageX_Down.Name = "BTN_StageX_Down"
        Me.BTN_StageX_Down.Size = New System.Drawing.Size(25, 13)
        Me.BTN_StageX_Down.TabIndex = 37
        Me.BTN_StageX_Down.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_StageX_Down.UseVisualStyleBackColor = True
        '
        'CKBX_soSPIMFOCUS
        '
        Me.CKBX_soSPIMFOCUS.AutoSize = True
        Me.CKBX_soSPIMFOCUS.Location = New System.Drawing.Point(68, 145)
        Me.CKBX_soSPIMFOCUS.Name = "CKBX_soSPIMFOCUS"
        Me.CKBX_soSPIMFOCUS.Size = New System.Drawing.Size(98, 17)
        Me.CKBX_soSPIMFOCUS.TabIndex = 88
        Me.CKBX_soSPIMFOCUS.Text = "soSPIM_Focus"
        Me.CKBX_soSPIMFOCUS.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(1017, 228)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(37, 30)
        Me.Button2.TabIndex = 89
        Me.Button2.TabStop = False
        Me.Button2.Text = " ..."
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(1093, 238)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(58, 20)
        Me.TextBox2.TabIndex = 91
        Me.TextBox2.Text = "1"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(1208, 238)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(58, 20)
        Me.TextBox3.TabIndex = 92
        Me.TextBox3.Text = "50"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(1060, 241)
        Me.Label18.MaximumSize = New System.Drawing.Size(0, 215)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(27, 13)
        Me.Label18.TabIndex = 93
        Me.Label18.Text = "step"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(1157, 241)
        Me.Label19.MaximumSize = New System.Drawing.Size(0, 215)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(45, 13)
        Me.Label19.TabIndex = 94
        Me.Label19.Text = "nbr step"
        '
        'Tabmain
        '
        Me.Tabmain.Controls.Add(Me.TabPage4)
        Me.Tabmain.Controls.Add(Me.TabPage5)
        Me.Tabmain.Controls.Add(Me.TabPage6)
        Me.Tabmain.Controls.Add(Me.TabPage7)
        Me.Tabmain.Controls.Add(Me.TabPage8)
        Me.Tabmain.Location = New System.Drawing.Point(12, 12)
        Me.Tabmain.Name = "Tabmain"
        Me.Tabmain.SelectedIndex = 0
        Me.Tabmain.Size = New System.Drawing.Size(659, 463)
        Me.Tabmain.TabIndex = 95
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox1)
        Me.TabPage4.Controls.Add(Me.GroupBox2)
        Me.TabPage4.Controls.Add(Me.GBX_MCL)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(651, 437)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "Settings"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button16)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.TXTBX_DelayStackZ)
        Me.GroupBox1.Controls.Add(Me.BTN_StackZStream)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.TXTBX_StackZnbrStep)
        Me.GroupBox1.Controls.Add(Me.BTN_StackZAcqu)
        Me.GroupBox1.Location = New System.Drawing.Point(322, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(224, 174)
        Me.GroupBox1.TabIndex = 107
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stack"
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button16.BackgroundImage = CType(resources.GetObject("Button16.BackgroundImage"), System.Drawing.Image)
        Me.Button16.FlatAppearance.BorderSize = 0
        Me.Button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button16.Location = New System.Drawing.Point(22, 120)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(11, 11)
        Me.Button16.TabIndex = 111
        Me.ToolTipZTrack.SetToolTip(Me.Button16, "Stack starts at the bottom, the Z inverted axis option is taken into account.")
        Me.Button16.UseVisualStyleBackColor = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(6, 158)
        Me.Label31.MaximumSize = New System.Drawing.Size(0, 215)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(0, 13)
        Me.Label31.TabIndex = 9
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(72, 58)
        Me.Label25.MaximumSize = New System.Drawing.Size(0, 215)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(54, 13)
        Me.Label25.TabIndex = 106
        Me.Label25.Text = "delay (ms)"
        '
        'TXTBX_DelayStackZ
        '
        Me.TXTBX_DelayStackZ.Location = New System.Drawing.Point(127, 55)
        Me.TXTBX_DelayStackZ.Name = "TXTBX_DelayStackZ"
        Me.TXTBX_DelayStackZ.Size = New System.Drawing.Size(51, 20)
        Me.TXTBX_DelayStackZ.TabIndex = 105
        Me.TXTBX_DelayStackZ.Text = "200"
        '
        'BTN_StackZStream
        '
        Me.BTN_StackZStream.Enabled = False
        Me.BTN_StackZStream.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BTN_StackZStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_StackZStream.Location = New System.Drawing.Point(62, 137)
        Me.BTN_StackZStream.Name = "BTN_StackZStream"
        Me.BTN_StackZStream.Size = New System.Drawing.Size(125, 23)
        Me.BTN_StackZStream.TabIndex = 104
        Me.BTN_StackZStream.Text = "Stack Z - Stream"
        Me.BTN_StackZStream.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(72, 32)
        Me.Label24.MaximumSize = New System.Drawing.Size(0, 215)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(47, 13)
        Me.Label24.TabIndex = 103
        Me.Label24.Text = "Nbr step"
        '
        'TXTBX_StackZnbrStep
        '
        Me.TXTBX_StackZnbrStep.Location = New System.Drawing.Point(127, 29)
        Me.TXTBX_StackZnbrStep.Name = "TXTBX_StackZnbrStep"
        Me.TXTBX_StackZnbrStep.Size = New System.Drawing.Size(51, 20)
        Me.TXTBX_StackZnbrStep.TabIndex = 55
        Me.TXTBX_StackZnbrStep.Text = "50"
        '
        'BTN_StackZAcqu
        '
        Me.BTN_StackZAcqu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BTN_StackZAcqu.FlatAppearance.BorderSize = 3
        Me.BTN_StackZAcqu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_StackZAcqu.Location = New System.Drawing.Point(62, 91)
        Me.BTN_StackZAcqu.Name = "BTN_StackZAcqu"
        Me.BTN_StackZAcqu.Size = New System.Drawing.Size(125, 40)
        Me.BTN_StackZAcqu.TabIndex = 102
        Me.BTN_StackZAcqu.Text = "Stack Z - Acquire"
        Me.BTN_StackZAcqu.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTN_Calibration)
        Me.GroupBox2.Controls.Add(Me.LBL_PathROI)
        Me.GroupBox2.Controls.Add(Me.BTN_PathROI)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(284, 131)
        Me.GroupBox2.TabIndex = 92
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Global"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.GroupBox8)
        Me.TabPage5.Controls.Add(Me.GB_DriftCorrectionType)
        Me.TabPage5.Controls.Add(Me.GroupBox4)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(651, 437)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "Acquisition"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Button18)
        Me.GroupBox8.Controls.Add(Me.Label10)
        Me.GroupBox8.Controls.Add(Me.CKBX_JNL)
        Me.GroupBox8.Controls.Add(Me.BTN_FocusJNL)
        Me.GroupBox8.Location = New System.Drawing.Point(21, 307)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(211, 87)
        Me.GroupBox8.TabIndex = 12
        Me.GroupBox8.TabStop = False
        '
        'Button18
        '
        Me.Button18.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button18.BackgroundImage = CType(resources.GetObject("Button18.BackgroundImage"), System.Drawing.Image)
        Me.Button18.FlatAppearance.BorderSize = 0
        Me.Button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button18.Location = New System.Drawing.Point(16, 47)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(11, 11)
        Me.Button18.TabIndex = 111
        Me.ToolTipZTrack.SetToolTip(Me.Button18, "*before each acquisitions of each plane")
        Me.Button18.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 71)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 13)
        Me.Label10.TabIndex = 13
        '
        'GB_DriftCorrectionType
        '
        Me.GB_DriftCorrectionType.Controls.Add(Me.Label21)
        Me.GB_DriftCorrectionType.Controls.Add(Me.RBTN_NoDriftCorrection)
        Me.GB_DriftCorrectionType.Controls.Add(Me.BTN_Load3DCalibrationFile)
        Me.GB_DriftCorrectionType.Controls.Add(Me.RBTN_2DDriftCorrection)
        Me.GB_DriftCorrectionType.Controls.Add(Me.Label7)
        Me.GB_DriftCorrectionType.Controls.Add(Me.RBTN_3DDriftCorrection)
        Me.GB_DriftCorrectionType.Controls.Add(Me.Label4)
        Me.GB_DriftCorrectionType.Controls.Add(Me.NUD_3DThicknessProcess)
        Me.GB_DriftCorrectionType.Controls.Add(Me.Label3)
        Me.GB_DriftCorrectionType.Controls.Add(Me.NUD_3DThickness)
        Me.GB_DriftCorrectionType.Controls.Add(Me.TXTBX_CalibrationXYumpxl)
        Me.GB_DriftCorrectionType.Location = New System.Drawing.Point(21, 162)
        Me.GB_DriftCorrectionType.Name = "GB_DriftCorrectionType"
        Me.GB_DriftCorrectionType.Size = New System.Drawing.Size(211, 139)
        Me.GB_DriftCorrectionType.TabIndex = 12
        Me.GB_DriftCorrectionType.TabStop = False
        Me.GB_DriftCorrectionType.Text = "Drift Correction "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(249, 24)
        Me.Label21.MaximumSize = New System.Drawing.Size(0, 215)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(137, 13)
        Me.Label21.TabIndex = 104
        Me.Label21.Text = "Load the 3DCalibration file :"
        '
        'RBTN_NoDriftCorrection
        '
        Me.RBTN_NoDriftCorrection.AutoSize = True
        Me.RBTN_NoDriftCorrection.Checked = True
        Me.RBTN_NoDriftCorrection.Location = New System.Drawing.Point(16, 98)
        Me.RBTN_NoDriftCorrection.Name = "RBTN_NoDriftCorrection"
        Me.RBTN_NoDriftCorrection.Size = New System.Drawing.Size(190, 17)
        Me.RBTN_NoDriftCorrection.TabIndex = 10
        Me.RBTN_NoDriftCorrection.TabStop = True
        Me.RBTN_NoDriftCorrection.Text = "No Drift correction (no stage move)"
        Me.RBTN_NoDriftCorrection.UseVisualStyleBackColor = True
        '
        'BTN_Load3DCalibrationFile
        '
        Me.BTN_Load3DCalibrationFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BTN_Load3DCalibrationFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Load3DCalibrationFile.Location = New System.Drawing.Point(404, 19)
        Me.BTN_Load3DCalibrationFile.Name = "BTN_Load3DCalibrationFile"
        Me.BTN_Load3DCalibrationFile.Size = New System.Drawing.Size(37, 22)
        Me.BTN_Load3DCalibrationFile.TabIndex = 103
        Me.BTN_Load3DCalibrationFile.TabStop = False
        Me.BTN_Load3DCalibrationFile.Text = " ..."
        Me.BTN_Load3DCalibrationFile.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_Load3DCalibrationFile.UseVisualStyleBackColor = True
        '
        'RBTN_2DDriftCorrection
        '
        Me.RBTN_2DDriftCorrection.AutoSize = True
        Me.RBTN_2DDriftCorrection.Location = New System.Drawing.Point(16, 33)
        Me.RBTN_2DDriftCorrection.Name = "RBTN_2DDriftCorrection"
        Me.RBTN_2DDriftCorrection.Size = New System.Drawing.Size(174, 17)
        Me.RBTN_2DDriftCorrection.TabIndex = 8
        Me.RBTN_2DDriftCorrection.Text = "2D Drift correction + AutoFocus"
        Me.RBTN_2DDriftCorrection.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(249, 105)
        Me.Label7.MaximumSize = New System.Drawing.Size(0, 215)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 13)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "3D process sampling (um)"
        '
        'RBTN_3DDriftCorrection
        '
        Me.RBTN_3DDriftCorrection.AutoSize = True
        Me.RBTN_3DDriftCorrection.Location = New System.Drawing.Point(16, 67)
        Me.RBTN_3DDriftCorrection.Name = "RBTN_3DDriftCorrection"
        Me.RBTN_3DDriftCorrection.Size = New System.Drawing.Size(111, 17)
        Me.RBTN_3DDriftCorrection.TabIndex = 9
        Me.RBTN_3DDriftCorrection.Text = "3D Drift correction"
        Me.RBTN_3DDriftCorrection.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(281, 79)
        Me.Label4.MaximumSize = New System.Drawing.Size(0, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "3D Thickness (um)"
        '
        'NUD_3DThicknessProcess
        '
        Me.NUD_3DThicknessProcess.DecimalPlaces = 3
        Me.NUD_3DThicknessProcess.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.NUD_3DThicknessProcess.Location = New System.Drawing.Point(394, 103)
        Me.NUD_3DThicknessProcess.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NUD_3DThicknessProcess.Name = "NUD_3DThicknessProcess"
        Me.NUD_3DThicknessProcess.Size = New System.Drawing.Size(60, 20)
        Me.NUD_3DThicknessProcess.TabIndex = 98
        Me.NUD_3DThicknessProcess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NUD_3DThicknessProcess.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(263, 55)
        Me.Label3.MaximumSize = New System.Drawing.Size(0, 215)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Calibration XY (um/pxl)"
        '
        'NUD_3DThickness
        '
        Me.NUD_3DThickness.DecimalPlaces = 3
        Me.NUD_3DThickness.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.NUD_3DThickness.Location = New System.Drawing.Point(394, 77)
        Me.NUD_3DThickness.Maximum = New Decimal(New Integer() {3, 0, 0, 0})
        Me.NUD_3DThickness.Name = "NUD_3DThickness"
        Me.NUD_3DThickness.Size = New System.Drawing.Size(60, 20)
        Me.NUD_3DThickness.TabIndex = 97
        Me.NUD_3DThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NUD_3DThickness.Value = New Decimal(New Integer() {15, 0, 0, 65536})
        '
        'TXTBX_CalibrationXYumpxl
        '
        Me.TXTBX_CalibrationXYumpxl.Location = New System.Drawing.Point(394, 52)
        Me.TXTBX_CalibrationXYumpxl.Name = "TXTBX_CalibrationXYumpxl"
        Me.TXTBX_CalibrationXYumpxl.Size = New System.Drawing.Size(60, 20)
        Me.TXTBX_CalibrationXYumpxl.TabIndex = 99
        Me.TXTBX_CalibrationXYumpxl.Text = "0.108"
        Me.TXTBX_CalibrationXYumpxl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RBTN_isSinglePlane)
        Me.GroupBox4.Controls.Add(Me.RBTN_isMultiplane)
        Me.GroupBox4.Controls.Add(Me.CKBX_WT)
        Me.GroupBox4.Controls.Add(Me.CKBX_3Dastig)
        Me.GroupBox4.Location = New System.Drawing.Point(21, 20)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(211, 136)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Stream"
        '
        'RBTN_isSinglePlane
        '
        Me.RBTN_isSinglePlane.AutoSize = True
        Me.RBTN_isSinglePlane.Location = New System.Drawing.Point(33, 51)
        Me.RBTN_isSinglePlane.Name = "RBTN_isSinglePlane"
        Me.RBTN_isSinglePlane.Size = New System.Drawing.Size(84, 17)
        Me.RBTN_isSinglePlane.TabIndex = 3
        Me.RBTN_isSinglePlane.Text = "Single Plane"
        Me.RBTN_isSinglePlane.UseVisualStyleBackColor = True
        '
        'RBTN_isMultiplane
        '
        Me.RBTN_isMultiplane.AutoSize = True
        Me.RBTN_isMultiplane.Checked = True
        Me.RBTN_isMultiplane.Location = New System.Drawing.Point(33, 28)
        Me.RBTN_isMultiplane.Name = "RBTN_isMultiplane"
        Me.RBTN_isMultiplane.Size = New System.Drawing.Size(73, 17)
        Me.RBTN_isMultiplane.TabIndex = 2
        Me.RBTN_isMultiplane.TabStop = True
        Me.RBTN_isMultiplane.Text = "Mulitplane"
        Me.RBTN_isMultiplane.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.GroupBox6)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(651, 437)
        Me.TabPage6.TabIndex = 2
        Me.TabPage6.Text = "Single Plane"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Button9)
        Me.GroupBox6.Controls.Add(Me.Button1)
        Me.GroupBox6.Controls.Add(Me.BTN_Autothreshold)
        Me.GroupBox6.Controls.Add(Me.TXTBX_GaussianFitSize)
        Me.GroupBox6.Controls.Add(Me.Label26)
        Me.GroupBox6.Controls.Add(Me.TXTBX_WT_Threshold)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Controls.Add(Me.BTN_GetROI)
        Me.GroupBox6.Controls.Add(Me.CKBX_AutoThreshPreview)
        Me.GroupBox6.Location = New System.Drawing.Point(18, 20)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(222, 201)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "ROI Definition"
        '
        'Button9
        '
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Location = New System.Drawing.Point(83, 172)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(58, 23)
        Me.Button9.TabIndex = 98
        Me.Button9.Text = "drift test"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.ZStack.My.Resources.Resources.preview_on
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(96, 63)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 20)
        Me.Button1.TabIndex = 49
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TXTBX_GaussianFitSize
        '
        Me.TXTBX_GaussianFitSize.Location = New System.Drawing.Point(127, 92)
        Me.TXTBX_GaussianFitSize.Name = "TXTBX_GaussianFitSize"
        Me.TXTBX_GaussianFitSize.Size = New System.Drawing.Size(38, 20)
        Me.TXTBX_GaussianFitSize.TabIndex = 47
        Me.TXTBX_GaussianFitSize.Text = "9"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(33, 95)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(88, 13)
        Me.Label26.TabIndex = 48
        Me.Label26.Text = "Guassian Fit Size"
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.GroupBox9)
        Me.TabPage7.Controls.Add(Me.GroupBox7)
        Me.TabPage7.Controls.Add(Me.BTN_ROIPlaneUP)
        Me.TabPage7.Controls.Add(Me.GroupBox11)
        Me.TabPage7.Controls.Add(Me.GroupBox10)
        Me.TabPage7.Controls.Add(Me.BTN_Save)
        Me.TabPage7.Controls.Add(Me.BTN_Load)
        Me.TabPage7.Controls.Add(Me.BTN_CancelROIlist)
        Me.TabPage7.Controls.Add(Me.BTN_AddROIlist)
        Me.TabPage7.Controls.Add(Me.BTN_GoToPlane)
        Me.TabPage7.Controls.Add(Me.BTN_ROIPlane_Down)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(651, 437)
        Me.TabPage7.TabIndex = 3
        Me.TabPage7.Text = "Multiplane"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Button19)
        Me.GroupBox9.Controls.Add(Me.Label40)
        Me.GroupBox9.Controls.Add(Me.BTN_StackBeadAutoExtration)
        Me.GroupBox9.Controls.Add(Me.Label30)
        Me.GroupBox9.Controls.Add(Me.Label36)
        Me.GroupBox9.Controls.Add(Me.CKBX_FindBeadStack)
        Me.GroupBox9.Controls.Add(Me.Label34)
        Me.GroupBox9.Controls.Add(Me.BTN_GetROI_well)
        Me.GroupBox9.Controls.Add(Me.CKBX_FindBeadAutoPlane)
        Me.GroupBox9.Controls.Add(Me.TXTBX_BeadAUto_Chi2Max)
        Me.GroupBox9.Controls.Add(Me.TXTBX_BeadAuto_SigmaYMax)
        Me.GroupBox9.Controls.Add(Me.TXTBX_BeadAUto_Chi2Min)
        Me.GroupBox9.Controls.Add(Me.Label29)
        Me.GroupBox9.Controls.Add(Me.TXTBX_BeadAuto_SigmaXMin)
        Me.GroupBox9.Controls.Add(Me.TXTBX_BeadAuto_SigmaYMin)
        Me.GroupBox9.Controls.Add(Me.TXTBX_BeadAuto_SigmaXMax)
        Me.GroupBox9.Location = New System.Drawing.Point(264, 263)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(325, 154)
        Me.GroupBox9.TabIndex = 114
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Automatic Bead Extraction"
        '
        'Button19
        '
        Me.Button19.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button19.BackgroundImage = CType(resources.GetObject("Button19.BackgroundImage"), System.Drawing.Image)
        Me.Button19.FlatAppearance.BorderSize = 0
        Me.Button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button19.Location = New System.Drawing.Point(294, 45)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(11, 11)
        Me.Button19.TabIndex = 115
        Me.ToolTipZTrack.SetToolTip(Me.Button19, "Set parameters filter. If ONE parameter is set to 0, filters are not apply. ")
        Me.Button19.UseVisualStyleBackColor = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(248, 39)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(40, 13)
        Me.Label40.TabIndex = 123
        Me.Label40.Text = "[    ;    ]"
        '
        'BTN_StackBeadAutoExtration
        '
        Me.BTN_StackBeadAutoExtration.Enabled = False
        Me.BTN_StackBeadAutoExtration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_StackBeadAutoExtration.Location = New System.Drawing.Point(41, 125)
        Me.BTN_StackBeadAutoExtration.Name = "BTN_StackBeadAutoExtration"
        Me.BTN_StackBeadAutoExtration.Size = New System.Drawing.Size(129, 23)
        Me.BTN_StackBeadAutoExtration.TabIndex = 116
        Me.BTN_StackBeadAutoExtration.Text = "Stack-Bead-Extraction"
        Me.BTN_StackBeadAutoExtration.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 22)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(198, 26)
        Me.Label30.TabIndex = 115
        Me.Label30.Text = "Set polymer bead Threshold" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Create ROI around the well (GetROIwell)"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(179, 97)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(43, 13)
        Me.Label36.TabIndex = 121
        Me.Label36.Text = "SigmaY"
        '
        'CKBX_FindBeadStack
        '
        Me.CKBX_FindBeadStack.AutoSize = True
        Me.CKBX_FindBeadStack.Location = New System.Drawing.Point(9, 95)
        Me.CKBX_FindBeadStack.Name = "CKBX_FindBeadStack"
        Me.CKBX_FindBeadStack.Size = New System.Drawing.Size(127, 17)
        Me.CKBX_FindBeadStack.TabIndex = 112
        Me.CKBX_FindBeadStack.Text = "Extraction from Stack"
        Me.CKBX_FindBeadStack.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(179, 78)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(43, 13)
        Me.Label34.TabIndex = 120
        Me.Label34.Text = "SigmaX"
        '
        'BTN_GetROI_well
        '
        Me.BTN_GetROI_well.FlatAppearance.BorderColor = System.Drawing.Color.Orange
        Me.BTN_GetROI_well.FlatAppearance.BorderSize = 2
        Me.BTN_GetROI_well.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_GetROI_well.Location = New System.Drawing.Point(176, 124)
        Me.BTN_GetROI_well.Name = "BTN_GetROI_well"
        Me.BTN_GetROI_well.Size = New System.Drawing.Size(129, 23)
        Me.BTN_GetROI_well.TabIndex = 111
        Me.BTN_GetROI_well.Text = "Get ROI - Well"
        Me.BTN_GetROI_well.UseVisualStyleBackColor = True
        '
        'CKBX_FindBeadAutoPlane
        '
        Me.CKBX_FindBeadAutoPlane.AutoSize = True
        Me.CKBX_FindBeadAutoPlane.Location = New System.Drawing.Point(9, 63)
        Me.CKBX_FindBeadAutoPlane.Name = "CKBX_FindBeadAutoPlane"
        Me.CKBX_FindBeadAutoPlane.Size = New System.Drawing.Size(95, 17)
        Me.CKBX_FindBeadAutoPlane.TabIndex = 113
        Me.CKBX_FindBeadAutoPlane.Text = "Live extraction"
        Me.CKBX_FindBeadAutoPlane.UseVisualStyleBackColor = True
        '
        'TXTBX_BeadAUto_Chi2Max
        '
        Me.TXTBX_BeadAUto_Chi2Max.Location = New System.Drawing.Point(269, 58)
        Me.TXTBX_BeadAUto_Chi2Max.Name = "TXTBX_BeadAUto_Chi2Max"
        Me.TXTBX_BeadAUto_Chi2Max.Size = New System.Drawing.Size(36, 20)
        Me.TXTBX_BeadAUto_Chi2Max.TabIndex = 113
        Me.TXTBX_BeadAUto_Chi2Max.Text = "1"
        '
        'TXTBX_BeadAuto_SigmaYMax
        '
        Me.TXTBX_BeadAuto_SigmaYMax.Location = New System.Drawing.Point(269, 94)
        Me.TXTBX_BeadAuto_SigmaYMax.Name = "TXTBX_BeadAuto_SigmaYMax"
        Me.TXTBX_BeadAuto_SigmaYMax.Size = New System.Drawing.Size(36, 20)
        Me.TXTBX_BeadAuto_SigmaYMax.TabIndex = 117
        Me.TXTBX_BeadAuto_SigmaYMax.Text = "2.5"
        '
        'TXTBX_BeadAUto_Chi2Min
        '
        Me.TXTBX_BeadAUto_Chi2Min.Location = New System.Drawing.Point(227, 58)
        Me.TXTBX_BeadAUto_Chi2Min.Name = "TXTBX_BeadAUto_Chi2Min"
        Me.TXTBX_BeadAUto_Chi2Min.Size = New System.Drawing.Size(36, 20)
        Me.TXTBX_BeadAUto_Chi2Min.TabIndex = 112
        Me.TXTBX_BeadAUto_Chi2Min.Text = "0.8"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(191, 61)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(31, 13)
        Me.Label29.TabIndex = 108
        Me.Label29.Text = "Chi2 "
        '
        'TXTBX_BeadAuto_SigmaXMin
        '
        Me.TXTBX_BeadAuto_SigmaXMin.Location = New System.Drawing.Point(227, 75)
        Me.TXTBX_BeadAuto_SigmaXMin.Name = "TXTBX_BeadAuto_SigmaXMin"
        Me.TXTBX_BeadAuto_SigmaXMin.Size = New System.Drawing.Size(36, 20)
        Me.TXTBX_BeadAuto_SigmaXMin.TabIndex = 115
        Me.TXTBX_BeadAuto_SigmaXMin.Text = "1.4"
        '
        'TXTBX_BeadAuto_SigmaYMin
        '
        Me.TXTBX_BeadAuto_SigmaYMin.Location = New System.Drawing.Point(227, 94)
        Me.TXTBX_BeadAuto_SigmaYMin.Name = "TXTBX_BeadAuto_SigmaYMin"
        Me.TXTBX_BeadAuto_SigmaYMin.Size = New System.Drawing.Size(36, 20)
        Me.TXTBX_BeadAuto_SigmaYMin.TabIndex = 116
        Me.TXTBX_BeadAuto_SigmaYMin.Text = "1.4"
        '
        'TXTBX_BeadAuto_SigmaXMax
        '
        Me.TXTBX_BeadAuto_SigmaXMax.Location = New System.Drawing.Point(269, 75)
        Me.TXTBX_BeadAuto_SigmaXMax.Name = "TXTBX_BeadAuto_SigmaXMax"
        Me.TXTBX_BeadAuto_SigmaXMax.Size = New System.Drawing.Size(36, 20)
        Me.TXTBX_BeadAuto_SigmaXMax.TabIndex = 114
        Me.TXTBX_BeadAuto_SigmaXMax.Text = "2.5"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.LW_ROIlist)
        Me.GroupBox7.Location = New System.Drawing.Point(264, 25)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(325, 237)
        Me.GroupBox7.TabIndex = 53
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "ROI Definition "
        '
        'LW_ROIlist
        '
        Me.LW_ROIlist.BackColor = System.Drawing.Color.AliceBlue
        Me.LW_ROIlist.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LW_ROIlist.Location = New System.Drawing.Point(6, 19)
        Me.LW_ROIlist.Name = "LW_ROIlist"
        Me.LW_ROIlist.Size = New System.Drawing.Size(313, 212)
        Me.LW_ROIlist.TabIndex = 43
        Me.LW_ROIlist.UseCompatibleStateImageBehavior = False
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Label12)
        Me.GroupBox11.Controls.Add(Me.CKBX_soSPIMFOCUS)
        Me.GroupBox11.Controls.Add(Me.TXTBX_precision)
        Me.GroupBox11.Controls.Add(Me.Label5)
        Me.GroupBox11.Controls.Add(Me.Label11)
        Me.GroupBox11.Controls.Add(Me.TXTBX_DzFocus)
        Me.GroupBox11.Controls.Add(Me.TXTBX_ZStreamStep)
        Me.GroupBox11.Controls.Add(Me.Label8)
        Me.GroupBox11.Controls.Add(Me.TXBX_NbrPlaneZStack)
        Me.GroupBox11.Location = New System.Drawing.Point(25, 242)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(224, 175)
        Me.GroupBox11.TabIndex = 52
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Z Stack Settings"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Label20)
        Me.GroupBox10.Controls.Add(Me.Button3)
        Me.GroupBox10.Controls.Add(Me.CKBX_MultiPlanePreviewWT)
        Me.GroupBox10.Controls.Add(Me.Button5)
        Me.GroupBox10.Controls.Add(Me.BNT_MultiplaneGetROI)
        Me.GroupBox10.Controls.Add(Me.TXTBX_Multiplane_GaussianfitSize)
        Me.GroupBox10.Controls.Add(Me.BTN_MultiplaneAutoThresh)
        Me.GroupBox10.Controls.Add(Me.TXBX_Multiplane_WTThresh)
        Me.GroupBox10.Controls.Add(Me.Label33)
        Me.GroupBox10.Location = New System.Drawing.Point(25, 21)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(224, 215)
        Me.GroupBox10.TabIndex = 1
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "ROI Definition"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(29, 95)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(88, 13)
        Me.Label20.TabIndex = 97
        Me.Label20.Text = "Guassian Fit Size"
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.ZStack.My.Resources.Resources.preview_on
        Me.Button3.Enabled = False
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(90, 64)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(25, 20)
        Me.Button3.TabIndex = 96
        Me.Button3.UseVisualStyleBackColor = True
        '
        'CKBX_MultiPlanePreviewWT
        '
        Me.CKBX_MultiPlanePreviewWT.AutoSize = True
        Me.CKBX_MultiPlanePreviewWT.Location = New System.Drawing.Point(32, 67)
        Me.CKBX_MultiPlanePreviewWT.Name = "CKBX_MultiPlanePreviewWT"
        Me.CKBX_MultiPlanePreviewWT.Size = New System.Drawing.Size(64, 17)
        Me.CKBX_MultiPlanePreviewWT.TabIndex = 47
        Me.CKBX_MultiPlanePreviewWT.Text = "Preview"
        Me.CKBX_MultiPlanePreviewWT.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(90, 172)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(58, 23)
        Me.Button5.TabIndex = 97
        Me.Button5.Text = "drift test"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'BNT_MultiplaneGetROI
        '
        Me.BNT_MultiplaneGetROI.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BNT_MultiplaneGetROI.FlatAppearance.BorderSize = 3
        Me.BNT_MultiplaneGetROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BNT_MultiplaneGetROI.Location = New System.Drawing.Point(56, 134)
        Me.BNT_MultiplaneGetROI.Name = "BNT_MultiplaneGetROI"
        Me.BNT_MultiplaneGetROI.Size = New System.Drawing.Size(122, 33)
        Me.BNT_MultiplaneGetROI.TabIndex = 41
        Me.BNT_MultiplaneGetROI.Text = "Get ROI"
        Me.BNT_MultiplaneGetROI.UseVisualStyleBackColor = True
        '
        'TXTBX_Multiplane_GaussianfitSize
        '
        Me.TXTBX_Multiplane_GaussianfitSize.Location = New System.Drawing.Point(123, 92)
        Me.TXTBX_Multiplane_GaussianfitSize.Name = "TXTBX_Multiplane_GaussianfitSize"
        Me.TXTBX_Multiplane_GaussianfitSize.Size = New System.Drawing.Size(38, 20)
        Me.TXTBX_Multiplane_GaussianfitSize.TabIndex = 47
        Me.TXTBX_Multiplane_GaussianfitSize.Text = "9"
        '
        'BTN_MultiplaneAutoThresh
        '
        Me.BTN_MultiplaneAutoThresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_MultiplaneAutoThresh.Location = New System.Drawing.Point(152, 31)
        Me.BTN_MultiplaneAutoThresh.Name = "BTN_MultiplaneAutoThresh"
        Me.BTN_MultiplaneAutoThresh.Size = New System.Drawing.Size(42, 25)
        Me.BTN_MultiplaneAutoThresh.TabIndex = 44
        Me.BTN_MultiplaneAutoThresh.Text = "Auto"
        Me.BTN_MultiplaneAutoThresh.UseVisualStyleBackColor = True
        '
        'TXBX_Multiplane_WTThresh
        '
        Me.TXBX_Multiplane_WTThresh.Location = New System.Drawing.Point(89, 34)
        Me.TXBX_Multiplane_WTThresh.Name = "TXBX_Multiplane_WTThresh"
        Me.TXBX_Multiplane_WTThresh.Size = New System.Drawing.Size(53, 20)
        Me.TXBX_Multiplane_WTThresh.TabIndex = 39
        Me.TXBX_Multiplane_WTThresh.Text = "100"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(29, 37)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(54, 13)
        Me.Label33.TabIndex = 40
        Me.Label33.Text = "Threshold"
        '
        'BTN_GoToPlane
        '
        Me.BTN_GoToPlane.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_GoToPlane.Location = New System.Drawing.Point(595, 166)
        Me.BTN_GoToPlane.Name = "BTN_GoToPlane"
        Me.BTN_GoToPlane.Size = New System.Drawing.Size(42, 22)
        Me.BTN_GoToPlane.TabIndex = 42
        Me.BTN_GoToPlane.Text = "Go"
        Me.BTN_GoToPlane.UseVisualStyleBackColor = True
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.GroupBox5)
        Me.TabPage8.Controls.Add(Me.BTN_StartStreamBeadAuto)
        Me.TabPage8.Controls.Add(Me.GroupBox3)
        Me.TabPage8.Controls.Add(Me.Label2)
        Me.TabPage8.Controls.Add(Me.BTN_StartStreamAcq)
        Me.TabPage8.Controls.Add(Me.GroupBox12)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(651, 437)
        Me.TabPage8.TabIndex = 6
        Me.TabPage8.Text = "Summary"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CKBX_StreamToRAM)
        Me.GroupBox5.Controls.Add(Me.RBTN_SingleStream)
        Me.GroupBox5.Controls.Add(Me.TXTBX_nbrStreamFrame)
        Me.GroupBox5.Controls.Add(Me.LBL_TotalSectionning)
        Me.GroupBox5.Controls.Add(Me.Label32)
        Me.GroupBox5.Controls.Add(Me.RBTN_Sectionning)
        Me.GroupBox5.Controls.Add(Me.TXTBX_nbrBinning)
        Me.GroupBox5.Controls.Add(Me.Label35)
        Me.GroupBox5.Controls.Add(Me.Label37)
        Me.GroupBox5.Controls.Add(Me.TXTBX_StreamBinning)
        Me.GroupBox5.Location = New System.Drawing.Point(22, 235)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(398, 127)
        Me.GroupBox5.TabIndex = 60
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Stream Acquisition"
        '
        'CKBX_StreamToRAM
        '
        Me.CKBX_StreamToRAM.AutoSize = True
        Me.CKBX_StreamToRAM.Checked = True
        Me.CKBX_StreamToRAM.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CKBX_StreamToRAM.Location = New System.Drawing.Point(6, 107)
        Me.CKBX_StreamToRAM.Name = "CKBX_StreamToRAM"
        Me.CKBX_StreamToRAM.Size = New System.Drawing.Size(98, 17)
        Me.CKBX_StreamToRAM.TabIndex = 62
        Me.CKBX_StreamToRAM.Text = "Stream to RAM"
        Me.CKBX_StreamToRAM.UseVisualStyleBackColor = True
        '
        'RBTN_SingleStream
        '
        Me.RBTN_SingleStream.AutoSize = True
        Me.RBTN_SingleStream.Location = New System.Drawing.Point(237, 27)
        Me.RBTN_SingleStream.Name = "RBTN_SingleStream"
        Me.RBTN_SingleStream.Size = New System.Drawing.Size(90, 17)
        Me.RBTN_SingleStream.TabIndex = 61
        Me.RBTN_SingleStream.Text = "Single Stream"
        Me.RBTN_SingleStream.UseVisualStyleBackColor = True
        '
        'TXTBX_nbrStreamFrame
        '
        Me.TXTBX_nbrStreamFrame.Enabled = False
        Me.TXTBX_nbrStreamFrame.Location = New System.Drawing.Point(308, 61)
        Me.TXTBX_nbrStreamFrame.Name = "TXTBX_nbrStreamFrame"
        Me.TXTBX_nbrStreamFrame.Size = New System.Drawing.Size(52, 20)
        Me.TXTBX_nbrStreamFrame.TabIndex = 53
        Me.TXTBX_nbrStreamFrame.Text = "4000"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(27, 57)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(75, 13)
        Me.Label32.TabIndex = 58
        Me.Label32.Text = "Frame/section"
        '
        'RBTN_Sectionning
        '
        Me.RBTN_Sectionning.AutoSize = True
        Me.RBTN_Sectionning.Checked = True
        Me.RBTN_Sectionning.Location = New System.Drawing.Point(13, 27)
        Me.RBTN_Sectionning.Name = "RBTN_Sectionning"
        Me.RBTN_Sectionning.Size = New System.Drawing.Size(168, 17)
        Me.RBTN_Sectionning.TabIndex = 51
        Me.RBTN_Sectionning.TabStop = True
        Me.RBTN_Sectionning.Text = "Sectionning - Serie Acquisition"
        Me.RBTN_Sectionning.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(26, 83)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(76, 13)
        Me.Label35.TabIndex = 57
        Me.Label35.Text = "nbr of sections"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(234, 64)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(68, 13)
        Me.Label37.TabIndex = 54
        Me.Label37.Text = "nbr of frames"
        '
        'BTN_StartStreamBeadAuto
        '
        Me.BTN_StartStreamBeadAuto.FlatAppearance.BorderColor = System.Drawing.Color.Orange
        Me.BTN_StartStreamBeadAuto.FlatAppearance.BorderSize = 2
        Me.BTN_StartStreamBeadAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_StartStreamBeadAuto.Location = New System.Drawing.Point(221, 385)
        Me.BTN_StartStreamBeadAuto.Name = "BTN_StartStreamBeadAuto"
        Me.BTN_StartStreamBeadAuto.Size = New System.Drawing.Size(163, 49)
        Me.BTN_StartStreamBeadAuto.TabIndex = 61
        Me.BTN_StartStreamBeadAuto.Text = "Z stream AutoBead"
        Me.BTN_StartStreamBeadAuto.UseVisualStyleBackColor = True
        Me.BTN_StartStreamBeadAuto.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button20)
        Me.GroupBox3.Controls.Add(Me.TXTBX_ReferencesAvg)
        Me.GroupBox3.Controls.Add(Me.Label41)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.RBTN_RegOnlineAcq)
        Me.GroupBox3.Controls.Add(Me.RBTN_RegBinningAcq)
        Me.GroupBox3.Controls.Add(Me.TXTBX_Binning)
        Me.GroupBox3.Location = New System.Drawing.Point(22, 146)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(398, 83)
        Me.GroupBox3.TabIndex = 55
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Registration mode"
        '
        'Button20
        '
        Me.Button20.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button20.BackgroundImage = CType(resources.GetObject("Button20.BackgroundImage"), System.Drawing.Image)
        Me.Button20.FlatAppearance.BorderSize = 0
        Me.Button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button20.Location = New System.Drawing.Point(353, 56)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(11, 11)
        Me.Button20.TabIndex = 125
        Me.ToolTipZTrack.SetToolTip(Me.Button20, "Number of frame the reference will be averaged. Depends on your SNR.")
        Me.Button20.UseVisualStyleBackColor = False
        '
        'TXTBX_ReferencesAvg
        '
        Me.TXTBX_ReferencesAvg.Location = New System.Drawing.Point(295, 52)
        Me.TXTBX_ReferencesAvg.Name = "TXTBX_ReferencesAvg"
        Me.TXTBX_ReferencesAvg.Size = New System.Drawing.Size(52, 20)
        Me.TXTBX_ReferencesAvg.TabIndex = 58
        Me.TXTBX_ReferencesAvg.Text = "15"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(145, 55)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(135, 13)
        Me.Label41.TabIndex = 57
        Me.Label41.Text = "Average Reference (frame)"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(163, 29)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(117, 13)
        Me.Label27.TabIndex = 56
        Me.Label27.Text = "Registration dist (frame)"
        '
        'RBTN_RegOnlineAcq
        '
        Me.RBTN_RegOnlineAcq.AutoSize = True
        Me.RBTN_RegOnlineAcq.Location = New System.Drawing.Point(26, 55)
        Me.RBTN_RegOnlineAcq.Name = "RBTN_RegOnlineAcq"
        Me.RBTN_RegOnlineAcq.Size = New System.Drawing.Size(117, 17)
        Me.RBTN_RegOnlineAcq.TabIndex = 52
        Me.RBTN_RegOnlineAcq.Text = "Registration Online "
        Me.RBTN_RegOnlineAcq.UseVisualStyleBackColor = True
        '
        'RBTN_RegBinningAcq
        '
        Me.RBTN_RegBinningAcq.AutoSize = True
        Me.RBTN_RegBinningAcq.Checked = True
        Me.RBTN_RegBinningAcq.Location = New System.Drawing.Point(26, 26)
        Me.RBTN_RegBinningAcq.Name = "RBTN_RegBinningAcq"
        Me.RBTN_RegBinningAcq.Size = New System.Drawing.Size(118, 17)
        Me.RBTN_RegBinningAcq.TabIndex = 52
        Me.RBTN_RegBinningAcq.TabStop = True
        Me.RBTN_RegBinningAcq.Text = "Registration binning"
        Me.RBTN_RegBinningAcq.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(96, 369)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(240, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Launch Stream Acqusition and fill the parameters."
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.NUD_TXTBX_regThreshZ_Min)
        Me.GroupBox12.Controls.Add(Me.NUD__regThreshXY_Min)
        Me.GroupBox12.Controls.Add(Me.Label23)
        Me.GroupBox12.Controls.Add(Me.Label22)
        Me.GroupBox12.Controls.Add(Me.Label39)
        Me.GroupBox12.Controls.Add(Me.TXTBX_slideWindow)
        Me.GroupBox12.Location = New System.Drawing.Point(22, 22)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(398, 120)
        Me.GroupBox12.TabIndex = 50
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Registration settings"
        '
        'NUD_TXTBX_regThreshZ_Min
        '
        Me.NUD_TXTBX_regThreshZ_Min.DecimalPlaces = 3
        Me.NUD_TXTBX_regThreshZ_Min.Increment = New Decimal(New Integer() {10, 0, 0, 196608})
        Me.NUD_TXTBX_regThreshZ_Min.Location = New System.Drawing.Point(247, 82)
        Me.NUD_TXTBX_regThreshZ_Min.Minimum = New Decimal(New Integer() {5, 0, 0, 131072})
        Me.NUD_TXTBX_regThreshZ_Min.Name = "NUD_TXTBX_regThreshZ_Min"
        Me.NUD_TXTBX_regThreshZ_Min.Size = New System.Drawing.Size(55, 20)
        Me.NUD_TXTBX_regThreshZ_Min.TabIndex = 62
        Me.NUD_TXTBX_regThreshZ_Min.Value = New Decimal(New Integer() {5, 0, 0, 131072})
        '
        'NUD__regThreshXY_Min
        '
        Me.NUD__regThreshXY_Min.DecimalPlaces = 3
        Me.NUD__regThreshXY_Min.Increment = New Decimal(New Integer() {10, 0, 0, 196608})
        Me.NUD__regThreshXY_Min.Location = New System.Drawing.Point(247, 52)
        Me.NUD__regThreshXY_Min.Minimum = New Decimal(New Integer() {5, 0, 0, 196608})
        Me.NUD__regThreshXY_Min.Name = "NUD__regThreshXY_Min"
        Me.NUD__regThreshXY_Min.Size = New System.Drawing.Size(55, 20)
        Me.NUD__regThreshXY_Min.TabIndex = 61
        Me.NUD__regThreshXY_Min.ThousandsSeparator = True
        Me.NUD__regThreshXY_Min.Value = New Decimal(New Integer() {6, 0, 0, 131072})
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(105, 84)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(130, 13)
        Me.Label23.TabIndex = 49
        Me.Label23.Text = "Registration if driftZ (um) >"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(99, 58)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(137, 13)
        Me.Label22.TabIndex = 48
        Me.Label22.Text = "Registration if driftXY (um) >"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(77, 29)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(158, 13)
        Me.Label39.TabIndex = 43
        Me.Label39.Text = "Average Sliding Window (frame)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(751, 274)
        Me.Label9.MaximumSize = New System.Drawing.Size(0, 215)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(222, 26)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "*se placer en haut de la bille et faire attention " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "au sens de la platine TiZ"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(385, 575)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(143, 23)
        Me.Button4.TabIndex = 96
        Me.Button4.Text = "Find billes stack"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(886, 48)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 98
        Me.Button6.Text = "PT test"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(886, 77)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 99
        Me.Button7.Text = "WT test"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(886, 106)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 100
        Me.Button8.Text = "sospim test"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(577, 559)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 104
        Me.Button10.Text = "snap jnl"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(577, 588)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(75, 23)
        Me.Button11.TabIndex = 105
        Me.Button11.Text = "snap test"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(874, 208)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(122, 23)
        Me.Button12.TabIndex = 106
        Me.Button12.Text = "Button12"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'TXTBX_BeadAuto
        '
        Me.TXTBX_BeadAuto.Location = New System.Drawing.Point(456, 549)
        Me.TXTBX_BeadAuto.Name = "TXTBX_BeadAuto"
        Me.TXTBX_BeadAuto.Size = New System.Drawing.Size(53, 20)
        Me.TXTBX_BeadAuto.TabIndex = 98
        Me.TXTBX_BeadAuto.Text = "1000"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(396, 552)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(54, 13)
        Me.Label28.TabIndex = 98
        Me.Label28.Text = "Threshold"
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(385, 604)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(143, 23)
        Me.Button13.TabIndex = 110
        Me.Button13.Text = "Find billes plane"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(10, 479)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(75, 23)
        Me.Button14.TabIndex = 111
        Me.Button14.Text = "Drift to Oxyz"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'LBL_BeadOrigin
        '
        Me.LBL_BeadOrigin.AutoSize = True
        Me.LBL_BeadOrigin.Location = New System.Drawing.Point(13, 505)
        Me.LBL_BeadOrigin.Name = "LBL_BeadOrigin"
        Me.LBL_BeadOrigin.Size = New System.Drawing.Size(127, 13)
        Me.LBL_BeadOrigin.TabIndex = 89
        Me.LBL_BeadOrigin.Text = "Coord O(x;y;z) : (0 ; 0 ; 0 )"
        '
        'TXTBX_BeadAuto_IntensityMax
        '
        Me.TXTBX_BeadAuto_IntensityMax.Enabled = False
        Me.TXTBX_BeadAuto_IntensityMax.Location = New System.Drawing.Point(617, 533)
        Me.TXTBX_BeadAuto_IntensityMax.Name = "TXTBX_BeadAuto_IntensityMax"
        Me.TXTBX_BeadAuto_IntensityMax.Size = New System.Drawing.Size(36, 20)
        Me.TXTBX_BeadAuto_IntensityMax.TabIndex = 119
        Me.TXTBX_BeadAuto_IntensityMax.Text = "20000"
        '
        'TXTBX_BeadAuto_IntensityMin
        '
        Me.TXTBX_BeadAuto_IntensityMin.Enabled = False
        Me.TXTBX_BeadAuto_IntensityMin.Location = New System.Drawing.Point(584, 533)
        Me.TXTBX_BeadAuto_IntensityMin.Name = "TXTBX_BeadAuto_IntensityMin"
        Me.TXTBX_BeadAuto_IntensityMin.Size = New System.Drawing.Size(36, 20)
        Me.TXTBX_BeadAuto_IntensityMin.TabIndex = 118
        Me.TXTBX_BeadAuto_IntensityMin.Text = "0"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Enabled = False
        Me.Label38.Location = New System.Drawing.Point(536, 536)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(46, 13)
        Me.Label38.TabIndex = 122
        Me.Label38.Text = "Intensity"
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(789, 343)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(122, 23)
        Me.Button15.TabIndex = 123
        Me.Button15.Text = "Button15"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'ToolTipZTrack
        '
        Me.ToolTipZTrack.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        '
        'TXTBX_ToleranceWTthresh
        '
        Me.TXTBX_ToleranceWTthresh.Location = New System.Drawing.Point(1184, 50)
        Me.TXTBX_ToleranceWTthresh.Name = "TXTBX_ToleranceWTthresh"
        Me.TXTBX_ToleranceWTthresh.Size = New System.Drawing.Size(100, 20)
        Me.TXTBX_ToleranceWTthresh.TabIndex = 124
        Me.TXTBX_ToleranceWTthresh.Text = "5"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(1181, 34)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(122, 13)
        Me.Label42.TabIndex = 125
        Me.Label42.Text = "Tolerance Threshold (%)"
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 478)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.TXTBX_ToleranceWTthresh)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.TXTBX_BeadAuto_IntensityMax)
        Me.Controls.Add(Me.TXTBX_BeadAuto_IntensityMin)
        Me.Controls.Add(Me.LBL_BeadOrigin)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.TXTBX_BeadAuto)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Tabmain)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CKBX_SingleStream)
        Me.Controls.Add(Me.TBCTRL_Stream)
        Me.Controls.Add(Me.CKBX_ZStack)
        Me.Controls.Add(Me.ListBox_UserPrograms)
        Me.Controls.Add(Me.CKBX_StageDisplacement)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainWindow"
        Me.Text = "ZTrack"
        Me.TopMost = True
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TBCTRL_Stream.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GBX_MCL.ResumeLayout(False)
        Me.GBX_MCL.PerformLayout()
        Me.Tabmain.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GB_DriftCorrectionType.ResumeLayout(False)
        Me.GB_DriftCorrectionType.PerformLayout()
        CType(Me.NUD_3DThicknessProcess, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_3DThickness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        CType(Me.NUD_TXTBX_regThreshZ_Min, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD__regThreshXY_Min, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TXTBX_WT_Threshold As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTN_GetROI As System.Windows.Forms.Button
    Friend WithEvents BTN_Calibration As System.Windows.Forms.Button
    Friend WithEvents BTN_PathROI As System.Windows.Forms.Button
    Friend WithEvents LBL_PathROI As System.Windows.Forms.Label
    Friend WithEvents TXTBX_Binning As System.Windows.Forms.TextBox
    Friend WithEvents CKBX_StageDisplacement As System.Windows.Forms.CheckBox
    Friend WithEvents TXTBX_slideWindow As System.Windows.Forms.TextBox
    Friend WithEvents CKBX_WT As System.Windows.Forms.CheckBox
    Friend WithEvents ListBox_UserPrograms As System.Windows.Forms.ListBox
    Friend WithEvents BTN_Autothreshold As System.Windows.Forms.Button
    Friend WithEvents CKBX_3Dastig As System.Windows.Forms.CheckBox
    Friend WithEvents CKBX_ZStack As System.Windows.Forms.CheckBox
    Friend WithEvents TXBX_NbrPlaneZStack As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BTN_CancelROIlist As System.Windows.Forms.Button
    Friend WithEvents BTN_AddROIlist As System.Windows.Forms.Button
    Friend WithEvents BTN_Save As System.Windows.Forms.Button
    Friend WithEvents BTN_Load As System.Windows.Forms.Button
    Friend WithEvents BTN_StartStreamAcq As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TXTBX_ZStreamStep As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TBCTRL_Stream As System.Windows.Forms.TabControl
    Friend WithEvents CKBX_JNL As System.Windows.Forms.CheckBox
    Friend WithEvents CKBX_AutoThreshPreview As System.Windows.Forms.CheckBox
    Friend WithEvents Timer_Preview As System.Windows.Forms.Timer
    Friend WithEvents BTN_MCLProductInfo As System.Windows.Forms.Button
    Friend WithEvents BTN_FocusJNL As System.Windows.Forms.Button
    Friend WithEvents CKBX_StreamSectionning As System.Windows.Forms.CheckBox
    Friend WithEvents TXTBX_StreamBinning As System.Windows.Forms.TextBox
    Friend WithEvents TXTBX_nbrBinning As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents LBL_TotalSectionning As System.Windows.Forms.Label
    Friend WithEvents BTN_SingleStream As System.Windows.Forms.Button
    Friend WithEvents CKBX_SingleStream As System.Windows.Forms.CheckBox
    Friend WithEvents TXTBX_DzFocus As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_precision As System.Windows.Forms.TextBox
    Friend WithEvents BTN_ROIPlaneUP As System.Windows.Forms.Button
    Friend WithEvents BTN_ROIPlane_Down As System.Windows.Forms.Button
    Friend WithEvents BTN_MCLCalibration As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_unit As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_Z As System.Windows.Forms.TextBox
    Friend WithEvents TXTBX_Y As System.Windows.Forms.TextBox
    Friend WithEvents TXTBX_X As System.Windows.Forms.TextBox
    Friend WithEvents BTN_StageX_Up As System.Windows.Forms.Button
    Friend WithEvents BTN_StageX_Down As System.Windows.Forms.Button
    Friend WithEvents BTN_StageY_Up As System.Windows.Forms.Button
    Friend WithEvents BTN_StageY_Down As System.Windows.Forms.Button
    Friend WithEvents BTN_StageZ_Up As System.Windows.Forms.Button
    Friend WithEvents BTN_StageZ_Down As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Timer_MCL As System.Windows.Forms.Timer
    Friend WithEvents GBX_MCL As System.Windows.Forms.GroupBox
    Friend WithEvents CKBX_soSPIMFOCUS As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Tabmain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents GB_DriftCorrectionType As System.Windows.Forms.GroupBox
    Friend WithEvents RBTN_NoDriftCorrection As System.Windows.Forms.RadioButton
    Friend WithEvents RBTN_2DDriftCorrection As System.Windows.Forms.RadioButton
    Friend WithEvents RBTN_3DDriftCorrection As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RBTN_isSinglePlane As System.Windows.Forms.RadioButton
    Friend WithEvents RBTN_isMultiplane As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTBX_GaussianFitSize As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents CKBX_MultiPlanePreviewWT As System.Windows.Forms.CheckBox
    Friend WithEvents BNT_MultiplaneGetROI As System.Windows.Forms.Button
    Friend WithEvents TXTBX_Multiplane_GaussianfitSize As System.Windows.Forms.TextBox
    Friend WithEvents BTN_MultiplaneAutoThresh As System.Windows.Forms.Button
    Friend WithEvents TXBX_Multiplane_WTThresh As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents TXTBX_nbrStreamFrame As System.Windows.Forms.TextBox
    Friend WithEvents RBTN_RegBinningAcq As System.Windows.Forms.RadioButton
    Friend WithEvents RBTN_Sectionning As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents LW_ROIlist As System.Windows.Forms.ListView
    Friend WithEvents BTN_GoToPlane As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents NUD_3DThickness As System.Windows.Forms.NumericUpDown
    Friend WithEvents NUD_3DThicknessProcess As System.Windows.Forms.NumericUpDown
    Friend WithEvents TXTBX_CalibrationXYumpxl As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BTN_Load3DCalibrationFile As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents CKBX_invertAxisXY As System.Windows.Forms.CheckBox
    Friend WithEvents BTN_StackZAcqu As Button
    Friend WithEvents TXTBX_StackZnbrStep As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Button10 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BTN_StackZStream As Button
    Friend WithEvents Label25 As Label
    Friend WithEvents TXTBX_DelayStackZ As TextBox
    Friend WithEvents Button12 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RBTN_RegOnlineAcq As RadioButton
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents RBTN_SingleStream As RadioButton
    Friend WithEvents Label27 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents NUD_TXTBX_regThreshZ_Min As NumericUpDown
    Friend WithEvents NUD__regThreshXY_Min As NumericUpDown
    Friend WithEvents TXTBX_BeadAuto As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Button13 As Button
    Friend WithEvents BTN_GetROI_well As Button
    Friend WithEvents BTN_StartStreamBeadAuto As Button
    Friend WithEvents CKBX_FindBeadStack As CheckBox
    Friend WithEvents CKBX_FindBeadAutoPlane As CheckBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents BTN_StackBeadAutoExtration As Button
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Button14 As Button
    Friend WithEvents LBL_BeadOrigin As Label
    Friend WithEvents TXTBX_BeadAUto_Chi2Max As TextBox
    Friend WithEvents TXTBX_BeadAuto_SigmaXMax As TextBox
    Friend WithEvents TXTBX_BeadAuto_SigmaXMin As TextBox
    Friend WithEvents TXTBX_BeadAuto_IntensityMax As TextBox
    Friend WithEvents TXTBX_BeadAuto_IntensityMin As TextBox
    Friend WithEvents TXTBX_BeadAuto_SigmaYMax As TextBox
    Friend WithEvents TXTBX_BeadAuto_SigmaYMin As TextBox
    Friend WithEvents TXTBX_BeadAUto_Chi2Min As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Button15 As Button
    Friend WithEvents CKBX_StreamToRAM As CheckBox
    Friend WithEvents TXTBX_ReferencesAvg As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents CKBX_AxisZinverted As CheckBox
    Friend WithEvents Button17 As Button
    Friend WithEvents ToolTipZTrack As ToolTip
    Friend WithEvents Button16 As Button
    Friend WithEvents Button18 As Button
    Friend WithEvents Button19 As Button
    Friend WithEvents Button20 As Button
    Friend WithEvents TXTBX_ToleranceWTthresh As TextBox
    Friend WithEvents Label42 As Label
End Class
