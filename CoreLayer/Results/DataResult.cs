
namespace CoreLayer.Results
{
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class DataResult<T> : Result,IDataResult<T>
    {
        
        public DataResult(T data , string message, bool isSuccess ) : base(isSuccess  , message)
        {
            Data = data;
        }
        public DataResult(T data , bool isSuccess) : base(isSuccess)
        {
            Data = data;
        }

        public T Data { get;}

    }
}
