using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductCategoryManager : IProductCategoryService
    {
        IProductCategoryDal _productCategoryDal;
        public ProductCategoryManager(IProductCategoryDal productCategoryDal)
        {
            _productCategoryDal = productCategoryDal;
        }
        public IResult Add(ProductCategory productCategory)
        {
            _productCategoryDal.Add(productCategory);
            return new SuccessResult();
        }

        public IResult Delete(ProductCategory productCategory)
        {
            _productCategoryDal.Delete(productCategory);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<ProductCategory>>> GetAll()
        {
            return new SuccessDataResult<List<ProductCategory>>(await _productCategoryDal.GetAll());
        }

        public async Task<IDataResult<ProductCategory>> GetById(int productCategoryId)
        {
            return new SuccessDataResult<ProductCategory>(await _productCategoryDal.Get(pc => pc.ProductCategoryId == productCategoryId));
        }

        public IResult Update(ProductCategory productCategory)
        {
            _productCategoryDal.Update(productCategory);
            return new SuccessResult();
        }
    }
}
