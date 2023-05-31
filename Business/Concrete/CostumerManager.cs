using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CostumerManager : ICostumerService
    {
        ICostumerDal _costumerDal;
        public CostumerManager(ICostumerDal costumerDal)
        {
            _costumerDal = costumerDal;
        }
        public IResult Add(Costumer costumer)
        {
            _costumerDal.Add(costumer);
            return new SuccessResult(Messages.CostumerAdded);
        }

        public IDataResult<List<Costumer>> GetAll()
        {
            return new SuccessDataResult<List<Costumer>>(_costumerDal.GetAll());
        }

        public IDataResult<List<Costumer>> GetUsersByCompanyName(string companyname)
        {
            var result = _costumerDal.GetAll().FirstOrDefault(c => c.CompanyName == companyname);
            if (result == null)
            {
                return new ErrorDataResult<List<Costumer>>("Böyle bir şirket yok");
            }
            return new SuccessDataResult<List<Costumer>>(_costumerDal.GetAll(c => c.CompanyName == companyname));
        }
    }
}
