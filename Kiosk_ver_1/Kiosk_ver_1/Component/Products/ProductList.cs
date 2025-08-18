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

namespace Kiosk_ver_1.Component.Products
{
    public partial class ProductList : UserControl
    {
        public event EventHandler<ProductCard> ItemClicked;
        public ProductList()
        {
            InitializeComponent();
            Items.CollectionChanged += Item_Collection;
        }

        private void Item_Collection(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (var item in Items)
            {
                var ProductCard = new ProductCard
                { 
                    ID = item.ID,
                    Title = item.Title,
                    Price = item.Price,
                    Image = item.Image,
                };
                ProductCard.Clicked += ProductCard_Clicked;
            }
        }

        private void ProductCard_Clicked(object sender, IProductCard e)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<IProductCard> Items { get; set; } = new ObservableCollection<IProductCard>();
    }
}
