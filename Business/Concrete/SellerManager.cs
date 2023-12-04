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

        public async Task<IDataResult<Seller>> GetById(int sellerId)
        {
            return new SuccessDataResult<Seller>(await _sellerDal.Get(s => s.SellerId == sellerId));
        }

        public async Task<IDataResult<List<Seller>>> GetAll()
        {
            return new SuccessDataResult<List<Seller>>(await _sellerDal.GetAll(), "Veriler Getirildi");
        }

        public IResult Update(Seller seller)
        {
            _sellerDal.Update(seller);
            return new SuccessResult("Güncellendi");
        }
        public async Task<IDataResult<List<SellerDetailDto>>> GetSellerDetails() 
        {
            return new SuccessDataResult<List<SellerDetailDto>>(await _sellerDal.GetSellerDetails(), "Seller detaylı bilgileri getirildi.");
        }
    }
}
