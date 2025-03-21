﻿using ConsoleApp13.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class TransportCompanyOrderSystem
    {
        private Way _wayObj;
        private Car _carObj;
        private string _email;
        private IEnumerable<Way> _allWays;

        private readonly TransportType _transportType;
        private readonly DateToReceve _receveDate;


        public TransportCompanyOrderSystem(City cityFrom, City cityTo, Car car, TransportType transportType, DateToReceve receveDate, string email, IEnumerable<Way> ways)
        {
            _transportType = transportType;
            _receveDate = receveDate;
            _email = email;
            _allWays = ways;
            AddWay(cityFrom, cityTo);
            AddCar(car);
        }

        public double CalculatePrice()
        {
            if (_wayObj == null)
            {
                throw new Exception("Way cant be null");
            }

            if (_carObj == null)
            {
                throw new Exception("Car cant be null");
            }

            double price = _wayObj.StartPrice;

            if (_transportType == TransportType.Enclosed)
            {
                price *= 1.3;
            }

            price *= _carObj.Coefficent;
            price *= CalculateDateToRecieveCoefficent();
            return price;
        }

        public void CompleteOrder()
        {
            SendMail(_email);
        }

        public void AddWay(City cityFrom, City cityTo)
        {
            if (cityFrom == null || cityTo == null)
            {
                throw new Exception("City cant be null");
            }
            if (cityFrom.Name == cityTo.Name)
            {
                throw new Exception("Cities are same");
            }

            Way way = _allWays.FirstOrDefault(c => c.CityFrom.Id == cityFrom.Id && c.CityTo.Id == cityTo.Id);

            if (way == null)
            {
                throw new Exception("Cant find this Way");
            }

            _wayObj = way;
        }

        public void AddCar(Car car)
        {
            if (car == null)
            {
                throw new Exception("Car cant be null");
            }

            _carObj = car;
        }

        private double CalculateDateToRecieveCoefficent()
        {
            double coefficent = 1.0;
            switch (_receveDate)
            {
                case DateToReceve.Week:
                    coefficent = 1.1;
                    break;
                case DateToReceve.Month:
                    coefficent = 1.2;
                    break;
                case DateToReceve.Months2:
                    coefficent = 1.3;
                    break;
            }
            return coefficent;
        }

        public void SendMail(string mail)
        {
            Console.WriteLine($"Confirmation mail sent to {mail}");
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
