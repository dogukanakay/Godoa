using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, GodoaContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = from claims in context.OperationClaims
                             join userclaims in context.UserOperationClaims
                             on claims.ClaimId equals userclaims.ClaimId
                             where userclaims.UserId == user.UserId
                             select new OperationClaim { ClaimId = claims.ClaimId, ClaimName = claims.ClaimName };
                return result.ToList();
            }
        }

    }
}
