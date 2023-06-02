using System.ComponentModel.DataAnnotations;

namespace HimanshuPracticalBE.DBModels
{
    public class UserLocation
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
