using PolygonLINQ;
using static PolygonLINQ.Polygon;
using static System.Console;

Polygon polygon = new();
polygon.Points.Add(new Point(0, 0));
polygon.Points.Add(new Point(2, 0));
polygon.Points.Add(new Point(2, 1));
polygon.Points.Add(new Point(0, 1));
WriteLine((bool)polygon.CheckIfThis.
    IsCornerCount(4).
    IsTwoSidesParallel(0, 2).
    IsTwoSidesParallel(1, 3).
    IsAllSidesIs((l, i, x) => l[i-1] == x, 1)
    ); // check is rect
