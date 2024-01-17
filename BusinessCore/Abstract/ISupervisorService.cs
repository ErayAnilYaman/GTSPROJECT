
namespace BusinessCore.Abstract
{
    using CoreLayer.Results;
    using Data.Models;
    using Data.Models.DTOs;
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public interface ISupervisorService
    {
        IDataResult<List<Supervisor>> List();
        IDataResult<Supervisor> GetByName(string name);
        IDataResult<Supervisor> GetByID(int id);


        IResult Add(Supervisor supervisor);
        IResult Update(Supervisor supervisor);
        IResult Delete(int id);
    }
}
