using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_Prototype.Components
{
    [DefaultEvent("Click")]
    public partial class RoundedButton : UserControl
    {
        private Color _originalBackColor;

        public RoundedButton()
        {
            InitializeComponent();
            base.BackColor = Color.Transparent;
            //이벤트 추가
            lblText.MouseEnter += LblText_MouseEnter;
            lblText.MouseLeave += LblText_MouseLeave;
            lblText.Click += LblText_Click;
        }

        public new event EventHandler Click;

        private void LblText_Click(object sender, EventArgs e)
        {
            Click?.Invoke(this, e);
        }

        private void LblText_MouseLeave(object sender, EventArgs e)
        {
            roundedPanel1.BorderBackgroundColor=_originalBackColor;
        }

        private void LblText_MouseEnter(object sender, EventArgs e)
        {
            //색상을 살짝 연하게
            roundedPanel1.BorderBackgroundColor = Color.FromArgb((int)(255 * 0.9), _originalBackColor);
        }

        //prop 하는거는 속성 추가하는거-> 클릭하면 우측하단에 나오는거 ex) Text, Color

        // Border정보 수정
        public Color BorderColor { get => roundedPanel1.BorderColor; set => roundedPanel1.BorderColor = value; }
        public int BorderWidth { get => roundedPanel1.BorderWitdh; set => roundedPanel1.BorderWitdh = value; }

        //이거 빼먹으면 속성창에서 안보임
        //상속받고있는 UserControl 안에서 [Browable(false)]로 되있기 때문
        //UserControl control+ 클릭 -> text 워드로 찾으면 나옴
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)] // 직렬화 hidden에서 Visible로 -> 안하면 값이 저장이 안됨

        // Text는 이미 존재하고 숨겨져 있어서 override해야함
        public override string Text { get => lblText.Text; set=>lblText.Text=value; }


        //background Color를 새로 만드는 방법(RoundedPanel) 말고 -> 기존에 있는 BackColor를 사용해서 배경색 바꾸는 법
        //override를 쓰면 모든것에 적용되버림 -> UserControl에도 적용됨
        //public override Color BackColor { get => roundedPanel1.BorderBackgroundColor; set => roundedPanel1.BorderBackgroundColor = value; }
        public new Color BackColor { get => roundedPanel1.BorderBackgroundColor; set 
            {
                _originalBackColor=value;
                roundedPanel1.BorderBackgroundColor = value;
            } }

        //override가 아니라 new를 하는 이유는 Font크기를 조절할때 다른 것를은 그대로고 label의 크기 만을 키워야해서
        public new Font Font { get => lblText.Font; set=>lblText.Font=value; }

        //Font는 빌드후에 초기화되는걸 막기위해 [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]  적용안됨
        //다른 로직존재


        //ShouldSerializeFont 매서드 : 속성 값이 기본값과 다를 떄 직렬화
        //정해진 룰 임(매서드)
        //ShouldSerialize까지는 동일하고 뒤에 꺼만 바뀜(속성이름으로) ex) BackColor... Default찍어보면 나오는 속성은 다됨
        private bool ShouldSerializeFont()
        { 
            //사용자 지정한 font와 default font랑 다를때 직렬화 시킴
            return lblText.Font != DefaultFont;
        }

    }
}
