using System.ComponentModel.DataAnnotations;

namespace MIS421FinalProjectGit.Models
{
    public class UserAccount
    {
        [Key]
        public Guid ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public string UserAccountType { get; set; }
        public DateTime LastLogin { get; set; }

    }
}
