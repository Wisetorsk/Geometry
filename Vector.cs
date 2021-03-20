using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    class Vector
    {
        public double X { get; set; }
        public double X0 { get; set; } = 0;
        public double Y0 { get; set; } = 0;
        public double Y { get; set; }

        public Point[] points { get; set; }

        public Vector(double x, double y)
        {
                
        }

        public Vector(double x0, double y0)
        {

        }

        public Vector(Point end)
        {

        }
    }
}
