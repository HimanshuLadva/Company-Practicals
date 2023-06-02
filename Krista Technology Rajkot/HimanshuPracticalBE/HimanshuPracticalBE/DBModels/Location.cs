namespace HimanshuPracticalBE.DBModels
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        //public ICollection<User>? Users { get; set; }
        //public ICollection<UserDepartment>? UserDepartments { get; set; }
        public ICollection<UserLocation>? UserLocations { get; set; }
    }
}
