using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Window
{
    // базовый класс бытовой техники
    public class HomeAppliance
    {
        protected string model;
        protected string manufacturer;
        protected double price;
        protected int year;

        public HomeAppliance(string m = "Unknown", string manu = "Unknown", double p = 0.0, int y = 2000)
        {
            model = m;
            manufacturer = manu;
            price = p;
            year = y;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Model: {model}, Manufacturer: {manufacturer}, Price: {price} RUB, Year: {year}");
        }

        // Свойства
        public string Model
        {
            get { return model; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                price = value;
            }
        }

        public int Year
        {
            get { return year; }
            set
            {
                int currentYear = 2024; // Предполагаем, что 2024 - текущий год
                if (value < 1980 || value > currentYear)
                {
                    throw new ArgumentException($"Year must be between 1980 and {currentYear}.");
                }
                year = value;
            }
        }
    }

    // дочерний класс стиральная машина
    public class WashingMachine : HomeAppliance
    {
        protected double capacity;
        protected string washType;
        protected int spinSpeed;

        public WashingMachine(string m = "Unknown", string manu = "Unknown", double p = 0.0,
            int y = 2000, double cap = 7.0, string wt = "Front Load", int ss = 1200) : base(m, manu, p, y)
        {
            capacity = cap;
            washType = wt;
            spinSpeed = ss;
        }

        public void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Capacity: {capacity}, Wash Type: {washType}, Spin Speed: {spinSpeed}");


        }

        // свойства
        public double Capacity
        {
            get { return capacity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity cannot be negative.");
                }
                capacity = value;
            }
        }

        public string WashType
        {
            get { return washType; }
        }

        public int SpinSpeed
        {
            get { return spinSpeed; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Speed cannot be negative.");
                }
                spinSpeed = value;
            }
        }
    }

    // дочерний класс микроволновка
    public class Microwave : HomeAppliance
    {
        protected double power;
        protected string cookingType;
        protected int turntableSize;

        public Microwave(string m = "Unknown", string manu = "Unknown", double p = 0.0, int y = 2000,
        double pow = 700.0, string ct = "Convection", int ts = 28) : base(m, manu, p, y)
        {
            power = pow;
            cookingType = ct;
            turntableSize = ts;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Power: {power}, Cooking Type: {cookingType}, Turntable Size: {turntableSize}");
        }

        // свойства
        public double Power
        {
            get { return power; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Power cannot be negative.");
                }
                power = value;
            }
        }

        public string CookingType
        {
            get { return cookingType; }
        }

        public int TurntableSize
        {
            get { return turntableSize; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Speed cannot be negative.");
                }
                turntableSize = value;
            }
        }

    }
    public class createAndAddAppliance
    {
        public void Input_Output(List<HomeAppliance> appliances, int choice)
        {
            Console.WriteLine("Enter model:");
            string? model = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter manufacturer:");
            string? manufacturer = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter price:");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter year:");
            int year = Convert.ToInt32(Console.ReadLine());

            try
            {
                if (price < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                int currentYear = 2024; // Assuming 2024 as current year
                if (year < 1980 || year > currentYear)
                {
                    throw new ArgumentException($"Year must be between 1980 and {currentYear}.");
                }

                if (choice == 1)
                {
                    if (model is not null && manufacturer is not null)
                    {
                        var appliance = new HomeAppliance(model, manufacturer, price, year);
                        appliances.Add(appliance);
                    }
                }
                else if (choice == 2)
                {

                    Console.WriteLine("Enter capacity:");
                    double capacity = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter wash type:");
                    string? washType = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter spin speed:");
                    int spinSpeed = Convert.ToInt32(Console.ReadLine());

                    if (capacity <= 0)
                    {
                        throw new ArgumentException("Capacity must be positive");
                    }
                    if (spinSpeed <= 0)
                    {
                        throw new ArgumentException("Spin speed must be positive");
                    }
                    if (model is not null && manufacturer is not null  && washType is not null)
                    {
                        var washingMachine = new WashingMachine(model, manufacturer, price, year, capacity, washType, spinSpeed);
                        appliances.Add(washingMachine);
                    } 
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter power:");
                    double power = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter cooking type:");
                    string? cookingType = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter turntable size:");
                    int turntableSize = Convert.ToInt32(Console.ReadLine());
                    if (power <= 0)
                    {
                        throw new ArgumentException("Power must be positive.");
                    }
                    if (turntableSize <= 0)
                    {
                        throw new ArgumentException("Turntable size must be positive.");
                    }

                    if (model is not null && manufacturer is not null && cookingType is not null)
                    {
                        var microwave = new Microwave(model, manufacturer, price, year, power, cookingType, turntableSize);
                        appliances.Add(microwave);
                    }
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void printAppliances(List<HomeAppliance> appliances)
        {
            foreach (var i in appliances)
            {
                i.PrintInfo();
                Console.WriteLine("--------------------------");
            }
        }
    }
}
