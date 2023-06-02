using Microsoft.EntityFrameworkCore;

namespace HimanshuPracticalBE.DBModels
{
    public class HimanshuPracticlaDB : DbContext
    {
        public HimanshuPracticlaDB(DbContextOptions<HimanshuPracticlaDB> dbContext) : base(dbContext)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserDepartment> UserDepartment { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<UserLocation> UserLocation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDepartment>().HasKey(sc => new { sc.UserId, sc.DepartmentId });

            modelBuilder.Entity<UserDepartment>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.UserDepartments)
                .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<UserDepartment>()
                .HasOne<Department>(sc => sc.Department)
                .WithMany(s => s.UserDepartments)
                .HasForeignKey(sc => sc.DepartmentId);

            modelBuilder.Entity<UserLocation>().HasKey(sc => new { sc.UserId, sc.LocationId });

            modelBuilder.Entity<UserLocation>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.UserLocations)
                .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<UserLocation>()
                .HasOne<Location>(sc => sc.Location)
                .WithMany(s => s.UserLocations)
                .HasForeignKey(sc => sc.LocationId);
            //modelBuilder.Entity<User>().HasMany(c => c.Departments).WithMany(c => c.Users).UsingEntity<UserDepartment>();

            //modelBuilder.Entity<User>().HasMany(c => c.Locations).WithMany(c => c.Users).UsingEntity<UserLocation>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
