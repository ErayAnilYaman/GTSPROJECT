
namespace Data.Models
{
    #region Usings
using Data.Models.Abstract;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    
    public class Author : IEntity
    {
        private ICollection<Thesis> _thesis;
        public Author()
        {
            _thesis = new HashSet<Thesis>();
        }
        [Key]
        public int AUTHORID { get; set; }
        [Required]
        [StringLength(150)]
        public string AUTHORNAME{ get; set; }
        [Required]
        [StringLength(150)]
        public string LASTNAME { get; set; }
        [Required]
        [StringLength(150)]
        public string EMAIL { get; set; }
        public virtual ICollection<Thesis> THESES { get { return _thesis; } set { value = this._thesis; } }
    }
}
