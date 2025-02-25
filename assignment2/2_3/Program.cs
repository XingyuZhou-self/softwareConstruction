//埃氏筛法筛选从2-100的素数
using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static bool[] InitArray(int length)
    {
        
        bool[] isPrime = new bool[length+1];
        isPrime[0] = false;
        isPrime[1] = false;
        for (int i = 2; i <= length; i++)
        {
            isPrime[i] = true;
        }
        return isPrime;
    }
    static void modify(ref bool[]isPrime,int length)
    {
        int sqrt = (int)Math.Sqrt(length);
        for (int j = 2; j <= sqrt; j++)//2~sqrt(n)的素数，一个合数有两个因子，其中一个小于sqrt(n)
        {
            if (isPrime[j])
            {
                for (int k = j * j; k <= length; k += j)//为什么从j*j开始？    j*1,j*2,j*3...都已经被1,2,3,这些小于j的数标记为合数
                {
                    isPrime[k] = false;
                }
            }
        }
    }
    static void Main()
    {
        //int n = 100;
        //// 创建一个布尔数组，数组下标代表数字，初始假设所有数字都是素数
        //bool[] isPrime = new bool[n + 1];
        //// 0 和 1 不是素数，其它数字设为 true
        //isPrime[0] = isPrime[1] = false;
        //for (int i = 2; i <= n; i++)
        //{
        //    isPrime[i] = true;
        //}

        //// 从 2 到 sqrt(n) 执行筛选
        //for (int i = 2; i * i <= n; i++)
        //{
        //    if (isPrime[i])
        //    {
        //        // 将 i 的所有倍数标记为非素数
        //        for (int j = i * i; j <= n; j += i)
        //        {
        //            isPrime[j] = false;
        //        }
        //    }
        //}

        //// 输出所有素数
        //Console.WriteLine("2 到 100 内的素数：");
        //for (int i = 2; i <= n; i++)
        //{
        //    if (isPrime[i])
        //        Console.Write(i + " ");
        //}
        //Console.WriteLine();

        int n = 100;
        bool[] isPrime = InitArray(n);
        modify(ref isPrime, n);
        Console.Write("2~100内的素数: ");
        for (int i = 2; i <= n; i++)
        {
            if (isPrime[i])
                Console.Write(i + " ");
        }
    }
}
