using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
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
                   join u in context.Users on o.UserId equals u.UserId
                   select new OrderDetailDto
                   {
                       OrderId = o.OrderId,
                       UserName = u.UserName,
                       OrderDate = o.OrderDate,
                       Status = o.Status,
                       TotalAmount = o.TotalAmount


                   };
        }
        public async Task<List<OrderDetailDto>> GetOrderDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetOrderDetailQuery(context);
                return await result.ToListAsync();
            }
        }
    }
}
