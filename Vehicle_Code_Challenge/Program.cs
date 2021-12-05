using System;

public static class Globals
{
    //Sets the current year to an int that can be used throughout the program for age checks.
    public static int currentYear = System.DateTime.Now.Year;
    //Sets one instance of random to be used for generating lists
    public static Random random = new Random();
}
public interface IVehicle
{
    string Color { get; set; }
    string Manufacturer { get; set; }
    string Model { get; set; }
    int YearBuilt { get; set; }
    int Calculate { get; }
}

public class GasVehicle : IVehicle
{
    private string _color;
    private string _manufacturer;
    private string _model;
    private int _yearBuilt;
    public string[] EngineSizes = new string[] { "Four cylinders", "Six cylinders", "Eight cylinders" };
    private string _engineSize;

    public GasVehicle ( string color, string manufacturer, string model, int yearBuilt, string engineSize )
    {
        //ensures the year is not a future year and that motor type is in the list of acceptable values
        if (yearBuilt > Globals.currentYear)
            throw new ArgumentException("Cannot be a future year");
        if (!EngineSizes.Any(x => x == engineSize))
            throw new ArgumentException("Not a valid motor type");
        _color = color;
        _manufacturer = manufacturer;
        _model = model;
        _yearBuilt = yearBuilt;
        _engineSize = engineSize;
    }
    public string Color { get => _color; set => _color = value; }
    public string Manufacturer { get => _manufacturer; set => _manufacturer = value; }
    public string Model { get => _model; set => _model = value; }
    public int YearBuilt
    {
        get => _yearBuilt;
        set
        {
            if (value > Globals.currentYear)
                throw new ArgumentException("Cannot be a future year");
            _yearBuilt = value;
        }
    }  
    public string EngineSize
    {
        get
        {
            return _engineSize;
        }
        set
        {
            //checks that the engine size being set is in the list of acceptable values
            if (!EngineSizes.Any(x => x == value))
                throw new ArgumentException("Not a valid engine size");
            _engineSize = value;
        }
    }
    public int Calculate
    {
        get
        {
            return Globals.currentYear - _yearBuilt;
        }
    }
    public override string ToString()
    {
        return String.Format("| {0,-10} | {1,-12} | {2,-10} | {3,-10} | {4,-10} | {5,-15} | {6,-10} |", "Gas", _manufacturer, _model, _color, _yearBuilt, _engineSize, Calculate);
    }
}

public class ElectricVehicle : IVehicle
{
    private string _color;
    private string _manufacturer;
    private string _model;
    private int _yearBuilt;
    public string[] MotorTypes = new string[] { "Single", "Dual" };
    private string _motorType;

    public ElectricVehicle(string color, string manufacturer, string model, int yearBuilt, string motorType)
    {
        //ensures the year is not a future year and that engine size is in the list of acceptable values
        if (yearBuilt > 2021)
            throw new ArgumentException("Cannot be a future year");
        if (!MotorTypes.Any(x => x == motorType))
            throw new ArgumentException("Not a valid motor type");
        _color = color;
        _manufacturer = manufacturer;
        _model = model;
        _yearBuilt = yearBuilt;
        _motorType = motorType;
    }
    public string Color { get => _color; set => _color = value; }
    public string Manufacturer { get => _manufacturer; set => _manufacturer = value; }
    public string Model { get => _model; set => _model = value; }
    public int YearBuilt
    {
        get => _yearBuilt;
        set
        {
            if (value > Globals.currentYear)
                throw new ArgumentException("Cannot be a future year");
            _yearBuilt = value;
        }
    }
    public string EngineSize
    {
        get
        {
            return _motorType;
        }
        set
        {
            //checks that the motor type being set is in the list of acceptable values
            if (!MotorTypes.Any(x => x == value))
                throw new ArgumentException("Not a valid motor type");
            _motorType = value;
        }
    }
    public int Calculate
    {
        get
        {
            return Globals.currentYear - _yearBuilt;
        }
    }
    public override string ToString()
    {
        return String.Format("| {0,-10} | {1,-12} | {2,-10} | {3,-10} | {4,-10} | {5,-15} | {6,-10} |", "Electric", _manufacturer, _model, _color, _yearBuilt, _motorType, Calculate);
    }
}

class Application
{
    public static int Menu()
    {
        Console.WriteLine("\nVehicle manager");
        Console.WriteLine("1. Show all vehicles");
        Console.WriteLine("2. Generate new random list");
        Console.WriteLine("3. Sort by type");
        Console.WriteLine("4. Sort by Manufacter/Model");
        Console.WriteLine("5. Exit");
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

        string header = String.Format("| {0,-10} | {1,-12} | {2,-10} | {3,-10} | {4,-10} | {5,-15} | {6,-10} |", "Type", "Manufacturer", "Model", "Color", "Year Built", "Motor Type", "Age");

        int userInput = 0;
        do
        {
            userInput = Menu();

            switch(userInput)
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
                    do {
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
                    //sorts by comparing the string value of the type names then writes the list
                    currentSelection.Sort((x, y) => string.Compare(x.GetType().Name, y.GetType().Name));
                    Console.WriteLine(header);
                    foreach (IVehicle vehicle in currentSelection)
                    {
                        Console.WriteLine(vehicle);
                    }
                    break;
                case 4:
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
        } while (userInput != 5);
    }
}
