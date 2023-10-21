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
    public class EfSellerDal : EfEntityRepositoryBase<Seller, GodoaContext>, ISellerDal
    {
        private IQueryable<SellerDetailDto> GetSellerDetailQuery(GodoaContext context)
        {
            return from g in context.Sellers
                   join ur in context.Users on g.UserID equals ur.UserId
                   select new SellerDetailDto
                   {
                       SellerId = g.SellerId,
                       UserName = ur.UserName,
                       NationalityIdentity = g.NationalityIdentity,
                       Adress = g.Adress,
                       SalesScore=g.SalesScore
                   };
        }
        public List<SellerDetailDto> GetSellerDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetSellerDetailQuery(context).ToList();
                return result.ToList();
            }
        }
    }
}
