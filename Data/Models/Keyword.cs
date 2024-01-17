
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
    public class Keyword : IEntity
    {
        private ICollection<ThesisKeyword> _thesisKeywords;
        public Keyword()
        {
            _thesisKeywords = new HashSet<ThesisKeyword>();
        }
        [Key]
        public int KEYWORDID { get; set; }
        [StringLength(255)]
        [Required]
        public string KEYWORD{ get; set;}
        public virtual ICollection<ThesisKeyword> THESISKEYWORDS { get; set; }

    }
}
