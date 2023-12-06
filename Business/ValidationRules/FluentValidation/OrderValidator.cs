using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o=>o.TotalPrice).NotEmpty();
            RuleFor(o=>o.TotalPrice).GreaterThan(0);
            RuleFor(o=>o.ProductId).NotNull();


        }
    }
}
