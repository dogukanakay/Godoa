using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserClaimDal : EfEntityRepositoryBase<UserOperationClaim, GodoaContext>, IUserOperationClaimDal
    {
        private IQueryable<UserClaimDetailDto> GetUserClaimDetailQuery(GodoaContext context)
        {
            return from u in context.UserOperationClaims
                   join us in context.Users on u.UserId equals us.UserId
                   join cl in context.OperationClaims on u.ClaimId equals cl.ClaimId
                   select new UserClaimDetailDto
                   {
                       UserClaimId = u.UserId,
                       UserName=us.UserName,
                       ClaimName=cl.ClaimName
                   };
        }
        public List<UserClaimDetailDto> GetUserClaimDetails()
        {
            using(GodoaContext context = new GodoaContext())
            {
                var result= GetUserClaimDetailQuery(context).ToList();
                return result.ToList();
            }
        }
    }
}
