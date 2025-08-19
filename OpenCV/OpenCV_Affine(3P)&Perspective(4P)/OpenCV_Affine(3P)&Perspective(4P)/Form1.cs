using OpenCvSharp;
using OpenCvSharp.UserInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCV_Affine_3P__Perspective_4P_
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
            src=new IplImage("../../../");
            OpenCV_CLASS Convert = new OpenCV_CLASS();
            pictureBoxIpl1.imageIpl = src;
            pictureBoxIpl2.imageIpl = Convert.AffineImage(src);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cv.ReleaseImage(src);
            if(src != null) src.Dispose();
        }
    }
}
