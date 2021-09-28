using MyScreenshot.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyScreenshot
{
    class Screenshot
    {
        public Bitmap image;
        private Graphics graphics;

        public Screenshot()
        {
            image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            graphics = Graphics.FromImage(image as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, image.Size);
        }

        public Screenshot(Bitmap bitmap)
        {
            image = bitmap;
            graphics = Graphics.FromImage(image as Image);
        }

        public void DrawShape(CustomShape shape)
        {
            switch (shape.type)
            {
                case ShapeType.Line:
                    graphics.DrawLine(shape.pen, shape.start, shape.end);
                    break;
                case ShapeType.Rectangle:
                    graphics.DrawRectangle(shape.pen, shape.start.X, shape.start.Y, shape.end.X - shape.start.X, shape.end.Y - shape.start.Y);
                    break;
                case ShapeType.Arrow:
                    graphics.DrawLine(shape.pen, shape.start, shape.end);
                    break;
            }
        }

        public void InsertText(CustomText text)
        {
            graphics.DrawString(text.text, text.font, text.brush, text.location);
        }

        public Bitmap CropImage(Rectangle cropArea)
        {
            Bitmap cropedImage = new Bitmap(cropArea.Width, cropArea.Height);
            using (Graphics g = Graphics.FromImage(cropedImage))
            {
                g.DrawImage(image, -cropArea.X, -cropArea.Y);
                image.Dispose();
                return new Bitmap(cropedImage);
            }
        }

        public void SaveScreenshot()
        {
            Random random = new Random();
            image.Save("screenshot" + random.Next() + ".png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
