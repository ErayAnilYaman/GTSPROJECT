
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
    public class University : IEntity
    {
        private ICollection<Thesis> _theses;
        public University()
        {
            _theses = new HashSet<Thesis>();
        }
        [Key]
        public int UNIVERSITYID { get; set; }
        [Required]
        [StringLength(150)]
        public string NAME{ get; set; }
        public virtual ICollection<Thesis> THESES { get { return _theses; } set { value = _theses; } }

    }
}
