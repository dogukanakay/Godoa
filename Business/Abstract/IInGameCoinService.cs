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
    public interface IInGameCoinService
    {       
            IResult Add(InGameCoin ınGameCoin);
            IResult Delete(InGameCoin ınGameCoin);
            IResult Update(InGameCoin ınGameCoin);

            Task<IDataResult<List<InGameCoin>>> GetAll(); 
            Task<IDataResult<InGameCoin>> GetById(int inGameCoinId);
            Task<IDataResult<List<InGameCoinDetailDto>>> GetInGameCoinDetils();
        
    }
}
