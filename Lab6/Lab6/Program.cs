using System;
using System.Collections.Generic;

namespace Lab6
{
    class MainClass
    {
        public static List<LibrariUser> librariUsers = new List<LibrariUser>();
        public static bool firstLoop = true;
        public static bool stayAtProgram = true;
        public static int choiseUser = 0;

        public static void Main()
        {
            if (firstLoop)
            {
                Console.WriteLine("Hello, wellcome to our program\nPlease registretion\n");
                RegistreUser();
            }
            if (librariUsers.Count > 1)
            {
                Console.WriteLine("Choise one of this user");
                for (int i = 0; i < librariUsers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{librariUsers[i].FirstName}");
                }

                choiseUser = int.Parse(Console.ReadLine()) - 1;
                Console.Clear();
            }
            else if(!firstLoop)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have only onne user");
                Console.ResetColor();
            }

            while (stayAtProgram)
            {
                if (firstLoop)
                {
                    Console.WriteLine("This is menu, were you can choise what you want to do");
                }
                else
                {
                    Console.WriteLine("Choise somesing"); 
                }
                Console.WriteLine($"1.Registre new user\n2.Add new book\n3.Remove book\n4.Information about your book" +
                    $"\n5.How many books do you have\n6.Change your phone number\n7.Give all information about user\n8.Exit to choise user\n9.Exit\n");

                int choise = int.Parse(Console.ReadLine());
                firstLoop = false;

                switch (choise)
                {
                    case (1):
                        Console.Clear();
                        RegistreUser();
                        break;
                    case (2):
                        Console.Clear();
                        librariUsers[choiseUser].AddBook();
                        break;
                    case (3):
                        Console.Clear();
                        librariUsers[choiseUser].RemoveBook();
                        break;
                    case (4):
                        Console.Clear();
                        librariUsers[choiseUser].BookInfo();
                        break;
                    case (5):
                        Console.Clear();
                        librariUsers[choiseUser].BookCount();
                        break;
                    case (6):
                        Console.Clear();
                        Console.Write("Write your phone numbe: ");
                        string newNumber = Console.ReadLine();
                        librariUsers[choiseUser].Phone = newNumber;
                        Console.WriteLine();
                        break;
                    case (7):
                        Console.Clear();
                        Information(librariUsers[choiseUser]);
                        break;
                    case (8):
                        Console.Clear();
                        Main();
                        break;
                    case (9):
                        Console.Clear();
                        stayAtProgram = false;
                        Console.WriteLine("Thank you for choosing our program");
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Pelase, choose one operation");
                        Console.ResetColor();
                        break;
                }
            }
        }

        public static void RegistreUser()
        {
            Console.Write("Input youd information \nName:");
            string userFirstName = Console.ReadLine();

            Console.Write("Last name:");
            string userLastName = Console.ReadLine();

            Console.Write("Id:");
            string userIdStr = Console.ReadLine();
            if (int.TryParse(userIdStr, out int userId))
            {
                userId = int.Parse(userIdStr);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please write number\n");
                Console.ResetColor();
                Main();
            }

            Console.Write("Book limit:");
            string userBookLimitStr = Console.ReadLine();
            if (int.TryParse(userBookLimitStr, out int userBookLimit))
            {
                userBookLimit = int.Parse(userBookLimitStr);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please write number\n");
                Console.ResetColor();
                Main();
            }

            Console.Write("Phone number:");
            string userPhoneNumber = Console.ReadLine();
            Console.WriteLine("");

            LibrariUser user = new LibrariUser(userFirstName, userLastName, userId, userBookLimit, userPhoneNumber);
            librariUsers.Add(user);
            Console.Clear();
        }

        public static void Information(LibrariUser librariUser)
        {
            Console.WriteLine($"Name: {librariUser.FirstName}\nLastname: {librariUser.LastName}\nID: {librariUser.Id}\nBook limit: {librariUser.BookLimit}\nPhone: {librariUser.Phone}\n");
        }
    }
}
