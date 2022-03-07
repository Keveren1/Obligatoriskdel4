using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Obligatoriskdel3;

namespace Obligatoriskdel3.Controllers.Managers
{
public class CarManager

{

    private static int nextId = 1; 

    private static List<Car> data = new List<Car>()
        {
            new Car() {Id = nextId++, Price = 50000, Model = "Toyota", LicensePlate = "442125"},
            new Car() {Id = nextId++, Price = 40000, Model = "Renault", LicensePlate = "582952"},
            new Car() {Id = nextId++, Price = 1000000, Model = "Ferrari", LicensePlate = "917682"},
            new Car() {Id = nextId++, Price = 450000, Model = "Tesla", LicensePlate = "957206"},
            new Car() {Id = nextId++, Price = 70000, Model = "Peugeot", LicensePlate = "275932"},
        };

        public List<Car> GetAll(string modelFilter, int? priceFilter, string? licensePlateFilter)
        {
            List<Car> result = new List<Car>(data);
            if (!string.IsNullOrWhiteSpace(modelFilter))
            {
                result = result.FindAll(filterCar =>
                    filterCar.Model.Contains(modelFilter, StringComparison.OrdinalIgnoreCase));
            }

            if (priceFilter != null)
            {
                result = result.FindAll(filterCar =>
                    filterCar.Price <= priceFilter);
            }

            if (!string.IsNullOrWhiteSpace(licensePlateFilter))
            {
                result = result.FindAll(filterCar =>
                    filterCar.LicensePlate.Contains(licensePlateFilter, StringComparison.OrdinalIgnoreCase));
            }

            return result;
        }

        public Car GetById(int id)
        {
            return data.Find(car => car.Id == id);
        }

        public Car AddCar(Car newCar)
        {
            newCar.Id = nextId;
            data.Add(newCar);
            return newCar;
        }

        public Car Delete(int id)
        {
            Car car = data.Find(car => car.Id == id);
            if (car == null) return null;
            data.Remove(car);
            return car;
        }
    }
}
