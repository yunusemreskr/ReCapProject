using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidation: AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p=>p.FirstName).NotEmpty();
            RuleFor(p=>p.Email).NotEmpty();
            RuleFor(p=>p.Password).NotEmpty();
            RuleFor(p=>p.Password).MinimumLength(6);
        }
    }
}
