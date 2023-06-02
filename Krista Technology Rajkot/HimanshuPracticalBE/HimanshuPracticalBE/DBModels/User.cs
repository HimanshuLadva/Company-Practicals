namespace HimanshuPracticalBE.DBModels
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastModifiedDate { get; set; }
        //public ICollection<Department>? Departments { get; set; }
        //public ICollection<Location>? Locations { get; set; }


        public ICollection<UserDepartment>? UserDepartments { get; set; }
        public ICollection<UserLocation>? UserLocations { get; set; }
    }
}
