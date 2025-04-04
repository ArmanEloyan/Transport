using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Models
{
    internal class Order
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

        public string DisplayInfo()
        {
            return $"ID: {Id} | Email {Email} | Way {WayObj.CityFrom.Name} - {WayObj.CityTo.Name}\nTransport Type: {TransportType.ToString()}\nDate: {RecieveDate}\nPrice: {Price}";
        }
    }
}
