
namespace BusinessCore.Abstract
{
   
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CoreLayer.Results;
    using Data.Models.Logins;
    #endregion
    public interface IAdminAccountService
    {

        IResult Login(AdminAccount adminAccount);
        
    }
}
