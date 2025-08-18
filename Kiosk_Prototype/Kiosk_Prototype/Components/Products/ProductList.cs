using Kiosk_Prototype.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_Prototype.Components.Products
{
    [DefaultEvent("ItemClicked")]
    //FlowLayOutPanel을 쓰는 이유는 옆으로 넓어지다가 칸이모자라면 자동으로 밑으로 내려가고 공간생기면 다시 위로 올라와서
    public partial class ProductList : UserControl
    {
        public event EventHandler<Product> ItemClicked;
        public ProductList()
        {
            InitializeComponent();
            //Items에 이벤트 추가 로직
            // CollectionChanged는 ObservableCollection안에 이벤트중 하나
            //컬렉션이 변경되었을때 이벤트 호출
            Items.CollectionChanged += Item_CollectionChanged;
        }
        // ProductList & PickList Border정보 수정
        public Color BorderColor { get => roundedPanel1.BorderColor; set=>roundedPanel1.BorderColor=value; }
        public int BorderWidth { get=>roundedPanel1.BorderWitdh; set=> roundedPanel1.BorderWitdh=value; }



        private void Item_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            flpnl.Controls.Clear();// 이거 안쓰면 계속 처음부터 추가하기 때문에 써야함
            foreach (var item in Items) 
            {
                var productCard = new ProductCard
                {
                    ID = item.ID,
                    Title = item.Title,
                    Price = item.Price,
                    Image = item.Image,
                };
                //ProductCard 인터페이스에 구현해놓은 Clicked 이벤트 가져옴
                productCard.Clicked += ProductCard_Clicked;
                //ProductList안에 flowpanel에 product 카드 요소 추가
                flpnl.Controls.Add(productCard);
            }
        }

        private void ProductCard_Clicked(object sender, IPorductCard e)
        {
            ItemClicked?.Invoke(this, new Product
            {
                ID=e.ID,
                Title = e.Title,
                Price = e.Price,
                Image = e.Image,
            });
        }


        //직렬화 코드
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //  ObservableCollection<Product> 이벤트를 추적할 수 있는 컬렉션
        public ObservableCollection<Product> Items { get; set; } = new ObservableCollection<Product>();
        // <Product> 는 Model 폴더 안에있는 Product임
        // 컬렉션 생성식  =[] 원본은 = new ObservableCollection<Product>() 임


    }
}
