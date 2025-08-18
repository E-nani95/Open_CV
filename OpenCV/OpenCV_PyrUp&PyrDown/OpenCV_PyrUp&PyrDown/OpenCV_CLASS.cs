using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCV_PyrUp_PyrDown
{
    internal class OpenCV_CLASS : IDisposable
    {
        // 원본사이즈 확대 -> PyrUp 피라미드 업 함수사용 -> 이미지 업샘플링 2배..4배..8배...
        // 원본사이즈 축소 -> PytDown 피라미드 다운 함수사용 -> 이미지 다운샘플링 1/2배 1/4배 1/8배..
        // 크기를 변화시켜주어 이미지에 대한 데이터를 크거나 작게 만들어줌 -> 더욱세밀한 연산 or 불필요한 연산을 줄여 줄 수도 있음
        // 샘플링을 통해 변환 시켜주므로 비교적 깨끗하게 변환시켜줌
        // ex) 사진의 안보이는 글을 업샘플링 하여 보여줄 수 도 있음


        // 이미지 크기를 바꿀때는 크기에 맞는 액자를 만들어줌 -> 바꿀이미지의 크기만큼 필드 크기도 조정함 ex) 원본크기의 2배 or 1/2배

        IplImage zoomin;
        IplImage zoomout;

        public IplImage ZoomIn(IplImage src)
        {
            // 이때까지는 원본크기랑 같아서 src.Size를 사용
            // 줌인은 크기가 2배라 사이즈를 키워줘야함 -> new CvSize(src.Width*2,src.Height*2)
            zoomin = new IplImage(new CvSize(src.Width * 2, src.Height * 2), BitDepth.U8, 3);
            //CvFilter.Gaussian5x5 ->  유일한 CcFilter 필터 
            //Cv.PyrUp(원본, 결과, 필터)
            Cv.PyrUp(src, zoomin, CvFilter.Gaussian5x5);
            return zoomin;
        }

        public IplImage ZoomOut(IplImage src)
        {
            zoomout = new IplImage(new CvSize(src.Width / 2, src.Height / 2), BitDepth.U8, 3);
            Cv.PyrDown(src,zoomout, CvFilter.Gaussian5x5); 
            return zoomout;
        }

        public void Dispose()
        {
            if (zoomin != null) Cv.ReleaseImage(zoomin);
            if (zoomout != null) Cv.ReleaseImage(zoomout);
        }
    }
}
