using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Square
    {
        public Point[] Corners { get; set; } = new Point[4];
        public Vector[] Sides { get; set; } // IMPLEMENT ME!!

        public double Width => Corners[3].X - Corners[0].X;
        public double Height => Corners[1].Y - Corners[0].Y;
        public double Hypotenuse => Math.Sqrt(Width * Width + Height * Height);
        public double Theta => Math.Atan(Height / Width);
        public double Area => Width * Height;
        public double Circumference => Width * 2 + Height * 2;

        public Square(double x, double y, double width, double height)
        {
            Corners[0] = new Point(x, y);
            Corners[1] = new Point(x, y + height);
            Corners[2] = new Point(x + width, y + height);
            Corners[3] = new Point(x + width, y);
        }

        public Square(Point centre, double width, double height)
        {
            Corners[0] = new Point(centre.X - width/2, centre.Y - height/2);
            Corners[1] = new Point(centre.X - width/2, centre.Y + height/2);
            Corners[2] = new Point(centre.X + width / 2, centre.Y + height / 2);
            Corners[3] = new Point(centre.X + width / 2, centre.Y - height / 2);
        }

        public Square(Point start, Point end)
        {
            Corners[0] = new Point(start.X, start.Y);
            Corners[1] = new Point(start.X, end.Y);
            Corners[2] = new Point(end.X, end.Y);
            Corners[3] = new Point(end.X, start.Y);
        }
    }
}
