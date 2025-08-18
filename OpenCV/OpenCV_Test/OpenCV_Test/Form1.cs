using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //아래처럼 변수할당하면 폼의 모든영역에서 불러와 사용가능

        //카메라의 속성설정과 프레임을 불러옴
        CvCapture capture;

        //lpl 이미지 형식으로 프레임을 불러와 이미지를 저장
        IplImage src;
        
        


        private void Form1_Load(object sender, EventArgs e)
        {
            //카메라가 인식되지 않았을때 catch문으로 넘어가 timer를 실행시키지 않게 하여 오류를 방지
            try
            {
                // 카메라
                ////인덱스 1은 외부카메라 0은 내부카메라
                //capture = CvCapture.FromCamera(CaptureDevice.DShow, 0);
                ////최초 picturebox 에서 넓이를 640 480으로 해서 임
                //capture.SetCaptureProperty(CaptureProperty.FrameWidth, 640);
                //capture.SetCaptureProperty(CaptureProperty.FrameHeight, 480);

                //동영상
                //FromFile -> 경로가 매개변수 -> 최초지점 project명/ project명/ bin/ debug
                capture = CvCapture.FromFile("../../../Saigon.mp4");
                // 여기 까지만 하면 동영상은 작동됨 그러나 동영상의 재생길이가 지난후도 타이머가 작동하여 form이 멈추는 현상발생
                // src가 비어있지 않을때만 실행되게 함

                //사진
                //-> 크기모드 strectch인지 확인
                // 프레임이 없어서 timer 기능은 없앰
                //src = new IplImage("../../../Saigon.jpg");
                //pictureBoxIpl1.ImageIpl =src;


                //회색
                src = new IplImage("../../../Italia.jpg");
                OpenCV_Test_Class Convert = new OpenCV_Test_Class();

                //PictureBoxpl2에서 원본
                pictureBoxIpl2.ImageIpl = src;

                //PictureBoxpl3에서 회색으로
                pictureBoxIpl3.ImageIpl = Convert.GrayScale(src);

            }
            catch (Exception)
            {

                timer1.Enabled = false;
            }
        }
        //현재프레임을 표기하는 변수 초기 값0
        int frame_count =0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //타이머 이벤트부분
            //이 부분은 타이머가 작동될떄 마다 영상을 받아와 src에 저장한 후 피쳐박스 IPL에 출력 
            //카메라
            //src = capture.QueryFrame();
            //pictureBoxIpl1.ImageIpl = src;

            //동영상

            //timer가 작동될때 마다 프레임을 표시 -> frame_count ++; 하는 이유
            frame_count++;
            //label에 현재 프레임수와 최대 프레임수 표시
            label1.Text = frame_count.ToString() + "/" + capture.FrameCount.ToString();

            src = capture.QueryFrame();

            // 현재프레임과 최대프레임이 같지 않은 경우에 실행 -> if(src != null) 지우고 해야함
            //if(frame_count != capture.FrameCount)

            // 전체 영상의 반만 재생 -> 이런 방법으로 특정구간 반복재생/ 특정구간에서 멈추기 가능
            //if(frame_count != capture.FrameCount/2)

            if (src != null)
            {
                pictureBoxIpl1.ImageIpl = src;
            }
            else
            {
                // 마지막 값이 null하면서 재생이 끝난후 마지막 프레임을 보여주는걸 없앰
                pictureBoxIpl1.ImageIpl= null;
                timer1.Enabled = false;

                //무한루프
                //timer1.Enabled = false; 코드 지우고 아래 코드 삽입 하면 무한히 보여줌
                //frame_count=0; -> 다시처음으로 돌려 재생되게하뮤
                //capture = CvCapture.FromFile("../../../Saigon.mp4");
                // 단점이 if문에 src가 null인지 확인하는 것 때문에 연결이 끊김
                // -> 처음 프레임 번호와 마지막프레임 번호를 알아내 마지막 프레임 번호일때 처음 프레임으로 돌림
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //닫을 때 마다 src에 대한 데이터와 메모리 해지
            Cv.ReleaseImage(src);
            if(src != null) src.Dispose();
        }
    }
}
