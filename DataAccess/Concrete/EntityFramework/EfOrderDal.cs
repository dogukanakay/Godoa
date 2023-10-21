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
            return from o in context.Orders
                   join p in context.Products on o.ProductId equals p.ProductId
                   join u in context.Users on o.UserId equals u.UserId
                   select new OrderDetailDto
                   {
                       OrderId = o.OrderId,
                       ProductName = p.ProductName,
                       UserName = u.UserName,
                       Amount = o.Amount,
                       TotalPrice = o.TotalPrice,
                       TradeUrl = o.TradeUrl,
                       IsConfirmed = o.IsConfirmed


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
