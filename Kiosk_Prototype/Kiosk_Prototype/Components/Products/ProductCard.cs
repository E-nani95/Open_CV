using Kiosk_Prototype.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_Prototype.Components.Products
{
    public interface IPorductCard 
    {
        // 이벤트발생하면 외부로 알려주는 코드
        event EventHandler<IPorductCard> Clicked;
        //7.3버전은 접근한정자 없어도 됨
        int ID { get; set; }
        string Title { get; set; }
        decimal Price { get; set; }

        Image Image { get; set; }

        // 원래는 이렇게 추가 해야함
        // 버전문제로 못함
        //ProductCard Toproduct()
        //{
        //    return new Product
        //    {
        //        ID = ID,
        //        Title = Title,
        //        Price = Price,
        //        Image = Image,
        //    };
        //}
        //위에 처럼한후 
        //ProductList에 가서 이렇게 수정할수 있음

        //private void ProductCard_Clicked(object sender, IPorductCard e)
        //{
        //    ItemClicked?.Invoke(this, e,Toproduct());
        //}

    }

    [DefaultEvent("Clicked")] // 내가 정한 event EventHandler<IPorductCard> Clicked 로 이동 Load대신

    public partial class ProductCard : UserControl, IPorductCard
    {
        private decimal _price;
        public ProductCard()
        {
            InitializeComponent();
            // 생성자 안에 넣는 이유는 어떤거든 클릭되면 이벤트 발생하게 할려고
            AddClickEvent(this);
        }
        private void AddClickEvent(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                //EvnetHandler.Click은 클릭 이벤트 발생시라는 의미
                //각 원소에 클릭이벤트 주입
                // (_,__) -> 매개변수 무시
                // Clicked?.Invoke(this, this) -> 첫번쨰 두번쨰 매개변수를 자기자신으로 해서 사전에 인터페이스에 정의했던 Clicked이벤트를 불러오는 과정
                //Clicked?.Invork에서 Clicked는 인터페이스에서 구현한 event EventHandler<IPorductCard> Clicked;
                //.Invoke(this, this) 는 앞선 메서드 Clicked 실행하라는 명령어
                // this는 함수가 할당되는 곳 기준임
                // control.Click 이벤트의 기존 매개변수들(sender와 EventArgs)을 사용하지 않고, 대신 Clicked 이벤트가 요구하는 매개변수들을 직접 전달하여 이벤트를 호출하겠다는 의미입니다.
                control.Click += (_, __) => Clicked?.Invoke(this, this);

                if (control.HasChildren) 
                { 
                    AddClickEvent(control);
                }
            }
        }

        public int ID { get; set; }
        public string Title { get => lblTitle.Text; set => lblTitle.Text=value.Trim(); }
        public decimal Price { get => _price; set { 
                _price = value;
                //3자리 마다 쉼표 매서드
                setPrice(); } }
        public Image Image { get => pictureBox1.Image; set => pictureBox1.Image=value; }

        public event EventHandler<IPorductCard> Clicked;

        private void setPrice()
        {
            lblPrice.Text=$"{_price.ToString("#,000")}원";
            // lblPrice.Text = $"{_price:0,000}원"; -> 줄인버전

            //.ToString("0,000"): 숫자를 천 단위 구분 기호(쉼표)가 있는 문자열로 포맷팅하는 부분입니다.
            //"0": 이 포맷 지정자는 숫자를 나타냅니다.
            //",": 이 포맷 지정자는 천 단위마다 쉼표를 삽입합니다.

            //    예시
            //만약 Price 변수의 값이 15000이라면:
            //Price.ToString("0,000")는 "15,000"이라는 문자열을 반환합니다.
            //lblPrice.Text에는 "15,000"이 할당되어 화면에 15,000으로 표시됩니다.
        }

    }
}
