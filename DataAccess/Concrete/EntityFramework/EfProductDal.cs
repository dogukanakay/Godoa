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
                       ProductCategoryId = p.ProductCategoryId,
                       ProductCategoryName = pg.ProductCategoryName,
                       ProductName = p.ProductName,
                       GameName = g.GameName,
                       Description = p.Description,
                       Price = p.Price,
                       StockQuantity = pg.ProductCategoryId == 2 ?
                                context.VirtualCurrencies.Count(vc => vc.ProductId == p.ProductId && !vc.IsUsed) :
                               context.GameKeys.Count(gk => gk.ProductId == p.ProductId && !gk.IsUsed)
                               ,
                       Status = p.Status,


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

        public async Task<List<ProductDetailDto>> GetProductDetailsByCategory(int categoryId)
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetProductDetailQuery(context).Where(p => p.ProductCategoryId == categoryId);
                return await result.ToListAsync();
            }
        }
    }
}
