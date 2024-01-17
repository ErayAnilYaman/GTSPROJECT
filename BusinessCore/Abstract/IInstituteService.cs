
namespace BusinessCore.Abstract
{
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CoreLayer.Results;
    using Data.Models;
    #endregion
    public interface IInstituteService
    {
        IResult DeleteById(int id);
        
        IResult Update(Institute institute);

        IResult Add(Institute institute);
        IDataResult<Institute> GetById(int id);
        IDataResult<List<Institute>> List();
    }
}
