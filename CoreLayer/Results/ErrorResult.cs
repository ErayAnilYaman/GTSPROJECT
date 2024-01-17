
namespace CoreLayer.Results
{
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
            
        }
        public ErrorResult(string message) :base(false , message)
        {
            
        }
    }
}
