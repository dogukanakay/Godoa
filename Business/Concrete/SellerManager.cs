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
    public class SellerManager : ISellerService
    {
        ISellerDal _sellerDal;
        public SellerManager(ISellerDal sellerDal)
        {
           _sellerDal = sellerDal;
        }
        public IResult Add(Seller seller)
        {
            _sellerDal.Add(seller);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(Seller seller)
        {
            _sellerDal.Delete(seller);
            return new SuccessResult("Silindi");
        }

        public IDataResult<Seller> GetById(int sellerId)
        {
            return new SuccessDataResult<Seller>(_sellerDal.Get(s => s.SellerId == sellerId));
        }

        public IDataResult<List<Seller>> GetAll()
        {
            return new SuccessDataResult<List<Seller>>(_sellerDal.GetAll(), "Veriler Getirildi");
        }

        public IResult Update(Seller seller)
        {
            _sellerDal.Update(seller);
            return new SuccessResult("Güncellendi");
        }
        public IDataResult<List<SellerDetailDto>> GetSellerDetails() 
        {
            return new SuccessDataResult<List<SellerDetailDto>>(_sellerDal.GetSellerDetails(), "Seller detaylı bilgileri getirildi.");
        }
    }
}
