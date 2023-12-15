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
    public class EfOrderItemDal : EfEntityRepositoryBase<OrderItem, GodoaContext>, IOrderItemDal
    {
        private IQueryable<OrderItemDetailDto> GetOrderItemsOfOrderQuery(GodoaContext context, int orderId)
        {
            return from oi in context.OrderItems
                   join o in context.Orders on oi.OrderId equals o.OrderId
                   join p in context.Products on oi.ProductId equals p.ProductId
                   where oi.OrderId == orderId
                   select new OrderItemDetailDto
                   {
                       OrderItemId = oi.OrderItemId,
                       ProductName = p.ProductName,
                       Quantity = oi.Quantity,
                       SubTotal = oi.SubTotal,
                   };
        }
        public async Task<List<OrderItemDetailDto>> GetOrderItemsOfOrderByOrderId(int orderId)
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetOrderItemsOfOrderQuery(context,orderId);
                return await result.ToListAsync();
            }
        }
    }
}
