using GeometryLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class RectangleTests
{
    [TestMethod]
    public void TestArea()
    {
        var rectangle = new Rectangle(4, 6);
        Assert.AreEqual(24, rectangle.CalculateArea());
    }

    [TestMethod]
    public void TestPerimeter()
    {
        var rectangle = new Rectangle(4, 6);
        Assert.AreEqual(20, rectangle.CalculatePerimeter());
    }
}
