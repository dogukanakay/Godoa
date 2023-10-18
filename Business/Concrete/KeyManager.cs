﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class KeyManager : IKeyService
    {
        IKeyDal _keyDal;
        public KeyManager(IKeyDal keyDal)
        {
            _keyDal = keyDal;
        }
        public IResult Add(Keys key )
        {
            _keyDal.Add(key);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(Keys key)
        {
            _keyDal.Delete(key);
            return new SuccessResult("Silindi");
        }

        public IDataResult<Keys> GetById(int keyId)
        {
            return new SuccessDataResult<Keys>(_keyDal.Get(k=>k.KeyId==keyId));
        }

        public IDataResult<List<Keys>> GetAll()
        {
            return new SuccessDataResult<List<Keys>>(_keyDal.GetAll(), "Veriler Getirildi");
        }

        public IResult Update(Keys key)
        {
            _keyDal.Update(key);
            return new SuccessResult("Güncellendi");
        }
    }
}
