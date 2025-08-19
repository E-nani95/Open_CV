using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Affine_3P__Perspective_4P_
{
    public class OpenCV_CLASS : IDisposable
    {
        //3점 매핑 ex) 각모서리 3개점 -> 6개 좌표 필요 -> 원본파일과 변환할파일을 1대1로 매칭시키지 않으면 회전과 다르게 이미지가 비틀려 출력될수도 있음
        // 예를 들면 원본이미지에서 각 모서리를 좌상,우상,좌하의 순서로 매핑한다면 결과이미지에서도 순서대로 좌상,우상,좌하 순서로 매핑해야함
        IplImage affine;
        IplImage perspective;
        public IplImage AffineImage(IplImage src)
        {
            // 이미지 크기는 변환하지 않을꺼라 src이미지 따라가고
            // 색상은 컬러색상을 사용 할 예정이라 3
            affine = new IplImage(src.Size, BitDepth.U8, 3);

            // 회전(Rotate)을 적용하기 위해 2x3 행열이 필요
            // Affine 변환에도 필요 -> matrix 생성해야함

            // 원본에서 포인트 생성을 위한 배열생성
            CvPoint2D32f[] srcPoint = new CvPoint2D32f[3];

            //결과에서 포인트 생성을 위한 배열 생성
            CvPoint2D32f[] dstPoint = new CvPoint2D32f[3];

            // 원본 포인트

            //1번째 점 좌상점  -> 100.0인 이유 float 형태라서
            srcPoint[0] = new CvPoint2D32f(100.0, 100.0);

            //2번째 점 우상점
            // x좌표는 넓이보다 100작음
            //y 좌표는 100
            srcPoint[1] = new CvPoint2D32f(src.Width - 100.0, 100.0);

            //3번째 점  좌하점
            srcPoint[2] = new CvPoint2D32f(100.0, src.Height - 100.0);

            //결과 포인트

            //1번째 좌상점 
            //src포인트에서 우측으로 200 더 가게함 2/3번은 동일하게
            dstPoint[0] = new CvPoint2D32f(300.0, 100.0);
            dstPoint[1] = new CvPoint2D32f(src.Width - 100.0, 100.0);
            dstPoint[2] = new CvPoint2D32f(100.0, src.Height - 100.0);

            //Affine 변환을 위한 Matrix 생성
            //Cv.GetAffineTransform(원본지점, 결과지점);
            CvMat matrix = Cv.GetAffineTransform(srcPoint, dstPoint);

            Console.WriteLine(matrix.ToString()); // -> Matrix확인법

            // Cv.WarpAffine(원본, 결과, matrix, 보간법, 여백색상)
            Cv.WarpAffine(src, affine, matrix, Interpolation.Linear, CvScalar.ScalarAll(0));
            
            return affine;
        }

        public IplImage Perspective(IplImage src)
        {
            perspective = new IplImage(src.Size, BitDepth.U8, 3);
            CvPoint2D32f[] srcPoint = new CvPoint2D32f[4];
            CvPoint2D32f[] dstPoint = new CvPoint2D32f[4];

            // 큰사진의 일부분만 발췌
            srcPoint[0] = new CvPoint2D32f(600.0, 600.0);
            srcPoint[1] = new CvPoint2D32f(300.0, 900.0);
            srcPoint[2] = new CvPoint2D32f(1300.0, 600.0);
            srcPoint[3] = new CvPoint2D32f(1600.0, 900.0);
            //좌상 좌하 우상 우하 순서로 매핑

            //코드 간소화를 위해함
            float witdh = src.Size.Width;
            float height=src.Size.Height;


            dstPoint[0] = new CvPoint2D32f(0, 0);
            dstPoint[1] = new CvPoint2D32f(0, height); // (0,높이)
            dstPoint[2] = new CvPoint2D32f(witdh, 0); // (넓이,0)
            dstPoint[3] = new CvPoint2D32f(witdh, height); //(넓이, 높이)

            //Cv.GetPerspectiveTransform(원본지점, 결과지점);
            CvMat matrix = Cv.GetPerspectiveTransform(srcPoint, dstPoint);
            Console.WriteLine(matrix);

            //Perspective 변환 확인
            //Cv.WarpPerspective(원본,결과,행열,보간법,여백색상)
            //CvScalar.ScalarAll(0) 모든 채널이 null인상태 --> 검은색
            Cv.WarpPerspective(src, perspective, matrix, Interpolation.Linear, CvScalar.ScalarAll(0));
            return perspective;
        }

        public void Dispose()
        {
            if(affine != null ) Cv.ReleaseImage(affine);
            if(perspective != null ) Cv.ReleaseImage(perspective);
        }
    }
}
