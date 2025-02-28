using Window;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Reflection;

namespace TestProject1
{
    [TestClass]
    public class laba1_test
    {
        private HomeAppliance home_appliance;
        private WashingMachine washing_machine;
        private Microwave microwave;
        private createAndAddAppliance _createAndAddAppliance;
        private List<HomeAppliance> appliances;

        [TestInitialize]
        public void home_app_setup()
        {
            home_appliance = new HomeAppliance();
            washing_machine = new WashingMachine();
            microwave = new Microwave();
            _createAndAddAppliance = new createAndAddAppliance();
            appliances = new List<HomeAppliance>();
        }

        [TestMethod]
        public void home_app_init1()
        {
            string model = "compact";
            string manufacturer = "bosch";
            double price = 10000.0;
            int year = 1990;

            home_appliance = new HomeAppliance(model, manufacturer, price, year);
            
            Assert.AreEqual(home_appliance.Manufacturer, manufacturer);
            Assert.AreEqual(home_appliance.Model, model);
            Assert.AreEqual(home_appliance.Price, price);
            Assert.AreEqual(home_appliance.Year, year);
        }

        [TestMethod]
        public void home_app_init2()
        {
            string model = "compact";
            string manufacturer = "bosch";
            double price = -2;
            int year = 500;

            home_appliance = new HomeAppliance(model, manufacturer, price, year);

            Assert.AreEqual(home_appliance.Manufacturer, manufacturer);
            Assert.AreEqual(home_appliance.Model, model);
            Assert.AreEqual(home_appliance.Price, price);
            Assert.AreEqual(home_appliance.Year, year);
        }

        [TestMethod]
        public void washingm_init1()
        {
            string model = "compact";
            string manufacturer = "bosch";
            double price = 10000.0;
            int year = 1990;
            double capacity = 23.0;
            string washType = "fast";
            int spinSpeed = 11;

            washing_machine = new WashingMachine(model, manufacturer, price, year, capacity, washType, spinSpeed);

            Assert.AreEqual(washing_machine.Capacity, capacity);
            Assert.AreEqual(washing_machine.WashType, washType);
            Assert.AreEqual(washing_machine.SpinSpeed, spinSpeed);
        }

        [TestMethod]
        public void washingm_init2()
        {
            string model = "compact";
            string manufacturer = "bosch";
            double price = -333;
            int year = -2;
            double capacity = 23.0;
            string washType = "fast";
            int spinSpeed = 11;

            washing_machine = new WashingMachine(model, manufacturer, price, year, capacity, washType, spinSpeed);

            Assert.AreEqual(washing_machine.Capacity, capacity);
            Assert.AreEqual(washing_machine.WashType, washType);
            Assert.AreEqual(washing_machine.SpinSpeed, spinSpeed);
        }

        [TestMethod]
        public void micro_init1() 
        {
            string model = "compact";
            string manufacturer = "bosch";
            double price = 10000.0;
            int year = 1990;
            double power = 100.0;
            string cookingType = "Refreshing";
            int turntableSize = 15;

            microwave = new Microwave(model, manufacturer, price, year, power, cookingType, turntableSize);


            Assert.AreEqual(microwave.Power, power);
            Assert.AreEqual(microwave.CookingType, cookingType);
            Assert.AreEqual(microwave.TurntableSize, turntableSize);
        }

        [TestMethod]
        public void micro_init2()
        {
            string model = "compact";
            string manufacturer = "bosch";
            double price = -10000.0;
            int year = 990;
            double power = -100.0;
            string cookingType = "Refreshing";
            int turntableSize = -15;

            microwave = new Microwave(model, manufacturer, price, year, power, cookingType, turntableSize);


            Assert.AreEqual(microwave.Power, power);
            Assert.AreEqual(microwave.CookingType, cookingType);
            Assert.AreEqual(microwave.TurntableSize, turntableSize);
        }

        [TestMethod]
        public void Input_Output_Test1()
        {
            // Подменяем ввод
            var input = "Model\nManufacturer\n100\n2022\n45\nwashType\n30"; // Введите данные, разделенные символом новой строки
            var reader = new StringReader(input);
            Console.SetIn(reader);

            int choice = 2; // выбор для стиральной машины
            _createAndAddAppliance.Input_Output(appliances, choice);

            Assert.IsNotNull(appliances);
            Assert.AreEqual(1, appliances.Count); // Убедитесь, что элемент действительно добавлен
        }

        [TestMethod]
        public void Input_Output_Test2()
        {
            // Подменяем ввод
            var input = "aa\nmm\n110\n2000\n45\nwww99\n30999"; // Введите данные, разделенные символом новой строки
            var reader = new StringReader(input);
            Console.SetIn(reader);

            int choice = 3; //выбор микроволновки
            _createAndAddAppliance.Input_Output(appliances, choice);

            Assert.IsNotNull(appliances);
            Assert.AreEqual(1, appliances.Count); // Убедитесь, что элемент действительно добавлен
        }

    }
}