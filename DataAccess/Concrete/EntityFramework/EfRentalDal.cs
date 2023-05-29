using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentDetailDto> GetRentDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result= from r in context.Rentals
                            join c in context.Cars on r.CarId equals c.Id
                            join b in context.Brands on c.BrandId equals b.BrandId
                            join cs in context.Costumers on r.CostumerId equals cs.UserId
                            join u in context.Users on cs.UserId equals u.Id
                            
                            select new RentDetailDto 
                            {
                                Id = r.Id,
                                BrandName=b.BrandName,
                                FirstName=u.FirstName,
                                LastName=u.LastName,
                                RentDate = r.RentDate,
                                ReturnDate = r.ReturnDate,
                                
                            };
                return result.ToList();
                            
            }
        }
    }
}
