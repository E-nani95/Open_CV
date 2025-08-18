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
    public partial class OrderSummaryControl : UserControl
    {
        private int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value; SetlblCount(); }
        }

        private decimal _totalPrice;

        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; SetTotalPrice(); }
        }


        public OrderSummaryControl()
        {
            InitializeComponent();
            SetlblCount();
            SetTotalPrice();
        }

        // Border정보 수정
        public Color BorderColor { get => roundedPanel1.BorderColor; set => roundedPanel1.BorderColor = value; }
        public int BorderWidth { get => roundedPanel1.BorderWitdh; set => roundedPanel1.BorderWitdh = value; }


        //초기값 초기화
        private void SetlblCount()
        {
            lblCount.Text = _count.ToString();
        }

        private void SetTotalPrice()
        {
            lblTotalPrice.Text = $"{_totalPrice:#,##0}원";
        }

    }
}
