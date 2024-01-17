
namespace Data.Models
{
    using Data.Models.Abstract;
    #region usings
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class Account : IEntity
    {
        public int ID { get; set; }

        [Display(Name = "Kullanici Adi")]
        [Required]
        public string USERNAME { get; set; }

        [Required]
        [Display(Name = "Sifre")]
        public string PASSWORD { get; set; }
        public int ROLEID { get; set; }
        public virtual Role Role{ get; set; }
    }
}
