using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        Task<IDataResult<List<User>>> GetAll();
        Task<IDataResult<User>> GetById(int userId);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        
    }
}
