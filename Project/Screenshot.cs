using System.Drawing;

namespace MyLightShot
{
    class Screenshot
    {
        public Bitmap background;
        Graphics graphics;

        public Screenshot(Bitmap background)
        {
            this.background = background;
            graphics = Graphics.FromImage(background);
        }

        public void DrawLine(Point start, Point end, Pen pen)
        {
            graphics.DrawLine(pen, start, end);
        }

        public void DrawText(ScreenshotInscription screenshotInscription)
        {
            graphics.DrawString(screenshotInscription.text, screenshotInscription.font, screenshotInscription.brush, screenshotInscription.location);
        }

        public void Save(string fileName)
        {
            background.Save(fileName);
        }
    }
}
