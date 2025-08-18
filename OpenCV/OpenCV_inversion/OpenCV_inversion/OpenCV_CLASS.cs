using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.UserInterface;

namespace OpenCV_inversion
{
    class OpenCV_CLASS : IDisposable //불필요한 메모리 해제
    {
        // 색상반전
        IplImage inversion;

        public IplImage InversionImage(IplImage src)
        {
            inversion = new IplImage(src.Size, BitDepth.U8, 3);
            Cv.Not(src, inversion);
            return inversion;
        }

        public void Dispose() 
        {
            if (inversion != null) Cv.ReleaseImage(inversion);
        }
    }
}
