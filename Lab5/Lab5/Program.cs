using System;
using System.Threading;

namespace Lab5
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Write first number");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            int numStr = int.Parse(Console.ReadLine());
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Write second number");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            int numStr1 = int.Parse(Console.ReadLine());
            Console.ResetColor();

            string result = ToUnaryNum(numStr);
            string result1 = ToUnaryNum(numStr1);
            string result2 = ToUnaryNum(Math.Abs(numStr1 - numStr));

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write($"{result}");
            Console.ResetColor();

            Console.Write("#");

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"{result1}");
            Console.ResetColor();

            if (numStr > numStr1)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{result2}");
                Console.ResetColor();
            }
            else if (numStr1 > numStr)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"{result2}");
                Console.ResetColor();
            }

            string resultbin = ToBinary(numStr + numStr1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"a + b = {numStr + numStr1} at binary {resultbin}");
            Console.ResetColor();

        }

        public static string ToUnaryNum(int numStr)
        {
            string res = "";
            for (int i = 0; i < numStr; i++)
            {
                res += 1;
            }
            return res;
        }

        public static string ToBinary(int num)
        {
            string bin = "";
            string bin1 = "";
            while (num >= 1)
            {
                int ost = num % 2;
                num = (num - ost) / 2;
                bin += ost;
            }

            char[] cArray = bin.ToCharArray();

            for (int i = 1; i <= bin.Length; i++)
            {
                bin1 += cArray[bin.Length - i];
            }

            return bin1;
        }

    }
}
