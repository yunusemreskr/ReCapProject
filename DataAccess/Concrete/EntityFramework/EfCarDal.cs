using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : IEntityRepository<Car>
    {
        List<Car> _car;
        public EfCarDal()
        {
            _car = new List<Car>
            {
                new Car {Id=1 , BrandId=1, ColorId=1, DailyPrice=950000, ModelYear=2022, Description="Bmw i20"},
                new Car {Id=2 , BrandId=5, ColorId=2, DailyPrice=850000, ModelYear=2023, Description="Golf "},
                new Car {Id=3 , BrandId=4, ColorId=4, DailyPrice=550000, ModelYear=2020, Description="Mercedes Sl"},
                new Car {Id=4 , BrandId=3, ColorId=3, DailyPrice=750000, ModelYear=2023, Description="Togg"},
            };

        }
        public void Add(Car entity)
        {
            _car.Add(entity);
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _car.ToList();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
