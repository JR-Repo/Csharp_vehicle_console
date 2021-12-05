using System;

namespace Vehicle_Code_Challenge
{
    public class GasVehicle : IVehicle
    {
        private string _color;
        private string _manufacturer;
        private string _model;
        private int _yearBuilt;
        public string[] EngineSizes = new string[] { "Four cylinders", "Six cylinders", "Eight cylinders" };
        private string _engineSize;

        public GasVehicle(string color, string manufacturer, string model, int yearBuilt, string engineSize)
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
            return String.Format("| {0,-10} | {1,-12} | {2,-10} | {3,-10} | {4,-10} | {5,-15} | {6,-11} |", "Gas", _manufacturer, _model, _color, _yearBuilt, _engineSize, Calculate);
        }
    }
}
