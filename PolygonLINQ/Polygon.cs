using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonLINQ;

public class Polygon
{
    public struct Point
    {
        public int x;
        public int y;
        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }

    private double[] _sides;
    private double[] _corners;
    public double[] Sides { get => _sides; }
    public double[] Corners { get => _corners; }

    private ObservableCollection<Point> _points;
    public ObservableCollection<Point> Points { get => _points; }
    public PolygonRequest CheckIfThis { get => new PolygonRequest(this); }


    public Polygon()
    {
        _points = new ObservableCollection<Point>();
        _sides = new double[0];
        _corners = new double[0];
        Points.CollectionChanged += GenerateCornersAndSide;
    }


    private void GenerateCornersAndSide(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (Points.Count <= 1)
        {
            _sides = new double[0];
            _corners = new double[0];
        }
        else if (Points.Count == 2)
        {
            _sides = new double[0];
            var a = Math.Abs(Points[0].x - Points[1].x);
            var b = Math.Abs(Points[0].y - Points[1].y);
            _corners = new double[1] { Math.Sqrt(a * a + b * b) };
        }
        else
        {
            double a;
            double b;
            var sds = new List<double>(_points.Count + 1);
            for (int i = 1; i < _points.Count; i++)
            {
                a = Math.Abs(Points[i - 1].x - Points[i].x);
                b = Math.Abs(Points[i - 1].y - Points[i].y);
                sds.Add(Math.Sqrt(a * a + b * b));
            }
            a = Math.Abs(Points[0].x - Points[^1].x);
            b = Math.Abs(Points[0].y - Points[^1].y);
            sds.Add(Math.Sqrt(a * a + b * b));
            _sides = sds.ToArray();


            var crns = new List<double>(_points.Count+1);
            for (int i = 0; i < _points.Count; i++)
            {
                // A = _points[i], B = _points[(i + 2) % _points.Count], C = _points[(i + 1) % _points.Count]
                var Ax = _points[(i + 1) % _points.Count].x - Points[i].x;
                var Ay = _points[(i + 1) % _points.Count].y - Points[i].y;
                var Bx = _points[(i + 1) % _points.Count].x - Points[(i + 2) % _points.Count].x;
                var By = _points[(i + 1) % _points.Count].y - Points[(i + 2) % _points.Count].y;
                crns.Add(Math.Round(Math.Acos(
                    (Ax * Bx + Ay * By)
                    /
                    (Math.Sqrt(Ax * Ax + Ay * Ay) * Math.Sqrt(Bx * Bx + By * By))
                    )/3.14*180, 1));
            }
            crns.Insert(0, crns[crns.Count - 1]);
            crns.RemoveAt(crns.Count-1);
            _corners = crns.ToArray();
        }
    }

}

