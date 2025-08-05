using GeometryLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TriangleTests
{
    [TestMethod]
    public void TestArea()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.AreEqual(6, triangle.CalculateArea(), 0.001);  // use delta for floating point
    }

    [TestMethod]
    public void TestPerimeter()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.AreEqual(12, triangle.CalculatePerimeter());
    }
}

