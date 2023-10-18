using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class InGameCoinManager:IInGameCoinService
    {
        IInGameCoinDal _inGameCoinDal;
        public IResult Add(InGameCoin inGameCoin)
        {
            _inGameCoinDal.Add(inGameCoin);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(InGameCoin inGameCoin)
        {
            _inGameCoinDal.Delete(inGameCoin);
            return new SuccessResult("Silindi");
        }

        public IDataResult<InGameCoin> GetById(int inGameCoinId)
        {
            return new SuccessDataResult<InGameCoin>(_inGameCoinDal.Get(s => s.InGameCoinId == inGameCoinId));

        }

        public IDataResult<List<InGameCoin>> GetAll()
        {
            return new SuccessDataResult<List<InGameCoin>>(_inGameCoinDal.GetAll(), "Verileri Getirildi");
        }

        public IResult Update(InGameCoin inGameCoin)
        {
            _inGameCoinDal.Update(inGameCoin);
            return new SuccessResult("Güncellendi");
        }
    }
}
