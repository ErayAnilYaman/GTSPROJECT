
namespace BusinessCore.Abstract
{
    using CoreLayer.Results;
    using Data.Models;
    using Data.Models.DTOs;

    public interface IAccountService 
    {
        IResult Login(AccountToLogin accountToLogin);

        IDataResult<Account> GetById(int id);
        IDataResult<Account> GetByUsername(string username);
    }
}
