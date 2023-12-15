using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class VirtualCurrencyManager:IVirtualCurrencyService
    {
        IVirtualCurrencyDal _virtualCurrencyDal;
        public VirtualCurrencyManager(IVirtualCurrencyDal virtualCurrencyDal)
        {
            _virtualCurrencyDal = virtualCurrencyDal;
        }
        public IResult Add(VirtualCurrency virtualCurrency)
        {
            _virtualCurrencyDal.Add(virtualCurrency);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(VirtualCurrency virtualCurrency)
        {
            _virtualCurrencyDal.Delete(virtualCurrency);
            return new SuccessResult("Silindi");
        }

        public  async Task<IDataResult<VirtualCurrency>> GetById(int currencyId)
        {
            return new SuccessDataResult<VirtualCurrency>(await _virtualCurrencyDal.Get(s => s.CurrencyId == currencyId));

        }

        public async Task<IDataResult<List<VirtualCurrency>>> GetAll()
        {
            return new SuccessDataResult<List<VirtualCurrency>>(await _virtualCurrencyDal.GetAll(), "Verileri Getirildi");
        }

        public IResult Update(VirtualCurrency virtualCurrency)
        {
            _virtualCurrencyDal.Update(virtualCurrency);
            return new SuccessResult("Güncellendi");
        }
       
    }
}
