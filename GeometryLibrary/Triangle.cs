using System;
using GeometryLibrary; 

namespace GeometryLibrary
{
    public class Triangle : IShape
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double CalculateArea()
        {
            var s = (A + B + C) / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }

        public double CalculatePerimeter() => A + B + C;
    }
}

