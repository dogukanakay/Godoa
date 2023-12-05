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
            RuleFor(r => r.PlatformName).MinimumLength(2).WithMessage("Platform ismi minimum 2 harf olmalı.");
            RuleFor(r=> r.PlatformName).NotEmpty().WithMessage("Platform ismi boş bırakılamaz");
        }
    }
}
