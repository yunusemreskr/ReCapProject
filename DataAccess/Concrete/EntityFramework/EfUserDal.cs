using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name, };
                return result.ToList();
            }
        }

        public List<UserDetailDto> GetUserDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from u in context.Users
                             join c in context.Costumers 
                             on u.Id equals c.UserId
                             

                             select new UserDetailDto
                             {
                                 UserId = u.Id,
                                 FirstName= u.FirstName,
                                 LastName= u.LastName,
                                 CompanyName= c.CompanyName,
                                 Email= u.Email,
                                  
                             };

                return result.ToList();

            }
        }
    }

}
