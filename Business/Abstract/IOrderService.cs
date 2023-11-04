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
    public interface IOrderService
    {
        IResult Add(Order order);
        IResult Delete(Order order);
        IResult Update(Order order);

        Task<IDataResult<List<Order>>> GetAll();
        Task<IDataResult<Order>> GetById(int orderId);
        Task<IDataResult<List<OrderDetailDto>>> GetOrderDetails();
    }
}
