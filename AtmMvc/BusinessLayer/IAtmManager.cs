using System.Collections.Generic;
using System.Threading.Tasks;
using AtmMvc.Common.Enums;
using AtmMvc.Models;

namespace AtmMvc.BusinessLayer
{
    public interface IAtmManager
    {
        //Task<int> CalculateCashDispenseAmount(int total);

        //Task<bool> AddMoneyType(DemoninationType type, int amount, int? coinDiameter);

        List<Currency> CalculateCashWithdrawalCurrency(int total);

        bool AddMoneyType(DemoninationType type, int amount, int? coinDiameter);
    }
}
