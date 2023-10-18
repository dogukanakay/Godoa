using Core.Utilities.Results;
using Entities.Concrete;
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

        IDataResult<List<CoinType>> GetAll();
        IDataResult<CoinType> Get();
    }
}
