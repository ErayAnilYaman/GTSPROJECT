
namespace Data.Models
{
    #region usings
    using Data.Models.Abstract;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class Role : IEntity
    {
        private  ICollection<Account> _accounts;
        public Role()
        {
            _accounts = new HashSet<Account>();
        }
        [Key]
        public int ROLEID { get; set; }
        [Display(Name = "Rol Adi")]
        [Required]
        public string ROLE { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
