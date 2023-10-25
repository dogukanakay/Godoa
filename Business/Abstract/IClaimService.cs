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

        IDataResult<List<OperationClaim>> GetAll();
        IDataResult<OperationClaim> GetById(int claimId);


    }
}
