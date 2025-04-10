using System.Text.Json.Serialization;

namespace ConsoleApp13.Entities;

public class Car
{
    private string _mark;
    private string _model;
    private int _year;

    public int Id { get; set; }
    public int CarTypeId { get; set; }

    public bool IsOperable { get; set; }

    [JsonIgnore]
    public CarType Type { get; set; }
    public List<Order> Orders { get; set; }

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


    public Car(string mark, string model, int year, CarType carType)
    {
        Mark = mark;
        Model = model;
        Year = year;
        Type = carType;
    }

    public Car()
    {

    }

    public string DisplayInfo()
    {
        return $"Id: {Id} | Mark: {Mark} | Model: {Model} | Year: {Year} | Coefficent: {Type.Coefficent} | Car Type: {Type.Name}";
    }
}
