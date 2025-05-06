using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace StreamProcessingUnsafe
{
    public static class Unmanaged
    {
        [DllImport("CPU_PALM.dll")]
        public static extern void _OpenPALMProcessing(ushort[] image, double[] pointsList, uint maxNbPoints, uint sizeX, uint sizeY, uint waveletNo, double thresholdVal, double watershedRatio, double volMin, double intMin, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size);

        [DllImport("CPU_PALM.dll")]
        public static extern int _PALMProcessing();

        [DllImport("CPU_PALM.dll")]
        public static extern void _closePALMProcessing();

        [DllImport("CPU_PALM.dll")]
        public static extern double RunCalibrationFit(double[] sigma, double[] Z, ushort pointsNbr, double[] C);

        [DllImport("Live_PALM.dll")]
        public static extern void __OpenPALMProcessing(ushort[] image, double[] pointsList, uint maxNbPoints, uint sizeX, uint sizeY, uint waveletNo, double thresholdVal, double watershedRatio, double volMin, double intMin, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size);

        [DllImport("Live_PALM.dll")]
        public static extern int __PALMProcessing();

        [DllImport("Live_PALM.dll")]
        public static extern void __closePALMProcessing();

        [DllImport("Live_PALM.dll")]
        public static extern void AllocateMemory(ushort frameCount, ushort width, ushort height);

        [DllImport("Live_PALM.dll")]
        public static extern void CopyFrame(ushort numImage, ushort[] image, ushort frameCount, ushort width, ushort height);

        [DllImport("Live_PALM.dll")]
        public static extern void LaunchGaussianFit(double[] pointsList, uint pointsListSize, ushort sizeStk, ushort sizeDataX, ushort sizeDataY, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size, ushort iterNum, ushort fromcplusplus, ushort computeZ, double[] SigmaXCoefs, double[] SigmaYCoefs, double ThreeDThickness/*µm*/, double ThreeDSampling/*µm*/, double pixelSize/*µm*/);

        [DllImport("Live_PALM.dll")]
        public static extern void GaussianVisuGPU(double[] gaussianPointsList, double[] pointsList, uint pointsListSize, ushort sizeStk, ushort width, ushort height, ushort sizeReg, ushort zoom, double conversionRatio, double pixelSize);

        [DllImport("CPU_PALM.dll")]
        public static extern void GaussianVisuCPU(double[] gaussianPointsList, double[] pointsList, uint pointsListSize, ushort sizeStk, ushort width, ushort height, ushort sizeReg, ushort zoom, double conversionRatio, double pixelSize);

        [DllImport("tracking.dll")]
        public static extern int tracking(double[] pointsList, uint pointsListSize, double[] trc, uint trcSize, double maxSpeed, double dZdX, double minLife, double decrease, uint allowFusiondisso, double costBirth, uint nbDim, uint model, uint nbTimes);

        [DllImport("tracking.dll")]
        public static extern int tracking_30(double[] pointsList, uint pointsListSize, double[] trc, uint trcSize, double maxSpeed, double dZdX, double minLife, double decrease, uint allowFusiondisso, double costBirth, uint nbDim, uint model, uint nbTimes);

        public static bool memoryError = false;

        public static void ReadImage(MMAppLib.UserCall mm, int src, short x, short y, short cx, short cy, ushort[] vbBuffer)
        {
            unsafe
            {
                fixed (UInt16* pBuffer = &vbBuffer[0])
                {
                    short bpp = 16;
                    mm.ReadImageUnsafe(ref src, ref x, ref y, ref cx, ref cy, ref bpp, (long)pBuffer);
                }
            }
        }

        public static void ReadFrame(MMAppLib.UserCall mm, int src, short x, short y, short cx, short cy, ushort[] vbBuffer)
        {
            unsafe
            {
                fixed (UInt16* pBuffer = &vbBuffer[0])
                {
                    short bpp = 16;
                    mm.ReadFrameUnsafe(ref src, ref x, ref y, ref cx, ref cy, ref bpp, (long)pBuffer);
                }
            }
        }

        public static void WriteImage(MMAppLib.UserCall mm, int src, short x, short y, short cx, short cy, short bpp, ushort[] vbBuffer)
        {
            unsafe
            {
                fixed (UInt16* pBuffer = &vbBuffer[0])
                {
                    mm.WriteImageUnsafe(ref src, ref x, ref y, ref cx, ref cy, ref bpp,
                    (long)pBuffer);
                }
            }
        }

        public static int CPUProcessing(bool isLive, MMAppLib.UserCall mm, int src, double[] Points, uint maxNbPoints, uint sizeX, uint sizeY, uint waveletNo, double thresholdVal, double watershedRatio, double volMin, double intMin, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size)
        {
            unsafe
            {
                ushort[] image = new ushort[sizeX * sizeY];
                fixed (UInt16* ptr = &image[0])
                {
                    short bpp = 16;
                    short x = 0;
                    short y = 0;
                    short width = (short)sizeX;
                    short height = (short)sizeY;

                    if (isLive == true)
                    {
                        int inter = src;
                        mm.ReadFrameUnsafe(ref inter, ref x, ref y, ref width, ref height, ref bpp, (long)ptr);
                    }
                    else
                    {
                        mm.ReadImageUnsafe(ref src, ref x, ref y, ref width, ref height, ref bpp, (long)ptr);
                    }

                    _OpenPALMProcessing(image, Points, maxNbPoints, sizeY, sizeX, waveletNo, thresholdVal, watershedRatio, volMin, intMin, gaussFit, sigmaX, sigmaY, angle, size);
                    int ret_val = _PALMProcessing();
                    _closePALMProcessing();

                    return ret_val;
                }

            }
        }


        public static ulong CalcIntegratedSum(ushort[] gImage, uint sizeX, uint sizeY)
        {
            ulong sum = 0;

            for (int i = 0; i < sizeY; i++)
            {
                for (int j = 0; j < sizeX; j++)
                {
                    sum += gImage[i * sizeX + j];
                }
            }

            return sum;
        }

        public static int LiveProcessing(bool isLive, MMAppLib.UserCall mm, int src, ushort numImage, ushort sizeStk, double[] Points, uint maxNbPoints, uint sizeX, uint sizeY, uint waveletNo, double thresholdVal, double watershedRatio, double volMin, double intMin, string computing, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size)
        {
            unsafe
            {

                ushort[] image = new ushort[sizeX * sizeY];
                fixed (UInt16* ptr = &image[0])
                {
                    short bpp = 16;
                    short x = 0;
                    short y = 0;
                    short width = (short)sizeX;
                    short height = (short)sizeY;
                    //mm.ReadImageUnsafe(ref src, ref x, ref y, ref width, ref height, ref bpp, (long)ptr);

                    // only for debug
                    //int inter1 = numImage + 30;
                    //mm.ReadFrameUnsafe(ref inter1, ref x, ref y, ref width, ref height, ref bpp, (long)ptr);

                    if (isLive == true)
                    {
                        int inter = numImage;
                        mm.ReadFrameUnsafe(ref inter, ref x, ref y, ref width, ref height, ref bpp, (long)ptr);
                    }
                    else
                    {
                        mm.ReadImageUnsafe(ref src, ref x, ref y, ref width, ref height, ref bpp, (long)ptr);
                    }

                    if (((computing == "3D") || (computing == "Wave+Gaussian")) && (Unmanaged.memoryError == false) && (isLive == true))
                        CopyMemory(numImage, image, sizeStk, (ushort)sizeY, (ushort)sizeX);

                    // 3D or Calibration
                    if (((gaussFit == 2) || (gaussFit == 3) || (gaussFit == 4)) && (Unmanaged.memoryError == false) && (isLive == false))
                        CopyMemory(numImage, image, sizeStk, (ushort)sizeY, (ushort)sizeX);

                    __OpenPALMProcessing(image, Points, maxNbPoints, sizeY, sizeX, waveletNo, thresholdVal, watershedRatio, volMin, intMin, gaussFit, sigmaX, sigmaY, angle, size);
                    int ret_val = __PALMProcessing();
                    __closePALMProcessing();

                    //***********************************************
                    //StreamWriter sr = new StreamWriter("D:\\Image_WT.txt");
                    //for (int j = 0; j < sizeX; j++)
                    //{
                    //    sr.WriteLine("");
                    //    for (int i = 0; i < sizeY; i++)
                    //        sr.Write(image[j*sizeY+i].ToString()+Convert.ToChar(9));
                    //}
                    //sr.Close();
                    //***********************************************

                    return ret_val;
                }

            }
        }

        public static int TrackingProcessing(double[] pointsList, uint pointsListSize, double[] trc, uint trcSize, double maxSpeed, double dZdX, double minLife, double decrease, uint allowFusiondisso, double costBirth, uint nbDim, uint model, uint nbTimes)
        {
            unsafe
            {
                return tracking(pointsList, pointsListSize, trc, trcSize, maxSpeed, dZdX, minLife, decrease, allowFusiondisso, costBirth, nbDim, model, nbTimes);
            }
        }

        public static int TrackingProcessing_30(double[] pointsList, uint pointsListSize, double[] trc, uint trcSize, double maxSpeed, double dZdX, double minLife, double decrease, uint allowFusiondisso, double costBirth, uint nbDim, uint model, uint nbTimes)
        {
            unsafe
            {
                return tracking_30(pointsList, pointsListSize, trc, trcSize, maxSpeed, dZdX, minLife, decrease, allowFusiondisso, costBirth, nbDim, model, nbTimes);
            }
        }

        public static void AllocateFrames(ushort frameCount, ushort width, ushort height)
        {
            try
            {
                AllocateMemory(frameCount, width, height);
            }
            catch (Exception exc)
            {
                memoryError = true;
                MessageBox.Show("Not enough memory for GPU processing !!!!!!!!!!!!!");
                //MessageBox.Show(exc.Message);
            }
        }

        public static void CopyMemory(ushort numImage, ushort[] image, ushort frameCount, ushort width, ushort height)
        {
            try
            {
                CopyFrame(numImage, image, frameCount, width, height);
            }
            catch (Exception exc)
            {
                memoryError = true;
                MessageBox.Show(exc.Message);
            }
        }

        public static void LaunchFit(double[] pointsList, uint pointsListSize, ushort sizeStk, ushort sizeDataX, ushort sizeDataY, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size, ushort iterNum, ushort computeZ, double[] SigmaXCoefs, double[] SigmaYCoefs, double ThreeDThickness, double ThreeDSampling, double pixelSize/*µm*/)
        {
            try
            {
                LaunchGaussianFit(pointsList, pointsListSize, sizeStk, sizeDataY, sizeDataX, gaussFit, sigmaX, sigmaY, angle, size, iterNum, 0, 1/*0*/, SigmaXCoefs, SigmaYCoefs, ThreeDThickness/*µm*/, ThreeDSampling/*µm*/, pixelSize);
            }
            catch (Exception exc)
            {
                memoryError = true;
                MessageBox.Show(exc.Message);
            }

        }

        public static double RunCalibration(double[] sigma, double[] Z, ushort pointsNbr, double[] C)
        {
            return RunCalibrationFit(sigma, Z, pointsNbr, C);
        }

        public static void GaussianVisuGPU_Unsafe(double[] gaussianPointsList, double[] pointsList, uint pointsListSize, ushort sizeStk, ushort width, ushort height, ushort sizeReg, ushort zoom, double conversionRatio, double pixelSize)
        {
            try
            {
                GaussianVisuGPU(gaussianPointsList, pointsList, pointsListSize, sizeStk, width, height, sizeReg, zoom, conversionRatio, pixelSize);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public static void GaussianVisuCPU_Unsafe(double[] gaussianPointsList, double[] pointsList, uint pointsListSize, ushort sizeStk, ushort width, ushort height, ushort sizeReg, ushort zoom, double conversionRatio, double pixelSize)
        {
            try
            {
                GaussianVisuCPU(gaussianPointsList, pointsList, pointsListSize, sizeStk, width, height, sizeReg, zoom, conversionRatio, pixelSize);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

    }
}