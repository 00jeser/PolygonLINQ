using PolygonLINQ;
using static PolygonLINQ.Polygon;
using static System.Console;

Polygon pol = new();
pol.Points.Add(new Point(0, 0));
pol.Points.Add(new Point(2, 0));
pol.Points.Add(new Point(2, 1));
pol.Points.Add(new Point(0, 1));
WriteLine((bool)pol.CheckIfThis.IsCornerCount(4).IsTwoSidesParallel(0, 2).IsTwoSidesParallel(1, 3).IsAllSidesIs((l, i, x) => l[i-1] == x, 1));
