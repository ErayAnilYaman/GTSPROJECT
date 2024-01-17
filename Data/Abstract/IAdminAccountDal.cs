
namespace Data.Abstract
{
    using Data.Abstract.Base;
    using Data.Models.Abstract;
    using Data.Models.Logins;
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public interface IAdminAccountDal : IEntityRepositoryBase<AdminAccount>
    {

    }
}
