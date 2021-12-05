using System;

namespace Vehicle_Code_Challenge
{
    public interface IVehicle
    {
        string Color { get; set; }
        string Manufacturer { get; set; }
        string Model { get; set; }
        int YearBuilt { get; set; }
        int Calculate { get; }
    }
}
