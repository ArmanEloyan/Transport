using ConsoleApp13.Models;
using ConsoleApp13.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class TransportCompanyOrderSystem
    {
        public event Action<Order> OrderCompleted;

        private Way _wayObj;
        private Car _carObj;
        private string _email;

        private readonly TransportType _transportType;
        private readonly DateToReceve _receveDate;

        IRepository<Order> _ordersRepository;

        public TransportCompanyOrderSystem(IRepository<Order> ordersRepository)
        {
            OrderCompleted = AddOrder;
            OrderCompleted += SendMail;

            _ordersRepository = ordersRepository;
        }

        public Order CreateOrder(Way way, Car car, string email, TransportType transportType, DateToReceve receveDate)
        {
            double price = CalculatePrice(way, car, transportType, receveDate);
            DateTime receveDateTime = ReceveDateToDateTime(receveDate);

            Order order = new Order(email, way, car, transportType, receveDateTime, price);
            return order;
        }

        public double CalculatePrice(Way way, Car car, TransportType transportType, DateToReceve recieveDate)
        {
            double price = way.StartPrice;

            if (transportType == TransportType.Enclosed)
            {
                price *= 1.3;
            }

            price *= car.Coefficent;
            price *= CalculateDateToRecieveCoefficent(recieveDate);
            return price;
        }

        private DateTime ReceveDateToDateTime(DateToReceve receveDate)
        {
            DateTime date = new DateTime();

            if (receveDate == DateToReceve.Week)
            {
                date = DateTime.Now.AddDays(7);
            }
            else if (receveDate == DateToReceve.Month)
            {
                date = DateTime.Now.AddMonths(1);
            }
            else if (receveDate == DateToReceve.Months2)
            {
                date = DateTime.Now.AddMonths(2);
            }

            return date;
        }

        public void CompleteOrder(Order order)
        {
            OrderCompleted.Invoke(order);
        }

        private double CalculateDateToRecieveCoefficent(DateToReceve recieveDate)
        {
            double coefficent = 1.0;
            switch (recieveDate)
            {
                case DateToReceve.Week:
                    coefficent = 1.3;
                    break;
                case DateToReceve.Month:
                    coefficent = 1.2;
                    break;
                case DateToReceve.Months2:
                    coefficent = 1.1;
                    break;
            }
            return coefficent;
        }

        private void AddOrder(Order order)
        {
            if (order == null)
            {
                throw new Exception("Order cant be null");
            }

            _ordersRepository.Add(order);
        }

        public void SendMail(Order order)
        {
            Console.WriteLine($"Confirmation mail sent to {order.Email}");
        }
    }

    public enum TransportType
    {
        Open,
        Enclosed
    }

    public enum DateToReceve
    {
        Week,
        Month,
        Months2
    }
}
