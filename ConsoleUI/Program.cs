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
            //UserAddTest();
            //UserListTest();
            //CustomerAddTest();
            //RentalAddTest();
        }

        private static void RentalAddTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            {
                CarId = 2,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = null
            });
            Console.WriteLine(result.Message);
        }

        private static void CustomerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer
            {
                UserId = 1,
                CompanyName = "Akyürek Bolatlı Ltd. Şti."
            });
        }

        private static void UserListTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.FirstName);
            }
        }

        private static void UserAddTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User
            {
                FirstName = "Ulug",
                LastName = "Aydoğan",
                Email = "ulugaydogan@test.com"
            });
        }

        private static void CarListTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            foreach (var car in result.Data)
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

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Car Name: {0}\nBrand Name: {1}\nColor Name: {2}\nDailyPrice: {3}\n", car.CarName, car.BrandName, car.ColorName, car.DailyPrice.ToString());
            }
        }
    }
}
