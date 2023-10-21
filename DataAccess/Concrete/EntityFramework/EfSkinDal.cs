using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSkinDal : EfEntityRepositoryBase<Skin, GodoaContext>, ISkinDal
    {
        

        private IQueryable <SkinDetailDto> GetSkinDetailQuery(GodoaContext context)
        {
            return from s in context.Skins
                   join se in context.Sellers on s.SellerId equals se.SellerId
                   join u in context.Users on se.UserID equals u.UserId
                   join g in context.Games on s.GameId equals g.GameId
                   select new SkinDetailDto
                   {
                       SkinId=s.SkinId,
                       SkinName=s.SkinName,
                       SellerName=u.UserName,
                       GameName=g.GameName,
                       Price=s.Price,
                       ImagePath=s.ImagePath,
                       Description=s.Description,
                       Statu=s.Statu
                   };
        }

        public List<SkinDetailDto> GetSkinDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetSkinDetailQuery(context).ToList();
                return result.ToList();

            }
        }

    }
}
