namespace HimanshuPracticalBE.DBModels
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Location>? Locations { get; set; }
        //public ICollection<User>? Users { get; set; }
        public ICollection<UserDepartment>? UserDepartments { get; set; }
    }
}
