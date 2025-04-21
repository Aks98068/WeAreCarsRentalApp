using System;

namespace WeAreCarsRental.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Car Car { get; set; }
        public bool HasInsurance { get; set; }
        public decimal TotalPrice { get; set; }

        public decimal CalculateTotalCost()
        {
            int days = (EndDate - StartDate).Days;
            if (days < 1) days = 1;

            decimal basePrice = Car.PricePerDay * days;
            decimal insurancePrice = HasInsurance ? basePrice * 0.15m : 0;

            return basePrice + insurancePrice;
        }
    }
}