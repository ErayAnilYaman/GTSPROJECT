
namespace CoreLayer.Results
{
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data ,string message) : base(data , message , true)
        {
            
        }
        public SuccessDataResult(T data) : base(data , true)
        {
            
        }

    }
}
