using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserClaimManager : IUserClaimService
    {
        IUserOperationClaimDal _userClaimDal;
        public UserClaimManager(IUserOperationClaimDal userClaimDal)
        {
            _userClaimDal = userClaimDal;
        }


        public IResult Add(UserOperationClaim userClaim)
        {
            _userClaimDal.Add(userClaim);
            return new SuccessResult("Rol Eklendi");
        }

        public IResult Delete(UserOperationClaim userClaim)
        {
            _userClaimDal.Delete(userClaim);
            return new SuccessResult("Rol Silindi");
        }

        public async Task<IDataResult<List<UserOperationClaim>>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(await _userClaimDal.GetAll());
        }

        public async Task<IDataResult<UserOperationClaim>> GetById(int userClaimId)
        {
            return new SuccessDataResult<UserOperationClaim>(await _userClaimDal.Get(uc => uc.UserClaimId == userClaimId));
        }

        public IResult Update(UserOperationClaim userClaim)
        {
            _userClaimDal.Update(userClaim);
            return new SuccessResult();
        }
        public async Task<IDataResult<List<UserClaimDetailDto>>> GetUserClaimDetails()
        {
            return new SuccessDataResult<List<UserClaimDetailDto>>(await _userClaimDal.GetUserClaimDetails(), "UserClaim detaylı bilgileri getirildi.");
        }

       
    }
}
