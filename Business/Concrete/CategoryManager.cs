using Business.Abstract;
using Business.Constants;
using Core.Aspects.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult("Eklendi");
        }
        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult("Silindi");
        }

        public async Task<IDataResult<Category>> GetById(int categoryId)
        {
            return  new SuccessDataResult<Category>(await _categoryDal.Get(c => c.CategoryId == categoryId),Messages.ExampleSuccess);
        
        }
        [CacheAspect]
        public async Task<IDataResult<List<Category>>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(await _categoryDal.GetAll(),"Verileri Getirildi");
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult("Güncellendi");
        }
    }
}
