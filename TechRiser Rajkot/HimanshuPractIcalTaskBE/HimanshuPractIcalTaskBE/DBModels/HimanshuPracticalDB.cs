using Microsoft.EntityFrameworkCore;

namespace HimanshuPractIcalTaskBE.DBModels
{
    public class HimanshuPracticalDB:DbContext
    {
        public HimanshuPracticalDB(DbContextOptions<HimanshuPracticalDB> dbContext):base(dbContext)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Education> Educations { get; set; }
    }
}
