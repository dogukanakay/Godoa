using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IKeysService
    {
        IResult Add(Keys keys);
        IResult Delete(Keys keys);
        IResult Update(Keys keys);

        IDataResult<List<Keys>> GetAll();
        IDataResult<Keys> Get();
    }
}
