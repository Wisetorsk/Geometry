using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Supershape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double M { get; set; }
        public double N1 { get; set; }
        public double N2 { get; set; }
        public double N3 { get; set; }
        public double Phi { get; set; }
        public double K(double theta) => (M * theta) / 4.0;
        public double F(double theta) => Math.Pow(Math.Abs(Math.Cos(K(theta)) / A), N2);
        public double G(double theta) => Math.Pow(Math.Abs(Math.Sin(K(theta)) / B), N3);
        public double R_1(double theta) => Math.Pow(F(theta) + G(theta), 1.0 / N1);
        public double R(double theta) => 1.0 / R_1(theta);
        public double X(double r, double theta) => r * Math.Cos(theta);
        public double Y(double r, double theta) => r * Math.Sin(theta);

        public Supershape(double a, double b, double m, double n1, double n2, double n3, double phi=2*Math.PI)
        {
            Phi = phi;
            A = a;
            B = b;
            M = m;
            N1 = n1;
            N2 = n2;
            N3 = n3;
        }

        public Point[] Interpolate(int steps)
        {
            var output = new Point[steps];
            Parallel.For(0, steps, i => {
                var theta = Theta(steps, i);
                var r = R(theta);
                output[i] = new Point(X(r, theta), Y(r, theta));
            });
            return output;
        }

        public Vector[] InterpolateToVectors(int steps)
        {
            var output = new Vector[steps];
            var x0 = X(R(0), 0);
            var y0 = Y(R(0), 0);
            for (int i = 0; i < steps; i++)
            {
                var theta = Theta(steps, i);
                var r = R(theta);
                var start = new Point(x0, y0);
                var x = X(r, theta);
                var y = Y(r, theta);
                var end = new Point(x, y);
                output[i] = new Vector(start, end);
                x0 = x;
                y0 = y;
            }

            return output;
        }

        private double Theta(int steps, int i)
        {
            return i * Phi / steps;
        }
    }
}
