# Polygon LINQ

## This project was created to imagine what an api for working with Polygons similar to LINQ would look like.

### **code examples**

create Polygon
```cs
Polygon _polygon = new();
_polygon.Points.Add(new Point(0, 0));
_polygon.Points.Add(new Point(2, 0));
_polygon.Points.Add(new Point(2, 1));
_polygon.Points.Add(new Point(0, 1));
```
checking a polygon for a rectangle
```cs
(bool)_polygon.CheckIfThis.
    IsCornerCount(4).
    IsTwoSidesParallel(0, 2).
    IsTwoSidesParallel(1, 3)
```
checking a polygon for a square
```cs
(bool)_polygon.CheckIfThis.
    IsCornerCount(4).
    IsTwoSidesParallel(0, 2).
    IsTwoSidesParallel(1, 3).
    IsAllSidesIs((l, i, x) => l[i-1] == x, 1)
```


### **function**

```cs 
// checking the number of corners
IsCornerCount(int count)

// checking the number of sides
IsSidesCount(int count)

// checking the two sides for parallelism
IsTwoSidesParallel(int n1, int n2)

// checking the function for all sides
IsAllSidesIs(Func<double[], int, double, bool> func, int startIndex = 0, int endIndex = -1)
IsAllSidesIs(Func<double, bool> func, int startIndex = 0, int endIndex = -1)
```

