using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator:AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator() 
        {
            RuleFor(ur => ur.Password)
           .NotEmpty().WithMessage("Şifre boş bırakılamaz !!!!!!")
           .MaximumLength(20).WithMessage("Şifre en fazla 20 karakter uzunluğunda olmalı")
           .MinimumLength(8).WithMessage("Şifre en az 8 karakter uzunluğunda olmalı")
           .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir")
           .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir")
           .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir")
           .Matches("[!@#$%^&*(),.?\":{}|<>]").WithMessage("Şifre en az bir özel karakter içermelidir")
           .Must(password => !password.Contains("123")).WithMessage("Şifre basit bir şablona uymamalıdır");
        }
    }
}
