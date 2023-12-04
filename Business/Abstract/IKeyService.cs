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
    public interface IKeyService
    {
        IResult Add(Keys keys);
        IResult Delete(Keys keys);
        IResult Update(Keys keys);

        Task<IDataResult<List<Keys>>> GetAll();
        Task<IDataResult<Keys>> GetById(int keysId);
        Task<IDataResult<List<KeyDetailDto>>> GetKeyDetails();
    }
}
