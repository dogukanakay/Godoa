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
    public class EfOrderDal : EfEntityRepositoryBase<Order, GodoaContext>, IOrderDal
    {
        private IQueryable<OrderDetailDto> GetOrderDetailQuery(GodoaContext context)
        {
            return from g in context.Orders
                   join c in context.Products on g.ProductId equals c.ProductId
                   join t in context.Users on g.UserId equals t.UserId
                   select new OrderDetailDto
                   {
                       OrderId = g.OrderId,
                       ProductName = c.ProductName,
                       UserName = t.UserName,
                       Amount = g.Amount,
                       TotalPrice = g.TotalPrice,
                       TradeUrl = g.TradeUrl,
                       IsConfirmed = g.IsConfirmed


                   };
        }
        public List<OrderDetailDto> GetOrderDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetOrderDetailQuery(context);
                return result.ToList();
            }
        }
    }
}
