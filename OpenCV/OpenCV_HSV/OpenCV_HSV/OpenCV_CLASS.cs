using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_HSV
{
    // Hue 색상파라미터 참고
    // 특정 색의 HSV를 알려주는 pdf참고
    //HSV - 이미지나 영상에서 색상 검출하기 위해 사용
    //색상(Hue) - 빨강, 노랑, 파랑 3가지 색상으로 최대값 179 최솟값 0 // 최대값과 최소값 부근에서 빨간색을 가짐 ex) 빨 ----- 빨
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

            ////hus
            //// 마스크생성
            //Cv.InRangeS(h, 20, 30, h); // -> 20,30 -> 노란색만 나오게
            ////마스크 적용
            //Cv.Copy(src, hsv, h);

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



            //HUS 빨간색만 나오게 하기 -> 양 끝단의 색 그래서 2개임 lower/upper -> 노란색은 1개
            // 색상의 채널의 값만 조절하였기 때문에 명도 채도 안함 -> 흰색도 프린트됨
            IplImage lower_red = new IplImage(src.Size, BitDepth.U8, 1);
            IplImage upper_red = new IplImage(src.Size, BitDepth.U8, 1);
            IplImage red = new IplImage(src.Size, BitDepth.U8, 1);

            // 이전에는 원본에 덧씌웠지만 이번에는 각각 lower_red, higher_red에 저장
            Cv.InRangeS(h, 0, 10, lower_red); //lower_red에는 0부터 10까지의 범위가 색깔바에서의 범위임
            Cv.InRangeS(h, 170, 179, upper_red); // higher_red 170부터 179까지의 범위가

            //서로다른범위를 가지는 채널을 합칠수 있음
            //Cv.AddWeighted(첫번째 이미지, alpha(첫번째 이미지 가중치), 두번째 이미지, beta(두번째 이미지 가중치), Gamma(각 합계에 더해질값), 결과)
            Cv.AddWeighted(lower_red, 1.0, upper_red, 1.0, 0.0, red);
            // Alpha와 Beta가 1인 이유는 본연의 이미지 그대로 사용하기 위해 if 0.0을 한다면 지정된 범위를 0으로 만들어버림
            // Gamma가 0.0인 이유는 각합계에 더해질 값이 필요없어서

            //마스크 레드 사용 ex) 마스크가 red 값으로 되어있으면 red만 복사
            Cv.Copy(src, hsv, red);
            // 색상의 채널의 값만 조절하였기 때문에 명도 채도 안함 -> 흰색도 프린트됨


            return hsv;
        }

        public IplImage HSV_hap(IplImage src)
        {
            //3채널합
            hsv = new IplImage(src.Size, BitDepth.U8, 3);
            //red
            IplImage lower_red = new IplImage(src.Size, BitDepth.U8, 1);
            IplImage upper_red = new IplImage(src.Size, BitDepth.U8, 1);
            IplImage red = new IplImage(src.Size, BitDepth.U8, 1);

            Cv.CvtColor(src, hsv, ColorConversion.BgrToHsv);


            // CvScalar를 사용한 이유 HSV에서는 한개의 채널만 사용해서 상수한개의 값만 입력했었음
            // CVScalar(h,s,v)
            Cv.InRangeS(hsv, new CvScalar(0, 100, 100), new CvScalar(10, 255, 255),lower_red); // 최소값 -> 색상:0,명도:100,채도:100 / 최댓값 -> 색상: 10 명도: 255 채도: 255
            Cv.InRangeS(hsv, new CvScalar(170, 100, 100), new CvScalar(179, 255, 255), upper_red); // 최소값 -> 색상:170,명도:100,채도:100 / 최댓값 -> 색상: 179 명도: 255 채도: 255

            Cv.AddWeighted(lower_red, 1.0, upper_red, 1.0, 0.0, red);

            //copy를 위한 초기화 -> red로 값이 넘어갔기때문에
            Cv.SetZero(hsv);
            Cv.Copy(src, hsv,red);

            //하얀색 배경 HSV -> H:3 S:15 V:251

            return hsv;
        }

        public void Dispose()
        {
            if (hsv != null) Cv.ReleaseImage(hsv);
        }
    }
}
