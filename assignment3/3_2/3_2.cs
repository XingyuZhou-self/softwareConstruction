using System;

namespace RandomShapesDemo
{
    // 定义形状接口
    public interface IShape
    {
        double Area { get; }
        bool IsValid { get; }
    }

    // 抽象基类
    public abstract class Shape : IShape
    {
        public abstract double Area { get; }
        public abstract bool IsValid { get; }
    }

    // 长方形类
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public override double Area => Length * Width;
        public override bool IsValid => Length > 0 && Width > 0;

        public override string ToString() => $"Rectangle (Length={Length:F2}, Width={Width:F2})";
    }

    // 正方形类
    public class Square : Shape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public override double Area => Side * Side;
        public override bool IsValid => Side > 0;

        public override string ToString() => $"Square (Side={Side:F2})";
    }

    // 三角形类
    public class Triangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override bool IsValid =>
            SideA > 0 && SideB > 0 && SideC > 0 &&
            (SideA + SideB > SideC) &&
            (SideA + SideC > SideB) &&
            (SideB + SideC > SideA);

        public override double Area
        {
            get
            {
                if (!IsValid)
                    return 0;
                double s = (SideA + SideB + SideC) / 2;
                return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
            }
        }

        public override string ToString() => $"Triangle (SideA={SideA:F2}, SideB={SideB:F2}, SideC={SideC:F2})";
    }

    // 简单工厂类，用于随机创建形状对象
    public static class ShapeFactory
    {
        public static Shape CreateRandomShape(Random rand)
        {
            // 随机选择形状类型：0-Rectangle, 1-Square, 2-Triangle
            int shapeType = rand.Next(3);
            switch (shapeType)
            {
                case 0: // 长方形：随机生成长和宽（范围在 1 到 11 之间）
                    double length = Math.Round(rand.NextDouble() * 10 + 1, 2);
                    double width = Math.Round(rand.NextDouble() * 10 + 1, 2);
                    return new Rectangle(length, width);
                case 1: // 正方形：随机生成边长
                    double side = Math.Round(rand.NextDouble() * 10 + 1, 2);
                    return new Square(side);
                case 2: // 三角形：保证生成有效的三角形
                    double a = Math.Round(rand.NextDouble() * 10 + 1, 2);
                    double b = Math.Round(rand.NextDouble() * 10 + 1, 2);
                    // 为保证三角形合法，第三边 c 的取值范围为 (|a-b|, a+b)
                    double min = Math.Abs(a - b) + 0.1;
                    double max = a + b - 0.1;
                    double c = Math.Round(rand.NextDouble() * (max - min) + min, 2);
                    return new Triangle(a, b, c);
                default:
                    throw new Exception("未知形状类型");
            }
        }
    }

    // 测试程序
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            const int shapeCount = 10;
            double totalArea = 0;

            for (int i = 0; i < shapeCount; i++)
            {
                Shape shape = ShapeFactory.CreateRandomShape(rand);
                Console.WriteLine($"{shape} | Area: {shape.Area:F2} | Valid: {shape.IsValid}");
                totalArea += shape.Area;
            }
            Console.WriteLine($"总面积: {totalArea:F2}");
        }
    }
}
