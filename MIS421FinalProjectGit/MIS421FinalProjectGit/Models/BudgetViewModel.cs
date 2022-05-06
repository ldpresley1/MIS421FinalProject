using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIS421FinalProjectGit.Models
{
    public class BudgetViewModel
    {
        [Key]
        public Guid BudgetID { get; set; }
        public double Balance { get; set; }
        public double LeftoverEarnings { get; set; }
        public double initialBalance { get; set; }
        [Required]
        public Guid ApplicationUserID { get; set; }
        [ForeignKey("ID")]
        public ApplicationUser? ApplicationUser { get; set; }
        public class MyTranscation
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

        public class MyBill
        {
            [Key]
            public Guid BillID { get; set; }
            public string BillType { get; set; }
            public DateTime DueDate { get; set; }
            public double Amount { get; set; }
            public DateTime DayPaid { get; set; }
            public string? Description { get; set; }

            [Required]
            public Guid ApplicationUserID { get; set; }
            [ForeignKey("ID")]


            public ApplicationUser? ApplicationUser { get; set; }
        }
    }
}
