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
    public class EfInGameCoinDal : EfEntityRepositoryBase<InGameCoin, GodoaContext>, IInGameCoinDal
    {
        private IQueryable<InGameCoinDetailDto> GetInGameCoinDetailQuery(GodoaContext context)
        {
            return from i in context.inGameCoins
                   join ct in context.CoinTypes on i.CoinTypeId equals ct.CoinTypeId
                   select new InGameCoinDetailDto
                   {
                       InGameCoinId = i.InGameCoinId,
                       CoinTypeName=ct.CoinTypeName,
                       Amount=i.Amount,
                       Price=i.Price,
                       Status=i.Status,
                       Stock=i.Stock,
                       ImagePath=i.ImagePath,

                   };
        }
        public List<InGameCoinDetailDto> GetInGameCoinDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetInGameCoinDetailQuery(context).ToList();
                return result.ToList();

            }
        }
    }
}
