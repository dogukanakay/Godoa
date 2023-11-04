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
    public class GameManager:IGameService
    {
        IGameDal _gameDal;
        public GameManager(IGameDal gameDal)
        {
            _gameDal = gameDal;
        }
        public IResult Add(Game game)
        {
            _gameDal.Add(game);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(Game game)
        {
            _gameDal.Delete(game);
            return new SuccessResult("Silindi");
        }

        public async Task<IDataResult<Game>> GetById(int gameId)
        {
            return new SuccessDataResult<Game>(await _gameDal.Get(s => s.GameId == gameId));

        }

        public async Task<IDataResult<List<Game>>> GetAll()
        {
            return new SuccessDataResult<List<Game>>(await _gameDal.GetAll(), "Verileri Getirildi");
        }

        public IResult Update(Game game)
        {
            _gameDal.Update(game);
            return new SuccessResult("Güncellendi");
        }

        public async Task<IDataResult<List<GameDetailDto>>> GetGameDetails()
        {
            return new SuccessDataResult<List<GameDetailDto>>(await _gameDal.GetGameDetails(), "Oyunun detaylı bilgileri getirildi");
        }
    }
}
