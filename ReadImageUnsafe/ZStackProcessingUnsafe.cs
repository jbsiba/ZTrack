using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZStackUnsafeProcessing
{
    public static class Unmanaged
    {
        static Unmanaged()
        {
            // Dynamically loads 32-bit or 64-bit DLLs at runtime
            var is64 = Environment.Is64BitProcess;

            // Load the DLLs installed in the PALMTracer directory (avoids conflicts with other versions of DLLs with the same name)
            //string directory = (string) Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\IINS\\PALMTracer", "InstallDirectory","");
            //LoadLibrary(directory + "GPU_PALM.dll");
            //LoadLibrary(directory + "CPU_PALM.dll" );
            //LoadLibrary(directory + "Live_PALM.dll");
            //LoadLibrary(directory + "tracking.dll" );
            //LoadLibrary(directory + "GPU_PALM.dll");

            //System.Windows.Forms.MessageBox.Show("CPU_PALM Loaded: " + loaded.ToString());

        }


        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("GPU_PALM.dll")]
        public static extern void OpenPALMProcessing(ushort[] image, double[] pointsList, uint maxNbPoints, uint sizeStk, uint sizeX, uint sizeY, uint waveletNo, double thresholdVal, double watershedRatio, double volMin, double intMin, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size, ushort IsComputingZ, double[] SigmaXCoefs, double[] SigmaYCoefs, double ThreeDThickness/*µm*/, double ThreeDSampling/*µm*/, double pixelSize /*µm*/);

        [DllImport("GPU_PALM.dll")]
        public static extern int PALMProcessing();

        [DllImport("GPU_PALM.dll")]
        public static extern void closePALMProcessing();


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


        public static void ReadImage(MMAppLib.UserCall64 mm, long src, short x, short y, short cx, short cy, ushort[] vbBuffer)
        {
            unsafe
            {
                fixed (UInt16* pBuffer = &vbBuffer[0])
                {
                    short bpp = 16;

                    mm.ReadImageUnsafe(ref src, ref x, ref y, ref cx, ref cy, ref bpp, (long)pBuffer);

                    //int testImage;
                    //string imageName = "testImage";
                    //mm.CreateImage(ref cx, ref cy, ref bpp, ref imageName, out testImage);
                    //mm.WriteImageUnsafe(ref testImage, ref x, ref y, ref cx, ref cy, ref bpp, (long)pBuffer);
                }
            }
        }

        public static void ReadFrame(MMAppLib.UserCall64 mm, int src, short x, short y, short cx, short cy, ushort[] vbBuffer)
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

        public static void WriteImage(MMAppLib.UserCall64 mm, long src, short x, short y, short cx, short cy, short bpp, ushort[] vbBuffer)
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

        public static void WriteImageToPlane(MMAppLib.UserCall64 mm, long src, int plane, short x, short y, short cx, short cy, short bpp, ushort[] vbBuffer)
        {
            unsafe
            {
                fixed (UInt16* pBuffer = &vbBuffer[0])
                {
                    mm.WriteImageToPlaneUnsafe(ref src, ref plane, ref x, ref y, ref cx, ref cy, ref bpp,
                    (long)pBuffer);
                }
            }
        }

        public static void ReadImageFromPlane(MMAppLib.UserCall64 mm, long src, int plane, short x, short y, short cx, short cy, ushort[] vbBuffer)
        {
            unsafe
            {
                fixed (UInt16* pBuffer = &vbBuffer[0])
                {
                    short bpp = 16;

                    mm.ReadImageFromPlaneUnsafe(ref src, ref plane, ref x, ref y, ref cx, ref cy, ref bpp, (long)pBuffer);

                }
            }
        }



        public static void CPU_OpenPALMProcessing(ushort[] image, double[] Points, uint maxNbPoints, uint sizeX, uint sizeY, uint waveletNo, double thresholdVal, double watershedRatio, double volMin, double intMin, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size)
        {
            _OpenPALMProcessing(image, Points, maxNbPoints, sizeY, sizeX, waveletNo, thresholdVal, watershedRatio, volMin, intMin, gaussFit, sigmaX, sigmaY, angle, size);
        }

        public static int CPU_PALMProcessing()
        {
            return _PALMProcessing();
        }

        public static void CPU_closePALMProcessing()
        {
            try
            {
                _closePALMProcessing();
            }
            catch (Exception e)
            {

            }
        }

        public static void GPU_OpenPALMProcessing(ushort[] image, double[] Points, uint maxNbPoints, uint sizeStk, uint sizeX, uint sizeY, uint waveletNo, double thresholdVal, double watershedRatio, double volMin, double intMin, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size, ushort IsComputingZ, double[] SigmaXCoefs, double[] SigmaYCoefs, double ThreeDThickness/*µm*/, double ThreeDSampling/*µm*/, double pixelSize /*µm*/)
        {
            //MessageBox.Show("GPU_OpenPALMProcessing");
            unsafe
            {
                OpenPALMProcessing(image, Points, maxNbPoints, sizeStk, sizeY, sizeX, waveletNo, thresholdVal, watershedRatio, volMin, intMin, gaussFit, sigmaX, sigmaY, angle, size, IsComputingZ, SigmaXCoefs, SigmaYCoefs, ThreeDThickness/*µm*/, ThreeDSampling/*µm*/, pixelSize /*µm*/);
            }
        }

        public static int GPU_PALMProcessing()
        {
            unsafe
            {


                return PALMProcessing();
            }
        }

        public static void GPU_closePALMProcessing()
        {
            unsafe
            {
                closePALMProcessing();
            }
        }

        public static int CPU_Processing(MMAppLib.UserCall64 meta, long src, int nb_planes, int NbSegParams, int srcDepth, int LRXoffset, int LRYoffset, int LRZoffset, int LRDZ, double[] Points, uint maxNbPoints, uint sizeX, uint sizeY, uint waveletNo, double thresholdVal, double watershedRatio, double volMin, double intMin, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size)
        {
            int ret_val = 0;
            int pointsNumber = 0;
            //int testImage;
            unsafe
            {
                //try
                // {
                ushort[] image = new ushort[sizeX * sizeY];
                ushort[] gLine16 = new ushort[sizeX * sizeY];
                int index = 0;
                fixed (UInt16* ptr = &image[0])
                {
                    //fixed(UInt16* ptr1 = &gLine16[0])
                    //  {
                    //short xPos = (short)0;
                    //short yPos = (short)0;
                    short xPos = (short)LRXoffset;
                    short yPos = (short)LRYoffset;
                    short nPixels = (short)sizeX;
                    short depth = (short)srcDepth;
                    // short xStart = 0;
                    // short yStart = 0;
                    short width = (short)sizeX;
                    short height = (short)sizeY;

                    //string imageName = "testImage";
                    //meta.CreateImage(ref width, ref height, ref depth, ref imageName, out testImage);

                    for (int k = LRZoffset; k <= LRZoffset + LRDZ - 1; k++)
                    {

                        double[] Points1 = new double[(int)(maxNbPoints / nb_planes)];


                        //for (int j = LRYoffset; j <= LRYoffset + sizeY - 1; j++)
                        //{
                        //    short xPos = (short)LRXoffset, yPos = (short)j, nPixels = (short)sizeX, depth = (short)srcDepth, xStart = 0, yStart = 0;
                        //    object tab = gLine16;
                        //    meta.ReadRowEx2(ref src, ref xPos, ref yPos, ref nPixels, ref depth, ref xStart, ref yStart, ref tab);
                        //    for (int i = LRXoffset; i <= LRXoffset + sizeX - 1; i++)
                        //    {
                        //        meta.PrintMsg(gLine16[i - LRXoffset].ToString());
                        //        image[(j - LRYoffset) + sizeY * (i - LRXoffset)] = gLine16[i - LRXoffset];
                        //    }
                        //}


                        meta.ReadImageFromPlaneUnsafe(ref src, ref k, ref xPos, ref yPos, ref width, ref height, ref depth, (long)ptr);
                        //meta.SetActivePlane(ref src, ref k);
                        //meta.ReadImageUnsafe(ref src, ref xPos, ref yPos, ref width, ref height, ref depth, (long)ptr);

                        try
                        {
                            _OpenPALMProcessing(image, Points1, (uint)(maxNbPoints / nb_planes), sizeY, sizeX, waveletNo, thresholdVal, watershedRatio, volMin, intMin, gaussFit, sigmaX, sigmaY, angle, size);
                            ret_val = _PALMProcessing();
                        }
                        catch (Exception e)
                        {

                        }


                        int pointsNumberCurrentFrame = (ret_val / NbSegParams) - 1;

                        try
                        {
                            if (pointsNumberCurrentFrame > 1)
                            {
                                _closePALMProcessing();
                            }

                        }
                        catch (Exception e)
                        {
                            meta.PrintMsg("CPU Processing Error: " + e.ToString());
                        }


                        //meta.PrintMsg(pointsNumberCurrentFrame.ToString());
                        pointsNumber = pointsNumberCurrentFrame + pointsNumber;

                        // copy data from 'points1' to 'points

                        for (int li = 0; li <= pointsNumberCurrentFrame - 1; li++)
                        {
                            for (int ind = 0; ind <= NbSegParams - 1; ind++)
                                Points[index + ind] = Points1[li * NbSegParams + ind];

                            // Inverser X et Y
                            double inter = Points[index + 3];
                            Points[index + 3] = Points[index + 4];
                            Points[index + 4] = inter;
                            index = index + NbSegParams;
                        }

                        for (int ind = 0; ind <= NbSegParams - 1; ind++)
                            Points[index + ind] = -1;

                        index = index + NbSegParams;

                        //meta.WriteImageUnsafe(ref testImage, ref xStart, ref yStart, ref width, ref height, ref depth, (long)ptr);
                        //double zDistance = 0;
                        //meta.AddImagePlane(ref testImage, ref zDistance);
                        //  }
                    }
                }
                // }
                // catch (Exception e)
                // {
                // }
            }
            return (pointsNumber + nb_planes) * NbSegParams;
        }


        public static int CPUProcessing(bool isLive, MMAppLib.UserCall64 mm, long src, double[] Points, uint maxNbPoints, uint sizeX, uint sizeY, uint waveletNo, double thresholdVal, double watershedRatio, double volMin, double intMin, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size)
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
                        int inter = (int)src;
                        mm.ReadFrameUnsafe(ref inter, ref x, ref y, ref width, ref height, ref bpp, (long)ptr);
                    }
                    else
                    {
                        mm.ReadImageUnsafe(ref src, ref x, ref y, ref width, ref height, ref bpp, (long)ptr);
                    }

                    _OpenPALMProcessing(image, Points, maxNbPoints, sizeY, sizeX, waveletNo, thresholdVal, watershedRatio, volMin, intMin, gaussFit, sigmaX, sigmaY, angle, size);
                    int ret_val = _PALMProcessing();

                    try
                    {
                        _closePALMProcessing();
                    }
                    catch (Exception e)
                    {

                    }


                    return ret_val;
                }

            }
        }
        
        
        public static int CPUProcessingROI(bool isLive, MMAppLib.UserCall64 mm, long src, double[] Points, uint maxNbPoints, uint sizeX, uint sizeY, uint refX, uint refY, uint waveletNo, double thresholdVal, double watershedRatio, double volMin, double intMin, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size)
        {
            unsafe
            {
                ushort[] image = new ushort[sizeX * sizeY];
                fixed (UInt16* ptr = &image[0])
                {
                    short bpp = 16;
                    short x = (short)refX;
                    short y = (short)refY;
                    short width = (short)sizeX;
                    short height = (short)sizeY;

                    if (isLive == true)
                    {
                        int inter = (int)src;
                        //long hret=0;
                        //short depth = 0;
                        //string str = "toto";
                        mm.ReadFrameUnsafe(ref inter, ref x, ref y, ref width, ref height, ref bpp, (long)ptr);
                       // mm.CreateImage(ref width,ref height,ref depth,ref str,out hret);
                        
                        int a = 0;
                        for (int i = 0; i < image.Length - 1; i++)
                        {
                            a += image[i];
                        }
                        a = a / image.Length;
                    }
                    else
                    {
                        mm.ReadImageUnsafe(ref src, ref x, ref y, ref width, ref height, ref bpp, (long)ptr);
                        int a = 0;
                        for (int i = 0; i < image.Length - 1; i++)
                        {
                            a += image[i];
                        }
                        a = a / image.Length;
                    }

                    _OpenPALMProcessing(image, Points, maxNbPoints, sizeY, sizeX, waveletNo, thresholdVal, watershedRatio, volMin, intMin, gaussFit, sigmaX, sigmaY, angle, size);
                    int ret_val = _PALMProcessing();

                    try
                    {
                        _closePALMProcessing();
                    }
                    catch (Exception e)
                    {

                    }


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

        //public static int LiveProcessing(bool isLive, ulong[] TMP, MMAppLib.UserCall64 mm, long src, ushort numImage, ushort sizeStk, double[] Points, uint maxNbPoints, uint sizeX, uint sizeY, uint waveletNo, double thresholdVal, double watershedRatio, double volMin, double intMin, string computing, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size)
        public static int LiveProcessing(bool isLive, MMAppLib.UserCall64 mm, long src, ushort numImage, ushort sizeStk, double[] Points, uint maxNbPoints, uint sizeX, uint sizeY, uint waveletNo, double thresholdVal, double watershedRatio, double volMin, double intMin, string computing, ushort gaussFit, double sigmaX, double sigmaY, double angle, ushort size)
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
                    //TMP[numImage] = CalcIntegratedSum(image, sizeX, sizeY);

                    if (isLive == true)
                    {
                        int inter = numImage;
                        mm.ReadFrameUnsafe(ref inter, ref x, ref y, ref width, ref height, ref bpp, (long)ptr);
                        //TMP[numImage] = CalcIntegratedSum(image, sizeX, sizeY);
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

                    //TMP[numImage] = CalcIntegratedSum(image, sizeX, sizeY);

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
                // MessageBox.Show("No enough memory !!!!!!!!!!!!!");
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