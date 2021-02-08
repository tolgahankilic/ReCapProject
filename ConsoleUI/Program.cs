using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarAddTest();
            //CarListTest();
            //CarDetailTest();
        }

        private static void CarListTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car Name: {0}\nBrand Id: {1}\nColor Id: {2}\nDaily Price: {3}\nDescriptions: {4}\nModel Year: {5}\n",
                    car.CarName, car.BrandId, car.ColorId, car.DailyPrice.ToString(), car.Descriptions, car.ModelYear);
            }
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car
            {
                BrandId = 2,
                CarName = "320d Sport Line",
                ColorId = 1,
                DailyPrice = 200,
                Descriptions = "Yarı Otomatik Dizel",
                ModelYear = "2013"
            });
        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Car Name: {0}\nBrand Name: {1}\nColor Name: {2}\nDailyPrice: {3}\n", car.CarName, car.BrandName, car.ColorName, car.DailyPrice.ToString());
            }
        }
    }
}
