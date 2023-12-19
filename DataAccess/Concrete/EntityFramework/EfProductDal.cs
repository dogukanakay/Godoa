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
    public class EfProductDal : EfEntityRepositoryBase<Product, GodoaContext>, IProductDal
    {
        

        private IQueryable<ProductDetailDto> GetProductDetailQuery(GodoaContext context) 
        {
            return from p in context.Products
                   join pg in context.ProductCategories on p.ProductCategoryId equals pg.ProductCategoryId
                   join g in context.Games on p.GameId equals g.GameId
                  
                   select new ProductDetailDto
                   {
                      ProductId = p.ProductId,
                      ProductCategoryName =pg.ProductCategoryName,
                      GameName = g.GameName,
                      ProductName = p.ProductName,
                      Description = p.Description,
                      Price = p.Price,
                      StockQuantity = pg.ProductCategoryId == 2 ?
                               context.GameKeys.Count(gk => gk.ProductId == p.ProductId && !gk.IsUsed) :
                               context.VirtualCurrencies.Count(vc => vc.ProductId == p.ProductId && !vc.IsUsed),
                      Status = p.Status

                   };
        }

        public async Task<List<ProductDetailDto>> GetProductDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetProductDetailQuery(context);
                return await result.ToListAsync();
            }
        }

    }
}
