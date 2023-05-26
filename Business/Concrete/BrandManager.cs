using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager ( IBrandDal brandDal) 
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            var result = _brandDal.GetAll().SingleOrDefault(b => b.BrandId == brand.BrandId);
            
            if (result == null) 
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.CarBrandAdded);

            }
            else
            {
                return new ErrorResult(Messages.CarBrandInvalid);
            }
            
        }

        

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetCarsByBrandId(int id)
        {
            return _brandDal.Get(b=>b.BrandId == id);
        }

        
    }
}
