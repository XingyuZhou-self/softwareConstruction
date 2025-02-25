// 编程求一个整数数组的最大值、最小值、平均值和所有数组元素的和

using System;

namespace ArrayApplication
{
    class Program
    {
        static void Main()
        {
            int[] numbers = { 12, 45, 23, 89, 56, 78, 34 };

            // 初始化最大值和最小值
            int max = numbers[0];
            int min = numbers[0];
            int sum = 0;

            // 遍历数组计算 max、min 和 sum
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max) max = numbers[i]; // 更新最大值
                if (numbers[i] < min) min = numbers[i]; // 更新最小值
                sum += numbers[i];  // 计算总和
            }

            double average = (double)sum / numbers.Length; // 计算平均值

            // 输出结果
            Console.WriteLine($"最大值: {max}");
            Console.WriteLine($"最小值: {min}");
            Console.WriteLine($"总和: {sum}");
            Console.WriteLine($"平均值: {average:F2}"); // 保留两位小数
        }
    }

}
