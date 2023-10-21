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
            return from g in context.inGameCoins
                   join ya in context.CoinTypes on g.CoinTypeId equals ya.CoinTypeId
                   select new InGameCoinDetailDto
                   {
                       InGameCoinId = g.InGameCoinId,
                       CoinTypeName=ya.CoinTypeName,
                       Amount=g.Amount,
                       Price=g.Price,
                       Status=g.Status,
                       Stock=g.Stock,
                       ImagePath=g.ImagePath,

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
