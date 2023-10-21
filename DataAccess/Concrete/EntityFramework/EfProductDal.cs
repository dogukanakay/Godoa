﻿using Core.DataAccess.EntityFramework;
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
            return from p in context.Products
                   join s in context.Skins on p.SkinId equals s.SkinId
                   join gk in context.GameKeys on p.GameKeyId equals gk.GameKeyId
                   join k in context.Keys on gk.KeyId equals k.KeyId
                   join i in context.inGameCoins on p.InGameCoinId equals i.InGameCoinId
                   join ct in context.CoinTypes on i.CoinTypeId equals ct.CoinTypeId
                   select new ProductDetailDto
                   {
                       ProductId = p.ProductId,
                       ProductName = p.ProductName,
                       SkinName=s.SkinName,
                       GameKeyDetail=k.KeyDetail,
                       InGameCoinName=ct.CoinTypeName

                   };
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetProductDetailQuery(context);
                return result.ToList();
            }
        }

    }
}
