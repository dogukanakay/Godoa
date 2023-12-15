using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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
   // [SecuredOperation("admin")]
    [LogAspect(typeof(FileLogger))]
    public class ClaimManager : IOperationClaimService
    {
        IOperationClaimDal _claimDal;
        public ClaimManager(IOperationClaimDal claimDal)
        {
            _claimDal = claimDal;
        }

        public IResult Add(OperationClaim claim)
        {
            _claimDal.Add(claim);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(OperationClaim claim)
        {
            _claimDal.Delete(claim);
            return new SuccessResult("Silindi");
        }

        public async Task<IDataResult<OperationClaim>> GetById(int claimId)
        {
            return new SuccessDataResult<OperationClaim>(await _claimDal.Get(c=>c.ClaimId == claimId ));
        }

        public async Task<IDataResult<List<OperationClaim>>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(await _claimDal.GetAll(), "Veriler Getirildi");
        }

        public IResult Update(OperationClaim claim)
        {
            _claimDal.Update(claim);
            return new SuccessResult("Güncellendi");
        }
    }
}
