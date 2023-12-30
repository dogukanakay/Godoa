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
    public interface IGameKeyService
    {
        IResult Add(GameKey gameKey);
        IResult Delete(GameKey gameKey);
        IResult Update(GameKey gameKey);

        Task<IDataResult<List<GameKey>>> GetAll();
        Task<IDataResult<GameKey>> GetById(int gameKeyId);
        Task<IDataResult<GameKey>> GetIfİnStockByProductId(int productId);
        
    }
}
