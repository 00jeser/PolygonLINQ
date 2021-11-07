using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonLINQ;

public class PolygonRequest
{
    public Polygon Polygon { get; set; }
    public bool Result { get; set; } = true;
    public PolygonRequest(Polygon polygon) => Polygon = polygon;
    public static explicit operator bool(PolygonRequest req) => req.Result;

    public PolygonRequest IsCornerCount(int count)
    {
        if (Result == false)
            return new PolygonRequest(Polygon) { Result = false };


        if (count == Polygon.Corners.Length)
            return new PolygonRequest(Polygon) { Result = true };
        return new PolygonRequest(Polygon) { Result = false };
    }

    public PolygonRequest IsSidesCount(int count)
    {
        if (Result == false)
            return new PolygonRequest(Polygon) { Result = false };


        if (count == Polygon.Sides.Length)
            return new PolygonRequest(Polygon) { Result = true };
        return new PolygonRequest(Polygon) { Result = false };
    }

    public PolygonRequest IsTwoSidesParallel(int n1, int n2)
    {
        if (Result == false)
            return new PolygonRequest(Polygon) { Result = false };


        var n10 = Polygon.Points[n1];
        var n11 = Polygon.Points[(n1 + 1) % Polygon.Points.Count];
        var n20 = Polygon.Points[n2];
        var n21 = Polygon.Points[(n2 + 1) % Polygon.Points.Count];
        if (n10.y - n20.y == n11.y - n21.y)
        {
            return new PolygonRequest(Polygon) { Result = true };
        }
        if (n10.x - n20.x == n11.x - n21.x)
        {
            return new PolygonRequest(Polygon) { Result = true };
        }
        return new PolygonRequest(Polygon) { Result = false };
    }

    public PolygonRequest IsAllSidesIs(Func<double[], int, double, bool> func, int startIndex = 0, int endIndex = -1)
    {
        if (Result == false)
            return new PolygonRequest(Polygon) { Result = false };

        if (endIndex == -1)
            endIndex = Polygon.Points.Count;
        for (int i = startIndex; i < Polygon.Points.Count; i++)
            if (!func(Polygon.Sides, i, Polygon.Sides[i]))
                return new PolygonRequest(Polygon) { Result = false };
        return new PolygonRequest(Polygon) { Result = true };
    }
    public PolygonRequest IsAllSidesIs(Func<double, bool> func, int startIndex = 0, int endIndex = -1)
    {
        if (Result == false)
            return new PolygonRequest(Polygon) { Result = false };

        if (endIndex == -1)
            endIndex = Polygon.Points.Count;
        for (int i = startIndex; i < Polygon.Points.Count; i++)
            if (!func(Polygon.Sides[i]))
                return new PolygonRequest(Polygon) { Result = false };
        return new PolygonRequest(Polygon) { Result = true };
    }
    public PolygonRequest IsAllCornersIs(Func<double[], int, double, bool> func, int startIndex = 0, int endIndex = -1)
    {
        if (Result == false)
            return new PolygonRequest(Polygon) { Result = false };

        if (endIndex == -1)
            endIndex = Polygon.Points.Count;
        for (int i = startIndex; i < Polygon.Points.Count; i++)
            if (!func(Polygon.Corners, i, Polygon.Corners[i]))
                return new PolygonRequest(Polygon) { Result = false };
        return new PolygonRequest(Polygon) { Result = true };
    }
    public PolygonRequest IsAllCornersIs(Func<double, bool> func, int startIndex = 0, int endIndex = -1)
    {
        if (Result == false)
            return new PolygonRequest(Polygon) { Result = false };

        if (endIndex == -1)
            endIndex = Polygon.Points.Count;
        for (int i = startIndex; i < Polygon.Points.Count; i++)
            if (!func(Polygon.Corners[i]))
                return new PolygonRequest(Polygon) { Result = false };
        return new PolygonRequest(Polygon) { Result = true };
    }

}

