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
    public class EfVirtualCurrencyDal : EfEntityRepositoryBase<VirtualCurrency, GodoaContext>, IVirtualCurrencyDal
    {
        private IQueryable<VirtualCurrencyDetailDto> GetVirtualCurrencyKeysByProductId(GodoaContext context, int productId)
        {
            return from v in context.VirtualCurrencies
                   join vc in context.VirtualCurrencyTypes on v.CurrencyTypeId equals vc.VirtualCurrencyTypeId
                   join g in context.Games on vc.GameId equals g.GameId
                   join p in context.Products on v.ProductId equals p.ProductId
                   where v.ProductId == productId && !v.IsUsed
                   select new VirtualCurrencyDetailDto
                   {
                       CurrencyId = v.CurrencyId,
                       GameName = g.GameName,
                       ProductName = p.ProductName,
                       CurrencyKey = v.CurrencyKey,
                   };
        }
        //public async Task<int> GetStockQuantityOfProduct(int productId)
        //{
        //    using (GodoaContext context = new GodoaContext())
        //    {
        //        var result = GetVirtualCurrencyKeysByProductId(context, productId);
        //        return await result.CountAsync();
        //    }

        //}
    }
}
