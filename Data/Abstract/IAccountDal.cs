
namespace Data.Abstract
{
    using Data.Abstract.Base;
    using Data.Models;

    public interface IAccountDal : IEntityRepositoryBase<Account>
    {
        List<Account> GetModelById(int id);
        List<Account> GetModelByUsername(string username);
    }
}
