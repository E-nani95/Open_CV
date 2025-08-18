using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Filp_Rotate
{
    internal class OpenCV_CLASS : IDisposable
    {

        // 대칭 -> 영상이나 사진을 상하대칭(x축 기준) 좌우대칭(y축 기준) 상하좌우대칭(x y 2축 둘다 기준으로 사용)으로함
        //-> 카메라 위치나 설정으로 인하여 카메라에서 불러온 영상이나 사진의 구도가 맞지 않을때 주로 사용
        // x,y축
        /// <summary>
        /// (0,0) ---- x축
        /// |
        /// |
        /// y축
        /// 드래그 하는 느낌으로 생각
        /// </summary>
        IplImage symm;
        IplImage rotate;

        public IplImage Symmetry(IplImage src)
        {
            // 대칭이라 이미지 크기 상관 없음 -> src.Size 원본사이즈 사용
            // 컬러 사진이라 채널은 3
            symm = new IplImage(src.Size, BitDepth.U8, 3);
            //Cv.Flip(원본,결과,대칭방법)  FlipMode.X -> X축 대칭
            Cv.Flip(src, symm,FlipMode.X );
            return symm;            
        }


        public IplImage RotateImage(IplImage src, int angle)
        { 
            //이미지가 회전하여 일부 이미지가 표시되지 않을 수는 있지만 원본이미지랑 동일하게 생성
            rotate = new IplImage(src.Size,BitDepth.U8, 3);

            // 회전 행열을 생성하는 함수
            //Cv.GetRotationMatrix2D(중심점, 각도, 스케일)
            // new CvPoint2D32f(src.Width / 2, src.Height / 2) -> 한 가운데를 중심점으로함
            // 스케일은 1대 1 비율이므로 1을 사용
            //CvMat matrix = Cv.GetRotationMatrix2D(new CvPoint2D32f(src.Width / 2, src.Height / 2), angle, 1);
            // 기준점을 좌측상단으로 -> new CvPoint2D32f(0,0)
            CvMat matrix = Cv.GetRotationMatrix2D(new CvPoint2D32f(0,0), angle, 1);

            //변환된 행열 회전적용
            // 기하학에서 사용되는 아핀변환사용 -> 직선을 직선으로, 평행선을 평행선으로 유지하는 기하학적 변환입니다
            // 크기 조절, 이동, 회전, 전단(비스듬하게 기울임)등 아핀변환은 직선을 직선으로 대응하는 모든 것에 적용가능
            //Cv.WarpAffine(원본, 결과, 행열, 보간법, 여백색상)
            //행열 -> 회전적용하기 위해 포함
            //보간법 -> 90도 180도 같은 회전이 아닐떄 이미지 일부분이 표시되지 않는 문제 해결하기위해 사용 -> 쌍선형 보간법사용
            //여백색상 -> 회전시 필연적으로 빈부분 생김 -> CvScalar.ScalarAll(0) 흑색으로 채움
            Cv.WarpAffine(src, rotate, matrix, Interpolation.Linear, CvScalar.ScalarAll(0));
            return rotate;

        }

        public void Dispose()
        {
            if (symm != null) Cv.ReleaseImage(symm);
            if (rotate != null) Cv.ReleaseImage(rotate);
        }
    }
}
