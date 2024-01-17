
namespace Data.Abstract
{
    
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data.Abstract.Base;
    using Data.Models;
    #endregion
    public interface IThesisDal : IEntityRepositoryBase<Thesis>
    {
        List<Thesis> GetAllOfModel();
        List<Thesis> GetAllOfModelByNumber(int number);
        List<Thesis> GetAllByUsername(string username);
    }
}
