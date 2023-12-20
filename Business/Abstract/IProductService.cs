﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);

        Task<IDataResult<List<Product>>> GetAll();
        Task<IDataResult<Product>> GetById(int productId);
        Task<IDataResult<List<ProductDetailDto>>> GetProductDetails();
        Task<IDataResult<List<ProductDetailDto>>> GetProductDetailsByCategory(ProductCategory productCategory);
        // Task<int> GetStockQuantityByProductId(int productId, int productCategoryId);
    }
}
