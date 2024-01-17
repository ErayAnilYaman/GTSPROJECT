
namespace Data.Concrete
{
    
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data.Abstract;
    using Data.Concrete.Base;
    using Data.Db;
    using Data.Models;
    #endregion
    public class EfUniversityDal : EfEntityRepositoryBase<University , ThesesContext> , IUniversityDal
    {

    }
}
