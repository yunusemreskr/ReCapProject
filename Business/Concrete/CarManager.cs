using Business.Abstract;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            var result = IsAdd(car);
            if (!result) return;
            _carDal.Add(car);
            Console.WriteLine("Add");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        private static bool IsAdd(Car car)
        {
            if (!string.IsNullOrEmpty(car.Description) && car.Description.Length >= 2)
            {
                if (car.DailyPrice > 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır");
                return false;
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var updatedEntity = context.Entry(car);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Car car)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var deletedEntity = context.Entry(car);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
