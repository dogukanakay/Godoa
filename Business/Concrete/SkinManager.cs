using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SkinManager : ISkinService
    {
        ISkinDal _skinDal;

        public SkinManager(ISkinDal skinDal)
        {
            _skinDal = skinDal; 
        }
        public IResult Add(Skin skin)
        {
            _skinDal.Add(skin);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(Skin skin)
        {
            _skinDal.Delete(skin);
            return new SuccessResult("Silindi");
        }

        public IDataResult<Skin> GetById(int skinId)
        {
            return new SuccessDataResult<Skin>(_skinDal.Get(s=>s.SkinId==skinId),skinId+" idli Skin Getirildi");
        }

        public IDataResult<List<Skin>> GetAll()
        {
            return new SuccessDataResult<List<Skin>>(_skinDal.GetAll(),"Veriler Getirildi");
        }

        public IResult Update(Skin skin)
        {
            _skinDal.Update(skin);
            return new SuccessResult("Güncellendi");
        }
    }
}
