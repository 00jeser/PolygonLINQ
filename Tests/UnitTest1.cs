using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolygonLINQ;
using static PolygonLINQ.Polygon;

namespace Tests;
[TestClass]
public class TestFunctions
{
    [TestMethod]
    public void IsZeroSidesFrom1Point()
    {
        Polygon pol = new();
        pol.Points.Add(new Point(0, 0));
        Assert.IsTrue((bool)pol.CheckIfThis.IsCornerCount(0));
    }
    [TestMethod]
    public void IsZeroSidesFrom0Point()
    {
        Polygon pol = new();
        Assert.IsTrue((bool)pol.CheckIfThis.IsCornerCount(0));
    }

    [TestMethod]
    public void IsFourSides()
    {
        Polygon pol = new();
        pol.Points.Add(new Point(0, 0));
        pol.Points.Add(new Point(1, 0));
        pol.Points.Add(new Point(1, 1));
        pol.Points.Add(new Point(0, 1));
        Assert.IsTrue((bool)pol.CheckIfThis.IsCornerCount(4));
    }
    [TestMethod]
    public void IsParallelHrisontal()
    {
        Polygon pol = new();
        pol.Points.Add(new Point(0, 0));
        pol.Points.Add(new Point(1, 0));
        pol.Points.Add(new Point(1, 1));
        pol.Points.Add(new Point(0, 1));
        Assert.IsTrue((bool)pol.CheckIfThis.IsTwoSidesParallel(0, 2));
    }
    [TestMethod]
    public void IsParallelVertical()
    {
        Polygon pol = new();
        pol.Points.Add(new Point(0, 0));
        pol.Points.Add(new Point(1, 0));
        pol.Points.Add(new Point(1, 1));
        pol.Points.Add(new Point(0, 1));
        Assert.IsTrue((bool)pol.CheckIfThis.IsTwoSidesParallel(1, 3));
    }
    [TestMethod]
    public void IsParallelVerticalAndVertiacl()
    {
        Polygon pol = new();
        pol.Points.Add(new Point(0, 0));
        pol.Points.Add(new Point(1, 1));
        pol.Points.Add(new Point(2, 2));
        pol.Points.Add(new Point(3, 3));
        Assert.IsTrue((bool)pol.CheckIfThis.IsTwoSidesParallel(0, 2));
    }
    [TestMethod]
    public void IsAllSidesIsOne()
    {
        Polygon pol = new();
        pol.Points.Add(new Point(0, 0));
        pol.Points.Add(new Point(1, 0));
        pol.Points.Add(new Point(1, 1));
        pol.Points.Add(new Point(0, 1));
        Assert.IsTrue((bool)pol.CheckIfThis.IsAllSidesIs(x => x == 1));
    }
    [TestMethod]
    public void IsAllSidesAreEquals()
    {
        Polygon pol = new();
        pol.Points.Add(new Point(0, 0));
        pol.Points.Add(new Point(1, 0));
        pol.Points.Add(new Point(1, 1));
        pol.Points.Add(new Point(0, 1));
        Assert.IsTrue((bool)pol.CheckIfThis.IsAllSidesIs((l, i, x) => x == l[i-1], 1));
    }
    [TestMethod]
    public void IsAllCornersIs90()
    {
        Polygon pol = new();
        pol.Points.Add(new Point(0, 0));
        pol.Points.Add(new Point(2, 0));
        pol.Points.Add(new Point(2, 1));
        pol.Points.Add(new Point(0, 1));
        Assert.IsTrue((bool)pol.CheckIfThis.IsAllCornersIs(x => x == 90));
    }
}
[TestClass]
public class TestFigures
{
    [TestMethod]
    public void SquareIsSquare()
    {
        Polygon pol = new();
        pol.Points.Add(new Point(0, 0));
        pol.Points.Add(new Point(1, 0));
        pol.Points.Add(new Point(1, 1));
        pol.Points.Add(new Point(0, 1));
        Assert.IsTrue((bool)pol.CheckIfThis.
            IsCornerCount(4).
            IsAllCornersIs(x => x == 90).
            IsAllSidesIs((l, i, x) => l[i - 1] == x, 1));
    }
    [TestMethod]
    public void RectIsSquare()
    {
        Polygon pol = new();
        pol.Points.Add(new Point(0, 0));
        pol.Points.Add(new Point(2, 0));
        pol.Points.Add(new Point(2, 1));
        pol.Points.Add(new Point(0, 1));
        Assert.IsFalse((bool)pol.CheckIfThis.
            IsCornerCount(4).
            IsAllCornersIs(x => x == 90).
            IsAllSidesIs((l, i, x) => l[i - 1] == x, 1));
    }
    [TestMethod]
    public void SquareIsRect()
    {
        Polygon pol = new();
        pol.Points.Add(new Point(0, 0));
        pol.Points.Add(new Point(1, 0));
        pol.Points.Add(new Point(1, 1));
        pol.Points.Add(new Point(0, 1));
        Assert.IsTrue((bool)pol.CheckIfThis.
            IsAllCornersIs(x => x == 90).
            IsCornerCount(4));
    }
    [TestMethod]
    public void RectIsRect()
    {
        Polygon pol = new();
        pol.Points.Add(new Point(0, 0));
        pol.Points.Add(new Point(2, 0));
        pol.Points.Add(new Point(2, 1));
        pol.Points.Add(new Point(0, 1));
        Assert.IsTrue((bool)pol.CheckIfThis.
            IsAllCornersIs(x => x == 90).
            IsCornerCount(4));
    }
}
