using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_Drawing
{
    public class OpenCV_CLASS : IDisposable
    {
        IplImage draw;
        //입력값없이 사용해봄 -> 검은 화면에 Drawing함
        //아무런 이미지가 포함되지 않았기 때문에 필드를 선언하고 속성을 설정한 후 이미지를 클론이나 카피해야함
        //-> 하지 않는다면 초기상태가 까만 이미지만 나옴

        // 좌표가 겹친다면 가장 마지막꺼 나옴
        public IplImage Drawing()
        { 
            draw = new IplImage(new CvSize(640,480),BitDepth.U8,3);
            //선그리기
            //Cv.DrawLine(이미지,시작점,도착점,색상, 두께)
            //CvPoint로 좌표 CvColor로 색상
            Cv.DrawLine(draw, new CvPoint(100, 100), new CvPoint(500, 100), CvColor.Blue, 20); // ==Cv.DrawLine(draw, 100, 100, 500, 100, new CvColor(0,0,255), 20);
            //Draw이외에도 Line으로도 선그리기 가능

            //원그리기
            //Cv.DrawCircle(이미지, 중심점, 반지름, 색상, 두께)
            Cv.DrawCircle(draw, new CvPoint(200, 200), 50, CvColor.Red, -1); // -1은 채워진 원 -> 선을 제외한 도형에서 -1은 내부가 채워짐

            //사각형그리기
            //Cv.Rectangle(이미지, 좌측상단, 우측하단, 색상, 두께)
            Cv.Rectangle(draw, new CvPoint(100, 150), new CvPoint(500, 300), CvColor.Green, 10);

            //호or타원 그리기
            //Cv.DrawEllipse(이미지, 중심점, 호의 크기, 기준각도, 시작각도, 종료각도,색상,두께)
            Cv.DrawEllipse(draw, new CvPoint(150, 400), new CvSize(100, 50), 0, 90, 360, CvColor.Yellow, 10); // 각도 설정이 중요 / 0도 -> 3시방향 / 90도 -> 6시방향 (기준각도에서 90도 떨어진곳이라) / 반시계방향회전(CCW)
            // 캔버스그리는거 상상 
            //시작각도는 기준각도에서 시작각도만큼 이격시켜 그리는거라고 생각
            // 중심점이 캔버스 바늘 꼽는곳 0 이니까 3시방향부터시작 

            //텍스트 그리기
            //영어만 가능 But HDC를 이용하면 타국어도 가능
            //new CvFont(글자모양, 글자높이,글자넓이)
            //Cv.PutText(이미지,텍스트,위치,글꼴,색상)
            Cv.PutText(draw, "OpenCV", new CvPoint(400, 400), new CvFont(FontFace.HersheyComplex, 1, 1), CvColor.White);// 위치 텍스트의 문자열 아래 좌측하단이 기준

            return draw;
        }

        public void Dispose()
        {
            if (draw != null) Cv.ReleaseImage(draw);
        }
    }
}
