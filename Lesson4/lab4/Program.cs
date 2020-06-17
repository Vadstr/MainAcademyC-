using lab4.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Program
    {
        public static bool upgrade = false;
        static void Main(string[] args)
        {
            Computer[][] departments = new Computer[4][];
            departments[0] = new Computer[5]
            {
                new Computer(ComputerType.Desktop),
                new Computer(ComputerType.Desktop),
                new Computer(ComputerType.Laptop),
                new Computer(ComputerType.Laptop),
                new Computer(ComputerType.Server)
            };

            departments[1] = new Computer[3]
            {
                new Computer(ComputerType.Laptop),
                new Computer(ComputerType.Laptop),
                new Computer(ComputerType.Laptop)
            };

            departments[2] = new Computer[5]
            {
                new Computer(ComputerType.Desktop),
                new Computer(ComputerType.Desktop),
                new Computer(ComputerType.Desktop),
                new Computer(ComputerType.Laptop),
                new Computer(ComputerType.Laptop)
            };

            departments[3] = new Computer[4]
            {
                new Computer(ComputerType.Desktop),
                new Computer(ComputerType.Laptop),
                new Computer(ComputerType.Server),
                new Computer(ComputerType.Server)
            };

            int desktopCount = 0;
            int laptopCount = 0;
            int serverCount = 0;
            int largHDD = 0;
            double lowestCPUPower = 0;
            var typeComputerWithLargeHDD = ComputerType.Desktop;
            int qualityOfLargHDD = 0;
            int qualityLargeCPUPower = 0;
            var typeComputerWithBestCPU = ComputerType.Desktop;
            double CPUCores = 0;
            double CPUGHZ = 0;

            
            for (int i = 0; i < departments.Length; i++)
            {
                Console.WriteLine($"Department {i}:");
                for (int j = 0; j < departments[i].Length; j++)
                {
                    if (departments[i][j].ComputerType == ComputerType.Desktop && upgrade)
                    {
                        departments[i][j].RAM += 8;
                    }
                    Console.Write($"{departments[i][j].ComputerType}:RAM {departments[i][j].RAM}GGB ");
                }
                Console.WriteLine("\n");
            }

            foreach (Computer[] computers in departments)
            {
                
                foreach(Computer computer in computers)
                {

                    if (computer.HDD > largHDD)
                    {
                        typeComputerWithLargeHDD = computer.ComputerType;
                        largHDD = computer.HDD;
                        qualityOfLargHDD = 1;
                    }
                    else if (computer.HDD == largHDD)
                    {
                        qualityOfLargHDD++;
                    }

                    if (lowestCPUPower == 0)
                    {
                        lowestCPUPower = computer.CPUCores * computer.CPUFrequency;
                    }

                    if (computer.CPUCores * computer.CPUFrequency == lowestCPUPower)
                    {
                        qualityLargeCPUPower++;
                    }
                    else if(computer.CPUCores * computer.CPUFrequency < lowestCPUPower)
                    {
                        CPUCores = computer.CPUCores;
                        CPUGHZ = computer.CPUFrequency;
                        typeComputerWithBestCPU = computer.ComputerType;
                        lowestCPUPower = computer.CPUCores * computer.CPUFrequency;
                        qualityLargeCPUPower = 1;
                    }

                    switch (computer.ComputerType)
                    {
                        case ComputerType.Desktop:
                            desktopCount++;
                            break;
                        case ComputerType.Laptop:
                            laptopCount++;
                            break;
                        case ComputerType.Server:
                            serverCount++;
                            break;
                        default:
                            throw new NotImplementedException();                          
                    }
                }
            }

            Console.WriteLine($"Desktops: {desktopCount}");
            Console.WriteLine($"Laptops: {laptopCount}");
            Console.WriteLine($"Server: {serverCount}");
            Console.WriteLine($"Total count: {desktopCount + laptopCount + serverCount}");
            Console.WriteLine($"Qyality computer whith large HDD: {qualityOfLargHDD}. And it`s {typeComputerWithLargeHDD} with {largHDD}GGB storage");
            Console.WriteLine($"Qyality computer whith lowest CPU power: {qualityLargeCPUPower}. And it`s {typeComputerWithBestCPU} with {CPUCores} cores and {CPUGHZ}GHZ\n");
            if (!upgrade)
            {
                upgrade = true;
                string[] bla = new string[1];
                Console.WriteLine("UPGRADE\n");
                Main(bla);
            }
        }
    }
}