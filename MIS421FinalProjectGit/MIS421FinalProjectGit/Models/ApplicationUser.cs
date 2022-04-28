using Microsoft.AspNetCore.Identity;

namespace MIS421FinalProjectGit.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int RiskLevel { get; set; } = 0;
    }
}
