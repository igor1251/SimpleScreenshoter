using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyLightShot
{
    public partial class MainForm : Form
    {
        bool drawNeeded = false;
        Point top, bottom;
        Bitmap printScreen;
        
        
        public MainForm()
        {
            InitializeComponent();

            printScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printScreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printScreen.Size);

            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

            screenshotPictureBox.Image = printScreen;
        }

        private void screenshotPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            drawNeeded = true;
            top = new Point(e.X, e.Y);
        }

        private void screenshotPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawNeeded)
            {
                bottom = new Point(e.X, e.Y);
                screenshotPictureBox.Invalidate();
            }
        }

        private void screenshotPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.BlueViolet, 5), top.X, top.Y, bottom.X - top.X, bottom.Y - top.Y);
        }

        private void screenshotPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            drawNeeded = false;
            ToolForm tf = new ToolForm();
            tf.Location = new Point(bottom.X, bottom.Y - tf.Height);

            tf.saveButton.Click += SaveButton_Click;
            tf.textAddButton.Click += TextAddButton_Click;

            tf.Show();
        }

        private void TextAddButton_Click(object sender, EventArgs e)
        {
            
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveScreenshot();
            Application.Exit();
        }

        private void SaveScreenshot()
        {
            Bitmap cropBmp = printScreen.Clone(new Rectangle(top.X, top.Y, Math.Abs(bottom.X - top.X), Math.Abs(bottom.Y - top.Y)), printScreen.PixelFormat);
            cropBmp.Save(@"D:\Libraries\Documents\screenshot" + ((DateTime.UtcNow.ToString().Replace(".", "-")).Replace(":", "-")).Replace(" ", "_") + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            cropBmp.Dispose();
            printScreen.Dispose();
        }
    }
}