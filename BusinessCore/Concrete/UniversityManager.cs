
namespace BusinessCore.Concrete
{
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BusinessCore.Abstract;
    using CoreLayer.Constants.Messages;
    using CoreLayer.Results;
    using Data.Abstract;
    using Data.Models;
    #endregion
    public class UniversityManager : IUniversityService
    {
        IUniversityDal _universityDal;
        public UniversityManager(IUniversityDal universityDal)
        {
            _universityDal = universityDal;
        }

        public IResult Add(University university)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<University> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<University>> List()
        {
            var result = _universityDal.GetAll();
            if (result != null)
            {
                return new SuccessDataResult<List<University>>(result , Messages.Listed);
            }
            return new ErrorDataResult<List<University>>(Messages.ErrorEncountered);
        }

        public IResult Update(University university)
        {
            throw new NotImplementedException();
        }
    }
}
