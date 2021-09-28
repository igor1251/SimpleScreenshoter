using System.Drawing;

namespace MyScreenshot.Models
{
    class CustomShape
    {
        public Point start;
        public Point end;
        public Pen pen;
        public ShapeType type;

        public CustomShape(Point start, Point end, Pen pen, ShapeType type)
        {
            this.start = start;
            this.end = end;
            this.pen = pen;
            this.type = type;
        }
    }
}
