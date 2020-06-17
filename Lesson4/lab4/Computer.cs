using lab4.Enums;

namespace lab4
{
    struct Computer
    {
        public int CPUCores;
        public double CPUFrequency;
        public int RAM;
        public int HDD;
        public ComputerType ComputerType;

        public Computer(ComputerType computerType)
        {
            ComputerType = computerType;
            switch(computerType)
            {
                case ComputerType.Desktop:
                    CPUCores = 4;
                    CPUFrequency = 2.5;
                    RAM = 6;
                    HDD = 500;
                    break;
                case ComputerType.Laptop:
                    CPUCores = 2;
                    CPUFrequency = 1.7;
                    RAM = 4;
                    HDD = 250;
                    break;
                case ComputerType.Server:
                    CPUCores = 8;
                    CPUFrequency = 3;
                    RAM = 16;
                    HDD = 2000;
                    break;
                default:
                    CPUCores = 0;
                    CPUFrequency = 0;
                    RAM = 0;
                    HDD = 0;
                    break;
            }
        }
    }
}
