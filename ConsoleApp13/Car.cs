
namespace ConsoleApp13
{
    public class Car
    {
        private static int s_allCarsCount;
        private string _mark;
        private string _model;
        private int _year;
        private double _coefficent;
        private CarType _type;

        public int Id { get; set; }
        public CarType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                Coefficent = GetCoefficent();
            }
        }

        public string Mark
        {
            get { return _mark; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Mark cant be empty");
                }
                _mark = value;
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Model cant be empty");
                }
                _model = value;
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                if (value < 1884)
                {
                    throw new Exception("Year cant be less 1884");
                }
                _year = value;
            }
        }

        public double Coefficent
        {
            get { return _coefficent; }
            set
            {
                if (value < 1.0)
                {
                    throw new Exception("Coefficent cant be less 1.0");
                }
                _coefficent = value;
            }
        }

        public Car(string mark, string model, int year, CarType carTypee)
        {
            Id = ++s_allCarsCount;
            Mark = mark;
            Model = model;
            Year = year;
            Type = carTypee;
        }

        private double GetCoefficent()
        {
            if (Type == CarType.Sedan)
            {
                return 1.1;
            }
            else if (Type == CarType.Jeep)
            {
                return 1.2;
            }
            else if (Type == CarType.Moto)
            {
                return 1.3;
            }
            else
            {
                return 1.4;
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Id: {Id} | Mark: {Mark} | Model: {Model} | Year: {Year} | Coefficent: {Coefficent} | Car Type: {Type.ToString()}");
        }
    }

    public enum CarType
    {
        Sedan,
        Jeep,
        Moto,
        Truck
    }
}
