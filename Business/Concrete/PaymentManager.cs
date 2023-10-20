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
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult("Silindi");
        }

        public IDataResult<Payment> GetById(int paymentId)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.PaymentId == paymentId));
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(), "Veriler Getirildi");
        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult("Güncellendi");
        }
        public IDataResult<List<PaymentDetailDto>> GetPaymentDetails()
        {
            return new SuccessDataResult<List<PaymentDetailDto>>(_paymentDal.GetPaymentDetails(), "Payment detaylı bilgileri getirildi");
        }
    }
}
