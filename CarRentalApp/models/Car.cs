using System;

namespace WeAreCarsRental.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{Make} {Model} ({Year}) - {Type}";
        }
    }
}