using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult("Kiralık araç eklendi");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentDetailDto>> GetRentDetails()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<RentDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentDetailDto>>(_rentalDal.GetRentDetails());
        }
    }
}
