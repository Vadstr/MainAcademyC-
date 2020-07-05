using System;

namespace Airport1
{
    class MainClass
    {
        private static bool firstLoop = true;
        private static bool stayAtProgram = true;
        private static object[,] airport = new object[5, 10]; 
        private static string[] lengPartOfTable = new string[10];
        private static string[] flightStatus;
        private static int countOfFlight = 0;
        private static DateTime arrivalDate;
        private static DateTime depurtureDate;
        private static int raseNum;
        private static bool[] emergencyStatus = new bool[3];
        private static string[] emergency;

        public static void Main(string[] args)
        {
            emergency = new string[3] { "Fire! Evacuation", "Bomb! Evacuation", "Gas! Evacuation" };

            DateTime arrival1 = DateTime.Now.Subtract(new TimeSpan(2, 0, 0));
            DateTime depurture1 = arrival1.AddHours(2);

            DateTime arrival2 = DateTime.Now.AddHours(1);
            DateTime depurture2 = arrival2.AddHours(3);

            DateTime arrival3 = DateTime.Now.AddMinutes(15);
            DateTime depurture3 = arrival3.AddHours(3.5);

            flightStatus = new string[9] { "Gate closed", "Expected", "Chec-in", "Departed", "In flight", "Arrived", "Delayed", "Unnown", "Canceled" };
            object[] nameOfPart = {"Flight number", "Depurture date and time", "Arrival date and time","City/port of depurture",
                "City/port of arrival","Airline","Terminal","Status","Gate"};
            object[] plane1 = { "0982", arrival1, depurture1, "Kyiv", "Lviv", "MAU", "C", "", 2 };
            object[] plane2 = { "3029", arrival2, depurture2, "Lviv", "London", "MAU", "A", "", 4 };
            object[] plane3 = { "3029", arrival3, depurture3, "London", "Moscow", "MAU", "E", "", 3 };

            AddFlight(nameOfPart);
            AddFlight(plane2);
            AddFlight(plane1);
            AddFlight(plane3);

            while (stayAtProgram)
            {
                for (int i = 0; i < emergencyStatus.Length; i++)
                {
                    if (emergencyStatus[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{emergency[i]}\n");
                        Console.ResetColor();
                    }
                }

                if (firstLoop)
                {
                    Console.WriteLine("This is menu, were you can choise what you want to do");
                }
                else
                {
                    Console.WriteLine("Choise somesing");
                }
                Console.WriteLine($"1.Add new flight\n2.Remove flight\n3.Editing information\n4.Search by data\n" +
                    $"5.Upcoming flights\n6.Give all information about flight\n7.Emergency\n8.Get automatic status\n9.Exit\n");

                var choise = Console.ReadLine();
                firstLoop = false;
                Console.Clear();

                switch (choise)
                {
                    case "1":
                        AddFlight();
                        break;
                    case "2":
                        RemoveFlight();
                        break;
                    case "3":
                        EditingInformation();
                        break;
                    case "4":
                        SearchByData();
                        break;
                    case "5":
                        UpcomingFlight();
                        break;
                    case "6":
                        GiveAllInformation();
                        break;
                    case "7":
                        Emergency();
                        break;
                    case "8":
                        FlightStatus();
                        break;
                    case "9":
                        stayAtProgram = false;
                        break;
                    default:
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
            try
            {
                Console.Write("Input flight information \nInput rase number:");
                raseNum = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Rase number must be number");
                Console.ResetColor();
                AddFlight();
                return;
            }

            try
            {
                Console.Write("Input depurture date (DD.MM.YYYY HH:MM:mm):");
                depurtureDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Input arrival date (DD.MM.YYYY HH:MM:mm):");
                arrivalDate = DateTime.Parse(Console.ReadLine());

                if (depurtureDate >= arrivalDate)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Departure cannot be later than arrival");
                    Console.ResetColor();
                    AddFlight();
                    return;
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Write in correct format");
                Console.ResetColor();
                AddFlight();
                return;
            }

            Console.Write("City/port of depurture:");
            string depurturePlace = Console.ReadLine();

            Console.Write("City/port of arrival:");
            string arrivalPlace = Console.ReadLine();

            Console.Write("Airlines:");
            string airlines = Console.ReadLine();

            Console.Write("Terminal:");
            string terminal = Console.ReadLine();

            Console.Write("Gate:");
            string gate = Console.ReadLine();

            airport[countOfFlight, 0] = countOfFlight+1;
            airport[countOfFlight, 1] = raseNum;
            airport[countOfFlight, 2] = depurtureDate;
            airport[countOfFlight, 3] = arrivalDate;
            airport[countOfFlight, 4] = depurturePlace;
            airport[countOfFlight, 5] = arrivalPlace;
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
            int raseNum = countOfFlight;

            for (int i = 0; i < countOfFlight; i++)
            {
                if (flyNumber == airport[i,1].ToString())
                {
                    raseNum = i;
                }
            }
            if (raseNum != countOfFlight)
            {
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
                countOfFlight--;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input\n");
                Console.ResetColor();
            }
        }

        public static void EditingInformation()
        {
            int[] planeArr = SearchByData();
            int planeArrLen = 0;
            int plane = 0;

            for (int i = 0; i < planeArr.Length; i++)
            {
                if (planeArr[i] != 0)
                {
                    planeArrLen++;
                    plane = planeArr[i];
                }
            }

            if (planeArrLen > 1)
            {
                Console.Write("\nChoose one of this flight:");
                string choise = Console.ReadLine();
                for (int i = 1; i < planeArr.Length; i++)
                {
                    if (choise == planeArr[i].ToString() && planeArr[i] != 0)
                    {
                        plane = planeArr[i];
                    }
                }
            }

            if (plane != countOfFlight && planeArrLen != 0) {
                for (int i = 0; i < airport.GetLength(1) - 1; i++)
                {
                    Console.WriteLine($"{i + 1}.{airport[0, i + 1]}");
                }

                Console.Write("Input what you whant to change: ");
                int choise = int.Parse(Console.ReadLine());

                Console.Write($"Input new {airport[0, choise]}: ");
                if (choise == 2)
                {
                    DateTime newDateTime = DateTime.Parse(Console.ReadLine());
                    TimeSpan diferent1 = newDateTime.Subtract((DateTime)airport[plane, choise]);

                    airport[plane, choise] = newDateTime;
                    airport[plane, choise + 1] = ((DateTime)airport[plane, choise + 1]).Add(diferent1);
                }
                else if (choise == 3)
                {

                }
                else if (choise == 8)
                {
                    Console.WriteLine("Choose one of status:");
                    for (int i = 0; i < flightStatus.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}.{flightStatus[i]}");
                    }

                    string choiseStatus = Console.ReadLine();
                    switch (choiseStatus)
                    {
                        case "1":
                            airport[plane, choise] = flightStatus[0];
                            break;
                        case "2":
                            airport[plane, choise] = flightStatus[1];
                            break;
                        case "3":
                            airport[plane, choise] = flightStatus[2];
                            break;
                        case "4":
                            airport[plane, choise] = flightStatus[3];
                            break;
                        case "5":
                            airport[plane, choise] = flightStatus[4];
                            break;
                        case "6":
                            airport[plane, choise] = flightStatus[5];
                            break;
                        case "7":
                            airport[plane, choise] = flightStatus[6];
                            break;
                        case "8":
                            airport[plane, choise] = flightStatus[7];
                            break;
                        case "9":
                            airport[plane, choise] = flightStatus[8];
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Pelase, choose one of status\n");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    airport[plane, choise] = Console.ReadLine();
                }

                Console.Clear();
            }
        }

        public static int[] SearchByData()
        {
            Console.WriteLine("Select criteria to refine your search");
            int crit = DoSomesingBy();
            Console.Write($"Write {airport[0, crit]}: ");
            string choise = Console.ReadLine();
            Console.Clear();
            bool maches = false;
            int carrentindex = 0;
            int[] index = new int[countOfFlight];

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
                    index[carrentindex] = i;
                    carrentindex++;
                }

                if (i < 1 || (i == countOfFlight - 1 && maches))
                {
                    PrintLine();
                }
            }


            if (!maches)
            {
                Console.WriteLine("No matches");
            }

            Console.WriteLine("");
            return index;
        }

        public static void UpcomingFlight()
        {
            int sortingCount = countOfFlight;
            DateTime lowDiferent = (DateTime)airport[1,2];
            DateTime now = DateTime.Now;

            for (int i = 1; i < sortingCount; i++)
            {
                for (int j = i; j < sortingCount; j++)
                {
                    if ((DateTime)airport[j, 2] < (DateTime)airport[i, 2])
                    {
                        SwapPlane(i, j);
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Information sort by depurture time:");
            Console.ResetColor();
            GiveAllInformation();
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
            for (int i = 0; i < emergency.Length; i++)
            {
                Console.WriteLine($"{i+1}.{emergency[i]}\n");
            }
            Console.Write("Сhoose what you need: ");
            try
            {
                int choise = int.Parse(Console.ReadLine());
                emergencyStatus[choise - 1] = !emergencyStatus[choise - 1];
                Console.WriteLine();
                Console.Clear();
            }
            catch
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pelase, choose one of operation\n");
                Console.ResetColor();
                Emergency();
            }
        }

        public static void FlightStatus()
        {
            DateTime now = DateTime.Now;

            for (int i = 1; i < countOfFlight; i++)
            {
                if (now.AddHours(3) <= (DateTime)airport[i, 2])
                {
                    airport[i, 8] = flightStatus[0];
                }
                else if (now.AddMinutes(90) <= (DateTime)airport[i, 2])
                {
                    airport[i, 8] = flightStatus[1];
                }
                else if (now.AddMinutes(15) <= (DateTime)airport[i, 2])
                {
                    airport[i, 8] = flightStatus[2];
                }
                else if (now.Subtract(new TimeSpan(0, 15, 0)) <= (DateTime)airport[i, 2])
                {
                    airport[i, 8] = flightStatus[3];
                }
                else if (now <= (DateTime)airport[i, 3])
                {
                    airport[i, 8] = flightStatus[4];
                }
                else if (now >= (DateTime)airport[i, 3])
                {
                    airport[i, 8] = flightStatus[5];
                }
            }
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

        public static int DoSomesingBy()
        {
            int raseNum = 0;
            Console.WriteLine($"1.By rase number \n2.By arrival date (DD.MM.YYYY HH:MM:mm)\n3.By depurture date (DD.MM.YYYY HH:MM:mm)\n4.By city/port of arrival\n" +
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
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choose one of operation");
                    Console.ResetColor();
                    return DoSomesingBy();
                }
            }
            else
            {
                Console.WriteLine("Write number");
            }
            return raseNum;
        }

        public static void SwapPlane(int i, int j)
        {
            object swapObject;
            for (int z = 0; z < airport.GetLength(1); z++)
            {
                swapObject = airport[j, z];
                airport[j, z] = airport[i, z];
                airport[i, z] = swapObject;
            }
        }
    }
}