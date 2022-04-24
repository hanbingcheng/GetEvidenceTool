using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetEvidenceTool
{
    public partial class FrmCapture : Form
    {
        //These variables control the mouse position
        int selectX;
        int selectY;
        int selectWidth;
        int selectHeight;
        Pen selectPen = new Pen(Color.Red, 5);
        Image? img;

        bool start = false;

        public FrmCapture()
        {
            InitializeComponent();
        }

        private void CaptureForm_Load(object sender, EventArgs e)
        {
            //Hide the Form
            this.Hide();
            this.Owner.Hide();

            //Create the Bitmap
            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                     Screen.PrimaryScreen.Bounds.Height);
            //Create the Graphic Variable with screen Dimensions
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            //Copy Image from the screen
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            //Create a temporal memory stream for the image
            using (MemoryStream s = new MemoryStream())
            {
                //save graphic variable into memory
                printscreen.Save(s, ImageFormat.Bmp);
                pictureBox1.Size = new System.Drawing.Size(this.Width, this.Height);

                //set the picture box with temporary stream
                img = Image.FromStream(s);
                Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                //ImageオブジェクトのGraphicsオブジェクトを作成する
                Graphics g = Graphics.FromImage(canvas);

                ColorMatrix cm = new ColorMatrix();
                //ColorMatrixの行列の値を変更して、アルファ値が0.5に変更されるようにする
                cm.Matrix00 = 1;
                cm.Matrix11 = 1;
                cm.Matrix22 = 1;
                cm.Matrix33 = 0.5F;
                cm.Matrix44 = 1;
                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm);

                //ImageAttributesを使用して画像を描画
                g.DrawImage(img, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height),
                    0, 0, pictureBox1.Width, pictureBox1.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();

                pictureBox1.Image = canvas;
            }

            this.Owner.Show();
            this.Show();
            Cursor = Cursors.Cross;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //validate if there is an image
            if (img == null)
                return;
            //validate if right-click was trigger
            if (start)
            {      
                selectWidth = Math.Abs(e.X - selectX);
                selectHeight = Math.Abs(e.Y - selectY);
                int x = Math.Min(e.X, selectX);
                int y = Math.Min(e.Y, selectY);
                //draw dotted rectangle
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawRectangle(selectPen,
                          x, y, selectWidth, selectHeight);
                g.FillRectangle(new SolidBrush(Color.Transparent),
                          x, y, selectWidth, selectHeight);

                ColorMatrix cm = new ColorMatrix();
                cm.Matrix00 = 1;
                cm.Matrix11 = 1;
                cm.Matrix22 = 1;
                cm.Matrix33 = 1;
                cm.Matrix44 = 1;
                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm);
                g.DrawImage(img, new Rectangle(x, y, selectWidth, selectHeight),
                    x, y, selectWidth, selectHeight, GraphicsUnit.Pixel, ia);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //starts coordinates for rectangle
                selectX = e.X;
                selectY = e.Y;
                selectPen.DashStyle = DashStyle.DashDotDot;
                //refresh picture box
                pictureBox1.Refresh();
                //start control variable for draw rectangle
                start = true;
            } else if (e.Button == MouseButtons.Right)
            {
                // cancel selection
                start = false;
                pictureBox1.Refresh();
            }            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!start)
            {
                return;
            }
            //validate if there is image
            if (pictureBox1.Image == null)
                return;
            //same functionality when mouse is over
            if (e.Button == MouseButtons.Left)
            {
                selectWidth = Math.Abs(e.X - selectX);
                selectHeight = Math.Abs(e.Y - selectY);
                selectX = Math.Min(e.X, selectX);
                selectY = Math.Min(e.Y, selectY);
                pictureBox1.CreateGraphics().DrawRectangle(selectPen, selectX,
                         selectY, selectWidth, selectHeight);

            }
            start = false;
            SaveToClipboard();
        }

        private void SaveToClipboard()
        {
            if (img == null)
            {
                return;
            }
            //validate if something selected
            if (selectWidth > 0)
            {
                Clipboard.Clear();
                Rectangle rect = new Rectangle(selectX, selectY, selectWidth, selectHeight);
                //create bitmap with original dimensions
                Bitmap OriginalImage = new Bitmap(img, pictureBox1.Width, pictureBox1.Height);
                //create bitmap with selected dimensions
                Bitmap _img = new Bitmap(selectWidth, selectHeight);
                //create graphic variable
                Graphics g = Graphics.FromImage(_img);
                //set graphic attributes
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);
                Clipboard.SetImage(_img);
            }
            this.Close();
        }        
    }
}
