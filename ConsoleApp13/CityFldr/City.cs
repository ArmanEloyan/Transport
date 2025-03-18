using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class City
{
    private string _name;
    private static int s_allCount;

    public int Id { get; set; }

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
        Id = ++s_allCount;
        Name = name;
    }

    public City()
    {
            
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Id: {Id} | Name: {Name}");
    }
}

