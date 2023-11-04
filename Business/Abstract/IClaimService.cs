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
    public interface IClaimService
    {

        IResult Add(OperationClaim claim);
        IResult Delete(OperationClaim claim);
        IResult Update(OperationClaim claim);

        Task<IDataResult<List<OperationClaim>>> GetAll();
        Task<IDataResult<OperationClaim>> GetById(int claimId);


    }
}
