using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture
{
    public partial class Form1 : Form
    {

        private int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureMyScreen();
        }

        private void CaptureMyScreen()
        {
            try
            {
                Rectangle virtulScreen =SystemInformation.VirtualScreen;
                Rectangle workingArea =SystemInformation.WorkingArea;

                //Creating a new Bitmap object
                Bitmap captureBitmap = new Bitmap(1024, 768, PixelFormat.Format32bppArgb);
                //Bitmap captureBitmap = new Bitmap(int width, int height, PixelFormat);
                //Creating a Rectangle object which will
                //capture our Current Screen
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                //Creating a New Graphics Object
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                //Copying Image from The Screen
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                
                string captureName = @"D:\WorkSpace\Dotnet\Framework\ScreenCapture\capturedImage\"+$"Capture{count}.jpg"; 
                //Saving the Image File (I am here Saving it in My E drive).
                captureBitmap.Save(captureName, ImageFormat.Jpeg);
                //Displaying the Successfull Result
                MessageBox.Show("Screen Captured");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
