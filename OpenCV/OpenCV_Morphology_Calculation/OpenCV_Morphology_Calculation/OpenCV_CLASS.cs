using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Morphology_Calculation
{

        //열기연산 -> 침식 적용 후 팽창 적용
        //닫기연산 -> 팽창 적용 후 침식 적용
        //그라디언트(Gradient) 연산 -> 팽창에서 침식 제외 => 팽창 - 침식 = 그라디언트
        //탑햇 연산 -> 원본에서 열기제외 => 원본 - 열기 = 탑햇
        //블랙햇 연산 -> 닫기에서 원본 제외 -> 닫기 - 원본 = 블랙햇

    public class OpenCV_CLASS : IDisposable
    {
        IplImage bin;
        IplImage morp;

        public IplImage Binary (IplImage src, int thershold) 
        {
            bin = new IplImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, bin, ColorConversion.BgrToGray);
            Cv.Threshold(bin, bin, thershold, 255, ThresholdType.Binary);
            return bin;
        
        }

        public IplImage MorphologyImage(IplImage src) 
        {
            morp = new IplImage(src.Size, BitDepth.U8,1);
            bin = this.Binary(src, 50);
            // 팽창이나 침식은 null로 사용가능
            // Morphology 연산은 Convolution Kernel을 생성해야함
            //Convolution Kernel 생성
            IplConvKernel element = new IplConvKernel(3, 3, 1, 1, ElementShape.Rect);

            //Morphology 연산
            //Cv.MorphologyEx(원본,결과,임시,컨벌루션 커널, 연산 방법, 반복횟수) -> 임시는 잠깐 결과를 저장할곳 -> 크가가 같은 인수 넣어주면됨
            Cv.MorphologyEx(bin, morp, bin, element, MorphologyOperation.Gradient, 10);
            return morp;

        }


        public void Dispose()
        {
            if(bin !=null) Cv.ReleaseImage(bin);
            if(morp !=null) Cv.ReleaseImage(morp);
        }
    }
}
