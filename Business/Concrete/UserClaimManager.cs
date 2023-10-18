using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserClaimManager : IUserClaimService
    {
        IUserClaimDal _userClaimDal;
        public UserClaimManager(IUserClaimDal userClaimDal)
        {
            _userClaimDal = userClaimDal;
        }


        public IResult Add(UserClaim userClaim)
        {
            _userClaimDal.Add(userClaim);
            return new SuccessResult("Rol Eklendi");
        }

        public IResult Delete(UserClaim userClaim)
        {
            _userClaimDal.Delete(userClaim);
            return new SuccessResult("Rol Silindi");
        }

        public IDataResult<List<UserClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserClaim>>(_userClaimDal.GetAll());
        }

        public IDataResult<UserClaim> GetById(int userClaimId)
        {
            return new SuccessDataResult<UserClaim>(_userClaimDal.Get(uc => uc.UserClaimId == userClaimId));
        }

        public IResult Update(UserClaim userClaim)
        {
            _userClaimDal.Update(userClaim);
            return new SuccessResult();
        }
    }
}
