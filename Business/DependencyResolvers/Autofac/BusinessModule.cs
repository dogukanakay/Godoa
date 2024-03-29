﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Tokens;
using Core.Utilities.Security.Tokens.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<GameTypeManager>().As<IGameTypeService>().SingleInstance();
            builder.RegisterType<EfGameTypeDal>().As<IGameTypeDal>().SingleInstance();

            builder.RegisterType<GameCategoryManager>().As<IGameCategoryService>().SingleInstance();
            builder.RegisterType<EfGameCategoryDal>().As<IGameCategoryDal>().SingleInstance();

            builder.RegisterType<VirtualCurrencyTypeManager>().As<IVirtualCurrencyTypeService>().SingleInstance();
            builder.RegisterType<EfVirtualCurrencyTypeDal>().As<IVirtualCurrencyTypeDal>().SingleInstance();

            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>().SingleInstance();

            builder.RegisterType<GameManager>().As<IGameService>().SingleInstance();
            builder.RegisterType<EfGameDal>().As<IGameDal>().SingleInstance();

            builder.RegisterType<GameKeyManager>().As<IGameKeyService>().SingleInstance();
            builder.RegisterType<EfGameKeyDal>().As<IGameKeyDal>().SingleInstance();

            builder.RegisterType<GameTypeManager>().As<IGameTypeService>().SingleInstance();
            builder.RegisterType<EfGameTypeDal>().As<IGameTypeDal>().SingleInstance();

            builder.RegisterType<VirtualCurrencyManager>().As<IVirtualCurrencyService>().SingleInstance();
            builder.RegisterType<EfVirtualCurrencyDal>().As<IVirtualCurrencyDal>().SingleInstance();

            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().SingleInstance();
            builder.RegisterType<OrderItemManager>().As<IOrderItemService>().SingleInstance();
            builder.RegisterType<EfOrderItemDal>().As<IOrderItemDal>().SingleInstance();

            builder.RegisterType<PaymentManager>().As<IPaymentService>().SingleInstance();
            builder.RegisterType<EfPaymentDal>().As<IPaymentDal>().SingleInstance();

            builder.RegisterType<PlatformManager>().As<IPlatformService>().SingleInstance();
            builder.RegisterType<EfPlatformDal>().As<IPlatformDal>().SingleInstance();

            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<ProductCategoryManager>().As<IProductCategoryService>().SingleInstance();
            builder.RegisterType<EfProductCategoryDal>().As<IProductCategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<ClaimManager>().As<IOperationClaimService>().SingleInstance();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();

            builder.RegisterType<UserClaimManager>().As<IUserClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();




            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
