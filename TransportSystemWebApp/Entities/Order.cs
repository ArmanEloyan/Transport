using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportSystemWebApp.Entities;

public class Order
{
    public int Id { get; set; }
    public string Email { get; set; }
    public double Price { get; set; }

    public int WayId { get; set; }
    public int CarId { get; set; }

    public TransportType TransportType { get; set; }
    public DateTime RecieveDate { get; set; }

    public Way WayObj { get; set; }
    public Car CarObj { get; set; }

    public Order(string email, Way way, Car car, TransportType transportType, DateTime receveDate, double price)
    {
        RecieveDate = receveDate;
        TransportType = transportType;
        Email = email;
        WayObj = way;
        CarObj = car;
        Price = price;
    }

    public Order()
    {

    }
}

public enum TransportType
{
    [Display(Name = "0 - Open")]
    Open = 0,

    [Display(Name = "1 - Enclosed")]
    Enclosed = 1
}