using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PraktikPortalWebApi.EfCore
{
    [Table("user")]
    public class User
    {
        [Key, Required]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;
        public int type { get; set; }
    }
}
