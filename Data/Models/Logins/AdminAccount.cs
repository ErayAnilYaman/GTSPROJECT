namespace Data.Models.Logins
{
    using Data.Models.Abstract;
    #region usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class AdminAccount : IEntity
    {

        public int ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string ROLE { get; set; }
    }
}
