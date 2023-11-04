using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        public CoinTypeManager(ICoinTypeDal coinTypeDal)
        {
            _coinTypeDal = coinTypeDal;
        }
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

        public async Task<IDataResult<CoinType>> GetById(int coinTypeId)
        {
            return new SuccessDataResult<CoinType>(await _coinTypeDal.Get(ct => ct.CoinTypeId== coinTypeId));

        }

        public async Task<IDataResult<List<CoinType>>> GetAll()
        {
            return new SuccessDataResult<List<CoinType>>(await _coinTypeDal.GetAll(), "Verileri Getirildi");
        }

        public IResult Update(CoinType coinType)
        {
            _coinTypeDal.Update(coinType);
            return new SuccessResult("Güncellendi");
        }

        public async Task<IDataResult<List<CoinTypeDetailDto>>> GetCoinTypeDetails()
        {
            return new SuccessDataResult<List<CoinTypeDetailDto>>(await _coinTypeDal.GetCoinTypeDetails(), "CoinType detaylı bilgileri getirildi");
        }
    }
}
