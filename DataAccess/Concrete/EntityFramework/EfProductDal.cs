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
                  
                   select new ProductDetailDto
                   {
                      ProductId = p.ProductId,
                      ProductCategoryName =pg.ProductCategoryName,
                      ProductName = p.ProductName,
                      Description = p.Description,
                      Price = p.Price,
                      StockQuantity = p.StockQuantity,
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
