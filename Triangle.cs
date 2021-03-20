using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Triangle
    {
        public Point Origin => Corners[0];
        public Point[] Corners { get; set; } = new Point[3];
        public Vector[] Sides { get; set; } // IMPLEMENT MEEEE!!!!!!!
        public double Area => throw new NotImplementedException(); // A = h_b * b / 2
        public double Circumference => throw new NotImplementedException();
        public double Hypotenuse => Math.Sqrt(Dx * Dx + Dy * Dy);
        public double Dx => Corners[0].X - Corners[3].X;
        public double Dy => Corners[0].Y - Corners[2].Y;
        public double Theta => Math.Atan(Dy/Dx);

        public Triangle(double x, double y, double width, double height)
        {
            Corners[0] = new Point(Origin);
            Corners[1] = new Point(x + width, y + height);
            Corners[2] = new Point(x + width, y);
        }

        public Triangle(Point origin, double theta, double length)
        {
            Corners[0] = new Point(origin);
            double dy = Math.Sin(theta) * length;
            Corners[1] = new Point(origin.X, origin.Y + dy);
            Corners[2] = new Point(origin.X, origin.Y + length);
        }
    }
}
