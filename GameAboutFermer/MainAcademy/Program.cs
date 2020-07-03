using System;

namespace MainAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] bla = { true, true, true, true };
            string[] obj = { "w", "g", "c", "f" };

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Who next? \nw, g, c, f \n");
                Console.ResetColor();

                for (int i = 0; i < 4; i++)
                {
                    Print(i, bla, obj);
                }

                Console.WriteLine();

                string choice = Console.ReadLine();
                bool j = false;
                bool inside = false;
                for (int a = 0; a < obj.Length; a++)
                {
                    if (obj[a] == choice)
                    {
                        inside = true;
                        j = bla[a];
                        break;
                    }
                }

                if (bla[3] == j)
                {
                    switch (choice)
                    {
                        case "c":
                            bla[2] = !bla[2];
                            break;
                        case "w":
                            bla[0] = !bla[0];
                            break;
                        case "g":
                            bla[1] = !bla[1];
                            break;
                        case "f":
                            break;
                    }
                    bla[3] = !bla[3];
                }
                else if (inside)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You can`t moov this object");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n Wrong input, try again \n");
                    Console.ResetColor();
                }
                Console.Clear();
                if ((bla[1] == !bla[3] && bla[0] == !bla[3]) || (bla[1] == !bla[3] && bla[2] == !bla[3]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    for (int i = 0; i < 4; i++)
                    {
                        Print(i, bla, obj);
                    }
                    Console.WriteLine("\n Game over \n But you can try again \n");
                    Console.ResetColor();
                    bla[2] = true;
                    bla[0] = true;
                    bla[1] = true;
                    bla[3] = true;
                }
            } while (bla[2] || bla[0] || bla[1]);


            for (int i = 0; i < 4; i++)
            {
                Print(i, bla, obj);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congratulation\n   YOU WIN");
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void Print(int index, bool[] bla, string[] obj)
        {
            if (bla[index] == true)
            {
                Console.WriteLine("|'{0}'|  |   |", obj[index]);
            }
            else
            {
                Console.WriteLine("|   |  |'{0}'|", obj[index]);
            }
        }
    }
}