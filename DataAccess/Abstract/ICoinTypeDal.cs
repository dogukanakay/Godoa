using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICoinTypeDal : IEntityRepository<CoinType>
    {
        Task<List<CoinTypeDetailDto>> GetCoinTypeDetails();
    }

}
