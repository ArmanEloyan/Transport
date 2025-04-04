using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Way
{
    private double _startPrice;

    public int Id { get; set; }
    public int CityFromId { get; set; }
    public int CityToId { get; set; }

    public City CityFrom { get; internal set; }
    public City CityTo { get; internal set; }

    public double StartPrice
    {
        get { return _startPrice; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Start Price cant be less then 0");
            }
            _startPrice = value;
        }
    }

    public Way(City cityFrom, City cityTo, double startPrice)
    {
        CityFrom = cityFrom;
        CityTo = cityTo;
        StartPrice = startPrice;
    }

    public Way()
    {
        
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Id: {Id} | CityFrom: {CityFrom.Name} | CityTo: {CityTo.Name} | StartPrice: {StartPrice}");
    }

}

