using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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
        IOrderItemDal _orderItemDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        [LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(OrderValidator))]
        [CacheRemoveAspect("IOrderService.Get")]
        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult("Sipariş Verildi");
        }
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IOrderService.Get")]
        public IResult Delete(Order order)
        {
            _orderDal.Delete(order);
            return new SuccessResult("Silindi");
        }

        [CacheAspect]
        public async Task<IDataResult<Order>> GetById(int orderId)
        {
            return new SuccessDataResult<Order>(await _orderDal.Get(o => o.OrderId == orderId));
        }
        [CacheAspect]
        public async Task<IDataResult<List<Order>>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(await _orderDal.GetAll(), "Veriler Getirildi");
        }

        [CacheRemoveAspect("IOrderService.Get")]
        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult("Güncellendi");
        }
        [CacheAspect]
        public async Task<IDataResult<List<OrderDetailDto>>> GetOrderDetails()
        {
            return new SuccessDataResult<List<OrderDetailDto>>(await _orderDal.GetOrderDetails(), "Order detaylı bilgileri getirildi");
        }

        [TransactionScopeAspect]
        public IResult MakeOrder(Product[] products, int userId)
        {
            Order order = new Order()
            {
                OrderId = 0,
                OrderDate = DateTime.Now,
                UserId = userId,
                TotalAmount = 0,
                Status = true
            };

            _orderDal.Add(order);

            Dictionary<int, OrderItem> productOrderItems = new Dictionary<int, OrderItem>();

            foreach (var product in products)
            {
                if (productOrderItems.TryGetValue(product.ProductId, out var existingOrderItem))
                {
                    existingOrderItem.Quantity++;
                    existingOrderItem.SubTotal += product.Price;
                }
                else
                {
                    OrderItem orderItem = new OrderItem()
                    {
                        OrderId = order.OrderId,
                        ProductId = product.ProductId,
                        Quantity = 1,
                        SubTotal = product.Price
                    };

                    productOrderItems.Add(product.ProductId, orderItem);
                }
                order.TotalAmount += product.Price;
            }
            foreach (var orderItem in productOrderItems.Values)
            {
                _orderItemDal.Add(orderItem);
            }

            _orderDal.Update(order);
            return new SuccessResult("Sipariş başarıyla oluşturuldu");
        }


    }
}
