using Core.Utilities.Results;
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
        Task<IResult> UpdateStatus(int producId);

        Task<IDataResult<List<Product>>> GetAll();
        Task<IDataResult<Product>> GetById(int productId);
        Task<IDataResult<List<ProductDetailDto>>> GetProductDetails();
<<<<<<< HEAD
        Task<IDataResult<List<ProductDetailDto>>> GetProductDetailsByCategory(ProductCategory productCategory);
        // Task<int> GetStockQuantityByProductId(int productId, int productCategoryId);
=======

       // Task<int> GetStockQuantityByProductId(int productId, int productCategoryId);
>>>>>>> db4722c4c4a36d55cae5aaa0371e864f4a1da301
    }
}
