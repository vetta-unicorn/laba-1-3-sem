using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Window
{
   
    public class program
    {
        static void Main(string[] args)
        {
            List<HomeAppliance> appliances = new List<HomeAppliance>();
            bool Flag = false;
            createAndAddAppliance create = new createAndAddAppliance();

            while (!Flag)
            {
                Console.WriteLine("1. Add appliance\n");
                Console.WriteLine("2. Print all appliances\n");
                Console.WriteLine("3. Exit\n");
                Console.WriteLine("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter what appliance do you need:\n 1. Home Appliance\n 2. Washing Machine\n 3. Microwave\n");
                            int choice_app = Convert.ToInt32(Console.ReadLine());
                            create.Input_Output(appliances, choice_app);
                            break;
                        }
                    case 2:
                        {
                            create.printAppliances(appliances);
                            break;
                        }
                    case 3:
                        {
                            Flag = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверный выбор.");
                            break;
                        }

                }
            }
        }
    }
}

