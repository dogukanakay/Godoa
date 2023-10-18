using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGameTypeService
    {
        IResult Add(GameType gameType);
        IResult Delete(GameType gameType);
        IResult Update(GameType gameType);

        IDataResult<List<GameType>> GetAll();
        IDataResult<GameType> GetById(int gameTypeId);
    }
}
