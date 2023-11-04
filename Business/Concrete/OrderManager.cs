using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult("Silindi");
        }

        public async Task<IDataResult<Order>> GetById(int orderId)
        {
            return new SuccessDataResult<Order>(await _orderDal.Get(o => o.OrderId == orderId));
        }

        public async Task<IDataResult<List<Order>>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(await _orderDal.GetAll(), "Veriler Getirildi");
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult("Güncellendi");
        }
        public async Task<IDataResult<List<OrderDetailDto>>> GetOrderDetails()
        {
            return new SuccessDataResult<List<OrderDetailDto>>(await _orderDal.GetOrderDetails(), "Order detaylı bilgileri getirildi");
        }

    }
}
