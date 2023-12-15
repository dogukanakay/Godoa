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
    public class EfVirtualCurrencyTypeDal : EfEntityRepositoryBase<VirtualCurrencyType, GodoaContext>, IVirtualCurrencyTypeDal
    {
        private IQueryable<VirtualCurrencyTypeDetailDto> GetCoinTypeDetailQuery(GodoaContext context)
        {
            return from v in context.VirtualCurrencyTypes
                   join g in context.Games on v.GameId equals g.GameId
                   select new VirtualCurrencyTypeDetailDto
                   {
                       VirtualCurrencyTypeId = v.VirtualCurrencyTypeId,
                       VirtualCurrencyTypeName=v.VirtualCurrencyTypeName,
                       GameName=g.GameName

                   };

        }
        public async Task<List<VirtualCurrencyTypeDetailDto>> GetCoinTypeDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetCoinTypeDetailQuery(context);
                return await result.ToListAsync();
            }
        }
    }
}
