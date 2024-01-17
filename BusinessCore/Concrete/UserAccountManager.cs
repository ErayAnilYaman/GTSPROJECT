namespace BusinessCore.Concrete
{
    #region usings
    using System;
    using BusinessCore.Abstract;
    using CoreLayer.Results;
    using Data.Abstract;
    using Data.Models.Logins;
    #endregion
    public class UserAccountManager : IUserAccountService
    {
        private readonly IUserAccountDal _userLoginDal;
        public UserAccountManager(IUserAccountDal userLoginDal)
        {
            _userLoginDal = userLoginDal;
        }
        public IResult Login(UserAccount userAccount)
        {
            var user = _userLoginDal.Get(u => u.USERNAME == userAccount.USERNAME);
            if (user!= null && userAccount.PASSWORD == user.PASSWORD)
            {
                return new SuccessResult("Giris Yapildi!!");    
            }
            return new ErrorResult("Sifre Hatali veya boyle bir kullanici yok!!");

        }
    }
}
