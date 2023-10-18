using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGameService
    {
        IResult Add(Game game);
        IResult Delete(Game game);
        IResult Update(Game game);

        IDataResult<List<Game>> GetAll();
        IDataResult<Game> GetById(int gameId);
    }
}
