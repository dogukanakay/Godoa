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
    public interface IProductCategoryService
    {
        IResult Add(ProductCategory productCategory);
        IResult Delete(ProductCategory productCategory);
        IResult Update(ProductCategory productCategory);

        Task<IDataResult<List<ProductCategory>>> GetAll();
        Task<IDataResult<ProductCategory>> GetById(int productCategoryId);
        
    }
}
