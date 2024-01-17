
namespace BusinessCore.Abstract
{
    using CoreLayer.Results;
    using Data.Models;
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public interface IUniversityService
    {
        IResult DeleteById(int id);

        IResult Update(University university);

        IResult Add(University university);
        IDataResult<University> GetById(int id);
        IDataResult<List<University>> List();
    }
}
