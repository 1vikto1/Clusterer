using System;
using System.Collections.Generic;
using System.Linq;

// Класс представляет точку с координатами X и Y
public class Point
{
    public double X { get; set; } // Координата X
    public double Y { get; set; } // Координата Y

    // Конструктор класса Point, инициализирует точку с заданными координатами
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}

public class Program
{
    // Функция для вычисления расстояния между двумя точками
    public static double Distance(Point point1, Point point2)
    {
        return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
    }

    public static void Main()
    {
        // Фиксированная стартовая точка
        Point startPoint = new Point(53.361231, 83.765688);

        Console.WriteLine("Введите координаты других точек:");

        // Создание списка для хранения других точек
        List<Point> points = new List<Point>();
        points.Add(CreatePoint());
        points.Add(CreatePoint());

        // Нахождение самой удаленной точки от стартовой точки
        Point farthestPoint = points.OrderByDescending(p => Distance(startPoint, p)).First();

        // Вывод результатов
        Console.WriteLine($"Самая удаленная точка от стартовой с координатами ({startPoint.X}, {startPoint.Y}) имеет координаты ({farthestPoint.X}, {farthestPoint.Y})");
    }

    // Функция для создания точки с введенными пользователем координатами
    public static Point CreatePoint()
    {
        Console.Write("X: ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Y: ");
        double y = Convert.ToDouble(Console.ReadLine());

        return new Point(x, y);
    }
}

