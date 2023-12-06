using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u=>u.UserName).MinimumLength(3).MaximumLength(20).NotEmpty();
            RuleFor(u =>u.Phone).MaximumLength(10).WithMessage("Başında sıfır olmadan 10 haneli telefon numarasını giriniz");
            RuleFor(u=>u.Email).EmailAddress();
            RuleFor(u => u.BirthDate).LessThan(DateTime.Now);
            RuleFor(u=>u.CreateDate).LessThan(DateTime.Now);
            RuleFor(u => u.LastName).MinimumLength(1).MaximumLength(20); 
            RuleFor(u=>u.FirstName).MinimumLength(1).MaximumLength(20);
         
        }
    }
}
