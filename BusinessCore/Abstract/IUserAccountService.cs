
namespace BusinessCore.Abstract
{
    #region usings
using CoreLayer.Results;
    using Data.Models.Logins;
    #endregion
    public interface IUserAccountService
    {
        IResult Login(UserAccount userAccount);
    }
}
