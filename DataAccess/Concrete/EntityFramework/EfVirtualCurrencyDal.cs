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
        private IQueryable<VirtualCurrencyDetailDto> GetVirtualCurrencyDetailsQuery(GodoaContext context)
        {
            return from vc in context.VirtualCurrencies
                   join vct in context.VirtualCurrencyTypes on vc.CurrencyTypeId equals vct.VirtualCurrencyTypeId
                   join g in context.Games on vct.GameId equals g.GameId
                   join p in context.Products on vc.ProductId equals p.ProductId
                   select new VirtualCurrencyDetailDto
                   {
                       CurrencyId = vc.CurrencyId,
                       CurrencyTypeId = vc.CurrencyTypeId,
                       ProductId = p.ProductId,
                       CurrencyTypeName = vct.VirtualCurrencyTypeName,
                       GameName = g.GameName,
                       ProductName = p.ProductName,
                       CurrencyKey = vc.CurrencyKey,
                       IsUsed = vc.IsUsed == false ? "Kullanılabilir" : "Kullanıldı"
                   };
        }


        public async Task<List<VirtualCurrencyDetailDto>> GetVirtualCurrencyDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetVirtualCurrencyDetailsQuery(context).OrderByDescending(vc => vc.IsUsed);
                return await result.ToListAsync();
            }
        }
    }
}
