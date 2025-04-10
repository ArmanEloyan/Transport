using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp13.Entities;

public class CarType
{
    private string _name;
    private double _coefficient;

    public int Id { get; set; }

    [JsonIgnore]
    public List<Car> Cars { get; set; }

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("Name cant be empty");
            }

            _name = value;
        }
    }

    public double Coefficent
    {
        get { return _coefficient; }
        set
        {
            if (value < 1.0)
            {
                throw new Exception("Coefficient cant be less than 1");
            }
            _coefficient = value;
        }
    }

    public CarType()
    {
        
    }

    public CarType(string name, double coefficent)
    {
        Name = name;
        Coefficent = coefficent;
    }

    public string DisplayInfo()
    {
        return $"Id: {Id} | Name: {Name} | Coefficent: {Coefficent}";
    }
}
