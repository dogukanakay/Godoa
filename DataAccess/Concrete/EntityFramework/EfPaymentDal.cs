using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
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
            return from g in context.Payments
                   join c in context.Orders on g.OrderId equals c.OrderId
                   join v in context.Users on g.UserId equals v.UserId
                   select new PaymentDetailDto
                   {
                       PaymentId = g.PaymentId,
                       OrderId=c.OrderId,
                       UserName=v.UserName,
                       PaymentDate=g.PaymentDate,
                       Status=g.Status
                   };
        }
        List<PaymentDetailDto> IPaymentDal.GetPaymentDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetPaymentDetailQuery(context);
                return result.ToList();
            }
        }
    }
}
