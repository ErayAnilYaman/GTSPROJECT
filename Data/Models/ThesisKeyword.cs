

namespace Data.Models
{
    #region usings
    using Data.Models.Abstract;
    using System.ComponentModel.DataAnnotations;
    #endregion
    public class ThesisKeyword : IEntity
    {
        public int THESISKEYWORDID { get; set; }
        [Required]
        public int THESISID{ get; set; }
        [Required]
        public int KEYWORDID { get; set; }
        public virtual Thesis THESIS{ get; set; }
        public virtual Keyword KEYWORD{ get; set; }
    }
}
