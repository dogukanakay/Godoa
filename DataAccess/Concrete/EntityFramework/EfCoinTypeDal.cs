using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCoinTypeDal : EfEntityRepositoryBase<CoinType, GodoaContext>, ICoinTypeDal
    {
        private IQueryable<CoinTypeDetailDto> GetCoinTypeDetailQuery(GodoaContext context)
        {
            return from g in context.CoinTypes
                   join r in context.Games on g.GameId equals r.GameId
                   select new CoinTypeDetailDto
                   {
                       CoinTypeId = g.CoinTypeId,
                       CoinTypeName=g.CoinTypeName,
                       GameName=r.GameName

                   };

        }
        public List<CoinTypeDetailDto> GetCoinTypeDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetCoinTypeDetailQuery(context).ToList();
                return result.ToList();
            }
        }
    }
}
