Imports ZStack.Calibration
Imports ZStack.MainWindow
Imports ZStack.Process
Imports MadCity.Madlib
Imports System.IO

Public Class RegionTracking

    '************Variables******************************
    Public MM As MMAppLib.UserCall64
    Public Shared ROIsizeX As Integer
    Public Shared ROIsizeY As Integer
    Public Shared tilt As Double

    Public stageXCoordinates(3) As Double 'Stores X stage coordinates retrieved when calibrating
    Public stageYCoordinates(3) As Double 'Stores Y stage coordinates retrieved when calibrating
    Public imageXCoordinates(3) As Double 'Stores X image coordinates retrieved when calibrating
    Public imageYCoordinates(3) As Double 'Stores Y image coordinates retrieved when calibrating
    '****************************************************


    ''' <summary>
    ''' Function called to move the stage depending to several parameters 
    ''' </summary>
    ''' <param name="coordTmp"></param> structure of the previous coordinates X and Y of the center of a ROI (i.e molecule)
    ''' <param name="coordX"></param> current X coordinates of the center of a ROI (i.e molecule)
    ''' <param name="coordY"></param> current Y coordinates of the center of a ROI (i.e molecule)
    '''' <remarks></remarks>
    'Public Sub SetPlatineShift(ByVal MM As MMAppLib.UserCall64, ByRef handleMCL As Integer, ByVal coordTmp As Coord, ByVal coordX As Integer, ByVal coordY As Integer, Optional ByVal screenmode As String = "Screen")
    '    Dim coeffX, coeffY, tiltY, tiltX, deltaX, deltaY, angleX, angleY As Double
    '    Dim shiftX As Double, shiftY As Double

    '    'Dim functionHdl As Integer
    '    tiltX = 0
    '    tiltY = 0

    '    If screenmode = "Screen" Then
    '        MM.GetMMVariable("CoefficientCalibrationX", coeffX)
    '        MM.GetMMVariable("CoefficientCalibrationY", coeffY)
    '    Else
    '        MM.GetMMVariable("CoefficientCalibrationX_ObjPS", coeffX)
    '        MM.GetMMVariable("CoefficientCalibrationY_ObjPS", coeffY)
    '    End If

    '    MM.GetMMVariable("tiltX", angleX)
    '    MM.GetMMVariable("tiltY", angleY)

    '    deltaX = (CDbl(coordTmp.coordX) - CDbl(coordX)) * coeffX
    '    deltaY = (CDbl(coordTmp.coordY) - CDbl(coordY)) * coeffY

    '    'tilt
    '    If deltaX <> 0 Then
    '        tiltY = Math.Tan(angleY) * deltaX
    '    End If
    '    If deltaY <> 0 Then
    '        tiltX = Math.Tan(angleX) * deltaY
    '    End If

    '    shiftX = deltaX + tiltX
    '    shiftY = deltaY + tiltY

    '    'Dim curCoordX =  MCL_SingleReadN(DeviceMCLdirectionX, handleMCL)
    '    'Dim curCoordY =  MCL_SingleReadN(DeviceMCLdirectionY, handleMCL)
    '    'Dim curCoordZ = MCL_SingleReadN(3, handleMCL)

    '    Dim curCoordX = MCL_SingleWriteN(MCL_Ref.coordX + shiftX, DeviceMCLdirectionX, handleMCL)
    '    Dim curCoordY = MCL_SingleWriteN(MCL_Ref.coordY + shiftY, DeviceMCLdirectionY, handleMCL)
    '    'curCoordZ = MCL_SingleWriteN(curCoordZ, 3, handleMCL)


    '    'MM.GetMMVariable("$Device.Stage.XPosition$", currentX)
    '    'MM.GetMMVariable("$Device.Stage.YPosition$", currentY)
    '    'MM.GetMMVariable("$Device.Focus.CurPos$", currentZ)

    '    'MM.SetMMVariable("$Device.Stage.XPosition$", currentX + shiftX)
    '    'MM.SetMMVariable("$Device.Stage.YPosition$", currentY + shiftY)
    '    'MM.SetMMVariable("$Device.Focus.CurPos$", currentZ)

    '    'MM.GetFunctionHandle("Move Stage to Relative Position", functionHdl)
    '    'MM.SetFunctionVariable(functionHdl, "dpX", shiftX)
    '    'MM.SetFunctionVariable(functionHdl, "dpY", shiftY)
    '    'MM.RunFunctionEx(functionHdl, 1)


    '    'MM.GetFunctionHandle("Move Stage to Absolute Position", functionHdl)
    '    'MM.SetFunctionVariable(functionHdl, "dpX", currentX + shiftX)
    '    'MM.SetFunctionVariable(functionHdl, "dpY", currentY + shiftY)
    '    'MM.SetFunctionVariable(functionHdl, "dpZ", currentZ)
    '    'MM.RunFunctionEx(functionHdl, 1)

    'End Sub


    ''' <summary>
    ''' Function called to move the stage depending to several parameters 
    ''' </summary>
    ''' <param name="coordTmp"></param> structure of the previous coordinates X and Y of the center of a ROI (i.e molecule)
    ''' <param name="coordX"></param> current X coordinates of the center of a ROI (i.e molecule)
    ''' <param name="coordY"></param> current Y coordinates of the center of a ROI (i.e molecule)
    ''' <remarks></remarks>
    Public Sub SetPlatineShiftCalibration(ByVal MM As MMAppLib.UserCall64, ByRef handleMCL As Integer, ByVal coordTmp As Coord, ByVal coordX As Integer, ByVal coordY As Integer, Optional ByVal screenmode As String = "Screen")
        Dim coeffX, coeffY, tiltY, tiltX, deltaX, deltaY, angleX, angleY As Double
        Dim shiftX As Double, shiftY As Double

        'Dim functionHdl As Integer
        tiltX = 0
        tiltY = 0

        If screenmode = "Screen" Then
            MM.GetMMVariable("CoefficientCalibrationX", coeffX)
            MM.GetMMVariable("CoefficientCalibrationY", coeffY)
        Else
            MM.GetMMVariable("CoefficientCalibrationX_ObjPS", coeffX)
            MM.GetMMVariable("CoefficientCalibrationY_ObjPS", coeffY)
        End If

        MM.GetMMVariable("tiltX", angleX)
        MM.GetMMVariable("tiltY", angleY)

        deltaX = (CDbl(coordTmp.coordX) - CDbl(coordX)) * coeffX
        deltaY = (CDbl(coordTmp.coordY) - CDbl(coordY)) * coeffY

        'tilt
        If deltaX <> 0 Then
            tiltY = Math.Tan(angleY) * deltaX
        End If
        If deltaY <> 0 Then
            tiltX = Math.Tan(angleX) * deltaY
        End If

        shiftX = deltaX + tiltX
        shiftY = deltaY + tiltY

        Dim curCoordX = MCL_SingleReadN(DeviceMCLdirectionX, handleMCL)
        Dim curCoordY = MCL_SingleReadN(DeviceMCLdirectionY, handleMCL)
        Dim curCoordZ = MCL_SingleReadN(3, handleMCL)

        curCoordX = MCL_SingleWriteN(curCoordX + shiftX, DeviceMCLdirectionX, handleMCL)
        curCoordY = MCL_SingleWriteN(curCoordY + shiftY, DeviceMCLdirectionY, handleMCL)
        'curCoordZ = MCL_SingleWriteN(curCoordZ, 3, handleMCL)


        'MM.GetMMVariable("$Device.Stage.XPosition$", currentX)
        'MM.GetMMVariable("$Device.Stage.YPosition$", currentY)
        'MM.GetMMVariable("$Device.Focus.CurPos$", currentZ)

        'MM.SetMMVariable("$Device.Stage.XPosition$", currentX + shiftX)
        'MM.SetMMVariable("$Device.Stage.YPosition$", currentY + shiftY)
        'MM.SetMMVariable("$Device.Focus.CurPos$", currentZ)

        'MM.GetFunctionHandle("Move Stage to Relative Position", functionHdl)
        'MM.SetFunctionVariable(functionHdl, "dpX", shiftX)
        'MM.SetFunctionVariable(functionHdl, "dpY", shiftY)
        'MM.RunFunctionEx(functionHdl, 1)


        'MM.GetFunctionHandle("Move Stage to Absolute Position", functionHdl)
        'MM.SetFunctionVariable(functionHdl, "dpX", currentX + shiftX)
        'MM.SetFunctionVariable(functionHdl, "dpY", currentY + shiftY)
        'MM.SetFunctionVariable(functionHdl, "dpZ", currentZ)
        'MM.RunFunctionEx(functionHdl, 1)

    End Sub


    ''' <summary>
    ''' Function called to move the stage depending to several parameters 
    ''' </summary>
    ''' <param name="coordTmp"></param> structure of the previous coordinates X and Y of the center of a ROI (i.e molecule)
    ''' <param name="coordX"></param> current X coordinates of the center of a ROI (i.e molecule)
    ''' <param name="coordY"></param> current Y coordinates of the center of a ROI (i.e molecule)
    ''' <remarks></remarks>
    Public Shared Sub SetPlatineShiftDrift(ByVal MM As MMAppLib.UserCall64, ByRef handleMCL As Integer, ByVal driftX As Double, ByVal driftY As Double)
        Dim coeffX, coeffY, tiltY, tiltX, deltaX, deltaY, angleX, angleY As Double
        Dim shiftX As Double, shiftY As Double
        Dim currentX, currentY As Double
        tiltX = 0
        tiltY = 0

        MM.GetMMVariable("CoefficientCalibrationX", coeffX)
        MM.GetMMVariable("CoefficientCalibrationY", coeffY)


        MM.GetMMVariable("tiltX", angleX)
        MM.GetMMVariable("tiltY", angleY)

        deltaX = driftX * coeffX
        deltaY = driftY * coeffY

        'tilt
        If deltaX <> 0 Then
            tiltY = Math.Tan(angleY) * deltaX
        End If
        If deltaY <> 0 Then
            tiltX = Math.Tan(angleX) * deltaY
        End If

        shiftX = MCL_Ref.coordX + deltaX + tiltX
        shiftY = MCL_Ref.coordY + deltaY + tiltY

        MCL_Ref.coordX = shiftX
        MCL_Ref.coordY = shiftY

        'MM.GetMMVariable("$Device.Stage.XPosition$", currentX)
        'MM.GetMMVariable("$Device.Stage.YPosition$", currentY)

        'MM.SetMMVariable("$Device.Stage.XPosition$", currentX + shiftX)
        'MM.SetMMVariable("$Device.Stage.YPosition$", currentY + shiftY)

        currentX = MCL_SingleReadN(DeviceMCLdirectionX, handleMCL)
        currentY = MCL_SingleReadN(DeviceMCLdirectionY, handleMCL)
        'Dim curCoordZ = MCL_SingleReadN(3, handleMCL)

        If deltaX <> 0 Then
            MCL_SingleWriteN(shiftX, DeviceMCLdirectionX, handleMCL)
        End If

        If deltaY <> 0 Then
            MCL_SingleWriteN(shiftY, DeviceMCLdirectionY, handleMCL)
        End If

        'MM.PrintMsg("referentiel X : " + MCL_Ref.coordX.ToString() + " - Y - " + MCL_Ref.coordY.ToString() + " - Z - " + MCL_Ref.coordZ.ToString())

        MM.PrintMsg("(pxl) driftX : " + (driftX).ToString("0.0000") + " - DriftY : " + (driftY).ToString("0.0000"))
        MM.PrintMsg("(um) driftX : " + (deltaX + tiltX).ToString("0.0000") + " - DriftY : " + (deltaY + tiltY).ToString("0.0000"))
        'MM.PrintMsg("Stage X : " + currentX.ToString("0.0000") + " ==> " + shiftX.ToString("0.0000"))
        ' MM.PrintMsg("Stage Y : " + currentY.ToString("0.0000") + " ==> : " + shiftY.ToString("0.0000"))
        MM.PrintMsg("")

    End Sub

    ''' <summary>
    ''' Function called to move the stage depending to several parameters 
    ''' </summary>
    ''' <param name="coordTmp"></param> structure of the previous coordinates X and Y of the center of a ROI (i.e molecule)
    ''' <param name="coordX"></param> current X coordinates of the center of a ROI (i.e molecule)
    ''' <param name="coordY"></param> current Y coordinates of the center of a ROI (i.e molecule)
    ''' <remarks></remarks>
    Public Shared Sub SetPlatineShiftDriftZ(ByVal MM As MMAppLib.UserCall64, ByRef handleMCL As Integer, ByVal driftZ As Double)
        Dim driftTotal, currentZ, CoordclockZ As Double

        'read Z
        currentZ = MCL_SingleReadN(3, handleMCL)
        'write Z
        driftTotal = MCL_Ref.coordZ + driftZ

        MCL_Ref.coordZ = driftTotal
        If driftZ <> 0 Then
            MCL_SingleWriteN(driftTotal, 3, handleMCL)
            CoordclockZ = MCL_SingleReadN(3, handleMCL)
            MM.SetMMVariable("MadCityLab.Device.Z", CoordclockZ)
        End If

        'MM.PrintMsg("driftZ : " + driftZ.ToString() + " - dritfTotal = MCLrefZ + driftZ = " + driftTotal.ToString())
        'MM.PrintMsg("before : currentZ : " + currentZ.ToString())
        'MM.PrintMsg("after : currentZ : " + CoordclockZ.ToString())
        MM.PrintMsg("(um) driftZ : " + driftZ.ToString("0.0000"))
        'MM.PrintMsg("Stage Z : " + currentZ.ToString("0.0000") + " ==> " + CoordclockZ.ToString("0.0000"))

    End Sub

    ''' <summary>
    ''' Function called recover the stage displacement between two points depending to several parameters 
    ''' </summary>
    ''' <param name="coordTmp"></param> structure of the previous coordinates X and Y of the center of a ROI (i.e molecule)
    ''' <param name="coordX"></param> current X coordinates of the center of a ROI (i.e molecule)
    ''' <param name="coordY"></param> current Y coordinates of the center of a ROI (i.e molecule)
    ''' <remarks></remarks>
    Public Function GetPlatineShift(ByVal MM As MMAppLib.UserCall64, ByRef handleMCL As Integer, ByVal coordTmpX As Integer, ByVal coordTmpY As Integer, ByVal coordX As Integer, ByVal coordY As Integer, ByVal coordScreen As Coord, ByVal screenMode As String) As Coord
        Dim coeffX, coeffY, tiltY, tiltX, deltaX, deltaY, angleX, angleY As Double
        Dim shiftX As Double, shiftY As Double
        Dim newCoord As Coord
        Dim currentX, currentY As Double
        tiltX = 0
        tiltY = 0

        If screenMode = "PreScreen" Then
            MM.GetMMVariable("CoefficientCalibrationX_ObjPS", coeffX)
            MM.GetMMVariable("CoefficientCalibrationY_ObjPS", coeffY)
        Else
            MM.GetMMVariable("CoefficientCalibrationX", coeffX)
            MM.GetMMVariable("CoefficientCalibrationY", coeffY)
        End If

        If coordScreen.coordX = 0 And coordScreen.coordY = 0 Then
            'MM.GetMMVariable("$Device.Stage.XPosition$", currentX)
            'MM.GetMMVariable("$Device.Stage.YPosition$", currentY)
            currentX = MCL_SingleReadN(DeviceMCLdirectionX, handleMCL)
            currentY = MCL_SingleReadN(DeviceMCLdirectionY, handleMCL)
        Else
            currentX = coordScreen.coordX
            currentY = coordScreen.coordY
        End If


        MM.GetMMVariable("tiltX", angleX)
        MM.GetMMVariable("tiltY", angleY)

        deltaX = (CDbl(coordTmpX) - CDbl(coordX)) * coeffX
        deltaY = (CDbl(coordTmpY) - CDbl(coordY)) * coeffY

        'tilt
        If deltaX <> 0 Then
            tiltY = Math.Tan(angleY) * deltaX
        End If
        If deltaY <> 0 Then
            tiltX = Math.Tan(angleX) * deltaY
        End If

        shiftX = deltaX + tiltX
        shiftY = deltaY + tiltY

        newCoord.coordX = shiftX + currentX
        newCoord.coordY = shiftY + currentY

        Return newCoord

    End Function



    ''' <summary>
    ''' Create 4 regions in the current image corner, in order to calibrate.
    ''' </summary>
    ''' <param name="MM"></param>
    ''' <param name="id"></param> Number of ROI, it's ROI ID
    ''' <param name="hROI"></param> Array of the 4 ROI handle
    ''' <remarks></remarks>
    Public Sub CreateRegionCalib(ByVal MM As MMAppLib.UserCall64, ByVal id As Integer, ByRef hROI() As Long)
        Dim handle, img As Long
        Dim W, H, HcenterROI, nX1, nX2, nY1, nY2 As Integer

        MM.GetCurrentImage(img)
        MM.GetWidth(img, W)
        MM.GetHeight(img, H)
        Dim pos As Integer = 20
        Select Case id

            Case 0
                ROIsizeX = 10
                ROIsizeY = 10
                Dim tmp = MM.DestroyRegion(hROI(id))
                MM.PrintMsg("HdlROI0 = " + tmp.ToString())
                MM.CreateRectRegion(img, pos, pos, pos + ROIsizeX, pos + ROIsizeY, hROI(id))
                'MM.CreateRectRegion(img, pos + (ROIsizeX / 2) - 0.5, pos + (ROIsizeY / 2) - 0.5, pos + (ROIsizeX / 2) + 0.5, pos + (ROIsizeY / 2) + 0.5, HcenterROI)

                'nX1 = pos
                'nY1 = pos
                'nX2 = pos + ROIsizeX
                'nY2 = pos + ROIsizeY

                'MM.GetFunctionHandle("Create Region", handle)
                'MM.SetFunctionVariable(handle, "nRgnType", 3)
                'MM.SetFunctionVariable(handle, "nX1", nX1)
                'MM.SetFunctionVariable(handle, "nY1", nY1)
                'MM.SetFunctionVariable(handle, "nX2", nX2)
                'MM.SetFunctionVariable(handle, "nY2", nY2)
                'MM.RunFunctionEx(handle, 1)

                'nX1 = pos
                'nY1 = pos + ROIsizeY
                'nX2 = pos + ROIsizeX
                'nY2 = pos

                'MM.GetFunctionHandle("Create Region", handle)
                'MM.SetFunctionVariable(handle, "nRgnType", 3)
                'MM.SetFunctionVariable(handle, "nX1", nX1)
                'MM.SetFunctionVariable(handle, "nY1", nY1)
                'MM.SetFunctionVariable(handle, "nX2", nX2)
                'MM.SetFunctionVariable(handle, "nY2", nY2)
                'MM.RunFunctionEx(handle, 1)

            Case 1

                MM.DestroyRegion(hROI(id))
                MM.CreateRectRegion(img, W - pos - ROIsizeX, pos, W - pos, pos + ROIsizeY, hROI(id))
                'MM.CreateRectRegion(img, W - pos - (ROIsizeX / 2) - 0.5, pos + (ROIsizeY / 2) - 0.5, W - pos - (ROIsizeX / 2) + 0.5, pos + (ROIsizeY / 2) + 0.5, HcenterROI)

                'nX1 = W - pos - ROIsizeX
                'nY1 = pos
                'nX2 = W - pos
                'nY2 = pos + ROIsizeY

                'MM.GetFunctionHandle("Create Region", handle)
                'MM.SetFunctionVariable(handle, "nRgnType", 3)
                'MM.SetFunctionVariable(handle, "nX1", nX1)
                'MM.SetFunctionVariable(handle, "nY1", nY1)
                'MM.SetFunctionVariable(handle, "nX2", nX2)
                'MM.SetFunctionVariable(handle, "nY2", nY2)
                'MM.RunFunctionEx(handle, 1)

                'nX1 = W - pos - ROIsizeX
                'nY1 = pos + ROIsizeY
                'nX2 = W - pos
                'nY2 = pos

                'MM.GetFunctionHandle("Create Region", handle)
                'MM.SetFunctionVariable(handle, "nRgnType", 3)
                'MM.SetFunctionVariable(handle, "nX1", nX1)
                'MM.SetFunctionVariable(handle, "nY1", nY1)
                'MM.SetFunctionVariable(handle, "nX2", nX2)
                'MM.SetFunctionVariable(handle, "nY2", nY2)
                'MM.RunFunctionEx(handle, 1)

            Case 2

                MM.DestroyRegion(hROI(id))
                MM.CreateRectRegion(img, W - pos - ROIsizeX, H - pos - ROIsizeY, W - pos, H - pos, hROI(id))
                'MM.CreateRectRegion(img, W - pos - (ROIsizeX / 2) - 0.5, H - pos - (ROIsizeY / 2) - 0.5, W - pos - (ROIsizeX / 2) + 0.5, H - pos - (ROIsizeY / 2) + 0.5, HcenterROI)
                'nX1 = W - pos - ROIsizeX
                'nY1 = H - pos - ROIsizeY
                'nX2 = W - pos
                'nY2 = H - pos

                'MM.GetFunctionHandle("Create Region", handle)
                'MM.SetFunctionVariable(handle, "nRgnType", 3)
                'MM.SetFunctionVariable(handle, "nX1", nX1)
                'MM.SetFunctionVariable(handle, "nY1", nY1)
                'MM.SetFunctionVariable(handle, "nX2", nX2)
                'MM.SetFunctionVariable(handle, "nY2", nY2)
                'MM.RunFunctionEx(handle, 1)

                'nX1 = W - pos - ROIsizeX
                'nY1 = H - pos
                'nX2 = W - pos
                'nY2 = H - pos - ROIsizeY

                'MM.GetFunctionHandle("Create Region", handle)
                'MM.SetFunctionVariable(handle, "nRgnType", 3)
                'MM.SetFunctionVariable(handle, "nX1", nX1)
                'MM.SetFunctionVariable(handle, "nY1", nY1)
                'MM.SetFunctionVariable(handle, "nX2", nX2)
                'MM.SetFunctionVariable(handle, "nY2", nY2)
                'MM.RunFunctionEx(handle, 1)

            Case 3

                MM.DestroyRegion(hROI(id))
                MM.CreateRectRegion(img, pos, H - pos - ROIsizeY, pos + ROIsizeX, H - pos, hROI(id))
                'MM.CreateRectRegion(img, pos + (ROIsizeX / 2) - 0.5, H - pos - (ROIsizeY / 2) - 0.5, pos + (ROIsizeX / 2) + 0.5, H - pos - (ROIsizeY / 2) + 0.5, HcenterROI)
                'nX1 = pos
                'nY1 = H - pos - ROIsizeY
                'nX2 = pos + ROIsizeX
                'nY2 = H - pos

                'MM.GetFunctionHandle("Create Region", handle)
                'MM.SetFunctionVariable(handle, "nRgnType", 3)
                'MM.SetFunctionVariable(handle, "nX1", nX1)
                'MM.SetFunctionVariable(handle, "nY1", nY1)
                'MM.SetFunctionVariable(handle, "nX2", nX2)
                'MM.SetFunctionVariable(handle, "nY2", nY2)
                'MM.RunFunctionEx(handle, 1)

                'nX1 = pos
                'nY1 = H - pos
                'nX2 = pos + ROIsizeX
                'nY2 = H - pos - ROIsizeY

                'MM.GetFunctionHandle("Create Region", handle)
                'MM.SetFunctionVariable(handle, "nRgnType", 3)
                'MM.SetFunctionVariable(handle, "nX1", nX1)
                'MM.SetFunctionVariable(handle, "nY1", nY1)
                'MM.SetFunctionVariable(handle, "nX2", nX2)
                'MM.SetFunctionVariable(handle, "nY2", nY2)
                'MM.RunFunctionEx(handle, 1)

        End Select

    End Sub

    Public Sub SetRegionSize(ByVal MM As MMAppLib.UserCall64, ByRef hRoi As Long)
        MM.GetRegionSize(hRoi, ROIsizeX, ROIsizeY)
    End Sub

    ''' <summary>
    ''' Recover the current coordinates in pixel of the molecule in a ROI during the calibration and the current stage position
    ''' </summary>
    ''' <param name="MM"></param>
    ''' <param name="id"></param> ROI ID
    ''' <param name="hRoi"></param> Array of the 4 ROI handle
    ''' <remarks></remarks>
    Public Sub SetCalibration(ByVal MM As MMAppLib.UserCall64, ByRef handleMCL As Integer, ByVal id As Integer, ByRef hRoi As Long)
        Dim currentPos As Coord
        'MM.GetMMVariable("$Device.Stage.XPosition$", currentPos.coordX)
        'MM.GetMMVariable("$Device.Stage.YPosition$", currentPos.coordY)
        'MM.GetMMVariable("$Device.Focus.CurPos$", currentPos.coordZ)

        currentPos.coordX = MCL_SingleReadN(DeviceMCLdirectionX, handleMCL)
        currentPos.coordY = MCL_SingleReadN(DeviceMCLdirectionY, handleMCL)
        currentPos.coordZ = MCL_SingleReadN(3, handleMCL)

        Dim X, Y As Integer
        MM.GetRegionPosition(hRoi, X, Y)
        If id = 0 Then
            imageXCoordinates = New Double() {0, 0, 0, 0}
            imageYCoordinates = New Double() {0, 0, 0, 0}
            stageXCoordinates = New Double() {0, 0, 0, 0}
            stageYCoordinates = New Double() {0, 0, 0, 0}
        End If

        imageXCoordinates(id) = X + Math.Floor(ROIsizeX / 2)
        imageYCoordinates(id) = Y + Math.Floor(ROIsizeY / 2)
        stageXCoordinates(id) = currentPos.coordX
        stageYCoordinates(id) = currentPos.coordY

        MM.PrintMsg("stageX - " + stageXCoordinates(id).ToString(0.0) + "stageY - " + stageYCoordinates(id).ToString(0.0) + "PixelX - " + imageXCoordinates(id).ToString(0.0) + "PixelY - " + imageYCoordinates(id).ToString(0.0))

    End Sub

    ''' <summary>
    ''' Calculate the calibration coefficient Stage/Pixel
    ''' </summary>
    ''' <param name="MM"></param>
    ''' <returns></returns> Tuple of the coefficient X and Y
    ''' <remarks></remarks>
    Public Function DeltaPlatineCalculation(ByVal MM As MMAppLib.UserCall64, ByVal objID As String) As Tuple(Of Double, Double)

        Dim deltaPxlX, deltaPxlY, deltaStageX, deltaStageY, coeffX, coeffY, microX, microY, coeffMicroX, coeffMicroY As Double

        If objID = "Screen" Then
            MM.GetMMVariable("CoefficientCalibrationXµmpxl", microX)
            MM.GetMMVariable("CoefficientCalibrationYµmpxl", microY)
        Else
            'micro = um/pixel
            MM.GetMMVariable("CoefficientCalibrationXµmpxl_ObjPS", microX)
            MM.GetMMVariable("CoefficientCalibrationYµmpxl_ObjPS", microY)
        End If

        deltaPxlX = imageXCoordinates(1) - imageXCoordinates(0)
        deltaPxlY = imageYCoordinates(2) - imageYCoordinates(1)

        deltaStageX = stageXCoordinates(1) - stageXCoordinates(0)
        deltaStageY = stageYCoordinates(2) - stageYCoordinates(1)

        'stage/pixel
        coeffX = deltaStageX / deltaPxlX
        coeffY = deltaStageY / deltaPxlY

        'coeffmicro = stage/um
        If microX <> 0 Then
            coeffMicroX = coeffX / microX
        Else
            coeffMicroX = 1
        End If
        If microY <> 0 Then
            coeffMicroY = coeffY / microY
        Else
            coeffMicroY = 1
        End If

        'save data according to the mode "PreScreenning" or "Screening"
        If objID = "Screen" Then
            MM.SetMMVariable("CoefficientCalibrationX", coeffX)
            MM.SetMMVariable("CoefficientCalibrationY", coeffY)

            MM.SetMMVariable("CoefficientCalibrationXµm", coeffMicroX)
            MM.SetMMVariable("CoefficientCalibrationYµm", coeffMicroY)
        Else
            MM.SetMMVariable("CoefficientCalibrationX_ObjPS", coeffX)
            MM.SetMMVariable("CoefficientCalibrationY_ObjPS", coeffY)

            MM.SetMMVariable("CoefficientCalibrationXµm_ObjPS", coeffMicroX)
            MM.SetMMVariable("CoefficientCalibrationYµm_ObjPS", coeffMicroY)
        End If

        Return New Tuple(Of Double, Double)(coeffX, coeffY)
    End Function

    ''' <summary>
    ''' Calulation of the tilt
    ''' </summary>
    ''' <param name="MM"></param> metamoprhe variable
    ''' <param name="id1"></param>
    ''' <param name="id2"></param>
    ''' <remarks></remarks>
    Public Sub GetTilt(ByVal MM As MMAppLib.UserCall64, ByVal id1 As Integer, ByVal id2 As Integer)

        Dim deltaX, deltaY, tilt As Double

        deltaX = stageXCoordinates(id2) - stageXCoordinates(id1)
        deltaY = stageYCoordinates(id2) - stageYCoordinates(id1)

        'MM.PrintMsg("tilt, deltaX = " + deltaX.ToString("0.00"))
        'MM.PrintMsg("tilt, deltaY = " + deltaY.ToString("0.00"))

        If id1 = 0 And id2 = 1 Then
            tilt = Math.Atan2(deltaY, deltaX)
            MM.SetMMVariable("tiltY", tilt)
            'MM.PrintMsg("tilt, angleY = " + tilt.ToString("0.00"))
        Else
            tilt = Math.Atan2(deltaX, deltaY)
            MM.SetMMVariable("tiltX", tilt)
            'MM.PrintMsg("tilt, angleX = " + tilt.ToString("0.00"))
        End If

    End Sub

    Public Sub ExportTxtfile(ByRef MM As MMAppLib.UserCall64, ByRef path As String)
        'Création d'un flux d'écriture
        Dim sw As New StreamWriter(path + "CalibrationFile.txt", False)
        Dim str As String
        Dim calibX, calibY, tiltX, tiltY As Double

        MM.GetMMVariable("CoefficientCalibrationX", calibX)
        MM.GetMMVariable("CoefficientCalibrationY", calibY)

        MM.GetMMVariable("tiltX", tiltX)
        MM.GetMMVariable("tiltY", tiltY)

        str = "coeffX_Screen " + calibX.ToString()
        sw.WriteLine(str)
        str = "coeffY_Screen " + calibY.ToString()
        sw.WriteLine(str)
        str = "tiltX " + tiltX.ToString()
        sw.WriteLine(str)
        str = "tiltY " + tiltY.ToString()
        sw.WriteLine(str)
        str = "isInvertedAxis " + isInvertedAxis.ToString()
        sw.WriteLine(str)

        sw.Close()

    End Sub

    Public Sub ImportTxtfile(ByRef MM As MMAppLib.UserCall64, ByRef pathFile As String)
        'Création d'un flux d'écriture
        Dim sr As New StreamReader(pathFile)
        Dim str As String
        Dim init As Boolean = True
        Dim ItemChar As String() = New String(8) {}
        Dim delimiterChars As Char() = {" "}
        Dim calibX, calibY, tiltX, tiltY As Double

        Dim cpt = 0
        Dim tmp As New List(Of String)
        While sr.Peek <> -1
            str = sr.ReadLine()
            ItemChar = str.Split(delimiterChars)
            cpt += 1
            tmp.Add(ItemChar(1))
        End While

        calibX = CDbl(tmp(0))
        calibY = CDbl(tmp(1))
        tiltX = CDbl(tmp(2))
        tiltY = CDbl(tmp(3))
        isInvertedAxis = CBool(tmp(4))


        MM.SetMMVariable("CoefficientCalibrationX", calibX)
        MM.SetMMVariable("CoefficientCalibrationY", calibY)
        MM.SetMMVariable("tiltX", tiltX)
        MM.SetMMVariable("tiltY", tiltY)



        If tmp(0) <> "0,00" And tmp(1) <> "0,00" And tmp(2) <> "0,00" And tmp(3) <> "0,00" Then
            IsCalibrationValidated = True
        End If

        sr.Close()

    End Sub

    Public Function SelectFolder() As String

        Dim browse As New FolderBrowserDialog
        Dim path As String = String.Empty

        With browse

            If (.ShowDialog = Windows.Forms.DialogResult.OK) Then
                path = .SelectedPath
                path &= "\"
            End If

        End With

        Return path

    End Function

    Public Function SelectFile() As String

        Dim Browser = New OpenFileDialog()
        Dim path As String = String.Empty

        With Browser

            If (.ShowDialog = Windows.Forms.DialogResult.OK) Then
                path = .FileName
            End If

        End With

        Return path

    End Function

    '                Case "NEWFRAME"
    'Dim Timer_All_1 = Microsoft.VisualBasic.DateAndTime.Timer()
    '' NumImage = NumImage + 1
    '                mm.GetCurrentImage(src)
    '                NumImage = GetFrameNumber() + 1

    '                If NumImage = 1 Then

    ''************MM**************************
    '                    mm.GetCurrentImage(src)
    '                    mm.GetWidth(src, srcWidth)
    '                    mm.GetHeight(src, srcHeight)
    ''mm.GetTotalFrameCount(src, nb_planes)
    ''mm.GetNumberOfPlanes(src, nb_planes)
    ''*******************************************

    ''*************Detection**********************
    '                    nb_planes = 4000
    '                    binning = CInt(MainWindow.TXTBX_Binning.Text)
    '                    NbMaxPtsPerImage = CLng(CDbl(MainWindow.roiTracking.width) * CDbl(MainWindow.roiTracking.height) * MaxDensityPerPixel)
    '                    Nb_Val = NbSegParams * NbMaxPtsPerImage
    '                    ReDim Points(Nb_Val - 1)
    '                    ReDim Points_all(Nb_Val * binning)
    '                    IsGPUAcceleration = False
    '                    IsWatershed = False
    '                    WaveletThreshold = CInt(MainWindow.TXTBX_WT_Threshold.Text)
    ''GaussFit = CInt(MainWindow.TXTBX_GaussFit.Text)
    '                    index = 0
    ''NumImage = 0
    '                    cpt = 0
    '                    isOnebead = False
    ''********************************************

    ''*************tracking**********************
    '                    Decrease = 10
    '                    CostBirth = 0.5#
    '                    MaxDistance = 5
    '                    MinLength = 2
    '                    ReDim trcList(nb_planes * 2)
    '                    ReDim driftTab(Math.Ceiling((nb_planes / binning)) + 1, 9)
    ''ReDim driftTab(100, 6)
    ''*******************************************

    '                    If IsWatershed Then
    '                        Wavelet_WatershedRatio = 0.0#
    '                    Else
    '                        Wavelet_WatershedRatio = 10.0#
    '                    End If

    '                End If

    ''Try

    ''Dim ret_val = UnsafeProcessing.Unmanaged.LiveProcessing(True, mm, src, CUShort(Nb_Val - 1), CUShort(nb_planes), Points, CUInt(NbMaxPtsPerImage * NbSegParams), srcWidth, srcHeight, 1, WaveletThreshold, Wavelet_WatershedRatio, 4.0#, 0.0#, "Wavelet", CUShort(9), 1.0#, 0.0#, 0.0#, CUShort(7))
    ''Dim ret_val = UnsafeProcessing.Unmanaged.LiveProcessing(True, mm, hImage, CUShort(NumImage - 1), CUShort(TotalFrameCount), Points, CUInt(NbPointsMaxPerPlane * NbSegParams), CUInt(srcWidth), CUInt(srcHeight), 1, WaveletThreshold, Wavelet_WatershedRatio, 4.0#, 0.0#, LocalizationMode, CUShort(GaussianFit), 1.0#, 0.0#, 0.0#, CUShort(7))
    ''Dim ret_val = UnsafeProcessing.Unmanaged.CPUProcessing(True, mm, NumImage - 1, Points, CUInt(Nb_Val), CUInt(srcWidth), CUInt(srcHeight), 1, WaveletThreshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(7))

    ''********************************************************
    ''Dim inter = NumImage - 1
    ''Dim buffer(MainWindow.roiTracking.width * MainWindow.roiTracking.height - 1) As UShort
    ''UnsafeProcessing.Unmanaged.ReadImage(mm, inter, MainWindow.roiTracking.Px, MainWindow.roiTracking.Py, CUInt(MainWindow.roiTracking.width), CUInt(MainWindow.roiTracking.height), buffer)
    ''mm.WriteImage(45, MainWindow.roiTracking.Px, MainWindow.roiTracking.Py, CUInt(MainWindow.roiTracking.width), CUInt(MainWindow.roiTracking.height), 0, 0, 0, buffer)
    ''********************************************************

    'Dim ret_val = UnsafeProcessing.Unmanaged.CPUProcessingROI(True, MM, NumImage - 1, Points, CUInt(Nb_Val), CUInt(MainWindow.roiTracking.width), CUInt(MainWindow.roiTracking.height), CUInt(MainWindow.roiTracking.Px), CUInt(MainWindow.roiTracking.Py), 1, WaveletThreshold, 10.0#, 4.0#, 0.0#, CUShort(Gauss_Fit_Calibration), SigmaGauss_Fit, SigmaGauss_Fit * 2, ThetaGauss_Fit, CUShort(7))
    ''If ret_val = 13 Then

    ''If NumImage = 1 Then
    ''Dim dest As Long
    ''Dim destImage(MainWindow.roiTracking.width, MainWindow.roiTracking.height) As Double
    ''Dim buffer(MainWindow.roiTracking.width * MainWindow.roiTracking.height - 1) As UShort
    ''UnsafeProcessing.Unmanaged.ReadFrame(mm, NumImage - 1, MainWindow.roiTracking.Px, MainWindow.roiTracking.Py, MainWindow.roiTracking.width, MainWindow.roiTracking.height, buffer)
    ''Dim a As Integer = 0
    ''For i = 0 To buffer.Length - 1
    ''    a = a + buffer(i)
    ''Next
    ''a = a / buffer.Length

    ''mm.CreateImage(MainWindow.roiTracking.width, MainWindow.roiTracking.height, 1, "dest", dest)

    ''For j = 0 To MainWindow.roiTracking.height - 1
    ''    ' Remplissage de la ligne courante
    ''    For i = 0 To MainWindow.roiTracking.width - 1
    ''        Dim Val = destImage(i, j)
    ''        ' Gestion 16bits pour conversion
    ''        If Val() > 32767 And Val() <= 65535 Then
    ''            Val = Val() - 65536
    ''        ElseIf Val() > 65535 Then ' Saturation
    ''            Val = -1
    ''        End If

    ''        index = j * MainWindow.roiTracking.width + i
    ''        buffer(index) = CInt(Val())
    ''    Next i
    ''Next j


    ''UnsafeProcessing.Unmanaged.WriteImageToPlane(mm, dest, NumImage - 1, 0, 0, MainWindow.roiTracking.width, MainWindow.roiTracking.height, 16, buffer)
    ''End If

    ''End If
    ''Dim ret_val = UnsafeProcessing.Unmanaged.CPUProcessingROI(True, mm, NumImage - 1, Points, CUInt(Nb_Val), CUInt(MainWindow.roiTracking.width), CUInt(MainWindow.roiTracking.height), CUInt(MainWindow.roiTracking.Px), CUInt(MainWindow.roiTracking.Py), 1, WaveletThreshold, Wavelet_WatershedRatio, 4.0#, 0.0#, CUShort(9), 1.0#, 0.0#, 0.0#, CUShort(7))




    '''**************************ret_val**************************
    '                If ret_val = 13 Then
    'Dim index = 0
    '                    For i = 0 To Points.Length - 1
    'Dim a = Points(i)
    '                        If a <> 0 Or a <> (-1) Then

    '                            For k = 0 To Points.Length - 1
    '                                If k < NbSegParams * 2 Then
    '                                    Points(k) = Points(i + k)
    '                                Else
    '                                    Points(k) = 0
    '                                End If
    '                            Next
    '                            Exit For
    '                        End If
    '                    Next

    '                ElseIf ret_val > 26 Then

    '                    pointsNumberCurrentFrame = ((ret_val) / NbSegParams) - 1
    'Dim id_detection = 0
    'Dim dxy0 = Math.Sqrt(Math.Pow((Points_all(NbSegParams * 2 * NumImage - 1 + 4) - Points(4)), 2) + Math.Pow((Points_all(NbSegParams * 2 * NumImage - 1 + 3) - Points(3)), 2))
    '                    For n = 1 To pointsNumberCurrentFrame - 1
    'Dim dxy = Math.Sqrt(Math.Pow((Points_all(NbSegParams * 2 * NumImage - 1 + 4) - Points(4 + n * NbSegParams)), 2) + Math.Pow((Points_all(NbSegParams * 2 * NumImage - 1 + 3) - Points(3 + n * NbSegParams)), 2))
    '                        If dxy < dxy0 Then
    '                            dxy0 = dxy
    '                            id_detection = n
    '                        End If
    '                    Next

    '                    For k = 0 To Points.Length - 1
    '                        If k < NbSegParams * 2 Then
    '                            Points(k) = Points(id_detection * NbSegParams + k)
    '                        Else
    '                            Points(k) = 0
    '                        End If
    '                    Next

    '                End If
    '''**************************************************************

    '''**************************************************************
    '                For k = 0 To Points.Length - 1
    '                    mm.PrintMsg(Points(k).ToString())
    '                Next
    '''**************************************************************

    '''******************creation PointsAll**************************
    '                    pointsNumberCurrentFrame = ((ret_val) / NbSegParams) - 1
    '                    PointsNumber = pointsNumberCurrentFrame + PointsNumber
    '                    For li = 0 To (pointsNumberCurrentFrame - 1)
    '                        For ind = 0 To NbSegParams - 1
    '                            Points_all(index + ind) = Points(li * NbSegParams + ind)

    '                        Next ind
    '                        index = index + NbSegParams
    '                    Next li

    '                    For ind = 0 To NbSegParams - 1
    '                        Points_all(index + ind) = -1
    '                    Next ind
    '                    index = index + NbSegParams
    '''**********************************************************

    '                If NumImage Mod binning = 0 Then
    '                    ReDim Preserve Points_all((binning + PointsNumber) * NbSegParams - 1)

    '                    ReDim trcList(PointsNumber * NbTrackParams - 1)
    'Dim Pk = New Process(MainWindow, MM)
    '                    Pk.NbMaxPtsPerImage = UserMethods64.NbMaxPtsPerImage

    ''REGISTRATION 
    'Dim bead_ref As detection_data

    ''*******************************************
    ''Si que une bille par frame 
    'Dim drift = Pk.RegistrationOneBead(Points_all, bead_ref, MainWindow.roiTracking.Px, MainWindow.roiTracking.Py)
    ''si plusieurs detection par frame
    ''drift = Pk.RegistrationOffLine(Points_all, PointsNumber, binning, MainWindow.roiTracking.Px + (MainWindow.roiTracking.width / 2), MainWindow.roiTracking.Py + (MainWindow.roiTracking.height / 2), mm)
    ''*******************************************


    '                    driftTab(cpt, 0) = drift(0)
    '                    driftTab(cpt, 1) = drift(1)
    '                    driftTab(cpt, 2) = drift(2)
    '                    driftTab(cpt, 3) = drift(3)
    '                    driftTab(cpt, 4) = drift(4)
    '                    driftTab(cpt, 5) = drift(5)
    '                    driftTab(cpt, 8) = NumImage - 1
    '                    driftTab(cpt, 9) = ret_val




    ''mm.PrintMsg("DriftX : " + (driftTab(cpt, 0)).ToString() + "  -  DriftY : " + (driftTab(cpt, 1)).ToString() + "  -  SigmaY : " + driftTab(cpt, 3).ToString() + "  -  SigmaX : " + driftTab(cpt, 4).ToString() + "  -  Instensity : " + driftTab(cpt, 5).ToString())


    'Dim Timer_All_2 = Microsoft.VisualBasic.DateAndTime.Timer()

    ''****************Stage Discplacement****************
    '                    If MainWindow.isStageDisplacement Then
    '                        SetPlatineShiftDrift(mm, drift(0), drift(1))
    '                    End If

    'Dim R_sigmaXY, R_sigmaXYref As Double
    '                    If drift(4) <> 0 Then
    '                        R_sigmaXY = drift(3) / drift(4)
    '                        R_sigmaXYref = MainWindow.beadRef.SigmaX / MainWindow.beadRef.SigmaY
    '                        ratioSigma = R_sigmaXYref - R_sigmaXY
    '                    Else
    '                        R_sigmaXY = 0
    '                        R_sigmaXYref = 0
    '                        ratioSigma = 0
    '                    End If
    ''***************************************************

    '                    ReDim Points(Nb_Val - 1)
    '                    ReDim Points_all(Nb_Val * binning - 1)
    '                    ReDim trcList(PointsNumber * NbTrackParams - 1)
    '                    index = 0
    '                    PointsNumber = 0

    '                    driftTab(cpt, 6) = (Timer_All_2 - Timer_All_1)
    '                    cpt = cpt + 1
    '                    driftTab(cpt, 7) = ratioSigma
    '                End If

End Class
