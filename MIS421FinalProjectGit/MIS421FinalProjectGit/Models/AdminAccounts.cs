using System.ComponentModel.DataAnnotations;

namespace MIS421FinalProjectGit.Models
{
    public class AdminAccounts
    {
        [Key]
        public Guid AdminID { get; set; }
        public string AdminFName { get; set; }
        public string AdminLName { get; set; }
        public string AdminEmail { get; set; }
        public DateTime AdminLastLogin { get; set; }
    }
}
