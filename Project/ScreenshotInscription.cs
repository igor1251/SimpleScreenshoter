using System.Drawing;

namespace MyLightShot
{
    class ScreenshotInscription
    {
        public string text;
        public Font font;
        public PointF location;
        public Brush brush;

        public ScreenshotInscription()
        {
            text = "";
            font = new Font("Arial", 14);
            location = new PointF(0.0f, 0.0f);
            brush = Brushes.White;
        }

        public ScreenshotInscription(string text, Font font, PointF location, Brush brush)
        {
            this.text = text;
            this.font = font;
            this.location = location;
            this.brush = brush;
        }
    }
}
