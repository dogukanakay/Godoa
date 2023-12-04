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
    public interface ISkinService
    {
        IResult Add(Skin skin);
        IResult Delete(Skin skin);
        IResult Update(Skin skin);

        Task<IDataResult<List<Skin>>> GetAll();
        Task<IDataResult<Skin>> GetById(int skinId);
        Task<IDataResult<List<SkinDetailDto>>> GetSkinDetails();
    }
}
