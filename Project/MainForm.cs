using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyLightShot
{
    public partial class MainForm : Form
    {
        bool drawMode = false, textMode = false, typeComplete = false;
        
        Point top, bottom;
        Bitmap printScreen;
        Pen pen;
        ToolForm tf;
        
        
        public MainForm()
        {
            InitializeComponent();

            pen = new Pen(Color.BlueViolet, 5);
            tf = new ToolForm();
            tf.saveButton.Click += SaveButton_Click;
            tf.textAddButton.Click += TextAddButton_Click;

            printScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printScreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printScreen.Size);

            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

            screenshotPictureBox.Image = printScreen;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tf.Close();
        }

        private void screenshotPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!textMode && !typeComplete)
            {
                tf.Hide();
                drawMode = true;
                top = new Point(e.X, e.Y);
            }
        }

        private void screenshotPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawMode && !textMode)
            {
                bottom = new Point(e.X, e.Y);
                screenshotPictureBox.Invalidate();
            }
        }

        private void screenshotPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, top.X, top.Y, bottom.X - top.X, bottom.Y - top.Y);
            if (typeComplete)
            {
                e.Graphics.DrawString(screenshotTextBox.Text, new Font("Times New Roman", 20), Brushes.BlueViolet, new PointF(screenshotTextBox.Location.X, screenshotTextBox.Location.Y));
                screenshotTextBox.ResetText();
            }
        }

        private void screenshotPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!textMode)
            {
                drawMode = false;
                tf.Location = new Point(bottom.X, bottom.Y - tf.Height);
                tf.Show();
            }
        }

        private void TextAddButton_Click(object sender, EventArgs e)
        {
            textMode = true;
            drawMode = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveScreenshot();
            Environment.Exit(0);
        }

        private void screenshotPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (textMode)
            {
                if (!screenshotTextBox.Visible) screenshotTextBox.Visible = true;
                screenshotTextBox.Location = new Point(e.X, e.Y);
                textMode = false;
                typeComplete = true;
            }
            else if (!textMode && typeComplete)
            {
                screenshotTextBox.Visible = false;
                screenshotPictureBox.Invalidate();
            }
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