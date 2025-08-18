using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk_Prototype.Components
{
    public partial class HeaderControllor : UserControl
    {
        public HeaderControllor()
        {
            InitializeComponent();
        }

        public string HeaderTitleFunc { get => HeaderTitle.Text; set=> HeaderTitle.Text = value; }

        //여러줄 적을 수 있게 해줌
        [Editor(typeof(MultilineStringEditor),typeof(UITypeEditor))]
        public string HeaderDescriptionFunc { get => HeaderDescription.Text; set => HeaderDescription.Text=value; }
    }
}
