namespace HimanshuPracticalBE.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DepartmentwiseLocation
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public bool IsSelected { get; set; } = false;
        public List<LocationNameModel>? LocationNames { get; set; }
    }
}
