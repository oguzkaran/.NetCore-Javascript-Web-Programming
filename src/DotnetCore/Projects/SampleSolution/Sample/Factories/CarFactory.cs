using CSD.Application.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace CSD.Application.Factories
{
    public class CarFactory
    {
        private static Car createCar(string[] carInfo) 
        {
            return new Car
            {
                Id = long.Parse(carInfo[0]),
                Vin = carInfo[1],
                Make = carInfo[2],
                Model = carInfo[3],
                Year = int.Parse(carInfo[4]),
                TrafficRegisterDate = DateTime.Parse(carInfo[5])
            };
        }

        private void loadCars(string path) 
        {
            using var sr = new StreamReader(path);

            string line;

            sr.ReadLine();

            while ((line = sr.ReadLine()) != null)
                Cars.Add(createCar(line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)));
        }

        public List<Car> Cars { get; private set; } = new List<Car>();

        public CarFactory(string path) 
        {
            loadCars(path);
        }
    }
}
