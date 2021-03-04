using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = "2015", Descriptions = "Megane", DailyPrice = 80000},
                new Car { Id = 2, BrandId = 2, ColorId = 2, ModelYear = "2013", Descriptions = "Golf", DailyPrice = 160000},
                new Car { Id = 3, BrandId = 2, ColorId = 3, ModelYear = "2018", Descriptions = "Polo", DailyPrice = 130000},
                new Car { Id = 4, BrandId = 1, ColorId = 2, ModelYear = "2017", Descriptions = "Clio", DailyPrice = 70000},
                new Car { Id = 5, BrandId = 3, ColorId = 4, ModelYear = "2020", Descriptions = "AMG200", DailyPrice = 230000}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            Car carById = _cars.Find(p => p.Id == id);
            return carById;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Descriptions = car.Descriptions;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
