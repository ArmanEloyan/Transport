using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class City
{
    private string _name;

    public int Id { get; set; }
    public List<Way> WaysFrom { get; set; }
    public List<Way> WaysTo { get; set; }


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


    public City(string name)
    {
        Name = name;
    }

    public string DisplayInfo()
    {
        return $"Id: {Id} | Name: {Name}";
    }
}

