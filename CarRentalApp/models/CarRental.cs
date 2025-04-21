using System;
using System.Collections.Generic;

namespace WeAreCarsRental.Models
{
    public class CarRental
    {
        public string CustomerFirstName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerAge { get; set; }
        public bool HasValidDrivingLicense { get; set; }
        public int NumberOfDays { get; set; }
        public CarType CarType { get; set; }
        public FuelType FuelType { get; set; }
        public bool HasUnlimitedMileage { get; set; }
        public bool HasBreakdownCover { get; set; }
        public DateTime RentalDate { get; set; }
        public decimal TotalPrice { get; set; }

        public CarRental()
        {
            RentalDate = DateTime.Now;
        }

        public decimal CalculateTotalPrice()
        {
            decimal basePrice = NumberOfDays * 25; // £25 per day

            // Add car type charges
            switch (CarType)
            {
                case CarType.Family:
                    basePrice += 50;
                    break;
                case CarType.Sports:
                    basePrice += 75;
                    break;
                case CarType.SUV:
                    basePrice += 65;
                    break;
            }

            // Add fuel type charges
            switch (FuelType)
            {
                case FuelType.Hybrid:
                    basePrice += 30;
                    break;
                case FuelType.Electric:
                    basePrice += 50;
                    break;
            }

            // Add optional extras
            if (HasUnlimitedMileage)
                basePrice += 10 * NumberOfDays;

            if (HasBreakdownCover)
                basePrice += 2 * NumberOfDays;

            TotalPrice = basePrice;
            return TotalPrice;
        }
    }

    public enum CarType
    {
        City,
        Family,
        Sports,
        SUV
    }

    public enum FuelType
    {
        Petrol,
        Diesel,
        Hybrid,
        Electric
    }

    // Static class to store the list of rentals
    public static class RentalData
    {
        public static List<CarRental> Rentals { get; } = new List<CarRental>();
    }
}