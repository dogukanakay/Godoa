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
    public interface IGameService
    {
        IResult Add(Game game);
        IResult Delete(Game game);
        IResult Update(Game game);

        Task<IDataResult<List<Game>>> GetAll();
        Task<IDataResult<Game>> GetById(int gameId);

        Task<IDataResult<List<GameDetailDto>>> GetGameDetails();
    }
}
