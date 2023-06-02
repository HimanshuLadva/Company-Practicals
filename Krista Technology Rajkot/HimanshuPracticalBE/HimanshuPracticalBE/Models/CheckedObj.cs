namespace HimanshuPracticalBE.Models
{
    public class CheckedObj
    {
        public List<string>? Departments { get; set; }
        public List<locCheckObj>? Locations { get; set; }
    }

    public class locCheckObj
    {
        public string? Id { get; set; }
        public string? DeptID { get; set; }
    }
}
