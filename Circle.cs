using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Circle
    {
        public Point Centre { get; set; }
        public double Radius { get; set; }
        public double Area => Math.PI * Radius * Radius;
        public double Circumference => Math.PI * Radius * 2;
        public Circle(double x, double y, double r)
        {
            Centre = new Point(x, y);
            Radius = r;
        }

        public Circle(Point centre, double radius)
        {
            Centre = centre;
            Radius = radius;
        }

        public Point[] Interpolate(int steps)
        {
            var points = new Point[steps];
            double x, y;
            for (int i = 0; i < steps; i++)
            {
                double theta = i / steps * Math.PI;
                x = Centre.X + Math.Cos(theta) * Radius;
                y = Centre.Y + Math.Sin(theta) * Radius;
                points[i] = new Point(x, y);
            }
            return points;
        }

        public Vector[] InterpolateToVectors(int steps)
        {
            var vectors = new Vector[steps];
            double x, y, x0, y0;
            x0 = 0;
            y0 = Radius;
            for (int i = 0; i < steps; i++)
            {
                double theta = i / steps * Math.PI;
                var start = new Point(x0, y0);
                x = Math.Cos(theta) * Radius;
                y = Math.Sin(theta) * Radius;
                var end = new Point(x, y);
                vectors[i] = new Vector(start, end);
                x0 = x;
                y0 = y;
            }
            return vectors;
        }
    }
}
