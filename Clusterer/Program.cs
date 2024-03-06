using System;
using System.Collections.Generic;

// Структура для представления точки на плоскости
struct Point
{
    public double x;
    public double y;

    

    // Метод для вычисления расстояния между текущей точкой и заданной startPoint
    public double DistanceTo(Point startPoint)
    {
        return Math.Sqrt(Math.Pow(x - startPoint.x, 2) + Math.Pow(y - startPoint.y, 2));
    }

    // Метод для вычисления угла между текущей точкой и заданной startPoint в градусах
    public double AngleTo(Point startPoint)
    {
        return Math.Atan2(y - startPoint.y, x - startPoint.x) * (180 / Math.PI);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Point[] pointsArray = { /* массив точек */ };

        Point startPoint = new Point { x = /* координата x начальной точки */, y =  /* координата y начальной точки */ };

        List<Point> farthestPoints = new List<Point>();
        double maxDistance = 0;

        // Проход по всем точкам из массива точек
        foreach (var point in pointsArray)
        {
            double distance = point.DistanceTo(startPoint); // Расстояние от текущей точки до начальной точки
            double angle = Math.Abs(point.AngleTo(startPoint)); // Угол между текущей точкой и начальной точкой

            // Проверка условий на наибольшее расстояние и разницу направления более 20 градусов
            if (distance > maxDistance && angle > 20)
            {
                maxDistance = distance;
                farthestPoints.Clear();
                farthestPoints.Add(point);
            }
            else if (distance == maxDistance && angle > 20)
            {
                farthestPoints.Add(point);
            }
        }

        // Вывод найденных точек с самым большим расстоянием и разницей направления более 20 градусов
        Console.WriteLine($"Самые отдаленные точки от начальной точки с разницей направления более 20 градусов ({farthestPoints.Count} точек):");
        foreach (var point in farthestPoints)
        {
            Console.WriteLine($"Точка: x = {point.x}, y = {point.y}");
        }
    }
}
