
namespace Data.Concrete
{
   
    #region usings
    
 using Data.Abstract;
    using Data.Concrete.Base;
    using Data.Db;
    using Data.Models.Logins;
    #endregion
    public class EfAdminAccountDal :EfEntityRepositoryBase<AdminAccount , ThesesContext>, IAdminAccountDal
    {
    }
}
