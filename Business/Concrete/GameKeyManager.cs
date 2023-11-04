using Business.Abstract;
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
        public IResult Add(GameKey gameKey)
        {
            _gameKeyDal.Add(gameKey);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(GameKey gameKey)
        {
            _gameKeyDal.Delete(gameKey);
            return new SuccessResult("Silindi");
        }

        public async Task<IDataResult<GameKey>> GetById(int gameKeyId)
        {
            return new SuccessDataResult<GameKey>(await _gameKeyDal.Get(s => s.GameKeyId == gameKeyId));

        }

        public async Task<IDataResult<List<GameKey>>> GetAll()
        {
            return new SuccessDataResult<List<GameKey>>(await _gameKeyDal.GetAll(), "Verileri Getirildi");
        }

        public IResult Update(GameKey gameKey)
        {
            _gameKeyDal.Update(gameKey);
            return new SuccessResult("Güncellendi");
        }

        public async Task<IDataResult<List<GameKeyDetailDto>>> GetGameKeyDetails()
        {
            return new SuccessDataResult<List<GameKeyDetailDto>>(await _gameKeyDal.GetGameKeyDetails(), "GameKey detaylı bilgileri getirildi.");
        }
    }
}
