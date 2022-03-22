using Blazor.FinanceMentor.Shared;

namespace Blazor.FinanceMentor.Client.Components
{
    public class EarningModel
    {
        public DateTime Date { get; set; }

        public string Subject { get; set; }
        
        public EarningCategory Category { get; set; }
        
        public decimal Amount { get; set; }
    }
}
