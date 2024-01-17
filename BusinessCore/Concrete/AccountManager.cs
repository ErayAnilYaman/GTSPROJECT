
namespace BusinessCore.Concrete
{
    using BusinessCore.Abstract;
    using CoreLayer.Constants.Messages;
    using CoreLayer.Results;
    using Data.Abstract;
    using Data.Models;
    using Data.Models.DTOs;

    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        public AccountManager(IAccountDal accountDal)
        {
            _accountDal  = accountDal;
        }

        public IDataResult<Account> GetById(int id)
        {
            var result = _accountDal.GetModelById(id);
            if (result != null)
            {
                return new SuccessDataResult<Account>(result[0], Messages.Listed);
            }
            return new ErrorDataResult<Account>(Messages.NotFound);
        }

        public IDataResult<Account> GetByUsername(string username)
        {
            var result = _accountDal.GetModelByUsername(username);
            if (result != null)
            {
                return new SuccessDataResult<Account>(result[0] , Messages.Listed);
            }
            return new ErrorDataResult<Account>(Messages.NotFound);
        }

        public IResult Login(AccountToLogin accountToLogin)
        {
            var result = _accountDal.Get(a => a.USERNAME== accountToLogin.USERNAME);
            if (result != null && result.PASSWORD == accountToLogin.PASSWORD)
            {
                return new SuccessResult("Basariyla Girisy Yapildi!!");
            }
            return new ErrorResult("Giris Yapilamadi!");
        }
    }
}
