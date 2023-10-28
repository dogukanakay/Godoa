using Core.Entities.Concrete;
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
    public interface IUserClaimService
    {
        IResult Add(UserOperationClaim userClaim);
        IResult Delete(UserOperationClaim userClaim);
        IResult Update(UserOperationClaim userClaim);

        IDataResult<List<UserOperationClaim>> GetAll();
        IDataResult<UserOperationClaim> GetById(int userClaimId);
        IDataResult<List<UserClaimDetailDto>> GetUserClaimDetails();
    }
}
