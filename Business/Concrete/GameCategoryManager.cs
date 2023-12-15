using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Caching;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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
    public class GameCategoryManager : IGameCategoryService
    {
        IGameCategoryDal _gameCategoryDal;
        public GameCategoryManager(IGameCategoryDal gameCategoryDal)
        {
            _gameCategoryDal = gameCategoryDal;
        }
      //  [SecuredOperation("admin,employee")]
        [CacheRemoveAspect("IGameCategoryService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Add(GameCategory gameCategory)
        {
            _gameCategoryDal.Add(gameCategory);
            return new SuccessResult("Eklendi");
        }
  
       // [SecuredOperation("admin,employee")]
        [CacheRemoveAspect("IGameCategoryService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(GameCategory gameCategory)
        {
            _gameCategoryDal.Delete(gameCategory);
            return new SuccessResult("Silindi");
        }
        [CacheAspect]
        public async Task<IDataResult<GameCategory>> GetById(int gameCategoryId)
        {
            return  new SuccessDataResult<GameCategory>(await _gameCategoryDal.Get(gk => gk.GameCategoryId == gameCategoryId),Messages.ExampleSuccess);
        
        }
        [CacheAspect]
        public async Task<IDataResult<List<GameCategory>>> GetAll()
        {
            return new SuccessDataResult<List<GameCategory>>(await _gameCategoryDal.GetAll(),"Verileri Getirildi");
        }

        [CacheRemoveAspect("IGameCategoryService.Get")]
       // [SecuredOperation("admin,employee")]
        [LogAspect(typeof(FileLogger))]
        public IResult Update(GameCategory gameCategory)
        {
            _gameCategoryDal.Update(gameCategory);
            return new SuccessResult("Güncellendi");
        }
    }
}
