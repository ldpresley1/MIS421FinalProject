using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MIS421FinalProjectGit.Models;

namespace MIS421FinalProjectGit.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MIS421FinalProjectGit.Models.UserAccount> UserAccount { get; set; }
        public DbSet<MIS421FinalProjectGit.Models.Bill> Bill { get; set; }
        public DbSet<MIS421FinalProjectGit.Models.Investment> Investments { get; set; }
        public DbSet<MIS421FinalProjectGit.Models.Transaction> Transactions { get; set; }
        public DbSet<MIS421FinalProjectGit.Models.Budget> Budget { get; set; }
    }
}
