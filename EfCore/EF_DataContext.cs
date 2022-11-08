using Microsoft.EntityFrameworkCore;

namespace PraktikPortalWebApi.EfCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Internship> Internships { get; set; }
    }
}
