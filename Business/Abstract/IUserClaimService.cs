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
    public interface IUserClaimService
    {
        IResult Add(UserClaim userClaim);
        IResult Delete(UserClaim userClaim);
        IResult Update(UserClaim userClaim);

        IDataResult<List<UserClaim>> GetAll();
        IDataResult<UserClaim> Get();
    }
}
