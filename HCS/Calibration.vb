
Option Explicit On

Imports System.IO
Imports System.Xml
Imports System.Threading
Imports Microsoft.Win32
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic.Strings
Imports ZStack.MainWindow
Imports ZStack.Process



Public Class Calibration

    '************MetaMorph Variable********************'
    Private MM As MMAppLib.UserCall64
    Private MetamorphDirectory As String = "C:\MM\"
    '***************************************************'

    '**********************Variable********************'
    Private hROI(3) As Long
    Private mn As MainWindow
    Dim RT As RegionTracking = New RegionTracking()
    Delegate Sub InvokeDelegate()
    Private wellDest As String
    Private cpt_chk2 As Integer = 1
    Public Shared IsCalibrationValidated = False
    '***************************************************'


    Sub New(ByRef _MM As MMAppLib.UserCall64, ByRef _mn As MainWindow)

        Dim calibX, calibY As Double
        InitializeComponent()
        MM = _MM
        mn = _mn
        hROI = New Long() {0, 0, 0, 0}


        'Initialization of paramters

        If IsCalibrationValidated Then
            Me.LBL_Track.Text = "Calibration Validated"
            Me.CKBX_CalibOK_4.Checked = True

            MM.GetMMVariable("CoefficientCalibrationX", calibX)
            MM.GetMMVariable("CoefficientCalibrationY", calibY)
            LBL_CS_CoefX.Text = "Coefficient X : " + calibX.ToString("0.000") + " stage/pxl"
            LBL_CS_CoefY.Text = "Coefficient Y : " + calibY.ToString("0.000") + " stage/pxl"

        Else
            MM.SetMMVariable("CoefficientCalibrationX", 0)
            MM.SetMMVariable("CoefficientCalibrationY", 0)
            MM.SetMMVariable("tiltX", 0)
            MM.SetMMVariable("tiltY", 0)
            Me.LBL_Track.Text = "Calibration not Validated"
        End If

    End Sub

    Private Sub MainWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '*
    End Sub

    Private Sub MainWindow_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        MainWindow.CalibNbr = MainWindow.CalibNbr - 1
    End Sub

    Private Sub Main_Frm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        MainWindow.CalibNbr = MainWindow.CalibNbr - 1
        If isInvertedAxis Then
            mn.CKBX_invertAxisXY.Checked = True
        Else
            mn.CKBX_invertAxisXY.Checked = False
        End If
    End Sub

    Private Sub BTN_SaveCalib_Click(sender As System.Object, e As System.EventArgs) Handles BTN_SaveCalib.Click
        Dim path = RT.SelectFolder()
        If path <> Nothing Then
            RT.ExportTxtfile(MM, path)
            'Me.CKBX_CalibOK_4.Checked = True
            '    LBL_Track.Text = "Calibration validated"
            '    LBL_Track.Visible = True
            '    IsCalibrationValidated = True
        End If
    End Sub

    Private Sub BTN_LoadCalib_Click(sender As System.Object, e As System.EventArgs) Handles BTN_LoadCalib.Click

        Dim calibX, calibY As Double
        Dim path = RT.SelectFile()

        If path <> Nothing Then
            RT.ImportTxtfile(MM, path)
            'CKBX_CheckCalib.Visible = True

            Me.CKBX_CalibOK_4.Checked = True

            If IsCalibrationValidated = True Then
                LBL_Track.Text = "Calibration validated"
                LBL_Track.Visible = True



            End If
            MM.GetMMVariable("CoefficientCalibrationX", calibX)
            MM.GetMMVariable("CoefficientCalibrationY", calibY)
            LBL_CS_CoefX.Text = "Coefficient X : " + calibX.ToString("0.000") + " stage/pxl"
            LBL_CS_CoefY.Text = "Coefficient Y : " + calibY.ToString("0.000") + " stage/pxl"


        End If
    End Sub

    Private Sub BTN_CS_Start_Click(sender As System.Object, e As System.EventArgs) Handles BTN_CS_Start.Click
            Label19.Visible = True
            Label21.Visible = True
            BTN_CS_Next.Visible = True
            BTN_CS_Previous.Visible = True

            BTN_CS_Start.Visible = False
            Label18.Visible = False
            BTN_CS_Next.Tag = 1
            BTN_CS_Previous.Tag = 1

            LBL_CS_CoefX.Visible = False
            LBL_CS_CoefY.Visible = False

            RT.CreateRegionCalib(MM, 0, hROI)
    End Sub

    Private Sub BTN_CS_Next_Click(sender As System.Object, e As System.EventArgs) Handles BTN_CS_Next.Click

            Select Case BTN_CS_Next.Tag

                Case 1

                    RT.SetRegionSize(MM, hROI(0))
                RT.SetCalibration(MM, mn.handleMCL, 0, hROI(0))
                RT.CreateRegionCalib(MM, 1, hROI)

                    Label19.Text = "Step 2 :"
                    Label21.Text = "Place your object in the second ROI and click on ""Next""."
                    BTN_CS_Next.Tag = 2
                    BTN_CS_Previous.Tag = 2

                Case 2

                    RT.SetRegionSize(MM, hROI(0))
                RT.SetCalibration(MM, mn.handleMCL, 1, hROI(1))
                    RT.CreateRegionCalib(MM, 2, hROI)
                    RT.GetTilt(MM, 0, 1)

                    Label19.Text = "Step 3 :"
                    Label21.Text = "Place your object in the third ROI and click on ""Finish""."
                    BTN_CS_Next.Tag = 3
                    BTN_CS_Previous.Tag = 3
                    BTN_CS_Next.Text = "Finish"

                Case 3

                RT.SetCalibration(MM, mn.handleMCL, 2, hROI(2))
                    Dim coeff = RT.DeltaPlatineCalculation(MM, "Screen")
                    RT.GetTilt(MM, 1, 2)

                    Label19.Visible = False
                    Label21.Visible = False
                    BTN_CS_Next.Visible = False

                    Label28.Visible = True
                    Label25.Visible = True
                    Label29.Visible = True
                    BTN_CS_Test.Visible = True
                    BTN_CS_Validation.Visible = True

                    LBL_CS_CoefX.Visible = True
                    LBL_CS_CoefX.Location = New System.Drawing.Point(75, 31)
                    LBL_CS_CoefX.Text = "Coefficient X : " + coeff.Item1.ToString("0.000") + " stage/pxl"
                    LBL_CS_CoefY.Visible = True
                    LBL_CS_CoefY.Location = New System.Drawing.Point(75, 49)
                    LBL_CS_CoefY.Text = "Coefficient Y : " + coeff.Item2.ToString("0.000") + " stage/pxl"

                    BTN_CS_Next.Tag = 4
                    BTN_CS_Previous.Tag = 4
                    BTN_CS_Previous.Location = New System.Drawing.Point(53, 161)


                Case Else

                    BTN_CS_Next.Tag = 1
                    BTN_CS_Previous.Tag = 1

            End Select

    End Sub

    Private Sub BTN_CS_Test_Click(sender As System.Object, e As System.EventArgs) Handles BTN_CS_Test.Click

        Dim coordTmp As Coord

            RT.SetRegionSize(MM, hROI(0))
            RT.CreateRegionCalib(MM, 3, hROI)
        RT.SetCalibration(MM, mn.handleMCL, 3, hROI(3))

            Thread.Sleep(100)

            coordTmp.coordX = RT.imageXCoordinates(3)
            coordTmp.coordY = RT.imageYCoordinates(3)

        RT.SetPlatineShiftCalibration(MM, mn.handleMCL, coordTmp, RT.imageXCoordinates(2), RT.imageYCoordinates(2))

    End Sub

    Private Sub BTN_CS_Validation_Click(sender As System.Object, e As System.EventArgs) Handles BTN_CS_Validation.Click

        LBL_Track.Text = "Calibration Screen validated"
        LBL_Track.Visible = True
        IsCalibrationValidated = True
        For i As Integer = 0 To hROI.Length - 1
            MM.DestroyRegion(hROI(i))
        Next

    End Sub

    Private Sub BTN_CS_Previous_Click(sender As System.Object, e As System.EventArgs) Handles BTN_CS_Previous.Click

            Dim calibX, calibY As Double
            MM.GetMMVariable("CoefficientCalibrationX", calibX)
            MM.GetMMVariable("CoefficientCalibrationY", calibY)


            Select Case BTN_CS_Next.Tag

                Case 1

                    Label19.Visible = False
                    Label21.Visible = False
                    BTN_CS_Next.Visible = False
                    BTN_CS_Previous.Visible = False

                    BTN_CS_Start.Visible = True
                    Label18.Visible = True

                    BTN_CS_Next.Tag = 0
                    BTN_CS_Previous.Tag = 0

                    LBL_CS_CoefX.Visible = True
                    LBL_CS_CoefY.Visible = True
                    LBL_CS_CoefX.Location = New System.Drawing.Point(75, 138)
                    LBL_CS_CoefX.Text = "Coefficient X : " + calibX.ToString("0.000") + " stage/pxl"
                    LBL_CS_CoefY.Location = New System.Drawing.Point(75, 156)
                    LBL_CS_CoefY.Text = "Coefficient Y : " + calibY.ToString("0.000") + " stage/pxl"

                Case 2

                    Label19.Text = "Step 1 :"
                    Label21.Text = "   Place an object in the ROI and click on ""Next""."
                    BTN_CS_Next.Tag = 1
                    BTN_CS_Previous.Tag = 1

                Case 3

                    Label19.Text = "Step 2 :"
                    Label21.Text = "Place your object in the second ROI and click on ""Next""."
                    BTN_CS_Next.Tag = 2
                    BTN_CS_Previous.Tag = 2
                    BTN_CS_Next.Text = "Next"

                Case 4

                    BTN_CS_Previous.Location = New System.Drawing.Point(50, 109)

                    Label19.Visible = True
                    Label21.Visible = True
                    BTN_CS_Next.Visible = True

                    Label28.Visible = False
                    Label25.Visible = False
                    Label29.Visible = False
                    BTN_CS_Test.Visible = False
                    BTN_CS_Validation.Visible = False

                    LBL_CS_CoefX.Visible = False
                    LBL_CS_CoefY.Visible = False

                    Label19.Text = "Step 3 :"
                    Label21.Text = "Place your object in the third ROI and click on ""Finish""."
                    BTN_CS_Next.Tag = 3
                    BTN_CS_Previous.Tag = 3
                    BTN_CS_Next.Text = "Finish"

            End Select
    End Sub

End Class