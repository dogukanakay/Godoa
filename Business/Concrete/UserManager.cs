﻿using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
            return new SuccessResult("Kullanici Eklendi");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("Kullanıcı Silindi");
        }

        public async Task<IDataResult<User>> GetById(int userId)
        {
            return new SuccessDataResult<User>(await _userDal.Get(u => u.UserId == userId),"Kullanıcı Getirildi");
        }

        public async Task<IDataResult<List<User>>> GetAll()
        {
            return new SuccessDataResult<List<User>>(await _userDal.GetAll(),"Kullanıcılar Getirildi");
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("Güncellendi");
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        
    }
}
