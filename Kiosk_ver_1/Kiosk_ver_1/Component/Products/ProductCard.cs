using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_ver_1.Component.Products
{
    public interface IProductCard
    {
        event EventHandler<IProductCard> Clicked;
        int ID { get; set; }
        string Title { get; set; }
        decimal Price { get; set; }
        Image Image { get; set; }
    }

    
    [DefaultEvent("Clicked")]
    public partial class ProductCard : UserControl,IProductCard
    {
        private decimal _price;
        public event EventHandler<IProductCard> Clicked;


        public ProductCard()
        {
            InitializeComponent();
            AddClickEvent(this);
        }

        private void AddClickEvent(Control ParentsControl)
        {
            foreach (Control ChildControl in ParentsControl.Controls)
            {
                ChildControl.Click += (_, __) => Clicked?.Invoke(this, this);

                if (ChildControl.HasChildren)
                {
                    AddClickEvent(ChildControl);
                }
            }

        }

        public int ID { get; set; }

        // 글씨 변화
        public string Title { get => lblTitle.Text; set { lblTitle.Text = value; Invalidate(); } }
        
        public decimal Price
        {
            get { return _price; }
            set 
            { 
                _price = value;
                //3자리마다 , 찍어주는 함수
                setPrice();
            }
        }

        private void setPrice()
        {
            lblPrice.Text = $"{_price.ToString("#,000")} 원";

        }

        //사진 변화
        public Image Image { get => pictureBox1.Image; set => pictureBox1.Image=value; }





    }


}
