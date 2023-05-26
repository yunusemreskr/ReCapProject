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

        

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
            
        }

        public IDataResult<List<Color>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c=>c.ColorId==id));            
        }                               

        
    }
}
