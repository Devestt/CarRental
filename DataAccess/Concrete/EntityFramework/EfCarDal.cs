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
    public class EfCarDal : EfEntityRepositoryBase<Car, DatabaseContext>, ICarDal
    {
        public List<DetailsDto> GetAllDto()
        {
            using (DatabaseContext context=new DatabaseContext())
            {
                var result = from c in context.CarDb
                             join p in context.BrandDb
                             on c.CarId equals p.BrandId 
                             join d in context.ColorDb
                             on c.CarId equals d.ColorId
                             select new DetailsDto { BrandName = p.BrandName, CarId = c.CarId, ColorName = d.ColorName };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (DatabaseContext context=new DatabaseContext())
            {
                var result = from p in context.BrandDb
                             join c in context.CarDb
                             on p.BrandId equals c.CarId
                             select new CarDetailDto { CarId = c.CarId,
                                  BrandName = p.BrandName, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
            
        }
    }
}
