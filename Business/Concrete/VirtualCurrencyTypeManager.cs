using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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
    public class VirtualCurrencyTypeManager : IVirtualCurrencyTypeService
    {
        IVirtualCurrencyTypeDal _virtualCurrencyTypeDal;
        public VirtualCurrencyTypeManager(IVirtualCurrencyTypeDal virtualCurrencyTypeDal)
        {
            _virtualCurrencyTypeDal = virtualCurrencyTypeDal;
        }
     //   [SecuredOperation("admin,employee")]
        [LogAspect(typeof(FileLogger))]
        public IResult Add(VirtualCurrencyType virtualCurrencyType)
        {
            _virtualCurrencyTypeDal.Add(virtualCurrencyType);
            return new SuccessResult("Eklendi");
        }

    //    [SecuredOperation("admin,employee")]
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(VirtualCurrencyType virtualCurrencyType)
        {
            _virtualCurrencyTypeDal.Delete(virtualCurrencyType);
            return new SuccessResult("Silindi");
        }

        public async Task<IDataResult<VirtualCurrencyType>> GetById(int virtualCurrencyTypeId)
        {
            return new SuccessDataResult<VirtualCurrencyType>(await _virtualCurrencyTypeDal.Get(ct => ct.VirtualCurrencyTypeId== virtualCurrencyTypeId));

        }

        public async Task<IDataResult<List<VirtualCurrencyType>>> GetAll()
        {
            return new SuccessDataResult<List<VirtualCurrencyType>>(await _virtualCurrencyTypeDal.GetAll(), "Verileri Getirildi");
        }

    //    [SecuredOperation("admin,employee")]
        [LogAspect(typeof(FileLogger))]
        public IResult Update(VirtualCurrencyType virtualCurrencyType)
        {
            _virtualCurrencyTypeDal.Update(virtualCurrencyType);
            return new SuccessResult("Güncellendi");
        }

      
    }
}
