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
    public class EfGameKeyDal : EfEntityRepositoryBase<GameKey, GodoaContext>, IGameKeyDal
    {
        private IQueryable<GameKeyDetialDto> GetGameKeyDetailQuery(GodoaContext context)
        {
            return from g in context.GameKeys 
                   join or in context.Games on g.GameId equals or.GameId
                   join ot in context.Keys on g.KeyId equals ot.KeyId

                   select new GameKeyDetialDto
                   {
                       GameKeyId=g.GameKeyId,
                       GameName = or.GameName,
                       KeyDetail = ot.KeyDetail,
                       Stock = g.Stock,
                       Price= g.Price,
                       Status= g.Status

                   };
        }
        List<GameKeyDetialDto> IGameKeyDal.GetGameKeyDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetGameKeyDetailQuery(context).ToList();
                return result.ToList();

            }
        }
    }
}
