using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Test
{
    internal class OpenCV_Test_Class: IDisposable // 영상처리는 메모리 관리가 중요하므로 IDisposable 추가하여 필요없는 것관리
    {
        // 회색으로

        IplImage gray;

        public IplImage GrayScale(IplImage src) 
        {
            //new IplImage(이미지크기, 정밀도, 채널)
            // 이미지 크기 => 대부분의 함수가 원본과 결과의 크기가 동일해야함(그레이의 경우)
            // 이미지의 정밀도 => 일반적으로 유효비트가 많을 수록 데이터의 처리결과는 더 정밀해짐 보통 U8쓰면됨
            // 이미지 채널 => 1개 색상 1 채널(아무런 색으로 설정해도 검은색으로 나옴 -> 3색조합으로 나타내기 때문) , RGB 컬러 3채널...
            gray = new IplImage(src.Size, BitDepth.U8, 1);
            //Cv.CvtColor(원본 ,결과, 변환타입)
            Cv.CvtColor(src, gray, ColorConversion.BgrToGray);
            return gray;
        }

        // 사용이 끝난 필드의 메모리를 해지하는 코드작성가능
        public void Dispose() 
        { 
            //gray라는 필드가 비어있는 값이 아니라면 이미지의 메모리를 해지한다는 의미
            if (gray != null) Cv.ReleaseImage(gray);
        }
    }
}
