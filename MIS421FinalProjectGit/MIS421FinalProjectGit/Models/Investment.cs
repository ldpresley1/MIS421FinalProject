using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS421FinalProjectGit.Models
{
    public class Investment
    {
        [Key]
        public Guid BillID { get; set; }
        public string InvestmentType { get; set; }
        public string? Description { get; set; }
        public int RiskLevel { get; set; }

        [Required]
        public int UserAccountID { get; set; }
        [ForeignKey("ID")]
        public UserAccount? UserAccount { get; set; }

    }
}
