namespace WebApplication.Models
{
    public class CreateThesisModel
    {
        public int? UNIVERSITYID { get; set; }
        public int? INSTITUTEID { get; set; }
        public string? TITLE { get; set; }
        public string? SUPERVISORID { get; set; }
        public string? TYPE { get; set; }
        public string? LANGUAGE { get; set; }
        public int? THESISYEAR { get; set; }
        public int ABSTRACT { get; set; }
        public int PAGES { get; set; }

    }
}
