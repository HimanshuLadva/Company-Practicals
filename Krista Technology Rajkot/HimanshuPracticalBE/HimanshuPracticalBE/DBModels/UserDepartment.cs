using System.ComponentModel.DataAnnotations;

namespace HimanshuPracticalBE.DBModels
{
    public class UserDepartment
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
