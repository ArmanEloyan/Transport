using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Entities;

public class City
{
    private string _name;

    public int Id { get; set; }


    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
        }
    }


    public City(string name)
    {
        Name = name;
    }

    public City()
    {
            
    }

    public string DisplayInfo()
    {
        return $"Id: {Id} | Name: {Name}";
    }
}

