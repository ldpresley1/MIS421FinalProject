using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS421FinalProjectGit.Models
{
    public class Investments
    {
        [Key]
        public Guid BillID { get; set; }
        public string InvestmentType { get; set; }
        public string? Description { get; set; }
        public int RiskLevel { get; set; }

        [Required]
        public Guid ApplicationUserID { get; set; }
        [ForeignKey("ID")]
        public ApplicationUser? ApplicationUser { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Investment Image")]
        public byte[]? InvestmentImage { get; set; }
    }
}
