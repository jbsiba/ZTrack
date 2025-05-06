using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MadCity
{
    public static class Madlib
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ProductInformation
        {
            public byte axis_bitmap;
            public short ADC_resolution;
            public short DAC_resolution;
            public short Product_id;
            public short FirmwareVersion;
            public short FirmwareProfile;
        }

        #region Handle Management
        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_InitHandle();

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_InitHandleOrGetExisting();

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_GrabHandle(
            short device
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_GrabHandleOrGetExisting(
            short device
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_GrabAllHandles();

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_GetAllHandles(
            [Out, MarshalAs(UnmanagedType.LPArray)]int[] handles,
            int size
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_NumberOfCurrentHandles();

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_GetHandleBySerial(
            short serial
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MCL_ReleaseHandle(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MCL_ReleaseAllHandles();
        #endregion

        #region Standard Device Movement
        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MCL_SingleReadZ(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MCL_SingleReadN(
            uint axis,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_SingleWriteZ(
            double zposition,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_SingleWriteN(
            double nposition,
            uint axis,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MCL_MonitorZ(
            double zposition,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MCL_MonitorN(
            double nposition,
            uint axis,
            int handle
            );
        #endregion

        #region Waveform Acquisition
        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_ReadWaveFormN(
            uint axis,
            uint DataPoints,
            double milliseconds,
            double[] waveform,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_Setup_ReadWaveFormN(
            uint axis,
            uint DataPoints,
            double milliseconds,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_Trigger_ReadWaveFormN(
            uint axis,
            uint DataPoints,
            [Out, MarshalAs(UnmanagedType.LPArray)]double[] waveform,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_LoadWaveFormN(
            uint axis,
            uint DataPoints,
            double milliseconds,
            double[] waveform,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_Setup_LoadWaveFormN(
            uint axis,
            uint DataPoints,
            double milliseconds,
            double[] waveform,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_Trigger_LoadWaveFormN(
            uint axis,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_TriggerWaveformAcquisition(
            uint axis,
            uint DataPoints,
            double[] waveform,
            int handle
            );
        #endregion

        #region Multi Axis Waveform Acquisition
        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_WfmaSetup(
            double[] wfDacX,
            double[] wfDacY,
            double[] wfDacZ,
            int dataPointsPerAxis,
            double milliseconds,
            ushort iterations,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_WfmaTriggerAndRead(
            double[] wfAdcX,
            double[] wfAdcY,
            double[] wfAdcZ,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_WfmaTrigger(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_WfmaRead(
            double[] wfAdcX,
            double[] wfAdcY,
            double[] wfAdcZ,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_WfmaStop(
            int handle
            );
        #endregion

        #region ISS Option
        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_PixelClock(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_LineClock(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_FrameClock(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_AuxClock(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_IssSetClock(
            int clock,
            int mode,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_IssResetDefaults(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_IssBindClockToAxis(
            int clock,
            int mode,
            int axis,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_IssConfigurePolarity(
            int clock,
            int mode,
            int handle
            );
        #endregion

        #region Cfocus
        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_CFocusSetFocusMode(
            bool focusModeOn,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_CFocusStep(
            double relativePositionChange,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_CFocusGetFocusMode(
            ref int focusLocked,
            int handle
            );

        #endregion

        #region Encoder
        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MCL_ReadEncoderZ(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_ResetEncoder(
            int handle
            );
        #endregion

        #region Tip Tilt Z
        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_ThetaX(
            double milliradians,
            ref double actual,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_ThetaY(
            double milliradians,
            ref double actual,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_MoveZCenter(
            double position,
            ref double actual,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_LevelZ(
            double position,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MCL_TipTiltHeight(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MCL_TipTiltWidth(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_MinMaxThetaX(
            ref double min,
            ref double max,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_MinMaxThetaY(
            ref double min,
            ref double max,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MCL_GetTipTiltThetaX(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MCL_GetTipTiltThetaY(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MCL_GetTipTiltCenter(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_CurrentMinMaxThetaX(
            ref double min,
            ref double max,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_CurrentMinMaxThetaY(
            ref double min,
            ref double max,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_CurrentMinMaxCenter(
            ref double min,
            ref double max,
            int handle
            );

        #endregion

        #region Clock Functionality
        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_ChangeClock(
            double milliseconds,
            short clock,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_GetClockFrequency(
            ref double adcfreq,
            ref double dacfreq,
            int handle
            );
        #endregion

        #region Device Information
        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_DeviceAttached(
                uint milliseconds,
                int handle
                );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double MCL_GetCalibration(
                 uint axis,
                 int handle
                 );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_GetFirmwareVersion(
            ref short version,
            ref short profile,
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MCL_PrintDeviceInfo(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_GetSerialNumber(
            int handle
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_GetProductInfo(
                ref ProductInformation pi,
                int handle
                );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MCL_DLLVersion(
            ref short version,
            ref short revision
            );

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MCL_CorrectDriverVersion();

        [DllImport("Madlib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int MCL_GetCommandedPosition(ref double xCom, ref double yCom, ref double zCom, int handle);
        #endregion
    }

}