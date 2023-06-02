using Microsoft.EntityFrameworkCore;

namespace MultiiconPracticalTask.DBModels
{
    public class UserBookDBContext: DbContext
    {
        public UserBookDBContext(DbContextOptions<UserBookDBContext> options):base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
