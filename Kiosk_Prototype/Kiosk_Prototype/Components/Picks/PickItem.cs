using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_Prototype.Components.Picks
{
    public partial class PickItem : UserControl
    {
        private int _count;
        private decimal _defaultPrice;
        void SetSumPrice()
        { 
            lblSumPrice.Text = (_defaultPrice*_count).ToString("#,###")+"원";
        }
        public PickItem()
        {
            InitializeComponent();
        }

        public event EventHandler DeleteClicked; // Delete click 이벤트에 적용
        public event EventHandler CountChanged; //Count set에 적용

        //선택된 항목의 고유아이디
        public int ID { get; set; }
        public string Title { get=>lblTitle.Text; set=>lblTitle.Text=value.Trim(); }

        public Image Image { get => picBox.Image; set => picBox.Image=value; }

        public int Count
        {
            get { return _count; }
            //Up,Down 버튼으로 수량조절 가능하게 할 예정
            set 
            { 
                if(value < 1) return; // 수량이 1보다 줄어들면 안되서 -> 상세페이지라 1보다 줄어들면 의미 없어짐
                _count = value; 
                lblCount.Text=_count.ToString();
                //count가 변경되면 수량과 가격을 곱한 sumprice도 변동이 있기떄문
                SetSumPrice();
                CountChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public decimal DefaultPrice
        {
            get { return _defaultPrice; }
            set 
            { 
                _defaultPrice = value;
                //defaultprice가 변경되면 SetSumPrice하게 만드는 코드
                SetSumPrice();
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Count--;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Count++;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty); // 별도로 넘길 이벤트가 없어서 Empty임
        }
    }
}
