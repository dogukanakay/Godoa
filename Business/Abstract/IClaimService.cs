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

        IResult Add(Claim claim);
        IResult Delete(Claim claim);
        IResult Update(Claim claim);

        IDataResult<List<Claim>> GetAll();
        IDataResult<Claim> GetById(int claimId);


    }
}
