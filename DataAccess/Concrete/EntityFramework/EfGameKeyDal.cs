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
        private IQueryable<GameKeyDetailDto> GetGameKeysByProductId(GodoaContext context, int productId)
        {
            return from gk in context.GameKeys
                   join g in context.Games on gk.GameId equals g.GameId
                   join p in context.Products on gk.ProductId equals p.ProductId
                   where gk.ProductId == productId && !gk.IsUsed
                   select new GameKeyDetailDto
                   {
                       GameKeyId = gk.GameKeyId,
                       GameName = g.GameName,
                       ProductName = p.ProductName,
                       KeyDetail = gk.KeyOfGame
                      
                   };
        }
        //public async Task<int> GetStockQuantityOfProduct(int productId)
        //{
        //    using (GodoaContext context = new GodoaContext())
        //    {
        //        var result = GetGameKeysByProductId(context, productId);
        //        return await result.CountAsync();
        //    }
            
        //}
    }
}
