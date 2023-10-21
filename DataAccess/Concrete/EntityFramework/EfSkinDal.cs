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
            return from g in context.Skins
                   join r in context.Sellers on g.SellerId equals r.SellerId
                   join or in context.Users on r.UserID equals or.UserId
                   join po in context.Games on g.GameId equals po.GameId
                   select new SkinDetailDto
                   {
                       SkinId=g.SkinId,
                       SkinName=g.SkinName,
                       SellerName=or.UserName,
                       GameName=po.GameName,
                       Price=g.Price,
                       ImagePath=g.ImagePath,
                       Description=g.Description,
                       Statu=g.Statu
                   };
        }
        List<SkinDetailDto> ISkinDal.GetSkinDetails()
        {
            using(GodoaContext context=new GodoaContext())
            {
                var result=GetSkinDetailQuery(context).ToList();
                return result.ToList();

            }
        }
    }
}
