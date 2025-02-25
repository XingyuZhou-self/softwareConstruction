// 用户输入数据的所有素数因子
using System;
namespace PrimeFactorApplication
{
    class Program
    {
        static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;

            int sqrtNum = (int)Math.Sqrt(num);
            for(int i=3;i<=sqrtNum;i+=2)//只检查奇数即可
            {
                if (num % i == 0) return false;
            }
            return true;
        }
        static void FindPrimeFactor(int num)
        {
            if (num <= 1) Console.Write("没有素数因子");
            if (num == 2) Console.Write("2是素数");
            Console.WriteLine("素数因子： ");
            //for(int i=2;i<num;++i)
            //{

            //    if(num%i==0)
            //    {//factors
            //        if(IsPrime(i))
            //        {//prime factors
            //            Console.Write(Convert.ToString(i));
            //        }
            //    }
            //}

            //一种更高效的算法
            int sqrtNum = (int)Math.Sqrt(num);
            for(int i=2;i<=sqrtNum;i++)
            {
                if(num%i==0)
                {//i是num的因子
                    if(IsPrime(i))//i是num的素数因子
                    {
                        Console.WriteLine(i);
                    }
                    if((i!=num/i)&&IsPrime(num/i))//判断num更大的因子是不是素数，减少遍历量
                    {
                        Console.WriteLine(num / i);
                    }
                }
            }
        }
        static void Main()
        {
            Console.Write("请输入数字: ");
            int number = Convert.ToInt32(Console.ReadLine());
            FindPrimeFactor(number);
        }
    }

}
