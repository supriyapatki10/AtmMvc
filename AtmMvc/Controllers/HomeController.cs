using AtmMvc.BusinessLayer;
using AtmMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtmMvc.Controllers
{
    public class HomeController : Controller
    {
        private IAtmManager atmManager;
        
        public ActionResult Index()
        {
            if (Request["txt"] != null)
            {              
                ViewBag.Total = Request["txt"];
                List<Currency> lstAllCurrencies = new List<Currency>();
                ViewBag.Model = lstAllCurrencies = CalculateCashWithdrawalCurrency(Request["txt"]);
                ViewBag.Notes = lstAllCurrencies.Where(a => a.CurrencyType == Common.Enums.DemoninationType.Notes);
                ViewBag.BigCoins = lstAllCurrencies.Where(a => a.CurrencyType == Common.Enums.DemoninationType.BigCoins);
                ViewBag.SmallCoins = lstAllCurrencies.Where(a => a.CurrencyType == Common.Enums.DemoninationType.SmallCoins);

                return View("Deposit", ViewBag);
            }
            return View();


        }


        public ActionResult Deposit()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Model = ViewBag.Notes = ViewBag.BigCoins = ViewBag.SmallCoins = new List<Currency>();
            return View();
        }      


        public string GetResult(string str)
        {
            List<char> symbleList = new List<char>();
            char[] charSymble = { '+', '-', '*', '/' };
            string[] st = str.Split(charSymble);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '/')
                {
                    symbleList.Add(str[i]);
                }
            }
            double result = Convert.ToDouble(st[0]);
            for (int i = 1; i < st.Length; i++)
            {
                double num = Convert.ToDouble(st[i]);
                int j = i - 1;
                switch (symbleList[j])
                {
                    case '+':
                        result = result + num;
                        break;
                    case '-':
                        result = result - num;
                        break;
                    case '*':
                        result = result * num;
                        break;
                    case '/':
                        result = result / num;
                        break;
                    default:
                        result = 0.0;
                        break;
                }
            }
            return result.ToString();
        }

        public List<Currency> CalculateCashWithdrawalCurrency(string str)
        {
            atmManager  = new AtmManager();
                var listNotes = atmManager.CalculateCashWithdrawalCurrency(Convert.ToInt32(str));
            return listNotes;
        }        
    }
}