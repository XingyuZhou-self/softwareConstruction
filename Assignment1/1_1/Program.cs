using System;
namespace SayHello
{
    class Program
    {

        static void Main(string[] args)
        {
            int firstInput = Convert.ToInt32(Console.ReadLine());
            int secondInput = Convert.ToInt32(Console.ReadLine());
            string @operator= Console.ReadLine();
            if (@operator == "+") Console.WriteLine($"{firstInput}{@operator}{secondInput}={firstInput + secondInput}");
            if (@operator == "-") Console.WriteLine($"{firstInput}{@operator}{secondInput}={firstInput - secondInput}");
            if (@operator == "*") Console.WriteLine($"{firstInput}{@operator}{secondInput}={firstInput * secondInput}");
            if (@operator == "/") Console.WriteLine($"{firstInput}{@operator}{secondInput}={firstInput / secondInput}");
        }
    }
}