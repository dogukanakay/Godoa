using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
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
            return from c in context.CoinTypes
                   join g in context.Games on c.GameId equals g.GameId
                   select new CoinTypeDetailDto
                   {
                       CoinTypeId = c.CoinTypeId,
                       CoinTypeName=c.CoinTypeName,
                       GameName=g.GameName

                   };

        }
        public async Task<List<CoinTypeDetailDto>> GetCoinTypeDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetCoinTypeDetailQuery(context);
                return await result.ToListAsync();
            }
        }
    }
}
