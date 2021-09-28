using System.Drawing;

namespace MyScreenshot.Models
{
    class CustomText
    {
        public PointF location;
        public string text;
        public Font font;
        public Brush brush;
        
        public CustomText(PointF location, string text, Font font, Brush brush)
        {
            this.location = location;
            this.text = text;
            this.font = font;
            this.brush = brush;
        }
    }
}
