using System;

namespace Lesson3HW
{
    class MainClass
    {
        private static void Main(string[] args)
        {
            bool bla = true;
            double result = 0;
            Console.WriteLine("Write first number");
            string firstNumStr = Console.ReadLine();
            Console.WriteLine("\nWrite action \n+ - * /");
            string action = Console.ReadLine();
            Console.WriteLine("\nWrite second number");
            string secondNumStr = Console.ReadLine();
            try
            {
                double firstNum = double.Parse(firstNumStr);
                double secondNum = double.Parse(secondNumStr);

                switch (action)
                {
                    case "+":
                        result = firstNum + secondNum;
                        break;
                    case "-":
                        result = firstNum - secondNum;
                        break;
                    case "*":
                        result = firstNum * secondNum;
                        break;
                    case "/":
                        if (secondNum == 0)
                        {
                            Console.WriteLine("Division by zero");
                            bla = false;
                        }
                        else
                        {
                            result = firstNum / secondNum;
                        }
                        break;
                    default:
                        Console.WriteLine("You can`t doing this action");
                        break;
                }
                if (bla) {
                    Console.WriteLine("\n{0}{1}{2}={3}", firstNumStr, action, secondNumStr, result);
                }
                Console.ReadKey();

            }
            catch
            {
                Console.WriteLine("\n Please write number");
            }
        }
    }
}

