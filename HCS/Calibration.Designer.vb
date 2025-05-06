<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Calibration
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Calibration))
        Me.BTN_SaveCalib = New System.Windows.Forms.Button()
        Me.BTN_LoadCalib = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.BTN_ROI4 = New System.Windows.Forms.Button()
        Me.BTN_TestCalib = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CKBX_CalibOK_4 = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BTN_Calib = New System.Windows.Forms.Button()
        Me.BTN_ROI3 = New System.Windows.Forms.Button()
        Me.BTN_ROI2 = New System.Windows.Forms.Button()
        Me.BTN_ROI1 = New System.Windows.Forms.Button()
        Me.CKBX_CalibOK_3 = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CKBX_CalibOK_2 = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CKBX_CalibOK_1 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CMBX_PreScreen_CalibObj = New System.Windows.Forms.ComboBox()
        Me.CMBX_updown = New System.Windows.Forms.ComboBox()
        Me.CMBX_LeftRight = New System.Windows.Forms.ComboBox()
        Me.LBL_Track = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTBX_DeltaY = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTBX_DeltaX = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.MyToolTypeCalib = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label36 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.BTN_CS_Start = New System.Windows.Forms.Button()
        Me.BTN_CS_Next = New System.Windows.Forms.Button()
        Me.LBL_CS_CoefX = New System.Windows.Forms.Label()
        Me.BTN_CS_Test = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.LBL_CS_CoefY = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.BTN_CS_Validation = New System.Windows.Forms.Button()
        Me.BTN_CS_Previous = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.MyTabControl = New System.Windows.Forms.TabControl()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.MyTabControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTN_SaveCalib
        '
        Me.BTN_SaveCalib.BackColor = System.Drawing.Color.Azure
        Me.BTN_SaveCalib.Location = New System.Drawing.Point(182, 254)
        Me.BTN_SaveCalib.Name = "BTN_SaveCalib"
        Me.BTN_SaveCalib.Size = New System.Drawing.Size(75, 27)
        Me.BTN_SaveCalib.TabIndex = 25
        Me.BTN_SaveCalib.Text = "Save..."
        Me.BTN_SaveCalib.UseVisualStyleBackColor = False
        '
        'BTN_LoadCalib
        '
        Me.BTN_LoadCalib.BackColor = System.Drawing.Color.Azure
        Me.BTN_LoadCalib.Location = New System.Drawing.Point(71, 254)
        Me.BTN_LoadCalib.Name = "BTN_LoadCalib"
        Me.BTN_LoadCalib.Size = New System.Drawing.Size(75, 27)
        Me.BTN_LoadCalib.TabIndex = 24
        Me.BTN_LoadCalib.Text = "Load..."
        Me.BTN_LoadCalib.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BTN_ROI4)
        Me.GroupBox4.Controls.Add(Me.BTN_TestCalib)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.CKBX_CalibOK_4)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Location = New System.Drawing.Point(626, 333)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(288, 43)
        Me.GroupBox4.TabIndex = 23
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Test "
        Me.GroupBox4.Visible = False
        '
        'BTN_ROI4
        '
        Me.BTN_ROI4.Location = New System.Drawing.Point(70, 14)
        Me.BTN_ROI4.Name = "BTN_ROI4"
        Me.BTN_ROI4.Size = New System.Drawing.Size(54, 21)
        Me.BTN_ROI4.TabIndex = 25
        Me.BTN_ROI4.Text = "ROI-4"
        Me.BTN_ROI4.UseVisualStyleBackColor = True
        '
        'BTN_TestCalib
        '
        Me.BTN_TestCalib.Location = New System.Drawing.Point(140, 14)
        Me.BTN_TestCalib.Name = "BTN_TestCalib"
        Me.BTN_TestCalib.Size = New System.Drawing.Size(46, 21)
        Me.BTN_TestCalib.TabIndex = 24
        Me.BTN_TestCalib.Text = "Test"
        Me.BTN_TestCalib.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(93, 90)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(0, 13)
        Me.Label16.TabIndex = 9
        '
        'CKBX_CalibOK_4
        '
        Me.CKBX_CalibOK_4.AutoSize = True
        Me.CKBX_CalibOK_4.BackColor = System.Drawing.SystemColors.Control
        Me.CKBX_CalibOK_4.Location = New System.Drawing.Point(199, 19)
        Me.CKBX_CalibOK_4.Name = "CKBX_CalibOK_4"
        Me.CKBX_CalibOK_4.Size = New System.Drawing.Size(75, 17)
        Me.CKBX_CalibOK_4.TabIndex = 21
        Me.CKBX_CalibOK_4.Text = "Validation "
        Me.CKBX_CalibOK_4.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Step 4 :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTN_Calib)
        Me.GroupBox2.Controls.Add(Me.BTN_ROI3)
        Me.GroupBox2.Controls.Add(Me.BTN_ROI2)
        Me.GroupBox2.Controls.Add(Me.BTN_ROI1)
        Me.GroupBox2.Controls.Add(Me.CKBX_CalibOK_3)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.CKBX_CalibOK_2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.CKBX_CalibOK_1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(626, 127)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 130)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Calibration"
        Me.GroupBox2.Visible = False
        '
        'BTN_Calib
        '
        Me.BTN_Calib.BackColor = System.Drawing.Color.Snow
        Me.BTN_Calib.Location = New System.Drawing.Point(90, 100)
        Me.BTN_Calib.Name = "BTN_Calib"
        Me.BTN_Calib.Size = New System.Drawing.Size(107, 21)
        Me.BTN_Calib.TabIndex = 27
        Me.BTN_Calib.Text = "Calibration"
        Me.BTN_Calib.UseVisualStyleBackColor = False
        '
        'BTN_ROI3
        '
        Me.BTN_ROI3.Location = New System.Drawing.Point(70, 73)
        Me.BTN_ROI3.Name = "BTN_ROI3"
        Me.BTN_ROI3.Size = New System.Drawing.Size(54, 21)
        Me.BTN_ROI3.TabIndex = 25
        Me.BTN_ROI3.Text = "ROI-3"
        Me.BTN_ROI3.UseVisualStyleBackColor = True
        '
        'BTN_ROI2
        '
        Me.BTN_ROI2.Location = New System.Drawing.Point(70, 45)
        Me.BTN_ROI2.Name = "BTN_ROI2"
        Me.BTN_ROI2.Size = New System.Drawing.Size(54, 21)
        Me.BTN_ROI2.TabIndex = 24
        Me.BTN_ROI2.Text = "ROI-2"
        Me.BTN_ROI2.UseVisualStyleBackColor = True
        '
        'BTN_ROI1
        '
        Me.BTN_ROI1.Location = New System.Drawing.Point(70, 16)
        Me.BTN_ROI1.Name = "BTN_ROI1"
        Me.BTN_ROI1.Size = New System.Drawing.Size(54, 21)
        Me.BTN_ROI1.TabIndex = 23
        Me.BTN_ROI1.Text = "ROI-1"
        Me.BTN_ROI1.UseVisualStyleBackColor = True
        '
        'CKBX_CalibOK_3
        '
        Me.CKBX_CalibOK_3.AutoSize = True
        Me.CKBX_CalibOK_3.Location = New System.Drawing.Point(145, 76)
        Me.CKBX_CalibOK_3.Name = "CKBX_CalibOK_3"
        Me.CKBX_CalibOK_3.Size = New System.Drawing.Size(41, 17)
        Me.CKBX_CalibOK_3.TabIndex = 18
        Me.CKBX_CalibOK_3.Text = "OK"
        Me.CKBX_CalibOK_3.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Step 3 :"
        '
        'CKBX_CalibOK_2
        '
        Me.CKBX_CalibOK_2.AutoSize = True
        Me.CKBX_CalibOK_2.Location = New System.Drawing.Point(145, 48)
        Me.CKBX_CalibOK_2.Name = "CKBX_CalibOK_2"
        Me.CKBX_CalibOK_2.Size = New System.Drawing.Size(41, 17)
        Me.CKBX_CalibOK_2.TabIndex = 15
        Me.CKBX_CalibOK_2.Text = "OK"
        Me.CKBX_CalibOK_2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Step 2 :"
        '
        'CKBX_CalibOK_1
        '
        Me.CKBX_CalibOK_1.AutoSize = True
        Me.CKBX_CalibOK_1.Location = New System.Drawing.Point(145, 19)
        Me.CKBX_CalibOK_1.Name = "CKBX_CalibOK_1"
        Me.CKBX_CalibOK_1.Size = New System.Drawing.Size(41, 17)
        Me.CKBX_CalibOK_1.TabIndex = 12
        Me.CKBX_CalibOK_1.Text = "OK"
        Me.CKBX_CalibOK_1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Step 1 :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(93, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 9
        '
        'CMBX_PreScreen_CalibObj
        '
        Me.CMBX_PreScreen_CalibObj.FormattingEnabled = True
        Me.CMBX_PreScreen_CalibObj.Items.AddRange(New Object() {"Screen", "PreScreen"})
        Me.CMBX_PreScreen_CalibObj.Location = New System.Drawing.Point(714, 12)
        Me.CMBX_PreScreen_CalibObj.Name = "CMBX_PreScreen_CalibObj"
        Me.CMBX_PreScreen_CalibObj.Size = New System.Drawing.Size(72, 21)
        Me.CMBX_PreScreen_CalibObj.TabIndex = 28
        Me.CMBX_PreScreen_CalibObj.Text = " "
        Me.CMBX_PreScreen_CalibObj.Visible = False
        '
        'CMBX_updown
        '
        Me.CMBX_updown.FormattingEnabled = True
        Me.CMBX_updown.Items.AddRange(New Object() {"Up", "Down"})
        Me.CMBX_updown.Location = New System.Drawing.Point(180, 24)
        Me.CMBX_updown.Name = "CMBX_updown"
        Me.CMBX_updown.Size = New System.Drawing.Size(51, 21)
        Me.CMBX_updown.TabIndex = 35
        Me.CMBX_updown.Text = "Stage"
        '
        'CMBX_LeftRight
        '
        Me.CMBX_LeftRight.FormattingEnabled = True
        Me.CMBX_LeftRight.Items.AddRange(New Object() {"Right", "Left"})
        Me.CMBX_LeftRight.Location = New System.Drawing.Point(71, 23)
        Me.CMBX_LeftRight.Name = "CMBX_LeftRight"
        Me.CMBX_LeftRight.Size = New System.Drawing.Size(51, 21)
        Me.CMBX_LeftRight.TabIndex = 34
        Me.CMBX_LeftRight.Text = "Stage"
        '
        'LBL_Track
        '
        Me.LBL_Track.AutoSize = True
        Me.LBL_Track.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Track.Location = New System.Drawing.Point(18, 284)
        Me.LBL_Track.Name = "LBL_Track"
        Me.LBL_Track.Size = New System.Drawing.Size(163, 15)
        Me.LBL_Track.TabIndex = 26
        Me.LBL_Track.Text = "Calibration not validated"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TXTBX_DeltaY)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TXTBX_DeltaX)
        Me.GroupBox1.Location = New System.Drawing.Point(627, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 82)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parameters"
        Me.GroupBox1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(120, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "µm/pxl"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "DeltaY  : "
        '
        'TXTBX_DeltaY
        '
        Me.TXTBX_DeltaY.Location = New System.Drawing.Point(67, 49)
        Me.TXTBX_DeltaY.Name = "TXTBX_DeltaY"
        Me.TXTBX_DeltaY.Size = New System.Drawing.Size(44, 20)
        Me.TXTBX_DeltaY.TabIndex = 30
        Me.TXTBX_DeltaY.Text = "0,16"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(120, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "µm/pxl"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "DeltaX  : "
        '
        'TXTBX_DeltaX
        '
        Me.TXTBX_DeltaX.Location = New System.Drawing.Point(67, 23)
        Me.TXTBX_DeltaX.Name = "TXTBX_DeltaX"
        Me.TXTBX_DeltaX.Size = New System.Drawing.Size(44, 20)
        Me.TXTBX_DeltaX.TabIndex = 28
        Me.TXTBX_DeltaX.Text = "0,16"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(257, 28)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(11, 11)
        Me.Button1.TabIndex = 47
        Me.MyToolTypeCalib.SetToolTip(Me.Button1, resources.GetString("Button1.ToolTip"))
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(128, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 37
        Me.Label11.Text = "Vertical :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Horizontal :"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Button1)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.CMBX_LeftRight)
        Me.GroupBox6.Controls.Add(Me.CMBX_updown)
        Me.GroupBox6.Location = New System.Drawing.Point(933, 44)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(298, 60)
        Me.GroupBox6.TabIndex = 46
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Stage Direction"
        '
        'MyToolTypeCalib
        '
        Me.MyToolTypeCalib.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(199, 509)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(57, 13)
        Me.Label36.TabIndex = 63
        Me.Label36.Text = "Results :"
        Me.Label36.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox8)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(312, 210)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Screening"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.BTN_CS_Start)
        Me.GroupBox8.Controls.Add(Me.BTN_CS_Next)
        Me.GroupBox8.Controls.Add(Me.LBL_CS_CoefX)
        Me.GroupBox8.Controls.Add(Me.BTN_CS_Test)
        Me.GroupBox8.Controls.Add(Me.Label18)
        Me.GroupBox8.Controls.Add(Me.Label25)
        Me.GroupBox8.Controls.Add(Me.Label21)
        Me.GroupBox8.Controls.Add(Me.Label29)
        Me.GroupBox8.Controls.Add(Me.LBL_CS_CoefY)
        Me.GroupBox8.Controls.Add(Me.Label28)
        Me.GroupBox8.Controls.Add(Me.BTN_CS_Validation)
        Me.GroupBox8.Controls.Add(Me.BTN_CS_Previous)
        Me.GroupBox8.Controls.Add(Me.Label19)
        Me.GroupBox8.Location = New System.Drawing.Point(5, 6)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(301, 197)
        Me.GroupBox8.TabIndex = 49
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Calibration pxl/stage"
        '
        'BTN_CS_Start
        '
        Me.BTN_CS_Start.BackColor = System.Drawing.Color.Azure
        Me.BTN_CS_Start.Location = New System.Drawing.Point(93, 90)
        Me.BTN_CS_Start.Name = "BTN_CS_Start"
        Me.BTN_CS_Start.Size = New System.Drawing.Size(114, 29)
        Me.BTN_CS_Start.TabIndex = 52
        Me.BTN_CS_Start.Text = "START"
        Me.BTN_CS_Start.UseVisualStyleBackColor = False
        '
        'BTN_CS_Next
        '
        Me.BTN_CS_Next.Location = New System.Drawing.Point(146, 109)
        Me.BTN_CS_Next.Name = "BTN_CS_Next"
        Me.BTN_CS_Next.Size = New System.Drawing.Size(90, 24)
        Me.BTN_CS_Next.TabIndex = 51
        Me.BTN_CS_Next.Tag = "1"
        Me.BTN_CS_Next.Text = "Next"
        Me.BTN_CS_Next.UseVisualStyleBackColor = True
        Me.BTN_CS_Next.Visible = False
        '
        'LBL_CS_CoefX
        '
        Me.LBL_CS_CoefX.AutoSize = True
        Me.LBL_CS_CoefX.Location = New System.Drawing.Point(75, 138)
        Me.LBL_CS_CoefX.Name = "LBL_CS_CoefX"
        Me.LBL_CS_CoefX.Size = New System.Drawing.Size(132, 13)
        Me.LBL_CS_CoefX.TabIndex = 3
        Me.LBL_CS_CoefX.Text = "Coefficient X :  -  pxl/stage"
        '
        'BTN_CS_Test
        '
        Me.BTN_CS_Test.Location = New System.Drawing.Point(94, 126)
        Me.BTN_CS_Test.Name = "BTN_CS_Test"
        Me.BTN_CS_Test.Size = New System.Drawing.Size(113, 21)
        Me.BTN_CS_Test.TabIndex = 24
        Me.BTN_CS_Test.Text = "Verification"
        Me.BTN_CS_Test.UseVisualStyleBackColor = True
        Me.BTN_CS_Test.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(29, 45)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(259, 13)
        Me.Label18.TabIndex = 51
        Me.Label18.Text = "Lock the PFS, pick the right objective and show live. "
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(12, 67)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 13)
        Me.Label25.TabIndex = 64
        Me.Label25.Text = "Test :"
        Me.Label25.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 64)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(240, 13)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "   Place an object in the ROI and click on ""Next""."
        Me.Label21.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(34, 90)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(211, 26)
        Me.Label29.TabIndex = 65
        Me.Label29.Text = "Verify that your object move to the 4th ROI." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Validate your calibration."
        Me.Label29.Visible = False
        '
        'LBL_CS_CoefY
        '
        Me.LBL_CS_CoefY.AutoSize = True
        Me.LBL_CS_CoefY.Location = New System.Drawing.Point(75, 156)
        Me.LBL_CS_CoefY.Name = "LBL_CS_CoefY"
        Me.LBL_CS_CoefY.Size = New System.Drawing.Size(132, 13)
        Me.LBL_CS_CoefY.TabIndex = 4
        Me.LBL_CS_CoefY.Text = "Coefficient Y :  -  pxl/stage"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(12, 16)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(57, 13)
        Me.Label28.TabIndex = 63
        Me.Label28.Text = "Results :"
        Me.Label28.Visible = False
        '
        'BTN_CS_Validation
        '
        Me.BTN_CS_Validation.Location = New System.Drawing.Point(149, 161)
        Me.BTN_CS_Validation.Name = "BTN_CS_Validation"
        Me.BTN_CS_Validation.Size = New System.Drawing.Size(90, 24)
        Me.BTN_CS_Validation.TabIndex = 66
        Me.BTN_CS_Validation.Text = "Validation"
        Me.BTN_CS_Validation.UseVisualStyleBackColor = True
        Me.BTN_CS_Validation.Visible = False
        '
        'BTN_CS_Previous
        '
        Me.BTN_CS_Previous.Location = New System.Drawing.Point(50, 109)
        Me.BTN_CS_Previous.Name = "BTN_CS_Previous"
        Me.BTN_CS_Previous.Size = New System.Drawing.Size(90, 24)
        Me.BTN_CS_Previous.TabIndex = 52
        Me.BTN_CS_Previous.Tag = "1"
        Me.BTN_CS_Previous.Text = "Previous"
        Me.BTN_CS_Previous.UseVisualStyleBackColor = True
        Me.BTN_CS_Previous.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(14, 29)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(52, 13)
        Me.Label19.TabIndex = 53
        Me.Label19.Text = "Step 1 :"
        Me.Label19.Visible = False
        '
        'MyTabControl
        '
        Me.MyTabControl.Controls.Add(Me.TabPage2)
        Me.MyTabControl.Location = New System.Drawing.Point(12, 12)
        Me.MyTabControl.Name = "MyTabControl"
        Me.MyTabControl.SelectedIndex = 0
        Me.MyTabControl.Size = New System.Drawing.Size(320, 236)
        Me.MyTabControl.TabIndex = 47
        '
        'Calibration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 304)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.CMBX_PreScreen_CalibObj)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.MyTabControl)
        Me.Controls.Add(Me.LBL_Track)
        Me.Controls.Add(Me.BTN_SaveCalib)
        Me.Controls.Add(Me.BTN_LoadCalib)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Calibration"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Calibration"
        Me.TopMost = True
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.MyTabControl.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_SaveCalib As System.Windows.Forms.Button
    Friend WithEvents BTN_LoadCalib As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BTN_ROI4 As System.Windows.Forms.Button
    Friend WithEvents BTN_TestCalib As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CKBX_CalibOK_4 As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BTN_Calib As System.Windows.Forms.Button
    Friend WithEvents BTN_ROI3 As System.Windows.Forms.Button
    Friend WithEvents BTN_ROI2 As System.Windows.Forms.Button
    Friend WithEvents BTN_ROI1 As System.Windows.Forms.Button
    Friend WithEvents CKBX_CalibOK_3 As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CKBX_CalibOK_2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CKBX_CalibOK_1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LBL_Track As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_DeltaY As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTBX_DeltaX As System.Windows.Forms.TextBox
    Friend WithEvents CMBX_LeftRight As System.Windows.Forms.ComboBox
    Friend WithEvents CMBX_updown As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMBX_PreScreen_CalibObj As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MyToolTypeCalib As System.Windows.Forms.ToolTip
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents BTN_CS_Start As System.Windows.Forms.Button
    Friend WithEvents BTN_CS_Next As System.Windows.Forms.Button
    Friend WithEvents LBL_CS_CoefX As System.Windows.Forms.Label
    Friend WithEvents BTN_CS_Test As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents LBL_CS_CoefY As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents BTN_CS_Validation As System.Windows.Forms.Button
    Friend WithEvents BTN_CS_Previous As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents MyTabControl As System.Windows.Forms.TabControl
End Class
