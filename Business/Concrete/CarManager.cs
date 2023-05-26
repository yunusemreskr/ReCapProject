using Business.Abstract;
using Business.Constants;
using Core.Entities;
using Core.Utilities.Results;
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

        public IResult Add(Car car)
        {

            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else if (car.DailyPrice == 0) 
            {
                return new ErrorResult(Messages.CarPriceInvalid);
            }
            
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
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

        

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

       
    }
}
