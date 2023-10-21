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
    public class EfGameKeyDal : EfEntityRepositoryBase<GameKey, GodoaContext>,IGameKeyDal
    {
       

        private IQueryable<GameKeyDetailDto> GetGameKeyDetailQuery(GodoaContext context)
        {
            return from gk in context.GameKeys 
                   join g in context.Games on gk.GameId equals g.GameId
                   join k in context.Keys on gk.KeyId equals k.KeyId

                   select new GameKeyDetailDto
                   {
                       GameKeyId=gk.GameKeyId,
                       GameName = g.GameName,
                       KeyDetail = k.KeyDetail,
                       Stock = gk.Stock,
                       Price= gk.Price,
                       Status= gk.Status

                   };
        }

        public List<GameKeyDetailDto> GetGameKeyDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetGameKeyDetailQuery(context);
                return result.ToList();

            }
        }

    }
}
