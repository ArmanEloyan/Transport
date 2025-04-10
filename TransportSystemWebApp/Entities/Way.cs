
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TransportSystemWebApp.Entities;

public class Way
{
    private double _startPrice;

    public int Id { get; set; }
    public int CityFromId { get; set; }
    public int CityToId { get; set; }

    public City CityFrom { get; set; }
    public City CityTo { get; set; }
    [JsonIgnore]
    public List<Order> Orders { get; set; }

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

    public string DisplayInfo()
    {
         return $"Id: {Id} | CityFrom: {CityFrom.Name} | CityTo: {CityTo.Name} | StartPrice: {StartPrice}";
    }

}

