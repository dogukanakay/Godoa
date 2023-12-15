using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        IOrderItemDal _orderItemDal;
        public OrderItemManager(IOrderItemDal orderItemDal)
        {
            _orderItemDal = orderItemDal;
        }

        public IResult Add(OrderItem orderItem)
        {
            _orderItemDal.Add(orderItem);
            return new SuccessResult();
        }

        public IResult Delete(OrderItem orderItem)
        {
            _orderItemDal.Delete(orderItem);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<OrderItem>>> GetAll()
        {
            return new SuccessDataResult<List<OrderItem>>(await _orderItemDal.GetAll());
        }

        public async Task<IDataResult<OrderItem>> GetById(int orderItemId)
        {
            return new SuccessDataResult<OrderItem>(await _orderItemDal.Get(oi=>oi.OrderItemId == orderItemId));
        }

        public async Task<IDataResult<List<OrderItemDetailDto>>> GetOrderItemDetailsOfOrderByOrderId(int orderId)
        {
            return new SuccessDataResult<List<OrderItemDetailDto>>(await _orderItemDal.GetOrderItemsOfOrderByOrderId(orderId));
        }

        public IResult Update(OrderItem orderItem)
        {
            _orderItemDal.Update(orderItem);
            return new SuccessResult();
        }
    }
}
