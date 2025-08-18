using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_ver_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void productCard1_Clicked(object sender, Component.Products.IProductCard e)
        {
            MessageBox.Show($"Title: {e.Title}, Price: {e.Price}");
        }
    }
}
