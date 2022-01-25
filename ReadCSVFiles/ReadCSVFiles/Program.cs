using ReadCSVFiles.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadCSVFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            //implicit operators
            //Car car = "Fusca,Volkswagen,5000,1959-01-03";
            //List<Car> listClassicCars = new List<Car>();
            
            foreach(string line in File.ReadAllLines(@"files\classicCars.csv"))
            {
                Car classicCar = line;
                WriteCarInfo(classicCar);
            }

            //save objects to CSV file
            List<Car> listCars = new List<Car>();

            listCars.AddRange(new List<Car>
            {
                new Car("Celta", "Chevrolet", 8500, new DateTime(2000, 9, 1)),
                new Car("Gran Siena", "Fiat", 40000, new DateTime(2012, 1, 1)),
                new Car("Focus", "Ford", 60000, new DateTime(2017, 1, 1))
            });

            var data = listCars.Select(car => (string)car);

            File.WriteAllLines(@"files\cars.csv", data);

            Console.WriteLine(@"Check in project folder, the created file with name files\cars.csv");
            Console.ReadKey();


        }

        private static void WriteCarInfo(Car car)
        {
            Console.WriteLine(car.Name);
            Console.WriteLine(car.Manufacturer);
            Console.WriteLine(car.Price);
            Console.WriteLine(car.ReleaseDate);
            Console.WriteLine();
        }
    }
}
