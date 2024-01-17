
namespace Data.Models
{
    #region using

    using Data.Models.Abstract;
    using System.ComponentModel.DataAnnotations;

    #endregion
    public class SubjectTopic : IEntity
    {
        private ICollection<ThesisSubjectTopic> _thesisSubjectTopics;
        public SubjectTopic()
        {
           _thesisSubjectTopics = new HashSet<ThesisSubjectTopic>();
        }
        [Key]
        public int TOPICID { get; set; }
        [Required]
        [StringLength(150)]
        public string TOPICNAME{ get; set; }
        public virtual ICollection<ThesisSubjectTopic> THESISSUBJECTTOPCIS { get { return _thesisSubjectTopics; } set { value = this._thesisSubjectTopics; } }

    }
}
