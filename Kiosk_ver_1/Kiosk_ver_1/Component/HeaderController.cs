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

namespace Kiosk_ver_1.Component
{
    public partial class HeaderController : UserControl
    {
        public HeaderController()
        {
            InitializeComponent();
        }
        [Category("ChangeLabel")]
        public string ChangingTitle { get => lblTitle.Text; set => lblTitle.Text=value; }

        [Category("ChangeLabel"), Editor(typeof(MultilineStringEditor),typeof(UITypeEditor))]
        public string ChangingDescription { get => lblDescription.Text; set => lblDescription.Text=value; }
    }
}
