using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidation))]
        public IResult Add(Car car)
        {

            //if (car.Description.Length < 2)
            //{
            //    return new ErrorResult(Messages.CarNameInvalid);
            //}
            //else if (car.DailyPrice == 0) 
            //{
            //    return new ErrorResult(Messages.CarPriceInvalid);
            //}
            
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==20)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var result = _carDal.GetAll().FirstOrDefault(c => c.BrandId == id);
            if (result == null)
            {
                return new ErrorDataResult<List<Car>>("Marka id geçersiz tekrar deneyiniz");
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var result = _carDal.GetAll().FirstOrDefault(c=>c.ColorId == id);
            if (result==null)
            {
                return new ErrorDataResult<List<Car>>("Geçersiz renk 'id' tekrar deneyiniz.");
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
            
        }

        

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
            
        }

       
    }
}
