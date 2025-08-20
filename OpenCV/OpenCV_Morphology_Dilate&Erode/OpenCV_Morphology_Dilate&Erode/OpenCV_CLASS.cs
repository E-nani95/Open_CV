using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Morphology_Dilate_Erode
{
    //팽창과 침식은 검색의 정확도를 높여주는 역할을 함 -> 노이즈제거등등
    //-> 노이즈를 제거하거나 노이즈 제거후 크기 복구를 위해 사용
    // 팽창후침식 or 침식후팽창으로 주로 사용 -> 두 연산을 순차적으로 사용하는 것이 일반적
    // 이진화 후 팽창을 하면 밝게감-> 팽창을 반복하면 원본에 비해 이미지가 커짐
    // 이진화 후 침식을 하면 어두워짐 -> 침식을 반복하면 원본에 비해 이미지가 작아짐
    // 팽창한만큼 침식하면 팽창의 장점과 침식의 장점을 가진체 원본이미지와 같아짐

    //팽창(Dilate)
    //구성요소를 사용하여 영역내의 현재 픽셀을 최대픽셀 값으로 대체합니다.
    //최대픽셀(255) = 밝은 영역
    // 어두운 영역이 줄어들며 밝은 영역이 늘어납니다.

    //침식(Erode)
    //구성요소를 사용하여 영역내의 현재 픽셀을 최소픽셀 값으로 대체합니다.
    //최소픽셀(0) = 어두운 영역
    // 밝은 영역이 줄어들며 어두운 영역이 늘어납니다.
    public class OpenCV_CLASS : IDisposable
    {
        IplImage morp;
        IplImage bin;

        //이진화 매서드
        public IplImage Binary(IplImage src, int threshold)
        {
            bin = new IplImage(src.Size, BitDepth.U8,1);
            Cv.CvtColor(src, bin, ColorConversion.BgrToGray);
            //원본과 결과를 같은 변수(bin)로 두는 이유는 원본을 덧씌우기 위해서 -> 함수로 들어올때 복사되서 오기떄문에 함수안에 원본이라는뜻
            //임계점(세번쨰 값 == threshold)을 넘으면 최대값 못 넘으면 최소값으로 감 0 아니면 255
            Cv.Threshold(bin, bin, threshold, 255, ThresholdType.Binary);
            return bin;
        }

        public IplImage DilateImage(IplImage src)
        {
            //반환될 이미지는 단색이므로 채널은 1
            morp = new IplImage(src.Size,BitDepth.U8,1);
            //이진화 매서드 사용
            //따로 할당하지 안하도 같은 클래스 안이라 this를 활용
            bin = this.Binary(src, 50);

            //Dilation 적용
            //Cv.Dilate(원본, 결과, 컨벌루션 커널, 반복횟수)
            //원본자리 bin 넣는 이유는 이진화된 원본을 쓰고 싶어서
            //null은 컨벌루션 커널을 사용하지 않는다는 의미가 아니라 3x3 사각형 구조를 쓴다는 의미
            Cv.Dilate(bin, morp, null, 10);
            return morp;
        }

        public IplImage ErodeImage(IplImage src)
        {
            morp = new IplImage(src.Size, BitDepth.U8, 1);
            bin = this.Binary(src, 50);

            //Erode 적용
            //Cv.Erode(원본, 결과, 컨벌루션 커널, 반복횟수)
            Cv.Erode(bin, morp, null, 10);

            return morp;
        }

        public IplImage DEImage(IplImage src)
        {
            morp = new IplImage(src.Size, BitDepth.U8, 1);
            bin = this.Binary(src, 50);

            // 팽창부터 적용을 위해 원본에는 bin  결과에는 morp
            Cv.Dilate(bin,morp,null, 10);
            // 원본과 결과를 모두 동일하게 morp
            Cv.Erode(morp, morp, null, 10); 
            return morp;

        }

        //Convolution kernel
        public IplImage ErodeImageConv(IplImage src)
        {
            morp = new IplImage(src.Size, BitDepth.U8, 1);
            bin = this.Binary(src, 50);

            //new IplConvKernel(n(행),m(열),x, y, 구조요소);
            // n x m 크기의 행렬 생성
            // x,y에 Anchor point설정
            // ElementShape를 통하여 형태 설정
            IplConvKernel element = new IplConvKernel(3,3,1,1,ElementShape.Rect); //-> Dilate나 Erode안에 null이랑 동일
            // 연산 마치고 한번에 적용
            //new IplConvKernel(3,3,1,1,ElementShape.Rect);
            // (0,0) (0,1) (0,2)
            // (1,0) (1,1) (1,2)      --> (1,1) 이 x,y에 해당되는거 -> Anchor 포인트
            // (2,0) (2,1) (2,2)
            //                         --> new IplConvKernel(3,3,0,0,ElementShape.Rect) 이라면 (0,0)이 Anchor 포인트
            
            
            // 팽창의 경우 해당 3x3 사각형 내의 최대 픽셀값을 Anchor Point에 넣음

            

            //Erode 적용
            //Cv.Erode(원본, 결과, 컨벌루션 커널, 반복횟수)
            Cv.Erode(bin, morp, element, 10);

            return morp;
        }

        public void Dispose()
        {
            if (morp != null) Cv.ReleaseImage(morp);
            if (bin != null) Cv.ReleaseImage(bin);
        }
    }
}
