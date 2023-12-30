using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderItemService
    {
        IResult Add(OrderItem orderItem);
        IResult Delete(OrderItem orderItem);
        IResult Update(OrderItem orderItem);
        Task<IDataResult<List<OrderItem>>> GetAll();
        Task<IDataResult<OrderItem>> GetById(int orderItemId);

        Task<IDataResult<List<OrderItemDetailDto>>> GetOrderItemDetailsOfOrderByOrderId(int orderId);
    }
}
