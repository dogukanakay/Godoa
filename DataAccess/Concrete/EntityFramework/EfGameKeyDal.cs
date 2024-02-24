using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
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
    public class EfGameKeyDal : EfEntityRepositoryBase<GameKey, GodoaContext>, IGameKeyDal
    {
        private IQueryable<GameKeyDetailDto> GetGameKeyDetailsQuery(GodoaContext context)
        {
            return from gk in context.GameKeys
                   join g in context.Games on gk.GameId equals g.GameId
                   join p in context.Products on gk.ProductId equals p.ProductId
                   select new GameKeyDetailDto
                   {
                       GameId = gk.GameId,
                       ProductId = gk.ProductId,
                       GameKeyId = gk.GameKeyId,
                       GameName = g.GameName,
                       ProductName = p.ProductName,
                       KeyDetail = gk.KeyOfGame,
                       IsUsed = gk.IsUsed == false ? "Kullanılabilir" : "Kullanıldı"
                      
                   };
        }
      

        public async Task<List<GameKeyDetailDto>> GetGameKeyDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetGameKeyDetailsQuery(context).OrderByDescending(gk => gk.IsUsed);
                return await result.ToListAsync();
            }
        }
    }
}
