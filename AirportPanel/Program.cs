using System;

namespace Airport1
{
    class MainClass
    {
        public static bool firstLoop = true;
        public static bool stayAtProgram = true;
        public static object[,] airport = new object[5, 10]; 
        public static string[] lengPartOfTable = new string[10];
        public static int countOfFlight = 0;
        private static DateTime arrivalDate;
        private static DateTime depurtureDate;

        public static void Main(string[] args)
        {
            DateTime arrival1 = new DateTime(12,12,12,7,0,0);
            DateTime depurture1 = new DateTime(12,12,12,9,0,0);

            DateTime arrival2 = new DateTime(2020, 12, 22, 10, 0, 0);
            DateTime depurture2 = new DateTime(2020, 12, 22, 12, 0, 0);

            object[] nameOfPart = {"Flight number", "Arrival date and time", "Departure date and time","City/port of arrival",
                "City/port of depurture","Airline","Terminal","Status","Gate"};
            object[] plane1 = new object[] { "0982", arrival1, depurture1, "Kyiv", "Lviv", "MAU", "C", "", 2 };
            object[] plane2 = new object[] { "3029", arrival2, depurture2, "Lviv", "London", "MAU", "A", "", 4 };

            AddFlight(nameOfPart);
            AddFlight(plane1);
            AddFlight(plane2);

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
                Console.WriteLine($"1.Add new flight\n2.Remove flight\n3.Editing information\n4.Search by data\n" +
                    $"5.Upcoming flights\n6.Give all information about flight\n7.Emergency\n8.Exit\n");

                var choise = Console.ReadLine();
                
                firstLoop = false;

                switch (choise)
                {
                    case ("1"):
                        Console.Clear();
                        AddFlight();
                        break;
                    case ("2"):
                        Console.Clear();
                        RemoveFlight();
                        break;
                    case ("3"):
                        Console.Clear();
                        EditingInformation();
                        break;
                    case ("4"):
                        Console.Clear();
                        SearchByData();
                        break;
                    case ("5"):
                        Console.Clear();
                        UpcomingFlight();
                        break;
                    case ("6"):
                        Console.Clear();
                        GiveAllInformation();
                        break;
                    case ("7"):
                        Console.Clear();
                        Emergency();
                        break;
                    case ("8"):
                        Console.Clear();
                        stayAtProgram = false;
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Pelase, choose one operation\n");
                        Console.ResetColor();
                        break;
                }
            }
            Console.WriteLine("Thanks for choosing our program");
        }

        public static void AddFlight()
        {
            Console.Write("Input flight information \nInput rase number:");
            string raseNum = Console.ReadLine();
            try
            {
                Console.Write("Input arrival date (DD.MM.YYYY HH:MM:mm):");
                arrivalDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Input depurture date (DD.MM.YYYY HH:MM:mm):");
                depurtureDate = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Write in correct format");
                Console.ResetColor();
                AddFlight();
                return;
            }

            Console.Write("City/port of arrival:");
            string arrivalPlace = Console.ReadLine();

            Console.Write("City/port of depurture:");
            string depurturePlace = Console.ReadLine();

            Console.Write("Airlines:");
            string airlines = Console.ReadLine();

            Console.Write("Terminal:");
            string terminal = Console.ReadLine();

            Console.Write("Gate:");
            string gate = Console.ReadLine();

            airport[countOfFlight, 0] = countOfFlight+1;
            airport[countOfFlight, 1] = raseNum;
            airport[countOfFlight, 2] = arrivalDate;
            airport[countOfFlight, 3] = depurtureDate;
            airport[countOfFlight, 4] = arrivalPlace;
            airport[countOfFlight, 5] = depurturePlace;
            airport[countOfFlight, 6] = airlines;
            airport[countOfFlight, 7] = terminal;
            airport[countOfFlight, 8] = "";
            airport[countOfFlight, 9] = gate;
            countOfFlight++;

            Console.Clear();
        }

        public static void AddFlight(object[] arr)
        {
            if (countOfFlight != 0)
            {
                airport[countOfFlight, 0] = countOfFlight;
            }
            else
            {
                airport[countOfFlight, 0] = "";
            }

            for (int i = 1; i < airport.GetLength(1); i++)
            {
                airport[countOfFlight, i] = arr[i - 1];
            }
            countOfFlight++;
        }

        public static void RemoveFlight()
        {
            GiveAllInformation();
            Console.Write("Input rase number to remove : ");
            string flyNumber = Console.ReadLine();
            int raseNum = 0;

            for (int i = 0; i < countOfFlight; i++)
            {
                if (flyNumber == airport[i,1].ToString())
                {
                    raseNum = i;
                }
            }

            for (int i = 0; i < countOfFlight; i++)
            {
                for (int j = 0; j < airport.GetLength(1); j++)
                {
                    if (i > raseNum)
                    {
                        airport[i - 1, j] = airport[i, j];
                    }
                }
            }

            if (raseNum == 0)
            {
                Console.WriteLine("Coc");
            }
            countOfFlight--;
        }

        public static void EditingInformation()
        {
            int plane = SearchByData();
            if (plane != countOfFlight) {
                for (int i = 0; i < airport.GetLength(1) - 1; i++)
                {
                    Console.WriteLine($"{i + 1}.{airport[0, i + 1]}");
                }

                Console.Write("Input what you whant to change: ");
                int choise = int.Parse(Console.ReadLine());

                Console.Write($"Input new {airport[0, choise]}: ");
                airport[plane, choise] = Console.ReadLine();
                Console.Clear();
            }
        }

        public static void UpcomingFlight()
        {

        }

        public static void GiveAllInformation()
        {
            for (int i = 0; i < countOfFlight; i++)
            {
                airport[i, 0] = i;
                if (i == 0)
                {
                    PrintLine();
                }

                for (int j = 0; j < airport.GetLength(1); j++)
                {
                    int ostatok = int.Parse(lengPartOfTable[j]) - airport[i, j].ToString().Length;
                    Console.Write($"{airport[i, j]}");
                    for (int d = 0; d < ostatok; d++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("|");
                }
                Console.WriteLine("");

                if (i < 1 || i == countOfFlight - 1)
                {
                    PrintLine();
                }
            }
            Console.WriteLine("");
        }

        public static void Emergency()
        {

        }


        public static void PrintLine()
        {

            for (int i = 0; i < airport.GetLength(1); i++)
            {
                lengPartOfTable[i] = "0";
                for (int j = 0; j < countOfFlight; j++)
                {
                    if (int.Parse(lengPartOfTable[i]) < airport[j, i].ToString().Length)
                    {
                        lengPartOfTable[i] = airport[j, i].ToString().Length.ToString();
                    }
                    if (airport[j + 1, 1] == null)
                    {
                        j = airport.GetLength(0);
                    }
                }
            }
            for (int i = 0; i < airport.GetLength(1); i++)
            {
                for (int d = 0; d < int.Parse(lengPartOfTable[i]); d++)
                {
                    Console.Write("-");
                }
                Console.Write("+");
            }
            Console.WriteLine("");
        }

        public static int SearchByData()
        {
            Console.WriteLine("Select criteria to refine your search");
            int crit = DoSomesingBy();
            Console.Write($"Write {airport[0, crit]}: ");
            string choise = Console.ReadLine();
            Console.Clear();
            bool maches = false;
            int index = 0;

            for (int i = 0; i < countOfFlight; i++)
            {
                if (airport[i, crit].ToString() == choise || i == 0)
                {
                    airport[i, 0] = i;
                    if (i == 0)
                    {
                        PrintLine();
                    }

                    for (int j = 0; j < airport.GetLength(1); j++)
                    {
                        int ostatok = int.Parse(lengPartOfTable[j]) - airport[i, j].ToString().Length;
                        Console.Write($"{airport[i, j]}");
                        for (int d = 0; d < ostatok; d++)
                        {
                            Console.Write(" ");
                        }
                        Console.Write("|");
                    }
                    Console.WriteLine("");

                    if (airport[i, crit].ToString() == choise)
                    {
                        maches = true;
                    }
                    index = i;
                }

                if (i < 1 || (i == countOfFlight - 1 && maches))
                {
                    PrintLine();
                }
            }


            if (!maches)
            {
                Console.WriteLine("No matches");
                index = countOfFlight;
            }

            Console.WriteLine("");
            return index;
        }

        public static int DoSomesingBy()
        {
            int raseNum = 0;
            Console.WriteLine($"1.By rase number \n2.By arrival date \n3.By depurture date \n4.By city/port of arrival\n" +
                    $"5.By city/port of depurture \n6.By airline \n7.By terminal \n8.By flight status \n9.By gate\n");
            string choise = Console.ReadLine();
            if (int.TryParse(choise, out int choiseInt))
            {
                if (choiseInt < 10)
                {
                    raseNum = choiseInt;
                }
                else
                {
                    Console.WriteLine("Choose one of operation");
                }
            }
            else
            {
                Console.WriteLine("Write number");
            }
            return raseNum;
        }
    }
}