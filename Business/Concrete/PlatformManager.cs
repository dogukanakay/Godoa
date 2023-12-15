using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
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
    public class PlatformManager : IPlatformService
    {
        IPlatformDal _platformDal;
        public PlatformManager(IPlatformDal platformDal)
        {
            _platformDal = platformDal;
        }
        [LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(PlatformValidator))]
        [CacheRemoveAspect("IPlatformService.Get")]
        //[SecuredOperation("admin,employee")]
        public IResult Add(Platform platform)
        {
            _platformDal.Add(platform);
            return new SuccessResult("Eklendi");
        }
        [CacheRemoveAspect("IPlatformService.Get")]
        //[SecuredOperation("admin,employee")]
        public IResult Delete(Platform platform)
        {
            _platformDal.Delete(platform);
            return new SuccessResult("Silindi");
        }

        [CacheAspect]
        public async Task<IDataResult<Platform>> GetById(int platformId)
        {
            return new SuccessDataResult<Platform>(await _platformDal.Get(p => p.PlatformId == platformId));
        }

        [CacheAspect]
        public async Task<IDataResult<List<Platform>>> GetAll()
        {
            return new SuccessDataResult<List<Platform>>(await _platformDal.GetAll(), "Veriler Getirildi");
        }

        [CacheRemoveAspect("IPlatformService.Get")]
        [ValidationAspect(typeof(PlatformValidator))]
        //[SecuredOperation("admin,employee")]
        public IResult Update(Platform platform)
        {
            _platformDal.Update(platform);
            return new SuccessResult("Güncellendi");
        }
    }
}
