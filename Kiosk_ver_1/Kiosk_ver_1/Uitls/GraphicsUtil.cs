using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk_ver_1.Uitls
{
    internal class GraphicsUtil
    {
        public static GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            // radius가 0이면 직사각형 경로 반환
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = radius * 2;

            // 둥근 모서리 좌표 계산
            Rectangle topLeft = new Rectangle(rect.X, rect.Y, diameter, diameter);
            Rectangle topRight = new Rectangle(rect.Right - diameter, rect.Y, diameter, diameter);
            Rectangle bottomRight = new Rectangle(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter);
            Rectangle bottomLeft = new Rectangle(rect.X, rect.Bottom - diameter, diameter, diameter);

            // 둥근 모서리를 위한 각도 추가
            path.AddArc(topLeft, 180, 90);         // 좌상단
            path.AddArc(topRight, 270, 90);        // 우상단
            path.AddArc(bottomRight, 0, 90);       // 우하단
            path.AddArc(bottomLeft, 90, 90);       // 좌하단

            // 경로 닫기
            path.CloseFigure();

            //둥근 사각형의 모양(경로) -> 둥근 사각형의 윤곽선 정보 포함
            //그림을 그리기 위한 '템플릿' 또는 '설계도'
            return path;
        }

    }
}
