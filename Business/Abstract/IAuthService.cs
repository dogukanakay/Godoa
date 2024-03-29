﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Tokens;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto);
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        Task<IResult> UserExist(string email);
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);
       
    } 
}
