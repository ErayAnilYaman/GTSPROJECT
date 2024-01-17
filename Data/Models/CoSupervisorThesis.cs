
namespace Data.Models
{
    #region Usings
    using Data.Models.Abstract;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class CoSupervisorThesis : IEntity
    {
        [Key]
        public int COSUPERVISORTHESISID { get; set; }
        [Required]
        public int THESISID { get; set; }
        [Required]
        public int SUPERVISORID { get; set; }
        public virtual Thesis  THESIS{ get; set; }
        public virtual Supervisor SUPERVISOR{ get; set; }
    }
}
