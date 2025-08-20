using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_HSV
{
    //HSV - 이미지나 영상에서 색상 검출하기 위해 사용
    //색상(Hue) - 빨강, 노랑, 파랑 3가지 색상으로 최대값 179 최솟값 0 // 최대값과 최소값 부근에서 빨간색을 가짐
    //채도 (Saturation)- 색상의 진하고 엶음을 나타내는 포화도 -> 아무것도 섞지 않아 맑고 원색에 가까운걸 채도가 높다고 표현// 최댓값 255 최소값 0
    //명도(Value) - 색상의 밝고 어두운 정도를 나타내는 속성 -> 어두운걸 저명도 밝은걸 고명도라고 함 -> 최댓값 255 최소값0

    public class OpenCV_CLASS : IDisposable
    {
        IplImage hsv;


        public IplImage HSV(IplImage src)
        {
            hsv = new IplImage(src.Size, BitDepth.U8, 3);

            // 3가지 속성으로 나눔 -> 채널이 1인 이유는 HSV에서 각각 1개씩만 출력하므로
            // 각 속성을 선언
            IplImage h = new IplImage(src.Size, BitDepth.U8, 1);
            IplImage s = new IplImage(src.Size, BitDepth.U8, 1);
            IplImage v = new IplImage(src.Size, BitDepth.U8, 1);

            // 초기 속성은 bgr -> hsv속성으로 바꿔줌
            //Cv.CvtColor(원본,결과,변환방법)-> gray로 바꿀때랑 동일
            Cv.CvtColor(src, hsv, ColorConversion.BgrToHsv);

            // 이미지 나누는 거는 최대 4개로 나눠짐
            //CV.Split(나눌이미지, 채널1, 채널2, 채널3, 채널4) -> h,s,v,alpha
            Cv.Split(hsv, h, s, v, null);

            // 현재 hsv에는 원본이미지가 hsv에 저장되어잇음 h,s,v에는 각각의 채널이 저장되어있음
            // hsv를 이용하여 채널을 나누었으므로 hsv필드를 초기화시켜 비어있는 이미지로 변경
            // 이유는 hsv를 결과값으로 return하기 위해
            // 카피를 사용하여 마스크를 적용해 표현할 예정 -> 카피는 덪씌우는 과정 -> 필드에 이미지가 있다면 올바르지 않게 표시되기 때문
            hsv.SetZero();

            //Cv.InRangeS(원본 ,최소, 최대, 결과)
            // 원본과 결과가 같은 이유는 원본에 결과를 덪씌우기 때문

            //Cv.Copy(원본, 결과. 마스크)

            //hus
            // 마스크생성
            Cv.InRangeS(h, 20, 30, h); // -> 20,30 -> 노란색만 나오게
            //마스크 적용
            Cv.Copy(src, hsv, h);

            ////Saturation
            //// 마스크생성
            //Cv.InRangeS(s, 20, 30, s); // -> 20,30 -> 노란색만 나오게
            ////마스크 적용
            //Cv.Copy(src, hsv, s);

            ////Value
            //// 마스크생성
            //Cv.InRangeS(v, 20, 30, v); // -> 20,30 -> 노란색만 나오게
            ////마스크 적용
            //Cv.Copy(src, hsv, v);

            return hsv;
        }
        public void Dispose()
        {
            if (hsv != null) Cv.ReleaseImage(hsv);
        }
    }
}
