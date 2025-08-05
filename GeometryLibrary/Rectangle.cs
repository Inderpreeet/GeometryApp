namespace GeometryLibrary
{
    public class Rectangle : IShape
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double CalculateArea() => Width * Height;

        public double CalculatePerimeter() => 2 * (Width + Height);
    }
}
