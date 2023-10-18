using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInGameCoin
    {       
            IResult Add(InGameCoin ınGameCoin);
            IResult Delete(InGameCoin ınGameCoin);
            IResult Update(InGameCoin ınGameCoin);

            IDataResult<List<InGameCoin>> GetAll();
            IDataResult<InGameCoin> Get();
        
    }
}
