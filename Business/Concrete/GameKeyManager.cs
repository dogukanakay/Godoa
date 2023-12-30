using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Caching;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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
    public class GameKeyManager:IGameKeyService
    {
        IGameKeyDal _gameKeyDal;
        public GameKeyManager(IGameKeyDal gameKeyDal)
        {
            _gameKeyDal = gameKeyDal;
        }
        //[SecuredOperation("admin,employee")]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IGameKeyService.Get")]
        public IResult Add(GameKey gameKey)
        {
            _gameKeyDal.Add(gameKey);
            return new SuccessResult("Eklendi");
        }
       // [SecuredOperation("admin,employee")]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IGameKeyService.Get")]
        public IResult Delete(GameKey gameKey)
        {
            _gameKeyDal.Delete(gameKey);
            return new SuccessResult("Silindi");
        }
        [CacheAspect]
        public async Task<IDataResult<GameKey>> GetById(int gameKeyId)
        {
            return new SuccessDataResult<GameKey>(await _gameKeyDal.Get(s => s.GameKeyId == gameKeyId));

        }
        [CacheAspect]
        public async Task<IDataResult<List<GameKey>>> GetAll()
        {
            return new SuccessDataResult<List<GameKey>>(await _gameKeyDal.GetAll(), "Verileri Getirildi");
        }

       // [SecuredOperation("admin,employee")]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IGameKeyService.Get")]
        public IResult Update(GameKey gameKey)
        {
            _gameKeyDal.Update(gameKey);
            return new SuccessResult("Güncellendi");
        }

        public async Task<IDataResult<GameKey>> GetIfİnStockByProductId(int productId)
        {
            return new SuccessDataResult<GameKey>(await _gameKeyDal.Get(gk => gk.ProductId == productId && gk.IsUsed == false));
        }
    }
}
