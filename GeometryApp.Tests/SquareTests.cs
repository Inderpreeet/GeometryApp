using GeometryLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SquareTests
{
    [TestMethod]
    public void TestArea()
    {
        var square = new Square(5);
        Assert.AreEqual(25, square.CalculateArea());
    }

    [TestMethod]
    public void TestPerimeter()
    {
        var square = new Square(5);
        Assert.AreEqual(20, square.CalculatePerimeter());
    }
}
