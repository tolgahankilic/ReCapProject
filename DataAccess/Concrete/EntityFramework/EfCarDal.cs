using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(int id)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in context.Cars.Where(c => c.Id == id)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             join ci in context.CarImages
                             on c.Id equals ci.CarId

                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 ImagePath =  ci.ImagePath,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                             };

                return result.ToList();
            }
        }
    }
}
