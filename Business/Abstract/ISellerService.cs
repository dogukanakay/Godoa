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
    public  interface ISellerService
    {
        IResult Add(Seller seller);
        IResult Delete(Seller seller);
        IResult Update(Seller seller);

        Task<IDataResult<List<Seller>>> GetAll();
        Task<IDataResult<Seller>> GetById(int sellerId);
        Task<IDataResult<List<SellerDetailDto>>> GetSellerDetails();
    }
}
