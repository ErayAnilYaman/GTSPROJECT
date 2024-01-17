
namespace BusinessCore.Concrete
{
    using BusinessCore.Abstract;
    using CoreLayer.Constants.Messages;
    using CoreLayer.Results;
    using Data.Abstract;
    using Data.Concrete;
    using Data.Models;
    using Data.Models.DTOs;
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class SupervisorManager : ISupervisorService
    {
        private readonly ISupervisorDal _supervisorDal;

        public SupervisorManager(ISupervisorDal supervisorDal)
        {
            _supervisorDal = supervisorDal;
        }

        public IResult Add(Supervisor supervisor)
        {
            try
            {
                
                _supervisorDal.Add(supervisor);
                return new SuccessResult(Messages.Succeed);


            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Supervisor> GetByID(int id)
        {
            try
            {
                return new SuccessDataResult<Supervisor>(_supervisorDal.Get(s => s.SUPERVISORID == id));
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<Supervisor>(ex.Message);
            }
        }

        public IDataResult<Supervisor> GetByName(string name)
        {
            var result = _supervisorDal.Get(s => s.LASTNAME == name);
            if (result != null)
            {
                return new SuccessDataResult<Supervisor>(result);
            }
            return new ErrorDataResult<Supervisor>(Messages.NotFound);
        }

        public IDataResult<List<Supervisor>> List()
        {
            try
            {
                var result = _supervisorDal.GetAll();
                if (result != null)
                {
                    return new SuccessDataResult<List<Supervisor>>(result , Messages.Succeed);
                }
                return new ErrorDataResult<List<Supervisor>>(Messages.ErrorEncountered);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<Supervisor>>(ex.Message);
            }
        }

        public IResult Update(Supervisor supervisor)
        {
            throw new NotImplementedException();
        }
    }
}
