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
            throw new NotImplementedException();
        }

        public IDataResult<Costumer> GetUsersByCompanyName(string companyname)
        {
            throw new NotImplementedException();
        }
    }
}
