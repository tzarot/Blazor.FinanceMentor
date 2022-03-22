using System.ComponentModel.DataAnnotations;
using Blazor.FinanceMentor.Shared;

namespace Blazor.FinanceMentor.Client.Components
{
    public class EarningModel
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        [Required]
        public EarningCategory Category { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
