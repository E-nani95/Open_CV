using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_Prototype.Models
{

    public class Product // 컬렉션을 만들어서 ProductList 안에서 속성으로 공유하게함
    {
        // ProductCard에 필요한 요소
        public int ID { get; set; }
        public string Title { get; set; } // =string.Empty -> 기본값설정
        public decimal Price { get; set; }

        //private Image _image;
        //public Image Image { get=> _image; set=> _image=value; }
        public Image Image { get; set; }
        //Image Image { get; set; } -> public Image? Image로 nullable설정을 해야함  

    }
}
