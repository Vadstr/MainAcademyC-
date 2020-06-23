using System;
using System.Collections.Generic;

namespace Lab6
{
    class MainClass
    {
        public static List<LibrariUser> librariUsers = new List<LibrariUser>();
        public static bool firstLoop = true;
        public static bool stayAtProgram = true;

        public static void Main()
        {
            if (firstLoop)
            {
                Console.WriteLine("Hello, wellcome to our program\nPlease registretion\n");
                RegistreUser();
            }

            int choiseUser = 0;
            if (librariUsers.Count > 1)
            {
                Console.WriteLine("Choise one of this user");
                for(int i = 0; i < librariUsers.Count;i++)
                {
                    Console.WriteLine($"{i+1}.{librariUsers[i].FirstName}");
                }
                
                choiseUser = int.Parse(Console.ReadLine())-1;
                Console.WriteLine();
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
                    $"\n5.How many books do you have\n6.Change your phone number\n7.Exit to choise user\n8.Exit\n");

                int choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case (1):
                        RegistreUser();
                        break;
                    case (2):
                        librariUsers[choiseUser].AddBook();
                        break;
                    case (3):
                        librariUsers[choiseUser].RemoveBook();
                        break;
                    case (4):
                        librariUsers[choiseUser].BookInfo();
                        break;
                    case (5):
                        librariUsers[choiseUser].BookCount();
                        break;
                    case (6):
                        Console.Write("Write your phone number");
                        string newNumber = Console.ReadLine();
                        librariUsers[choiseUser].Phone = newNumber;
                        Console.WriteLine();
                        break;
                    case (7):
                        firstLoop = false;
                        Main();
                        break;
                    case (8):
                        stayAtProgram = false;
                        Console.WriteLine("Thank you for choosing our program");
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
            int userId = int.Parse(Console.ReadLine());

            Console.Write("Book limit:");
            int userBookLimit = int.Parse(Console.ReadLine());

            Console.Write("Phone number:");
            string userPhoneNumber = Console.ReadLine();
            Console.WriteLine("");

            LibrariUser user = new LibrariUser(userFirstName, userLastName, userId, userBookLimit, userPhoneNumber);

            librariUsers.Add(user);
        }
    }
}
