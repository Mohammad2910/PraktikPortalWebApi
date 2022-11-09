namespace PraktikPortalWebApi.Models
{
    public class InternshipModel
    {
        public int InternshipId { get; set; }
        public string InternshipName { get; set; } = string.Empty;
        public string InternshipCompany { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public int StudentId { get; set; }
    }
}
