using HimanshuPracticalBE.DBModels;

namespace HimanshuPracticalBE.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }

    public class LocationNameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}
