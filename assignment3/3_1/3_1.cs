using System;

namespace ShapesDemo
{
    // 定义一个形状接口
    public interface IShape
    {
        // 只读属性：面积
        double Area { get; }
        // 只读属性：形状是否合法
        bool IsValid { get; }
    }

    // 抽象基类实现IShape接口，方便后续扩展公共功能
    public abstract class Shape : IShape
    {
        public abstract double Area { get; }
        public abstract bool IsValid { get; }
    }

    // 长方形类
    public class Rectangle : Shape
    {
        // 长和宽的属性
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        // 面积计算：长 * 宽
        public override double Area => Length * Width;

        // 合法性判断：长和宽都必须大于0
        public override bool IsValid => Length > 0 && Width > 0;
    }

    // 正方形类
    public class Square : Shape
    {
        // 边长属性
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        // 面积计算：边长的平方
        public override double Area => Side * Side;

        // 合法性判断：边长必须大于0
        public override bool IsValid => Side > 0;
    }

    // 三角形类
    public class Triangle : Shape
    {
        // 三边属性
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        // 合法性判断：任意两边之和大于第三边，并且三边均大于0
        public override bool IsValid =>
            SideA > 0 && SideB > 0 && SideC > 0 &&
            (SideA + SideB > SideC) &&
            (SideA + SideC > SideB) &&
            (SideB + SideC > SideA);

        // 面积计算：使用海伦公式
        public override double Area
        {
            get
            {
                if (!IsValid)
                {
                    return 0;
                }
                double s = (SideA + SideB + SideC) / 2;
                return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
            }
        }
    }

    // 测试程序
    class Program
    {
        static void Main(string[] args)
        {
            // 测试长方形
            Rectangle rect = new Rectangle(5, 3);
            Console.WriteLine("长方形：面积 = {0}, 合法 = {1}", rect.Area, rect.IsValid);

            // 测试正方形
            Square square = new Square(4);
            Console.WriteLine("正方形：面积 = {0}, 合法 = {1}", square.Area, square.IsValid);

            // 测试三角形
            Triangle triangle = new Triangle(3, 4, 5);
            Console.WriteLine("三角形：面积 = {0:F2}, 合法 = {1}", triangle.Area, triangle.IsValid);

            // 测试不合法的三角形
            Triangle invalidTriangle = new Triangle(1, 2, 3);
            Console.WriteLine("无效三角形：面积 = {0:F2}, 合法 = {1}", invalidTriangle.Area, invalidTriangle.IsValid);
        }
    }
}
