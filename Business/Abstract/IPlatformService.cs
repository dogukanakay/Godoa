using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPlatformService
    {
        IResult Add(Platform platform);
        IResult Delete(Platform platform);
        IResult Update(Platform platform);

        IDataResult<List<Platform>> GetAll();
        IDataResult<Platform> Get();
    }
}
