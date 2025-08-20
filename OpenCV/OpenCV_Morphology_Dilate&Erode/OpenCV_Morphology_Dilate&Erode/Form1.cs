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

namespace OpenCV_Morphology_Dilate_Erode
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
            src = new IplImage("../../../coin.jpg");
            OpenCV_CLASS Convert = new OpenCV_CLASS();

            pictureBoxIpl1.ImageIpl = src;
            pictureBoxIpl2.ImageIpl = Convert.DilateImage(src);
            pictureBoxIpl3.ImageIpl = Convert.ErodeImage(src);
            pictureBoxIpl4.ImageIpl = Convert.DEImage(src);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cv.ReleaseImage(src);
            if(src != null) src.Dispose();
        }
    }
}
