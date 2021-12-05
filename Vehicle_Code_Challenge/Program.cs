using System;
using System.Collections.Generic;

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
    //object[] getNewList()
    //{
    //    return { }
    //}
    static public int Menu()
    {
        Console.WriteLine("Vehicles");
        Console.WriteLine();
        Console.WriteLine("1. Show all vehicles");
        Console.WriteLine("2. Generate new random list");
        Console.WriteLine("3. Sort by type");
        Console.WriteLine("4. Sort by Manufacter/Model");
        Console.WriteLine("5. Exit");
        var choice = Console.ReadLine();
        int x;
        bool isNumber;
        isNumber = int.TryParse(choice, out x);
        return x;
    }
    public List<IVehicle> getRandomList(List<IVehicle> list, int n)
    {
        return (List<IVehicle>)list.OrderBy(c => Globals.random.Next()).Take(5);
    }
    public static void Main()
    {
        //Make two lists of each type. Hardcoded instead of randomly generated in order to avoid extra complexity of matching Manufacturer to Model and having extra collections to handle that.
        //List<GasVehicle> gasVehicles = new List<GasVehicle>();
        //try
        //{
        //    gasVehicles.Add(new GasVehicle("White", "Ford", "F150", 2016, "Eight cylinders"));
        //    gasVehicles.Add(new GasVehicle("Red", "BMW", "3 Series", 2020, "Six cylinders"));
        //    gasVehicles.Add(new GasVehicle("Blue", "Hyundai", "Sonata", 2010, "Four cylinders"));
        //    gasVehicles.Add(new GasVehicle("Green", "Subaru", "Impreza", 2018, "Six cylinders"));
        //    gasVehicles.Add(new GasVehicle("Black", "Nissan", "GT-R", 2012, "Four cylinders"));
        //    gasVehicles.Add(new GasVehicle("Yellow", "Mazda", "CX-8", 2021, "Eight cylinders"));
        //}
        //catch (Exception e) { Console.WriteLine(e.Message); }
        //List<ElectricVehicle> electricVehicles = new List<ElectricVehicle>();
        //try {
        //    electricVehicles.Add(new ElectricVehicle("Red", "Tesla", "Model S", 2019, "Dual"));
        //    electricVehicles.Add(new ElectricVehicle("Green", "BMW", "I3", 2020, "Single"));
        //    electricVehicles.Add(new ElectricVehicle("Blue", "Nissan", "Leaf", 2016, "Single"));
        //    electricVehicles.Add(new ElectricVehicle("Black", "Kia", "Soul EV", 2014, "Dual"));
        //    electricVehicles.Add(new ElectricVehicle("White", "Chevrolet", "Spark EV", 2021, "Single"));
        //    electricVehicles.Add(new ElectricVehicle("Yellow", "Honda", "Fit EV", 2017, "Dual"));
        //}
        //catch (Exception e) { Console.WriteLine(e.Message); }

        List<IVehicle> allCars = new List<IVehicle>();
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

        Console.WriteLine(allCars[0]);
        Console.WriteLine(allCars[1]);
        Console.WriteLine("Test");

        Random random = new Random();
        int userInput = 0;
        do
        {
            Console.WriteLine("| {0,-10} | {1,-12} | {2,-10} | {3,-10} | {4,-10} | {5,-14} | {6,-10} |", "Type", "Manufacturer", "Model", "Color", "Year Built", "Motor Type", "Age");
            Console.WriteLine(allCars[random.Next(allCars.Count)]);
            Console.WriteLine(allCars[random.Next(allCars.Count)]);
            userInput = Menu();

            switch(userInput)
            {
                case 1:
                    Console.WriteLine("| {0,-10} | {1,-12} | {2,-10} | {3,-10} | {4,-10} | {5,-14} | {6,-10} |", "Type", "Manufacturer", "Model", "Color", "Year Built", "Motor Type", "Age");
                    foreach (IVehicle vehicle in allCars)
                    {
                        Console.WriteLine(vehicle);
                    }
                    break;
                case 2:
                    Console.WriteLine("blak");
                    break;
                case 3:
                    Console.WriteLine("blak");
                    break;
                case 4:
                    Console.WriteLine("blak");
                    break;
                default:
                    break;
            }

            
            //Console.WriteLine(gasVehicles[random.Next(gasVehicles.Count)]);
            //Console.WriteLine(electricVehicles[random.Next(electricVehicles.Count)]);
        } while (userInput != 5);
    }
}
