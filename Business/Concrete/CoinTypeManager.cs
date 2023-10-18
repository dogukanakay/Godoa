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
    public class CoinTypeManager : ICoinTypeService
    {
        ICoinTypeDal _coinTypeDal;
        public IResult Add(CoinType coinType)
        {
            _coinTypeDal.Add(coinType);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(CoinType coinType)
        {
            _coinTypeDal.Delete(coinType);
            return new SuccessResult("Silindi");
        }

        public IDataResult<CoinType> GetById(int coinTypeId)
        {
            return new SuccessDataResult<CoinType>(_coinTypeDal.Get(s => s.CoinTypeId== coinTypeId));

        }

        public IDataResult<List<CoinType>> GetAll()
        {
            return new SuccessDataResult<List<CoinType>>(_coinTypeDal.GetAll(), "Verileri Getirildi");
        }

        public IResult Update(CoinType coinType)
        {
            _coinTypeDal.Update(coinType);
            return new SuccessResult("Güncellendi");
        }
    }
}
