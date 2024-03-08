using System;
using System.Collections.Generic;

// Структура для представления точки на плоскости
struct Point
{
    //Координаты точки
    public double x;
    public double y;

    //Градус угла вектора направленного к этой точке
    public int Corner;

    // Метод для вычисления расстояния между текущей точкой и заданной startPoint
    public double DistanceTo(Point startPoint)
    {
        return Math.Sqrt(Math.Pow(x - startPoint.x, 2) + Math.Pow(y - startPoint.y, 2));
    }

    // Метод для вычисления угла направления вектора
    static double AngleBetweenVectors(Point p1, Point p2, Point p3)
    {
        double angleRad = Math.Acos(((p2.x - p1.x) * (p3.x - p1.x) + (p2.y - p1.y) * (p3.y - p1.y)) / (Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2)) * Math.Sqrt(Math.Pow(p3.x - p1.x, 2) + Math.Pow(p3.y - p1.y, 2))));
        double angleDeg = angleRad * (180.0 / Math.PI);
        return angleDeg;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Point[] PointsArray = { /* массив точек */ };

        Point StartPoint = new Point { x = 10, y = 10 };

        List<Point> FarthestPoints = new List<Point>();
        double MaxDistance = 0;

        // Проход по всем точкам из массива точек
        foreach (var Point in PointsArray)
        {
            double distance = Point.DistanceTo(StartPoint); // Расстояние от текущей точки до начальной точки
            double angle = Math.Abs(Point.AngleTo(StartPoint)); // Угол между текущей точкой и начальной точкой

            // Проверка условий на наибольшее расстояние и разницу направления более 20 градусов
            if (distance > MaxDistance && angle > 20)
            {
                MaxDistance = distance;
                FarthestPoints.Clear();
                FarthestPoints.Add(Point);
            }
            else if (distance == MaxDistance && angle > 20)
            {
                FarthestPoints.Add(Point);
            }
        }

        // Вывод найденных точек с самым большим расстоянием и разницей направления более 20 градусов
        Console.WriteLine($"Самые отдаленные точки от начальной точки с разницей направления более 20 градусов ({FarthestPoints.Count} точек):");
        foreach (var point in FarthestPoints)
        {
            Console.WriteLine($"Точка: x = {point.x}, y = {point.y}");
        }
    }
}
