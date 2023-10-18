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
    public class GameTypeManager:IGameTypeService
    {
        IGameTypeDal _gameTypeDal;
        public IResult Add(GameType gameType)
        {
            _gameTypeDal.Add(gameType);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(GameType gameType)
        {
            _gameTypeDal.Delete(gameType);
            return new SuccessResult("Silindi");
        }

        public IDataResult<GameType> GetById(int gameTypeId)
        {
            return new SuccessDataResult<GameType>(_gameTypeDal.Get(s => s.GameTypeId == gameTypeId));

        }

        public IDataResult<List<GameType>> GetAll()
        {
            return new SuccessDataResult<List<GameType>>(_gameTypeDal.GetAll(), "Verileri Getirildi");
        }

        public IResult Update(GameType gameType)
        {
            _gameTypeDal.Update(gameType);
            return new SuccessResult("Güncellendi");
        }
    }
}
