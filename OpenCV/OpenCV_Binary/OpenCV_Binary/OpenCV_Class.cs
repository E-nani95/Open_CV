using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//이진화
//    어떤 영상이나 이미지를 임계점을 기준으로 흑색또는 흰색의 색상으로 변환
//    -> 노이즈제거 또는 필터링 용도(너무 작거나 너무 큰 픽셀을)
//    -> 많은 함수의 계산 이미지로 사용
namespace OpenCV_Binary
{
    class OpenCV_Class : IDisposable
    {
        IplImage bin;
        IplImage gray;

        public IplImage GrayImage(IplImage src)
        {
            bin = new IplImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, gray, ColorConversion.BgrToGray);
            return bin;
        }


        public IplImage BinaryImage(IplImage src)
        {
            //Binary는  흑백이라 채널 1 
            bin = new IplImage(src.Size, BitDepth.U8, 1);
            // src로 들어오는 이미지는 여러가지 색이라서 단색으로 바꿔주는 과정
            Cv.CvtColor(src, bin, ColorConversion.BgrToGray);
            
            
            // this.GrayImage(src); -> 이 위로는 회색으로 바꾸는 거랑 코드가 같아서 회색으로 바꾸는 코드 이렇게 써도됨
            
            //원본과 결과를 같은 변수(bin)로 두는 이유는 원본을 덧씌우기 위해서 -> 함수로 들어올때 복사되서 오기떄문에 함수안에 원본이라는뜻
            Cv.Threshold(bin, bin, 150, 255, ThresholdType.Binary);  // 많이쓰는거는 ThresholdType.Binary 아니면 ThresholdType.BinaryInv (인버스)
            //임계점(세번쨰 값 == 150)을 넘으면 최대값 못 넘으면 최소값으로 감 0 아니면 255
            return bin;
        }



        public void Dispose()
        {
            if (bin != null) Cv.ReleaseImage(bin);
        }
    }
}
