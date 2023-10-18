using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ClaimManager : IClaimService
    {
        IClaimDal _claimDal;
        public ClaimManager(IClaimDal claimDal)
        {
            _claimDal = claimDal;
        }

        public IResult Add(Claim claim)
        {
            _claimDal.Add(claim);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(Claim claim)
        {
            _claimDal.Delete(claim);
            return new SuccessResult("Silindi");
        }

        public IDataResult<Claim> GetById(int claimId)
        {
            return new SuccessDataResult<Claim>(_claimDal.Get(c=>c.ClaimId == claimId ));
        }

        public IDataResult<List<Claim>> GetAll()
        {
            return new SuccessDataResult<List<Claim>>(_claimDal.GetAll(), "Veriler Getirildi");
        }

        public IResult Update(Claim claim)
        {
            _claimDal.Update(claim);
            return new SuccessResult("Güncellendi");
        }
    }
}
