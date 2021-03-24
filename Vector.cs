using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Vector
    {
        public double X0 => Origin.X;
        public double Y0 => Origin.Y;
        public double X => End.X;
        public double Y => End.Y;
        public Point Origin { get; set; }
        public Point End { get; set; }
        public double Dx => X - X0;
        public double Dy => Y - Y0;
        public double Theta => Math.Atan(Dy / Dx);
        public double Magnitude => Math.Sqrt(Dx*Dx + Dy*Dy);


        public static Vector operator- (Vector a, Vector b)
        {
            double x, y;
            x = a.X - b.X;
            y = a.Y - b.Y;
            Vector output = new Vector(x, y);
            return output;
        }

        public static Vector operator+ (Vector a, Vector b)
        {
            double x, y;
            x = a.X + b.X;
            y = a.Y + b.Y;
            var output = new Vector(x, y);
            return output;
        }

        public static double operator* (Vector a, Vector b)
        {
            double result;
            result = a.X * b.X + a.Y * b.Y;
            return result;
        }

        public Vector(double x, double y)
        {
            Origin = new Point(0, 0);
            End = new Point(x, y);
        }

        public Vector(Point end)
        {
            Origin = new Point(0, 0);
            End = end;
        }

        public Vector(Point start, Point end)
        {
            Origin = start;
            End = end;
        }

        public Vector(double x0, double y0, double theta, double length)
        {
            Origin = new Point(x0, y0);
            double x = Math.Cos(theta) * length;
            double y = Math.Sin(theta) * length;
            End = new Point(x, y);
        }

        public Vector(Point start, double theta, double length)
        {
            Origin = start;
            double x = Math.Cos(theta) * length;
            double y = Math.Sin(theta) * length;
            End = new Point(x, y);
        }

        public Point[] Interpolate(int steps)
        {
            Point[] points = new Point[steps];
            for (int i = 0; i < steps-1; i++)
            {
                double x, y;
                double r_partial = Magnitude * i / steps;
                x = Origin.X + Math.Cos(Theta) * r_partial;
                y = Origin.Y + Math.Sin(Theta) * r_partial;
                points[i] = new Point(x, y);
            }
            points[steps] = End;
            return points;
        }

        public Vector[] InterpolateIntoVectors(int steps)
        {
            Vector[] vectors = new Vector[steps];
            double x0 = Origin.X;
            double y0 = Origin.Y;
            double x, y;
            for (int i = 0; i < steps-1; i++)
            {
                double r_partial = Magnitude * i / steps;
                x = x0 + Math.Cos(Theta) * r_partial;
                y = y0 + Math.Sin(Theta) * r_partial;
                vectors[i] = new Vector(new Point(x0, y0), new Point(x, y));
                x0 = x;
                y0 = y;
            }
            vectors[steps] = new Vector(new Point(x0, y0), new Point(End));
            return vectors;
        }

        public static double Distance(Point A, Point B)
        {
            Vector intermediate = new Vector(A, B);
            return intermediate.Magnitude;
        }

        public static double Distance(double x0, double y0, double x, double y)
        {
            Point A = new Point(x0, y0);
            Point B = new Point(x, y);
            Vector intermediate = new Vector(A, B);
            return intermediate.Magnitude;
        }

        public static double DeltaX(Point A, Point B)
        {
            Vector intermediate = new Vector(A, B);
            return intermediate.Dx;
        }

        public static double DeltaY(Point A, Point B)
        {
            Vector intermediate = new Vector(A, B);
            return intermediate.Dy;
        }

        public override string ToString()
        {
            return $"i: {X}\tj: {Y}";
        }
    }
}
