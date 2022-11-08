using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PraktikPortalWebApi.EfCore
{
    [Table("internship")]
    public class Internship
    {
        [Key, Required]
        public int InternshipId { get; set; }
        public string InternshipName { get; set; } = string.Empty;
        public string InternshipCompany { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
