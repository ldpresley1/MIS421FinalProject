using Microsoft.AspNetCore.Identity;

namespace MIS421FinalProjectGit.Models
{
    public class ApplicationUser : IdentityUser
    {
      
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string? Address { get; set; }

            public string DateOfBirth { get; set; }

            public string PhoneNumber { get; set; }

            public DateTime LastLogin { get; set; }
            
     

    }

}
