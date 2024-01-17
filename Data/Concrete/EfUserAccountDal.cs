
namespace Data.Concrete
{
    using Data.Abstract;
    using Data.Concrete.Base;
    using Data.Db;
    using Data.Models.Logins;
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class EfUserAccountDal : EfEntityRepositoryBase<UserAccount , ThesesContext> , IUserAccountDal
    {

    }
}
