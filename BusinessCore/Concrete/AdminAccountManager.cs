
namespace BusinessCore.Concrete
{
    using BusinessCore.Abstract;
    using CoreLayer.Results;
    using Data.Abstract;
    using Data.Models.Logins;
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class AdminAccountManager : IAdminAccountService
    {
        private readonly IAdminAccountDal _adminAccountDal;
        public AdminAccountManager(IAdminAccountDal adminAccountDal)
        {
            _adminAccountDal = adminAccountDal;
        }
        public IResult Login(AdminAccount adminAccount)
        {
            var admin = _adminAccountDal.Get(u => u.USERNAME == adminAccount.USERNAME);
            if (admin != null && admin.PASSWORD == adminAccount.PASSWORD)
            {
                return new SuccessResult("Giris Yapildi!!");
            }
            return new ErrorResult("Sifre Hatali veya boyle bir kullanici yok!!");

        }
    }
}
