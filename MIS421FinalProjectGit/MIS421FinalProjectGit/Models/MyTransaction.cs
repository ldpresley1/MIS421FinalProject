using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS421FinalProjectGit.Models
{
    public class MyTransaction
    {

        [Key]
        public Guid TransactionID { get; set; }
        public string TransType { get; set; }
        public string? TransCategory { get; set; }
        public double Amount { get; set; }
        public string? comments { get; set; }

        [Required]
        public Guid ApplicationUserID { get; set; }
        [ForeignKey("ID")]
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
