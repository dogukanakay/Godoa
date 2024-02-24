using Core.DataAccess;
using Core.Entities.Abstracts;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IVirtualCurrencyDal : IEntityRepository<VirtualCurrency>
    {
        Task<List<VirtualCurrencyDetailDto>> GetVirtualCurrencyDetails();
    }
}
