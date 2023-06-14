using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour==05)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserListed);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u=>u.Email==email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<UserDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails(),Messages.UserDetailsListed);
        }

        public IDataResult<List<User>> GetUsersByName(string name)
        {
            var result = _userDal.GetAll().FirstOrDefault(u => u.FirstName == name);            
            
            if (result == null)
            {
                return new ErrorDataResult<List<User>>("Bu isimli bir kullanıcı yok");
            }
            
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u=>u.FirstName == name), Messages.UserGet);    

        }
    }
}
