
namespace Data.Models
{
    #region usings
    using Data.Models.Abstract;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Runtime;
    using System.Text;
    using System.Threading.Tasks;

    #endregion
    public class Thesis : IEntity
    {
        private ICollection<CoSupervisorThesis> _coSupervisorTheses;
        private ICollection<ThesisKeyword> _thesisKeywords;
        private ICollection<ThesisSubjectTopic> _subjectTopics;
        public Thesis()
        {
            _coSupervisorTheses = new HashSet<CoSupervisorThesis>();
            _thesisKeywords = new HashSet<ThesisKeyword>();
            _subjectTopics = new HashSet<ThesisSubjectTopic>();
        }
        [Key]
        public int THESISID { get; set; }
        [Required]
        public int NUMBER { get; set; }
        [Required]
        [StringLength(250)]
        public string TITLE { get; set; }
        [Required]
        [StringLength(250)]
        public string ABSTRACT{ get; set; }
        [Required]
        public int AUTHORID{ get; set; }
        [Required]
        public int THESISYEAR{ get; set; }
        [Required]
        [StringLength(150)]
        public string TYPE{ get; set; }
        [Required]
        public int INSTITUTEID{ get; set; }
        [Required]
        public int SUPERVISORID { get; set; }
        [Required]
        public int UNIVERSITYID { get; set; }
        [Required]
        public int PAGES{ get; set; }
        [Required]
        [StringLength(100)]
        public string LANGUAGE{ get; set; }
        [Required]
        public DateTime SUBMISSIONDATE{ get; set; }

        public virtual Author AUTHOR { get; set; }
        public virtual Institute INSTITUTE{ get; set; }
        public virtual University UNIVERSITY { get; set; }
        public virtual Supervisor SUPERVISOR { get; set; }
        public virtual ICollection<CoSupervisorThesis> COSUPERVISORTHESES{ get { return _coSupervisorTheses; } set { value = _coSupervisorTheses; } }
        public virtual ICollection<ThesisKeyword> THESISKEYWORDS{ get { return _thesisKeywords; } set { value = _thesisKeywords; } }
        public virtual ICollection<ThesisSubjectTopic> THESISSUBJECTTOPICS
        {
            get { return _subjectTopics; }
            set
            {
                value = this._subjectTopics;
            }
        }
    }
}
