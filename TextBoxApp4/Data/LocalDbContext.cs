using Microsoft.EntityFrameworkCore;

namespace TextBoxApp4.Data
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
    }


}
