using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGameCategoryService
    {
        IResult Add(GameCategory gameCategory);
        IResult Delete(GameCategory gameCategory);
        IResult Update(GameCategory gameCategory);

        Task<IDataResult<List<GameCategory>>> GetAll();
        Task<IDataResult<GameCategory>> GetById(int gameCategoryId);
    }
}
