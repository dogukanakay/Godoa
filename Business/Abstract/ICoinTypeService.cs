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
    public interface ICoinTypeService
    {
        IResult Add(CoinType coinType);
        IResult Delete(CoinType coinType);
        IResult Update(CoinType coinType);

        Task<IDataResult<List<CoinType>>> GetAll();
        Task<IDataResult<CoinType>> GetById(int coinTypeId);
        Task<IDataResult<List<CoinTypeDetailDto>>> GetCoinTypeDetails(); 
    }
}
