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
    public class EfProductDal : EfEntityRepositoryBase<Product, GodoaContext>, IProductDal
    {
        private IQueryable<ProductDetailDto> GetProductDetailQuery(GodoaContext context) 
        {
            return from g in context.Products
                   join c in context.Skins on g.SkinId equals c.SkinId
                   join u in context.GameKeys on g.GameKeyId equals u.GameKeyId
                   join da in context.Keys on u.KeyId equals da.KeyId
                   join or in context.inGameCoins on g.InGameCoinId equals or.InGameCoinId
                   join na in context.CoinTypes on or.CoinTypeId equals na.CoinTypeId
                   select new ProductDetailDto
                   {
                       ProductId = g.ProductId,
                       ProductName = g.ProductName,
                       SkinName=c.SkinName,
                       GameKeyDetail=da.KeyDetail,
                       InGameCoinName=na.CoinTypeName

                   };
        }
        List<ProductDetailDto> IProductDal.GetProductDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetProductDetailQuery(context);
                return result.ToList();
            }
        }
    }
}
