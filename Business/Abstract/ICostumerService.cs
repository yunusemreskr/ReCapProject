using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICostumerService
    {
        IDataResult<List<Costumer>> GetAll();
        IDataResult<List<Costumer>> GetUsersByCompanyName(string companyname);
        IResult Add(Costumer costumer);
    }
}
