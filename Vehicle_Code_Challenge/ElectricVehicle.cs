using System;

namespace Vehicle_Code_Challenge
{
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
            if (yearBuilt > Globals.currentYear)
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
            return String.Format("| {0,-10} | {1,-12} | {2,-10} | {3,-10} | {4,-10} | {5,-15} | {6,-11} |", "Electric", _manufacturer, _model, _color, _yearBuilt, _motorType, Calculate);
        }
    }
}
