using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS421FinalProjectGit.Models
{
    public class Budget
    {
        [Key]
        public Guid BudgetID { get; set; }
        public string BugetItem { get; set; }
        public double Amount { get; set; }
        public string? Description { get; set; }


        [Required]
        public Guid ApplicationUserID { get; set; }
        [ForeignKey("ID")]
        public ApplicationUser? ApplicationUser { get; set; }


    }
}
