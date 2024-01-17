
namespace Data.Models
{
    using Data.Models.Abstract;
    #region usings
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection.Metadata.Ecma335;

    #endregion

    public class ThesisSubjectTopic:IEntity
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int THESISID { get; set; }
        [Required]
        public int TOPICID{ get; set; }

        public virtual Thesis THESIS{ get; set; }
        public virtual SubjectTopic SUBJECTTOPIC { get; set; }
    }

}
