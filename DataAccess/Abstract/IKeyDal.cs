using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
<<<<<<<< HEAD:DataAccess/Abstract/ICoinTypeDal.cs
    public interface ICoinTypeDal:IEntityRepository<CoinType>
========
    public interface IKeyDal : IEntityRepository<Keys>
>>>>>>>> 164d5ece7539f4648d6aa67bfd5560a563c10309:DataAccess/Abstract/IKeyDal.cs
    {
    }
}
