<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NouvelleGUI
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GBX_MCL = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TXTBX_unit = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.BTN_MCLProductInfo = New System.Windows.Forms.Button()
        Me.BTN_MCLCalibration = New System.Windows.Forms.Button()
        Me.TXTBX_X = New System.Windows.Forms.TextBox()
        Me.TXTBX_Y = New System.Windows.Forms.TextBox()
        Me.TXTBX_Z = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LBL_PathROI = New System.Windows.Forms.Label()
        Me.BTN_PathROI = New System.Windows.Forms.Button()
        Me.BTN_Calibration = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.CKBX_AutoThreshPreview = New System.Windows.Forms.CheckBox()
        Me.BTN_Autothreshold = New System.Windows.Forms.Button()
        Me.BTN_GetROI = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTBX_WT_Threshold = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.BTN_FocusJNL = New System.Windows.Forms.Button()
        Me.CKBX_Focus = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTBX_regThresh = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTBX_slideWindow = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTBX_Binning = New System.Windows.Forms.TextBox()
        Me.LBL_TotalSectionning = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTBX_StreamBinning = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTBX_nbrBinning = New System.Windows.Forms.TextBox()
        Me.RadioButton8 = New System.Windows.Forms.RadioButton()
        Me.RadioButton9 = New System.Windows.Forms.RadioButton()
        Me.BTN_StartStreamAcq = New System.Windows.Forms.Button()
        Me.CKBX_WT = New System.Windows.Forms.CheckBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTBX_precision = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTBX_DzFocus = New System.Windows.Forms.TextBox()
        Me.TXTBX_ZStreamStep = New System.Windows.Forms.TextBox()
        Me.TXBX_NbrPlaneZStack = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TXTBX_nbrStreamFrame = New System.Windows.Forms.TextBox()
        Me.CKBX_soSPIMFOCUS = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BTN_Load = New System.Windows.Forms.Button()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.LBX_Roilist = New System.Windows.Forms.ListBox()
        Me.BTN_StageZ_Up = New System.Windows.Forms.Button()
        Me.BTN_StageZ_Down = New System.Windows.Forms.Button()
        Me.BTN_StageY_Up = New System.Windows.Forms.Button()
        Me.BTN_StageY_Down = New System.Windows.Forms.Button()
        Me.BTN_StageX_Up = New System.Windows.Forms.Button()
        Me.BTN_StageX_Down = New System.Windows.Forms.Button()
        Me.BTN_ROIPlaneUP = New System.Windows.Forms.Button()
        Me.BTN_ROIPlane_Down = New System.Windows.Forms.Button()
        Me.BTN_CancelROIlist = New System.Windows.Forms.Button()
        Me.BTN_AddROIlist = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GBX_MCL.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Location = New System.Drawing.Point(29, 18)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(654, 455)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GBX_MCL)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(646, 429)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox8)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(646, 429)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Acquisition"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GBX_MCL
        '
        Me.GBX_MCL.Controls.Add(Me.TextBox1)
        Me.GBX_MCL.Controls.Add(Me.Button1)
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
        Me.GBX_MCL.Location = New System.Drawing.Point(20, 169)
        Me.GBX_MCL.Name = "GBX_MCL"
        Me.GBX_MCL.Size = New System.Drawing.Size(198, 245)
        Me.GBX_MCL.TabIndex = 91
        Me.GBX_MCL.TabStop = False
        Me.GBX_MCL.Text = "MadCityLab Control Tab "
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(41, 205)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(49, 20)
        Me.TextBox1.TabIndex = 90
        Me.TextBox1.Text = "10"
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(96, 203)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 22)
        Me.Button1.TabIndex = 89
        Me.Button1.TabStop = False
        Me.Button1.Text = "Monitor"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TXTBX_unit
        '
        Me.TXTBX_unit.Location = New System.Drawing.Point(96, 28)
        Me.TXTBX_unit.Name = "TXTBX_unit"
        Me.TXTBX_unit.Size = New System.Drawing.Size(64, 20)
        Me.TXTBX_unit.TabIndex = 80
        Me.TXTBX_unit.Text = "1"
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
        'BTN_MCLProductInfo
        '
        Me.BTN_MCLProductInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_MCLProductInfo.Location = New System.Drawing.Point(41, 176)
        Me.BTN_MCLProductInfo.Name = "BTN_MCLProductInfo"
        Me.BTN_MCLProductInfo.Size = New System.Drawing.Size(119, 23)
        Me.BTN_MCLProductInfo.TabIndex = 39
        Me.BTN_MCLProductInfo.Text = "MadCity device Info"
        Me.BTN_MCLProductInfo.UseVisualStyleBackColor = True
        '
        'BTN_MCLCalibration
        '
        Me.BTN_MCLCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_MCLCalibration.Location = New System.Drawing.Point(41, 147)
        Me.BTN_MCLCalibration.Name = "BTN_MCLCalibration"
        Me.BTN_MCLCalibration.Size = New System.Drawing.Size(119, 23)
        Me.BTN_MCLCalibration.TabIndex = 41
        Me.BTN_MCLCalibration.Text = "MCL Calibration"
        Me.BTN_MCLCalibration.UseVisualStyleBackColor = True
        '
        'TXTBX_X
        '
        Me.TXTBX_X.Location = New System.Drawing.Point(46, 60)
        Me.TXTBX_X.Name = "TXTBX_X"
        Me.TXTBX_X.Size = New System.Drawing.Size(58, 20)
        Me.TXTBX_X.TabIndex = 67
        '
        'TXTBX_Y
        '
        Me.TXTBX_Y.Location = New System.Drawing.Point(46, 90)
        Me.TXTBX_Y.Name = "TXTBX_Y"
        Me.TXTBX_Y.Size = New System.Drawing.Size(58, 20)
        Me.TXTBX_Y.TabIndex = 68
        '
        'TXTBX_Z
        '
        Me.TXTBX_Z.Location = New System.Drawing.Point(46, 118)
        Me.TXTBX_Z.Name = "TXTBX_Z"
        Me.TXTBX_Z.Size = New System.Drawing.Size(58, 20)
        Me.TXTBX_Z.TabIndex = 69
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(26, 63)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(14, 13)
        Me.Label16.TabIndex = 70
        Me.Label16.Text = "X"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(26, 92)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(14, 13)
        Me.Label15.TabIndex = 71
        Me.Label15.Text = "Y"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(26, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 81
        Me.Label13.Text = "unit of steps"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(26, 121)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(14, 13)
        Me.Label14.TabIndex = 72
        Me.Label14.Text = "Z"
        '
        'LBL_PathROI
        '
        Me.LBL_PathROI.AutoSize = True
        Me.LBL_PathROI.Location = New System.Drawing.Point(28, 34)
        Me.LBL_PathROI.MaximumSize = New System.Drawing.Size(0, 215)
        Me.LBL_PathROI.Name = "LBL_PathROI"
        Me.LBL_PathROI.Size = New System.Drawing.Size(71, 13)
        Me.LBL_PathROI.TabIndex = 90
        Me.LBL_PathROI.Text = "Path logFile : "
        '
        'BTN_PathROI
        '
        Me.BTN_PathROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BTN_PathROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_PathROI.Location = New System.Drawing.Point(126, 29)
        Me.BTN_PathROI.Name = "BTN_PathROI"
        Me.BTN_PathROI.Size = New System.Drawing.Size(37, 22)
        Me.BTN_PathROI.TabIndex = 89
        Me.BTN_PathROI.TabStop = False
        Me.BTN_PathROI.Text = " ..."
        Me.BTN_PathROI.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_PathROI.UseVisualStyleBackColor = True
        '
        'BTN_Calibration
        '
        Me.BTN_Calibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Calibration.Location = New System.Drawing.Point(39, 78)
        Me.BTN_Calibration.Name = "BTN_Calibration"
        Me.BTN_Calibration.Size = New System.Drawing.Size(123, 28)
        Me.BTN_Calibration.TabIndex = 88
        Me.BTN_Calibration.Text = "Calibration"
        Me.BTN_Calibration.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTN_Calibration)
        Me.GroupBox2.Controls.Add(Me.BTN_PathROI)
        Me.GroupBox2.Controls.Add(Me.LBL_PathROI)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 131)
        Me.GroupBox2.TabIndex = 92
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Global"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(33, 28)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(73, 17)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Mulitplane"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(33, 51)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(84, 17)
        Me.RadioButton2.TabIndex = 3
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Single Plane"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(18, 53)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(111, 17)
        Me.RadioButton5.TabIndex = 9
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "3D Drift correction"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(18, 30)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(174, 17)
        Me.RadioButton6.TabIndex = 8
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "2D Drift correction + AutoFocus"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CKBX_WT)
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Location = New System.Drawing.Point(21, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(211, 115)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Stream"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.RadioButton7)
        Me.GroupBox5.Controls.Add(Me.RadioButton6)
        Me.GroupBox5.Controls.Add(Me.RadioButton5)
        Me.GroupBox5.Location = New System.Drawing.Point(21, 141)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(211, 113)
        Me.GroupBox5.TabIndex = 12
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Drift Correction "
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox6)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(646, 429)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Single Plane"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox4)
        Me.TabPage4.Controls.Add(Me.GroupBox11)
        Me.TabPage4.Controls.Add(Me.GroupBox10)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(646, 429)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Multiplane"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.BTN_StartStreamAcq)
        Me.TabPage7.Controls.Add(Me.GroupBox9)
        Me.TabPage7.Controls.Add(Me.GroupBox7)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(646, 429)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Summary"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.Location = New System.Drawing.Point(18, 76)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(190, 17)
        Me.RadioButton7.TabIndex = 10
        Me.RadioButton7.TabStop = True
        Me.RadioButton7.Text = "No Drift correction (no stage move)"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.CKBX_AutoThreshPreview)
        Me.GroupBox6.Controls.Add(Me.CheckBox1)
        Me.GroupBox6.Controls.Add(Me.BTN_GetROI)
        Me.GroupBox6.Controls.Add(Me.TextBox2)
        Me.GroupBox6.Controls.Add(Me.BTN_Autothreshold)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.TXTBX_WT_Threshold)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Location = New System.Drawing.Point(18, 20)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(222, 194)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "ROI Definition"
        '
        'CKBX_AutoThreshPreview
        '
        Me.CKBX_AutoThreshPreview.AutoSize = True
        Me.CKBX_AutoThreshPreview.Location = New System.Drawing.Point(32, 67)
        Me.CKBX_AutoThreshPreview.Name = "CKBX_AutoThreshPreview"
        Me.CKBX_AutoThreshPreview.Size = New System.Drawing.Size(64, 17)
        Me.CKBX_AutoThreshPreview.TabIndex = 47
        Me.CKBX_AutoThreshPreview.Text = "Preview"
        Me.CKBX_AutoThreshPreview.UseVisualStyleBackColor = True
        '
        'BTN_Autothreshold
        '
        Me.BTN_Autothreshold.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Autothreshold.Location = New System.Drawing.Point(152, 31)
        Me.BTN_Autothreshold.Name = "BTN_Autothreshold"
        Me.BTN_Autothreshold.Size = New System.Drawing.Size(42, 25)
        Me.BTN_Autothreshold.TabIndex = 44
        Me.BTN_Autothreshold.Text = "Auto"
        Me.BTN_Autothreshold.UseVisualStyleBackColor = True
        '
        'BTN_GetROI
        '
        Me.BTN_GetROI.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.BTN_GetROI.FlatAppearance.BorderSize = 3
        Me.BTN_GetROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_GetROI.Location = New System.Drawing.Point(56, 134)
        Me.BTN_GetROI.Name = "BTN_GetROI"
        Me.BTN_GetROI.Size = New System.Drawing.Size(122, 33)
        Me.BTN_GetROI.TabIndex = 41
        Me.BTN_GetROI.Text = "Get ROI"
        Me.BTN_GetROI.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Threshold"
        '
        'TXTBX_WT_Threshold
        '
        Me.TXTBX_WT_Threshold.Location = New System.Drawing.Point(89, 34)
        Me.TXTBX_WT_Threshold.Name = "TXTBX_WT_Threshold"
        Me.TXTBX_WT_Threshold.Size = New System.Drawing.Size(53, 20)
        Me.TXTBX_WT_Threshold.TabIndex = 39
        Me.TXTBX_WT_Threshold.Text = "12"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(152, 88)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(38, 20)
        Me.TextBox2.TabIndex = 47
        Me.TextBox2.Text = "12"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(119, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Size"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(32, 90)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 48
        Me.CheckBox1.Text = "Gaussian fit"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.BTN_FocusJNL)
        Me.GroupBox8.Controls.Add(Me.CKBX_Focus)
        Me.GroupBox8.Location = New System.Drawing.Point(21, 260)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(211, 87)
        Me.GroupBox8.TabIndex = 12
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Journal"
        '
        'BTN_FocusJNL
        '
        Me.BTN_FocusJNL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BTN_FocusJNL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_FocusJNL.Location = New System.Drawing.Point(112, 35)
        Me.BTN_FocusJNL.Name = "BTN_FocusJNL"
        Me.BTN_FocusJNL.Size = New System.Drawing.Size(47, 22)
        Me.BTN_FocusJNL.TabIndex = 42
        Me.BTN_FocusJNL.TabStop = False
        Me.BTN_FocusJNL.Text = " ..."
        Me.BTN_FocusJNL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_FocusJNL.UseVisualStyleBackColor = True
        Me.BTN_FocusJNL.Visible = False
        '
        'CKBX_Focus
        '
        Me.CKBX_Focus.AutoSize = True
        Me.CKBX_Focus.Location = New System.Drawing.Point(43, 39)
        Me.CKBX_Focus.Name = "CKBX_Focus"
        Me.CKBX_Focus.Size = New System.Drawing.Size(63, 17)
        Me.CKBX_Focus.TabIndex = 41
        Me.CKBX_Focus.Text = " Journal"
        Me.CKBX_Focus.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label2)
        Me.GroupBox7.Controls.Add(Me.TXTBX_regThresh)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Controls.Add(Me.TXTBX_slideWindow)
        Me.GroupBox7.Location = New System.Drawing.Point(22, 22)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(398, 93)
        Me.GroupBox7.TabIndex = 50
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Registration settings"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(76, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Average Sliding Window (frame)"
        '
        'TXTBX_regThresh
        '
        Me.TXTBX_regThresh.Location = New System.Drawing.Point(240, 55)
        Me.TXTBX_regThresh.Name = "TXTBX_regThresh"
        Me.TXTBX_regThresh.Size = New System.Drawing.Size(54, 20)
        Me.TXTBX_regThresh.TabIndex = 45
        Me.TXTBX_regThresh.Text = "0,1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(134, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Reg Thresh (pxl)"
        '
        'TXTBX_slideWindow
        '
        Me.TXTBX_slideWindow.Location = New System.Drawing.Point(240, 31)
        Me.TXTBX_slideWindow.Name = "TXTBX_slideWindow"
        Me.TXTBX_slideWindow.Size = New System.Drawing.Size(54, 20)
        Me.TXTBX_slideWindow.TabIndex = 42
        Me.TXTBX_slideWindow.Text = "20"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.Label19)
        Me.GroupBox9.Controls.Add(Me.TXTBX_nbrStreamFrame)
        Me.GroupBox9.Controls.Add(Me.RadioButton8)
        Me.GroupBox9.Controls.Add(Me.RadioButton9)
        Me.GroupBox9.Controls.Add(Me.LBL_TotalSectionning)
        Me.GroupBox9.Controls.Add(Me.Label5)
        Me.GroupBox9.Controls.Add(Me.Label10)
        Me.GroupBox9.Controls.Add(Me.TXTBX_StreamBinning)
        Me.GroupBox9.Controls.Add(Me.TXTBX_Binning)
        Me.GroupBox9.Controls.Add(Me.Label9)
        Me.GroupBox9.Controls.Add(Me.TXTBX_nbrBinning)
        Me.GroupBox9.Location = New System.Drawing.Point(22, 121)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(398, 165)
        Me.GroupBox9.TabIndex = 51
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Registration mode"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(21, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Registration dist (frame)"
        '
        'TXTBX_Binning
        '
        Me.TXTBX_Binning.Enabled = False
        Me.TXTBX_Binning.Location = New System.Drawing.Point(144, 101)
        Me.TXTBX_Binning.Name = "TXTBX_Binning"
        Me.TXTBX_Binning.Size = New System.Drawing.Size(52, 20)
        Me.TXTBX_Binning.TabIndex = 13
        Me.TXTBX_Binning.Text = "1000"
        '
        'LBL_TotalSectionning
        '
        Me.LBL_TotalSectionning.AutoSize = True
        Me.LBL_TotalSectionning.Location = New System.Drawing.Point(239, 128)
        Me.LBL_TotalSectionning.Name = "LBL_TotalSectionning"
        Me.LBL_TotalSectionning.Size = New System.Drawing.Size(95, 13)
        Me.LBL_TotalSectionning.TabIndex = 50
        Me.LBL_TotalSectionning.Text = "Total of frames : 0 "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(239, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 13)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Frame/section"
        '
        'TXTBX_StreamBinning
        '
        Me.TXTBX_StreamBinning.Location = New System.Drawing.Point(320, 69)
        Me.TXTBX_StreamBinning.Name = "TXTBX_StreamBinning"
        Me.TXTBX_StreamBinning.Size = New System.Drawing.Size(51, 20)
        Me.TXTBX_StreamBinning.TabIndex = 46
        Me.TXTBX_StreamBinning.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(239, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "nbr of sections"
        '
        'TXTBX_nbrBinning
        '
        Me.TXTBX_nbrBinning.Location = New System.Drawing.Point(320, 95)
        Me.TXTBX_nbrBinning.Name = "TXTBX_nbrBinning"
        Me.TXTBX_nbrBinning.Size = New System.Drawing.Size(51, 20)
        Me.TXTBX_nbrBinning.TabIndex = 47
        Me.TXTBX_nbrBinning.Text = "0"
        '
        'RadioButton8
        '
        Me.RadioButton8.AutoSize = True
        Me.RadioButton8.Location = New System.Drawing.Point(30, 32)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(163, 17)
        Me.RadioButton8.TabIndex = 52
        Me.RadioButton8.TabStop = True
        Me.RadioButton8.Text = "Registraion during acquisition"
        Me.RadioButton8.UseVisualStyleBackColor = True
        '
        'RadioButton9
        '
        Me.RadioButton9.AutoSize = True
        Me.RadioButton9.Location = New System.Drawing.Point(242, 32)
        Me.RadioButton9.Name = "RadioButton9"
        Me.RadioButton9.Size = New System.Drawing.Size(81, 17)
        Me.RadioButton9.TabIndex = 51
        Me.RadioButton9.TabStop = True
        Me.RadioButton9.Text = "Sectionning"
        Me.RadioButton9.UseVisualStyleBackColor = True
        '
        'BTN_StartStreamAcq
        '
        Me.BTN_StartStreamAcq.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BTN_StartStreamAcq.FlatAppearance.BorderSize = 2
        Me.BTN_StartStreamAcq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_StartStreamAcq.Location = New System.Drawing.Point(141, 308)
        Me.BTN_StartStreamAcq.Name = "BTN_StartStreamAcq"
        Me.BTN_StartStreamAcq.Size = New System.Drawing.Size(155, 34)
        Me.BTN_StartStreamAcq.TabIndex = 52
        Me.BTN_StartStreamAcq.Text = "START"
        Me.BTN_StartStreamAcq.UseVisualStyleBackColor = True
        '
        'CKBX_WT
        '
        Me.CKBX_WT.AutoSize = True
        Me.CKBX_WT.Location = New System.Drawing.Point(33, 83)
        Me.CKBX_WT.Name = "CKBX_WT"
        Me.CKBX_WT.Size = New System.Drawing.Size(86, 17)
        Me.CKBX_WT.TabIndex = 17
        Me.CKBX_WT.Text = "WaveTracer"
        Me.CKBX_WT.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.CheckBox2)
        Me.GroupBox10.Controls.Add(Me.CheckBox3)
        Me.GroupBox10.Controls.Add(Me.Button2)
        Me.GroupBox10.Controls.Add(Me.TextBox3)
        Me.GroupBox10.Controls.Add(Me.Button3)
        Me.GroupBox10.Controls.Add(Me.Label6)
        Me.GroupBox10.Controls.Add(Me.TextBox4)
        Me.GroupBox10.Controls.Add(Me.Label7)
        Me.GroupBox10.Location = New System.Drawing.Point(25, 21)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(224, 194)
        Me.GroupBox10.TabIndex = 1
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "ROI Definition"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(32, 67)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(64, 17)
        Me.CheckBox2.TabIndex = 47
        Me.CheckBox2.Text = "Preview"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(32, 90)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox3.TabIndex = 48
        Me.CheckBox3.Text = "Gaussian fit"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.Button2.FlatAppearance.BorderSize = 3
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(56, 134)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(122, 33)
        Me.Button2.TabIndex = 41
        Me.Button2.Text = "Get ROI"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(152, 88)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(38, 20)
        Me.TextBox3.TabIndex = 47
        Me.TextBox3.Text = "12"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(152, 31)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(42, 25)
        Me.Button3.TabIndex = 44
        Me.Button3.Text = "Auto"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(119, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Size"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(89, 34)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(53, 20)
        Me.TextBox4.TabIndex = 39
        Me.TextBox4.Text = "12"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 37)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Threshold"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(66, 115)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "precision"
        '
        'TXTBX_precision
        '
        Me.TXTBX_precision.Location = New System.Drawing.Point(131, 115)
        Me.TXTBX_precision.Name = "TXTBX_precision"
        Me.TXTBX_precision.Size = New System.Drawing.Size(47, 20)
        Me.TXTBX_precision.TabIndex = 50
        Me.TXTBX_precision.Text = "0.05"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(66, 89)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 49
        Me.Label11.Text = "dZ (nm)"
        '
        'TXTBX_DzFocus
        '
        Me.TXTBX_DzFocus.Location = New System.Drawing.Point(131, 89)
        Me.TXTBX_DzFocus.Name = "TXTBX_DzFocus"
        Me.TXTBX_DzFocus.Size = New System.Drawing.Size(47, 20)
        Me.TXTBX_DzFocus.TabIndex = 48
        Me.TXTBX_DzFocus.Text = "1000"
        '
        'TXTBX_ZStreamStep
        '
        Me.TXTBX_ZStreamStep.Location = New System.Drawing.Point(131, 60)
        Me.TXTBX_ZStreamStep.Name = "TXTBX_ZStreamStep"
        Me.TXTBX_ZStreamStep.Size = New System.Drawing.Size(47, 20)
        Me.TXTBX_ZStreamStep.TabIndex = 46
        Me.TXTBX_ZStreamStep.Text = "5"
        '
        'TXBX_NbrPlaneZStack
        '
        Me.TXBX_NbrPlaneZStack.Location = New System.Drawing.Point(131, 32)
        Me.TXBX_NbrPlaneZStack.Name = "TXBX_NbrPlaneZStack"
        Me.TXBX_NbrPlaneZStack.Size = New System.Drawing.Size(47, 20)
        Me.TXBX_NbrPlaneZStack.TabIndex = 42
        Me.TXBX_NbrPlaneZStack.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(41, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Z step (offset)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(35, 35)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(78, 13)
        Me.Label18.TabIndex = 43
        Me.Label18.Text = "nbr of Z-planes"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.CKBX_soSPIMFOCUS)
        Me.GroupBox11.Controls.Add(Me.Label18)
        Me.GroupBox11.Controls.Add(Me.Label12)
        Me.GroupBox11.Controls.Add(Me.TXTBX_precision)
        Me.GroupBox11.Controls.Add(Me.Label11)
        Me.GroupBox11.Controls.Add(Me.Label8)
        Me.GroupBox11.Controls.Add(Me.TXTBX_DzFocus)
        Me.GroupBox11.Controls.Add(Me.TXBX_NbrPlaneZStack)
        Me.GroupBox11.Controls.Add(Me.TXTBX_ZStreamStep)
        Me.GroupBox11.Location = New System.Drawing.Point(25, 228)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(224, 178)
        Me.GroupBox11.TabIndex = 52
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Z Stack Settings"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(70, 75)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 13)
        Me.Label19.TabIndex = 54
        Me.Label19.Text = "nbr of frames"
        '
        'TXTBX_nbrStreamFrame
        '
        Me.TXTBX_nbrStreamFrame.Location = New System.Drawing.Point(144, 72)
        Me.TXTBX_nbrStreamFrame.Name = "TXTBX_nbrStreamFrame"
        Me.TXTBX_nbrStreamFrame.Size = New System.Drawing.Size(52, 20)
        Me.TXTBX_nbrStreamFrame.TabIndex = 53
        Me.TXTBX_nbrStreamFrame.Text = "4000"
        '
        'CKBX_soSPIMFOCUS
        '
        Me.CKBX_soSPIMFOCUS.AutoSize = True
        Me.CKBX_soSPIMFOCUS.Location = New System.Drawing.Point(69, 145)
        Me.CKBX_soSPIMFOCUS.Name = "CKBX_soSPIMFOCUS"
        Me.CKBX_soSPIMFOCUS.Size = New System.Drawing.Size(98, 17)
        Me.CKBX_soSPIMFOCUS.TabIndex = 89
        Me.CKBX_soSPIMFOCUS.Text = "soSPIM_Focus"
        Me.CKBX_soSPIMFOCUS.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.LBX_Roilist)
        Me.GroupBox4.Controls.Add(Me.Button4)
        Me.GroupBox4.Controls.Add(Me.BTN_ROIPlaneUP)
        Me.GroupBox4.Controls.Add(Me.BTN_ROIPlane_Down)
        Me.GroupBox4.Controls.Add(Me.BTN_Load)
        Me.GroupBox4.Controls.Add(Me.BTN_Save)
        Me.GroupBox4.Controls.Add(Me.BTN_CancelROIlist)
        Me.GroupBox4.Controls.Add(Me.BTN_AddROIlist)
        Me.GroupBox4.Location = New System.Drawing.Point(264, 25)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(359, 381)
        Me.GroupBox4.TabIndex = 53
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "ROI Definition "
        '
        'BTN_Load
        '
        Me.BTN_Load.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Load.Location = New System.Drawing.Point(301, 294)
        Me.BTN_Load.Name = "BTN_Load"
        Me.BTN_Load.Size = New System.Drawing.Size(42, 22)
        Me.BTN_Load.TabIndex = 39
        Me.BTN_Load.Text = "Load"
        Me.BTN_Load.UseVisualStyleBackColor = True
        '
        'BTN_Save
        '
        Me.BTN_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Save.Location = New System.Drawing.Point(301, 322)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(42, 22)
        Me.BTN_Save.TabIndex = 38
        Me.BTN_Save.Text = "Save"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(301, 266)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(42, 22)
        Me.Button4.TabIndex = 42
        Me.Button4.Text = "Go"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'LBX_Roilist
        '
        Me.LBX_Roilist.BackColor = System.Drawing.Color.AliceBlue
        Me.LBX_Roilist.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz
        Me.LBX_Roilist.FormattingEnabled = True
        Me.LBX_Roilist.Location = New System.Drawing.Point(15, 23)
        Me.LBX_Roilist.Name = "LBX_Roilist"
        Me.LBX_Roilist.Size = New System.Drawing.Size(270, 342)
        Me.LBX_Roilist.TabIndex = 43
        '
        'BTN_StageZ_Up
        '
        Me.BTN_StageZ_Up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_StageZ_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_StageZ_Up.Image = Global.ZStack.My.Resources.Resources.up51
        Me.BTN_StageZ_Up.Location = New System.Drawing.Point(110, 121)
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
        Me.BTN_StageZ_Down.Location = New System.Drawing.Point(135, 121)
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
        Me.BTN_StageY_Up.Location = New System.Drawing.Point(110, 93)
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
        Me.BTN_StageY_Down.Location = New System.Drawing.Point(135, 93)
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
        Me.BTN_StageX_Up.Location = New System.Drawing.Point(110, 63)
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
        Me.BTN_StageX_Down.Location = New System.Drawing.Point(135, 63)
        Me.BTN_StageX_Down.Name = "BTN_StageX_Down"
        Me.BTN_StageX_Down.Size = New System.Drawing.Size(25, 13)
        Me.BTN_StageX_Down.TabIndex = 37
        Me.BTN_StageX_Down.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_StageX_Down.UseVisualStyleBackColor = True
        '
        'BTN_ROIPlaneUP
        '
        Me.BTN_ROIPlaneUP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_ROIPlaneUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_ROIPlaneUP.Image = Global.ZStack.My.Resources.Resources.up2
        Me.BTN_ROIPlaneUP.Location = New System.Drawing.Point(312, 106)
        Me.BTN_ROIPlaneUP.Name = "BTN_ROIPlaneUP"
        Me.BTN_ROIPlaneUP.Size = New System.Drawing.Size(21, 18)
        Me.BTN_ROIPlaneUP.TabIndex = 40
        Me.BTN_ROIPlaneUP.UseVisualStyleBackColor = True
        '
        'BTN_ROIPlane_Down
        '
        Me.BTN_ROIPlane_Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_ROIPlane_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_ROIPlane_Down.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ROIPlane_Down.Image = Global.ZStack.My.Resources.Resources.down21
        Me.BTN_ROIPlane_Down.Location = New System.Drawing.Point(312, 130)
        Me.BTN_ROIPlane_Down.Name = "BTN_ROIPlane_Down"
        Me.BTN_ROIPlane_Down.Size = New System.Drawing.Size(21, 18)
        Me.BTN_ROIPlane_Down.TabIndex = 41
        Me.BTN_ROIPlane_Down.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_ROIPlane_Down.UseVisualStyleBackColor = True
        '
        'BTN_CancelROIlist
        '
        Me.BTN_CancelROIlist.BackgroundImage = Global.ZStack.My.Resources.Resources.surouge3
        Me.BTN_CancelROIlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_CancelROIlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CancelROIlist.Location = New System.Drawing.Point(312, 54)
        Me.BTN_CancelROIlist.Name = "BTN_CancelROIlist"
        Me.BTN_CancelROIlist.Size = New System.Drawing.Size(21, 18)
        Me.BTN_CancelROIlist.TabIndex = 36
        Me.BTN_CancelROIlist.UseVisualStyleBackColor = True
        '
        'BTN_AddROIlist
        '
        Me.BTN_AddROIlist.BackgroundImage = Global.ZStack.My.Resources.Resources.plu3
        Me.BTN_AddROIlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BTN_AddROIlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_AddROIlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_AddROIlist.Location = New System.Drawing.Point(312, 78)
        Me.BTN_AddROIlist.Name = "BTN_AddROIlist"
        Me.BTN_AddROIlist.Size = New System.Drawing.Size(21, 18)
        Me.BTN_AddROIlist.TabIndex = 37
        Me.BTN_AddROIlist.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTN_AddROIlist.UseVisualStyleBackColor = True
        '
        'NouvelleGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 485)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "NouvelleGUI"
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GBX_MCL.ResumeLayout(False)
        Me.GBX_MCL.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BTN_Calibration As System.Windows.Forms.Button
    Friend WithEvents BTN_PathROI As System.Windows.Forms.Button
    Friend WithEvents LBL_PathROI As System.Windows.Forms.Label
    Friend WithEvents GBX_MCL As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TXTBX_unit As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents BTN_MCLProductInfo As System.Windows.Forms.Button
    Friend WithEvents BTN_StageZ_Up As System.Windows.Forms.Button
    Friend WithEvents BTN_MCLCalibration As System.Windows.Forms.Button
    Friend WithEvents BTN_StageZ_Down As System.Windows.Forms.Button
    Friend WithEvents TXTBX_X As System.Windows.Forms.TextBox
    Friend WithEvents BTN_StageY_Up As System.Windows.Forms.Button
    Friend WithEvents TXTBX_Y As System.Windows.Forms.TextBox
    Friend WithEvents BTN_StageY_Down As System.Windows.Forms.Button
    Friend WithEvents TXTBX_Z As System.Windows.Forms.TextBox
    Friend WithEvents BTN_StageX_Up As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BTN_StageX_Down As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents CKBX_AutoThreshPreview As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents BTN_GetROI As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents BTN_Autothreshold As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_WT_Threshold As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTN_FocusJNL As System.Windows.Forms.Button
    Friend WithEvents CKBX_Focus As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_regThresh As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_slideWindow As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_Binning As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton9 As System.Windows.Forms.RadioButton
    Friend WithEvents LBL_TotalSectionning As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_StreamBinning As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_nbrBinning As System.Windows.Forms.TextBox
    Friend WithEvents BTN_StartStreamAcq As System.Windows.Forms.Button
    Friend WithEvents CKBX_WT As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_precision As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_DzFocus As System.Windows.Forms.TextBox
    Friend WithEvents TXBX_NbrPlaneZStack As System.Windows.Forms.TextBox
    Friend WithEvents TXTBX_ZStreamStep As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_nbrStreamFrame As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CKBX_soSPIMFOCUS As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents BTN_ROIPlaneUP As System.Windows.Forms.Button
    Friend WithEvents BTN_ROIPlane_Down As System.Windows.Forms.Button
    Friend WithEvents BTN_Load As System.Windows.Forms.Button
    Friend WithEvents BTN_Save As System.Windows.Forms.Button
    Friend WithEvents BTN_CancelROIlist As System.Windows.Forms.Button
    Friend WithEvents BTN_AddROIlist As System.Windows.Forms.Button
    Friend WithEvents LBX_Roilist As System.Windows.Forms.ListBox
End Class
