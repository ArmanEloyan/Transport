using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.CityFldr
{
    internal class Way
    {
        //  private double _distantion;
        private static int s_allCityFromToCount;

        private double _startPrice;

        public int Id { get; set; }
        public City CityFrom { get; set; }
        public City CityTo { get; set; }
     //   public TransportType TransportType { get; set; }

        //public double Distantion
        //{
        //    get { return _distantion; }
        //    set
        //    {
        //        if(value<0)
        //        {
        //            throw new Exception("Distantion cant be less then 0");
        //        }
        //        _distantion = value;
        //    }
        //}

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

        public Way(City cityFrom, City cityTo, double startPrice = 10000)//, TransportType transportType = TransportType.Open)
        {
            Id = ++s_allCityFromToCount;
            CityFrom = cityFrom;
            CityTo = cityTo;
           // Distantion = distantion;
            StartPrice = startPrice;
          //  TransportType = transportType;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Id: {Id} CityFrom: {CityFrom.Name} CityTo: {CityTo.Name} StartPrice: {StartPrice}");
        }

    }
}
