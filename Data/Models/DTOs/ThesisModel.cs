using Data.Models.Abstract;

namespace Data.Models.DTOs
{
    public class ThesisModel : IEntity
    {
        public int? UNIVERSITYID { get; set; }
        public int? INSTITUTEID { get; set; }
        public string? TITLE { get; set; }
        public string? AUTHORNAME { get; set; }
        public string? SUPERVISORNAME { get; set; }
        public string? TYPE { get; set; }
        public string? LANGUAGE { get; set; }
        public int? THESISYEAR { get; set; }
    }
}
