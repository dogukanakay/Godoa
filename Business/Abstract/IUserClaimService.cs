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

        Task<IDataResult<List<UserOperationClaim>>> GetAll();
        Task<IDataResult<UserOperationClaim>> GetById(int userClaimId);
        Task<IDataResult<List<UserClaimDetailDto>>> GetUserClaimDetails();
    }
}
