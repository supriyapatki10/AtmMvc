using AtmMvc.Common.Enums;

namespace AtmMvc.Models
{
    public class Currency
    {
        public DemoninationType CurrencyType { get; set; }
        public int CurrencyCount { get; set; }
        public int CurrencyAmount { get; set; }
    }
}