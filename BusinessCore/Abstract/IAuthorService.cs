
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
    public interface IAuthorService
    {

        IResult Add(Author author);
        IResult Update(Author author);
        IResult Delete(int id);
        IDataResult<List<Author>> GetAll();
        IDataResult<Author> GetById(int id);
        IDataResult<Author> GetByName(string name);

    }
}
