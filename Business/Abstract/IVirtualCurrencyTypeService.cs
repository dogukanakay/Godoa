using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IVirtualCurrencyTypeService
    {
        IResult Add(VirtualCurrencyType virtualCurrencyType);
        IResult Delete(VirtualCurrencyType virtualCurrencyType);
        IResult Update(VirtualCurrencyType virtualCurrencyType);

        Task<IDataResult<List<VirtualCurrencyType>>> GetAll();
        Task<IDataResult<VirtualCurrencyType>> GetById(int virtualCurrencyTypeId);
      
    }
}
