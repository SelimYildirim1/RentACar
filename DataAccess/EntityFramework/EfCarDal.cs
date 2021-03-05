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

namespace DataAccess.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext rentACarContext = new RentACarContext())
            {
                var result = from c in rentACarContext.Cars
                             join b in rentACarContext.Brands
                             on c.CarId equals b.BrandId
                             join co in rentACarContext.Colors
                             on c.CarId equals co.ColorId
                             select new CarDetailDto 
                             { CarId = c.CarId, CarName = c.CarName,
                               BrandName = b.BrandName,ColorName=co.ColorName ,DailyPrice = c.DailyPrice 
                             };
                return result.ToList();
            }
        }
    }
}
