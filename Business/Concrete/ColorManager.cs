using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspect.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal) 
        {
            _colorDal = colorDal;
        }

        
        [SecuredOperation("admin")]
        public IResult Add(Color color)
        {
            var result = _colorDal.GetAll().SingleOrDefault(c=>c.ColorId==color.ColorId);

            if (result == null) 
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.CarColorAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarColorInvalid);     
            }
               
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
            
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetCarsByColorId(int id)
        {
            var result = _colorDal.GetAll().FirstOrDefault(c => c.ColorId == id);
            if (result == null)
            {
                return new ErrorDataResult<List<Color>>("Geçersiz renk 'id' tekrar deneyiniz.");
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c=>c.ColorId==id));            
        }                               

        
    }
}
