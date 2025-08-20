using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_HSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IplImage src;

        private void Form1_Load(object sender, EventArgs e)
        {
            src = new IplImage("../../../apple.png");
            OpenCV_CLASS Convert = new OpenCV_CLASS();

            pictureBoxIpl1.ImageIpl = src;
            // 명도 채도 x
            pictureBoxIpl2.ImageIpl = Convert.HSV(src);
            // 명도 채도 0
            pictureBoxIpl3.ImageIpl = Convert.HSV_hap(src);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (src != null) Cv.ReleaseImage(src);
        }

    }
}
