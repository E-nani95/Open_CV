using Kiosk_Prototype.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_Prototype.Components
{
    public partial class RoundedPanel : Panel
    {

        private int _borderWidth=2;
        private int _borderRadius=8;
        private Color _borderColor=Color.Black;
        private Color _borderBackgroundColor=Color.White;

        // 실행하고 Form 사이즈 변경시 흔적남는거 해결 코드
        public RoundedPanel()
        {
            Resize += Rounded_Resize;
        }

        private void Rounded_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        // 필드 값과 디폴트값 일치하게 설정해야함
        [DefaultValue(2), Category("커스텀"), Description("보더 두께를 조절합니다.")]
        public int BorderWitdh
        {
            get { return _borderWidth; }
            set { _borderWidth = value; Invalidate();  } //Invalidate -> 변경사항 즉각반영 -> 해당 컴포넌트에 새로운 속성값이 들어올떄 마다 즉각 렌더링함
        }

        [DefaultValue(8), Category("커스텀"), Description("보더 둥글기를 조절합니다.")]
        public int BorderRadius
        {
            get { return _borderRadius; }
            set { _borderRadius = value; Invalidate(); }
        }

        [DefaultValue(typeof(Color),"Black"), Category("커스텀"), Description("보더의 색을 조절합니다.")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        [DefaultValue(typeof(Color),"White"), Category("커스텀"), Description("배경 색을 조절합니다.")]
        public Color BorderBackgroundColor
        {
            get { return _borderBackgroundColor; }
            set { _borderBackgroundColor = value; Invalidate(); }
        }

        // OnPaint에서 디자인을 그려줌
        // 이게 없으면 적용되지 않음
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Graphice객체얻는 코드 -> 림을 그릴 수 있는 도화지를 준비하는 코드
            Graphics graphics = e.Graphics;
            // 보더를 둥글게 그릴때 좀 더 부드럽게해줌
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //Panel 경계 계산 new Rectangle(x,y,width,height)
            Rectangle rect = new Rectangle(_borderWidth, _borderWidth, Width - _borderWidth * 2, Height - _borderRadius * 2);

            // 임시적으로 테스트를 위해 그려본거
            // new Pen(그릴 선색상, 그릴 선두께) -> border를 정하는 매서드
            //DrawRectangle(border색과 border두께 정보, border위치와 border크기) -> 사각형을 그리는 메서드
            //graphics.DrawRectangle(new Pen(_borderColor,_borderWidth), rect);

            GraphicsPath path =  GraphicsUtil.GetRoundedRectanglePath(rect, _borderRadius);

            // 내부영역 채우기
            // using은 사용된 뒤 해당 자원 정리해줌
            using (SolidBrush innerBrush = new SolidBrush(_borderBackgroundColor))
            { 
                graphics.FillPath(innerBrush, path);
            }

            //보더 그리기
            using (Pen borderPen = new Pen(_borderColor, _borderWidth))
            { 
                graphics.DrawPath(borderPen, path);
            }
        }

    }
}
