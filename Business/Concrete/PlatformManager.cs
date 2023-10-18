using Business.Abstract;
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
    public class PlatformManager : IPlatformService
    {
        IPlatformDal _platformDal;
        public PlatformManager(IPlatformDal platformDal)
        {
            _platformDal = platformDal;
        }
        public IResult Add(Platform platform)
        {
            _platformDal.Add(platform);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(Platform platform)
        {
            _platformDal.Delete(platform);
            return new SuccessResult("Silindi");
        }

        public IDataResult<Platform> GetById(int platformId)
        {
            return new SuccessDataResult<Platform>(_platformDal.Get(p => p.PlatformId == platformId));
        }

        public IDataResult<List<Platform>> GetAll()
        {
            return new SuccessDataResult<List<Platform>>(_platformDal.GetAll(), "Veriler Getirildi");
        }

        public IResult Update(Platform platform)
        {
            _platformDal.Update(platform);
            return new SuccessResult("Güncellendi");
        }
    }
}
