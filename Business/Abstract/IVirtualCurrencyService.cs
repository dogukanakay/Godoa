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
    public interface IVirtualCurrencyService
    {       
            IResult Add(VirtualCurrency virtualCurrency);
            IResult Delete(VirtualCurrency virtualCurrency);
            IResult Update(VirtualCurrency virtualCurrency);

            Task<IDataResult<List<VirtualCurrency>>> GetAll(); 
            Task<IDataResult<VirtualCurrency>> GetById(int virtualCurrencyId);
           
        
    }
}
