using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal 
    {
        List<Car> _car;
        public InMemoryProductDal() 
        {
            _car = new List<Car>
            {
                new Car {Id=1 , BrandId=1, ColorId=1, DailyPrice=950000, Description="Bmw i20"},
                new Car {Id=2 , BrandId=5, ColorId=2, DailyPrice=850000, Description="Golf "},
                new Car {Id=3 , BrandId=4, ColorId=4, DailyPrice=550000, Description="Mercedes Sl"},
                new Car {Id=4 , BrandId=3, ColorId=3, DailyPrice=750000, Description="Togg"},
            };
        
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(p => p.Id == car.Id);
            _car.Remove(carToUpdate);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _car;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(p=> p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
