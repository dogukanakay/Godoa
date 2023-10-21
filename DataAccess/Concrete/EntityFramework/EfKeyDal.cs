using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfKeyDal : EfEntityRepositoryBase<Keys, GodoaContext>, IKeyDal
    {
        private IQueryable<KeyDetailDto> GetKeyDetailQuery(GodoaContext context) 
        {
            return from g in context.Keys
                   join ur in context.Games on g.GameId equals ur.GameId
                   select new KeyDetailDto
                   {
                       KeyId = g.KeyId,
                       GameName=ur.GameName,
                       KeyDetail=g.KeyDetail,
                       EndDate=g.EndDate
                   };
        }
        public List<KeyDetailDto> GetKeyDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetKeyDetailQuery(context).ToList();
                return result.ToList();
            }
        }
    }
}
