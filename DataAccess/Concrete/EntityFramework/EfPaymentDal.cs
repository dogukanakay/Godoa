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
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, GodoaContext>, IPaymentDal
    {
       

        private IQueryable<PaymentDetailDto> GetPaymentDetailQuery(GodoaContext context)
        {
            return from p in context.Payments
                   join o in context.Orders on p.OrderId equals o.OrderId
                   join u in context.Users on p.UserId equals u.UserId
                   select new PaymentDetailDto
                   {
                       PaymentId = p.PaymentId,
                       OrderId=o.OrderId,
                       UserName=u.UserName,
                       PaymentDate=p.PaymentDate,
                       Status=p.Status
                   };
        }
        public async Task<List<PaymentDetailDto>> GetPaymentDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetPaymentDetailQuery(context);
                return await result.ToListAsync();
            }
        }

    }
}
