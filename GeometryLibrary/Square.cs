using GeometryLibrary; 

namespace GeometryLibrary
{
    public class Square : IShape
    {
        public double Side { get; }

        public Square(double side)
        {
            Side = side;
        }

        public double CalculateArea()
        {
            return Side * Side;
        }

        public double CalculatePerimeter()
        {
            return 4 * Side;
        }
    }
}

