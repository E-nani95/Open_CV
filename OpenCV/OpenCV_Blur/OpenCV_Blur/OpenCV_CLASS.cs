using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Blur
{
    class OpenCV_CLASS : IDisposable
    {

        // Blur 이미지를 흐리게함
        //-> 노이즈를 제거하여 연산시 계산속도를 빠르게하고 정확하게 해줌
        // 육안으로 봤을떄 큰차이가 없을 수가 있다.
        //픽셀단위로 하여 연산에서는 큰차이
        // 만드는 방법 ex) 3x3 상자 가운데값을 조정함 모든것에 이렇게함

        IplImage blur;

        public IplImage BlurImage(IplImage src)
        {
            // 색상이미지를 흐림효과 할 예정이므로 채널은 3으로함
            blur = new IplImage(src.Size, BitDepth.U8, 3);
            // 매개변수 순서대로 (원본, 결과, 블러처리방법,파라미터1,파라미터2,파라미터3,파라미터4)
            // 파라미터3,4 -> 가오시안 블러할때 사용
            // 그이외는 파라미터1,2 만 사용
            //파라미터1만 입력시 자동으로 파라미터2도 1과 같아짐 ex) Cv.Smooth(src, blur,SmoothType.Blur,9);-> 파라미터 1,2 둘다 9로 취급
            // 될수 있으면 홀수로 --> 중심에 재조정값을 넣기때문
            Cv.Smooth(src, blur,SmoothType.Blur,9);
            return blur;
        }

        //Blur종류 -> 단순블러와 가우시안 블러를 많이 사용
        //Bilateral(양방향 블러) -> 색상(파라미터1) x 위치(파라미터2)에 대한 3x3필터를 이용 -> 크기가 3x3으로 고정이라 짝수 사용가능 / 크기가 작아서 육안으로는 차이 안날수도
        //Blur(단순블러) -> 파라미터 1 x 파라미터 2 크기의 픽셀들의 평균으로 나타냄-> 자주사용
        //BlurNoScale(스케일링이 없는 단순 블러) -> Param1 * Param2 크기 픽셀들의 합 -> 합으로 픽셀들을 재조정하다보니 매우 극단적으로 나타남
        //Median(중간값 블러) Param1 * Param2 크기 픽셀들의 중간값(평균값과 다름) -> 중간값 순서를 나열하였을떄 중간값 ex) 1,2,3,100,1000 의 중간값은 3이다.
        //Gaussian(가우시안 블러) -> Param1 * Param2 크기 픽셀들의 가중치 합 , Param3 가로방향 표준편차 , Param4 세로방향 표준편차 -> 자주사용 But 일반적으로 Param3,4 값을 미입력하여 자동으로 할당되게함

        //파라미터에 따른 반응
        //Param1 조정하면 크기를 크게 잡아서 커질 수로 흐려짐 -> 너무크면 효과가 떨어짐
        // 보통 Param1값을 조정하여 사용

        public void Dispose()
        {
            if(blur != null) Cv.ReleaseImage(blur);
        }
    }
}
