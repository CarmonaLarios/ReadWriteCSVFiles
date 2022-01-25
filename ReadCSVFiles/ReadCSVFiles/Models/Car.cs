using System;
using System.Collections.Generic;
using System.Text;

namespace ReadCSVFiles.Models
{
    public class Car
    {
        public Car(string name, string manufacturer, double price, DateTime releaseDate)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
            ReleaseDate = releaseDate;
        }

        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public static implicit operator string (Car car) => $"{car.Name}, {car.Manufacturer}, {car.Price}, {car.ReleaseDate.ToString("dd-MM-yyyy")}";

        public static implicit operator Car(string line)
        {
            var data = line.Split(',');

            return new Car(data[0],
                           data[1],
                           Double.Parse(data[2]),
                           data[3].ToDateTime());
        }
    }
}
