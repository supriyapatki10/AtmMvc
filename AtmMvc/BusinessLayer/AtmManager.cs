using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AtmMvc.Common.Enums;
using AtmMvc.Models;

namespace AtmMvc.BusinessLayer
{
    public class AtmManager : IAtmManager
    {

        //public async Task<int> CalculateCashDispenseAmount(int total)
        //{

        //    return 0;

        //}

        //public async Task<bool> AddMoneyType(DemoninationType type, int amount, int? coinDiameter)
        //{
        //     return  true;
        //}

        public List<Currency> CalculateCashWithdrawalCurrency(int total)
        {

			return countCurrency(total);
        }

        public bool AddMoneyType(DemoninationType type, int amount, int? coinDiameter)
        {
            return true;
        }


        // C# program to accept an amount
// and count number of notes


		// function to count and
		// print currency notes
		private static string countCurrencyOld(int amount)
		{
			StringBuilder strNotes = new StringBuilder();
            int[] notes = new int[] { 2000, 500, 200, 100, 50, 20, 10, 5, 1 };
			int[] noteCounter = new int[9];

			// count notes using Greedy approach
			for (int i = 0; i < 9; i++)
			{
				if (amount >= notes[i])
				{
					noteCounter[i] = amount / notes[i];
					amount = amount - noteCounter[i] * notes[i];
				}
			}

			// Print notes
			strNotes.Append ("Currency Count -> ");
			Console.WriteLine("Currency Count ->");
			for (int i = 0; i < 9; i++)
			{
				if (noteCounter[i] != 0)
				{
					
					strNotes.Append(notes[i] + " : " + noteCounter[i] + " , ");
					Console.WriteLine(notes[i] + " : "
						+ noteCounter[i]);
				}
			}

			return strNotes.ToString();
		}

		private static List<Currency> countCurrency(int amount)
		{
			StringBuilder strNotes = new StringBuilder();
			List<Currency> lstCurrencies = new List<Currency>();

			 string _currencies = ConfigurationManager.AppSettings["Currencies"];

			if (_currencies != null)
			{				
				string[] arrCurrency =  _currencies.Split(',');
				//int[] notes = new int[] { 2000, 500, 200, 100, 50, 20, 10, 5, 1 };
				int[] noteCounter = new int[arrCurrency.Length];
				int[] notes = new int[arrCurrency.Length];
				//Dictionary<string, string> currencyCollection  = _currencies.Split(',');
				//var settings = Settings.Default.StatusReason;
				//Dictionary<string, string> statusReason = new Dictionary<string, string>(); 


				//var lstNotes = from c in arrCurrency
				//			   select c.Split(';').Select(a=>a[0]).OrderBy(a=> a[1])



				//int[] notes = new int[] { 2000, 500, 200, 100, 50, 20, 10, 5, 1 };
				//int[] noteCounter = new int[9];

				for (int i = 0; i < arrCurrency.Length; i++)
				{
					var cur = arrCurrency[i].Split(';');
					var atmAmount = Convert.ToInt32(cur[0]);
					var atmAmountType = (DemoninationType) Convert.ToInt32(cur[1]);

					if (amount >= atmAmount)
					{
						noteCounter[i] = amount / atmAmount;
						amount = amount - noteCounter[i] * atmAmount;

						lstCurrencies.Add(new Currency
						{
							CurrencyAmount = atmAmount,
							CurrencyCount = noteCounter[i],
							CurrencyType = atmAmountType
						});
					}
				}

				
				//// Print notes
				//strNotes.Append("Currency Count -> ");
				//Console.WriteLine("Currency Count ->");
				//for (int i = 0; i < 9; i++)
				//{
				//	if (noteCounter[i] != 0)
				//	{

				//		strNotes.Append(notes[i] + " : " + noteCounter[i] + " , ");
				//		Console.WriteLine(notes[i] + " : "
				//			+ noteCounter[i]);
				//	}
				//}
			}
			//return strNotes.ToString();
			return lstCurrencies;
		}

		//// Driver function
		//public static void Main()
		//{
		//	int amount = 868;
		//	countCurrency(amount);
		//}


	}

}