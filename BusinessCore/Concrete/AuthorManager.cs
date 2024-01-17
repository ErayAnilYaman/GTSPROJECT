

namespace BusinessCore.Concrete

{
    using BusinessCore.Abstract;
    using CoreLayer.Constants.Messages;
    using CoreLayer.Results;
    using Data.Abstract;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal _authorDal;
        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }
        public IResult Add(Author author)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Author>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Author> GetById(int id)
        {
            var result = _authorDal.Get(a => a.AUTHORID == id)!;
            if (result != null)
            {
                return new SuccessDataResult<Author>(result);
            }
            return new ErrorDataResult<Author>(ThesisMessages.ThesisFound);
        }

        public IDataResult<Author> GetByName(string name)
        {
            var result = _authorDal.Get(a => (a.AUTHORNAME + a.LASTNAME).Replace(" ", "").ToString() == name);
            if (result!=null)
            {
                return new SuccessDataResult<Author>(result, Messages.Succeed);
            }
            return new ErrorDataResult<Author>(Messages.NotFound);
        }

        public IResult Update(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
