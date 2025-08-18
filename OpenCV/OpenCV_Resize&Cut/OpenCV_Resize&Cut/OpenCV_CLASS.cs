using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Resize_Cut
{
    internal class OpenCV_CLASS : IDisposable
    {
        //피라미드 함수는 -> 샘플링을 통해함
        //리사이즈는 -> 보간(interpolation)
        // 샘플링 크기 키우면 부드럽고 리사이즈는 각져있음
        //피라미드는 2의 배수로만 리사이즈는 마음대로

        IplImage resize;
        IplImage slice;
        public IplImage ResizeImage(IplImage src)
        {
            resize = new IplImage(new CvSize(src.Width / 4, src.Height - 1200), BitDepth.U8, 3);
            //Cv.Resize(원본,결과,복안법)
            Cv.Resize(src, resize, Interpolation.Linear); // 쌍선형보간법이 제일 보편적임
            return resize;
        }

        //자르기 Slice
        // 자르기는 이미지의 크기를 조절x -> 해당 원본에서 해당부분을 잘라서 가져옴 -> 저장할 필드의 크기를 이미지의 크기에 맞게 설정해야함
        //관심영역을 이미지를 담을 영역과 동일하게 설정하고 resize나 복사를 하여 적용
        //관심영역 -> 선택된 부분을 잘라내주는 역할
        // 검출하는 매소드 사용시 유용하게 사용가능 -> 알고리즘 생성시 하나만 구분하는게 아니라 여러상태를 구분해야하는 경우 
        //ex) 이미지에서 원과 원색상을 검출하는 경우 -> 이미지에서 각각 원검출 후 그 검출된 부분에서 색상구분 실행

        public IplImage SliceImage(IplImage src)
        {
            slice = new IplImage(new CvSize(350, 150), BitDepth.U8, 3);
            //관심영역을 총 3가지
            //But 하나만 해도 문제없음
            //new CvRect -> 사각형 크기설정 CvRect(x좌표,y좌표,사각형 넓이,사각형 높이) -> 마우스랑 동일한 느낌 좌상단을 클릭하여 높이와 넓이를 맞춰준다는 느낌 왼쪽 상단 (0,0) 우측하단(max,max)-> 수학에서 x,y 좌표계랑다름

            //관심영역 자르는 법 3가지
            //1. ROI -> 사각형 크기설정 -> 바꿀 이미지(src).ROI = 사각형 크기설정(CvRect)
            //src.ROI = new CvRect(750,840,slice.Width,slice.Height);

            //2. SetROI -> 바꿀이미지(src).SetROI(사각형 크기설정(CvRect))
            //src.SetROI(new CvRect(750,840,slice.Width,slice.Height));

            //3. SetImageROI ->Cv.SetImageROI(변경이미지, 사각형 크기설정(CvRect))
            //Cv.SetImageROI(src, new CvRect(750, 840, slice.Width, slice.Height));


            //이미지에 적용하는 방법 3가지 copy, clone으로 복제/ resize로 크기조절
            //1. Copy -> 원본이미지를 결과이미지에 그대로 복사
            //Cv.Copy(src, slice);

            //2. Resize -> 비율이 1:1이므로 변영되지 않고 그대로 변형됨(== 그냥 그대로 붙여넣는다는 뜻)
            //Cv.Resize(src, slice);

            //3. Clone -> Copy처럼 복사하지만 차이가 있음
            //-> copy는 내가 속성을 설정해놓은 방법을 따라감 ex) 채널 1설정 -> 색상있는 이미지 복사 -> 에러
            //-> Clone은 속성까지 복사 -> 채널 1로 설정했더라도 -> 색상이미지면 채널 3으로 변경 -> 에러x
            //Copy는 마스크를 씌워 약간 변형가능 But Clone은 그대로 복제
            //slice=src.Clone();

            //관심영역 해제 2가지 방법
            //1.ResetROI -> 이미지.RestROI();
            //src.ResetROI();

            //2.Cv.ResetImageROI -> Cv.RestImageROI(이미지);
            //Cv.ResetImageROI(src);



            //-------------------------------------------------

            //관심영역 설정없이 이미지 자르기
            // 1. 클론에 직접주기
            //slice = src.Clone(new CvRect(750, 840, slice.Width, slice.Height));

            // 2. 사각형 생성을 변수로 만들기 -> 값을 유동적으로 변경가능
            CvRect rect = new CvRect(750, 840, slice.Width, slice.Height);
            slice = src.Clone(rect);


            //처음부터 잘라진 src 사용가능 But 이렇게 하지 않는이유는
            //-> src에 부가적인 처리를 할때 잘라진 src에 처리가 되기때문에 원본으로 사용하였다면 항상 초기화 해줘야함
            //-> 새로운필드를 생성하여 src를 복제하여 사용하는 방법 추천

            //관심영역이 중요한이유는 이미지의 크기는 데이터의 양

            //결과출력
            return slice;



        }

        public void Dispose()
        {
            if (resize != null) Cv.ReleaseImage(resize);
            if (slice != null) Cv.ReleaseImage(slice);
        }
    }
}
