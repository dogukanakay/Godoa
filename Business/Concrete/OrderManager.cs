using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        IOrderItemService _orderItemService;
        IGameKeyService _gameKeyService;
        IVirtualCurrencyService _virtualCurrencyService;

        public OrderManager(IOrderDal orderDal, IOrderItemService orderItemService, IGameKeyService gameKeyService, IVirtualCurrencyService virtualCurrencyService)
        {
            _orderDal = orderDal;
            _orderItemService = orderItemService;
            _gameKeyService = gameKeyService;
            _virtualCurrencyService = virtualCurrencyService;
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

        [CacheRemoveAspect("IOrderService.Get")]
        [TransactionScopeAspect]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<ReturnOrderDto>> MakeOrder(List<Product> products, int userId)
        {
           
            Order order = new Order()
            {
                OrderId = 0,
                OrderDate = DateTime.Now,
                UserId = userId,
                TotalAmount = 0,
                Status = true
            };
            List<ReturnOrderDto> returnOrderDto = new List<ReturnOrderDto>();
            List<ReturnOrderDto> outOfStock = new List<ReturnOrderDto>();

            _orderDal.Add(order);

            Dictionary<int, OrderItem> productOrderItems = new Dictionary<int, OrderItem>();

            foreach (var product in products)
            {
                bool isInStock = false;
                if (product.ProductCategoryId == 1)
                {
                    var gameKey = _gameKeyService.GetIfİnStockByProductId(product.ProductId).Result.Data;
                    if (gameKey != null)
                    {
                        isInStock = true;
                        returnOrderDto.Add(new ReturnOrderDto
                        {
                            Key = gameKey.KeyOfGame,
                            ProductName = product.ProductName,
                        });

                        gameKey.IsUsed = true;
                        _gameKeyService.Update(gameKey);
                      

                    }
                    else
                    {
                        outOfStock.Add(new ReturnOrderDto
                        {
                            Key = "Stokta Yok",
                            ProductName = product.ProductName,
                        });
                    }
                }
                else if (product.ProductCategoryId == 2)
                {
                    var virtualCurrency = _virtualCurrencyService.GetIfInStockByProductId(product.ProductId).Result.Data;
                    if(virtualCurrency != null)
                    {
                        isInStock = true;
                        returnOrderDto.Add(new ReturnOrderDto
                        {
                            ProductName = product.ProductName,
                            Key = virtualCurrency.CurrencyKey
                        });
                        virtualCurrency.IsUsed = true;
                        _virtualCurrencyService.Update(virtualCurrency);
                    }
                    else
                    {
                        outOfStock.Add(new ReturnOrderDto
                        {
                            Key ="Stokta Yok",
                            ProductName = product.ProductName,
                        });
                    }
                }
                if (isInStock)
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

               
                
            }
            foreach (var orderItem in productOrderItems.Values)
            {
                _orderItemService.Add(orderItem);
            }

            _orderDal.Update(order);
            if(outOfStock.Count > 0)
            {
                string productNames = string.Join(", ", outOfStock.Select(dto => dto.ProductName));
                throw new Exception("Bu ürünler stokta yok => " + productNames );
            }
            return new SuccessDataResult<List<ReturnOrderDto>>(returnOrderDto,"Sipariş başarıyla oluşturuldu");
        }


    }
}
