using Business.Abstract;
using Core.Aspects.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        IGameKeyDal _gameKeyDal;
        IVirtualCurrencyDal _virtualCurrencyDal;
        public ProductManager(IProductDal productDal, IGameKeyDal gameKeyDal, IVirtualCurrencyDal virtualCurrencyDal)
        {
            _productDal = productDal;
            _gameKeyDal = gameKeyDal;
            _virtualCurrencyDal = virtualCurrencyDal;
        }
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult("Silindi");
        }

        public async Task<IDataResult<Product>> GetById(int productId)
        {
            return new SuccessDataResult<Product>(await _productDal.Get(p => p.ProductId == productId));
        }


        public async Task<IDataResult<List<Product>>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(await _productDal.GetAll(), "Veriler Getirildi");
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult("Güncellendi");
        }
        public async Task<IDataResult<List<ProductDetailDto>>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(await _productDal.GetProductDetails(), "Product detaylı bilgileri getirildi");
        }

        public async Task<IDataResult<List<ProductDetailDto>>> GetProductDetailsByCategory(ProductCategory productCategory)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(await _productDal.GetProductDetailsByCategory(productCategory));
        }

        //public async Task<int> GetStockQuantityByProductId(int productId, int productCategoryId)
        //{
        //    if (productCategoryId == 1)
        //    {
        //        return await _gameKeyDal.GetStockQuantityOfProduct(productId);
        //    }
        //    else if (productCategoryId == 0)
        //    {
        //        return await _virtualCurrencyDal.GetStockQuantityOfProduct(productId);
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
    }
}
