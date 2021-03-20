using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Point
    {
        public double X { get; set; } = 0.0;
        public double Y { get; set; } = 0.0;
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public override string ToString()
        {
            return $"x: {X}\ty: {Y}";
        }
    }
}
