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
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual User User { get; set; } = null!;
        public int DTUSupervisor_id { get; set; }
        [ForeignKey("DTUSupervisor_id")]
        public virtual User DTUUser { get; set; } = null!;
        public int CompanySupervisor_id { get; set; }
        [ForeignKey("CompanySupervisor_id")]
        public virtual User CompanyUser { get; set; } = null!;
    }
}
