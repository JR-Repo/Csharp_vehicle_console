using System;

namespace Vehicle_Code_Challenge
{
    class Application
    {
        public static int Menu()
        {
            Console.WriteLine("\nVehicle manager");
            Console.WriteLine("1. Show all vehicles");
            Console.WriteLine("2. Generate new random list");
            Console.WriteLine("3. Loop through list");
            Console.WriteLine("4. Sort by type");
            Console.WriteLine("5. Sort by Manufacter/Model");
            Console.WriteLine("6. Exit");
            var choice = Console.ReadLine();
            int x;
            if (int.TryParse(choice, out x)) return x;
            return 0;
        }
        public static List<IVehicle> getRandomList(List<IVehicle> list, int n)
        {
            return (List<IVehicle>)list.OrderBy(c => Globals.random.Next()).Take(n).ToList();
        }
        public static void Main()
        {
            List<IVehicle> allCars = new List<IVehicle>();      //Holds all vehicles
            List<IVehicle> currentSelection = new List<IVehicle>();     //Holds the current random selection of vehicles for sorting

            allCars.Add(new GasVehicle("White", "Ford", "F150", 2016, "Eight cylinders"));
            allCars.Add(new GasVehicle("Red", "BMW", "3 Series", 2020, "Six cylinders"));
            allCars.Add(new GasVehicle("Blue", "Hyundai", "Sonata", 2010, "Four cylinders"));
            allCars.Add(new GasVehicle("Green", "Subaru", "Impreza", 2018, "Six cylinders"));
            allCars.Add(new GasVehicle("Black", "Nissan", "GT-R", 2012, "Four cylinders"));
            allCars.Add(new GasVehicle("Yellow", "Mazda", "CX-8", 2021, "Eight cylinders"));

            allCars.Add(new ElectricVehicle("Red", "Tesla", "Model S", 2019, "Dual"));
            allCars.Add(new ElectricVehicle("Green", "BMW", "I3", 2020, "Single"));
            allCars.Add(new ElectricVehicle("Blue", "Nissan", "Leaf", 2016, "Single"));
            allCars.Add(new ElectricVehicle("Black", "Kia", "Soul EV", 2014, "Dual"));
            allCars.Add(new ElectricVehicle("White", "Chevrolet", "Spark EV", 2021, "Single"));
            allCars.Add(new ElectricVehicle("Yellow", "Honda", "Fit EV", 2017, "Dual"));

            string header = String.Format("| {0,-10} | {1,-12} | {2,-10} | {3,-10} | {4,-10} | {5,-15} | {6,-11} |", "Type", "Manufacturer", "Model", "Color", "Year Built", "Motor Type", "Age (Years)");

            int userInput = 0;
            do
            {
                userInput = Menu();

                switch (userInput)
                {
                    case 1:
                        //print all the cars in the base list
                        Console.WriteLine(header);
                        foreach (IVehicle vehicle in allCars)
                        {
                            Console.WriteLine(vehicle);
                        }
                        break;
                    case 2:
                        int n = 0;
                        currentSelection.Clear();   //Empty current selection
                        do
                        {
                            //user chooses the number of random cars to be put into the current selection list (3+ according to requirements)
                            Console.WriteLine(String.Format("How many? (Between 3 and {0}", allCars.Count));
                            var numOfCars = Console.ReadLine();
                            int.TryParse(numOfCars, out n);
                        } while (n < 3 || n > allCars.Count);
                        currentSelection = getRandomList(allCars, n);

                        Console.WriteLine(header);
                        foreach (IVehicle vehicle in currentSelection)
                        {
                            Console.WriteLine(vehicle);
                        }
                        break;
                    case 3:
                        var x = "";
                        foreach (IVehicle vehicle in currentSelection)
                        {
                            //Loops through each vehicle and displays it alone
                            Console.WriteLine(header);
                            Console.WriteLine(vehicle);
                            Console.WriteLine("Next? (x to stop)\n");
                            x = Console.ReadLine();
                            if (x == "x") break;
                        }
                        break;
                    case 4:
                        //sorts by comparing the string value of the type names then writes the list
                        currentSelection.Sort((x, y) => string.Compare(x.GetType().Name, y.GetType().Name));
                        Console.WriteLine(header);
                        foreach (IVehicle vehicle in currentSelection)
                        {
                            Console.WriteLine(vehicle);
                        }
                        break;
                    case 5:
                        //sorts by manufacturer then by model
                        currentSelection = (List<IVehicle>)currentSelection.OrderBy(a => a.Manufacturer).ThenBy(a => a.Model).ToList();
                        Console.WriteLine(header);
                        foreach (IVehicle vehicle in currentSelection)
                        {
                            Console.WriteLine(vehicle);
                        }
                        break;
                    default:
                        break;
                }
            } while (userInput != 6);
        }
    }
}