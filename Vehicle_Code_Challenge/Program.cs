using System;
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
        if (yearBuilt > 2021)
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
            if (value > 2021)
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
            return 2020 - _yearBuilt;
        }
    }
    public override string ToString()
    {
        return String.Format("| {0,-10} | {1,-12} | {2,-10} | {3,-10} | {4,-10} | {5,-14} | {6,-10} |", "Gas", _manufacturer, _model, _color, _yearBuilt, _engineSize, Calculate);
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
            if (value > 2021)
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
            return 2020 - _yearBuilt;
        }
    }
    public override string ToString()
    {
        return String.Format("| {0,-10} | {1,-12} | {2,-10} | {3,-10} | {4,-10} | {5,-14} | {6,-10} |", "Electric", _manufacturer, _model, _color, _yearBuilt, _motorType, Calculate);
    }
}

class Application
{
    public static void Main()
    {
        Console.WriteLine("| {0,-10} | {1,-12} | {2,-10} | {3,-10} | {4,-10} | {5,-14} | {6,-10} |", "Type", "Manufacturer", "Model", "Color", "Year Built", "Motor Type", "Age");
        //Console.WriteLine("Hello");
        try
        {
            GasVehicle car1 = new GasVehicle("Red", "Ford", "F150", 2019, "Four cylinders");
            Console.WriteLine(car1.ToString());
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        try
        {
            ElectricVehicle car2 = new ElectricVehicle("White", "Tesla", "Model S", 2018, "Single");
            Console.WriteLine(car2.ToString());
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
}
