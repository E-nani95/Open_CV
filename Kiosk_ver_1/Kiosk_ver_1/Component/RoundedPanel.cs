using Kiosk_ver_1.Uitls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_ver_1.Component
{
    public class RoundedPanel:Panel
    {
		private int _borderWidth=2;
		private int _borderRadius=8;
		private Color _borderColor;
		private Color _innerBorderColor;


		public RoundedPanel() 
		{
			Resize += Resize_Panel;
		}

        private void Resize_Panel(object sender, EventArgs e)
        {
            Invalidate();
        }

        [DefaultValue(2),Category("기타"),Description("Border두께")]
		public int BorderWidth
		{
			get { return _borderWidth; }
			set { _borderWidth = value; Invalidate(); }
		}

		[DefaultValue(8), Category("기타"), Description("Border둥글기")]
		public int BorderRadius
		{
			get { return _borderRadius; }
			set { _borderRadius = value; Invalidate(); }
		}

		[DefaultValue(typeof(Color),"Black"), Category("기타"), Description("Border색")]
		public Color BorderColor
		{
			get { return _borderColor; }
			set { _borderColor = value; Invalidate(); }
		}

		[DefaultValue(typeof(Color),"White"), Category("기타"), Description("Border 내부 색")]
		public Color InnerBorderColor
		{
			get { return _innerBorderColor; }
			set { _innerBorderColor = value; Invalidate(); }
		}

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
			Graphics graphics = e.Graphics;
			graphics.SmoothingMode=SmoothingMode.HighQuality;
            Rectangle rect = new Rectangle(_borderWidth, _borderRadius, Width - _borderWidth * 2, Height - _borderRadius * 2);
			GraphicsPath path = GraphicsUtil.GetRoundedRectanglePath(rect, _borderRadius);

			using (SolidBrush innerBrush = new SolidBrush(InnerBorderColor))
			{ 
				graphics.FillPath(innerBrush, path);
			}

			using (Pen borderPen = new Pen(_borderColor, _borderWidth))
			{ 
				graphics.DrawPath(borderPen, path);
			}
        }

	}
}
