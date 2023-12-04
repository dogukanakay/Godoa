using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PlatformValidator : AbstractValidator<Platform>
    {
        public PlatformValidator()
        {
            RuleFor(r=> r.PlatformName).NotEmpty();
        }
    }
}
