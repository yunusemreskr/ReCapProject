using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join l in context.Colors on c.Id equals l.ColorId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             
                             select new CarDetailDto
                             {
                                 CarName = c.Description,
                                 BrandName = b.BrandName, 
                                 ColorName = l.ColorName, 
                                 DailyPrice = c.DailyPrice

                             };
                return result.ToList();

            }
        }
    }
}
