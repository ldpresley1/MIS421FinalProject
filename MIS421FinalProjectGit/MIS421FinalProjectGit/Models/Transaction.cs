using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS421FinalProjectGit.Models
{
    public class Transaction
    {
        [Key]
        public Guid TransactionID { get; set; }
        public string TransType { get; set; }
        public string? TransCategory { get; set; }
        public double Amount { get; set; }
        public string? comments { get; set; }

        [Required]
        public int UserAccountID { get; set; }
        [ForeignKey("ID")]
        public UserAccount? UserAccount { get; set; }





    }
}
