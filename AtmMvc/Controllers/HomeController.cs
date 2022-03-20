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
        //public ActionResult Index()
        //{
        //    return View();
        //}


        public ActionResult Index()
        {
            if (Request["txt"] != null)
            {
                //    if (Request["txt"][Request["txt"].Length - 1] == '+' || Request["txt"][Request["txt"].Length - 1] == '-' || Request["txt"][Request["txt"].Length - 1] == '*' || Request["txt"][Request["txt"].Length - 1] == '/')
                //    {
                //        ViewBag.flag = 0;
                //        ViewBag.result = Request["txt"];
                //    }
                //    else
                //    {
                //ViewBag.result = GetResult(Request["txt"]);

                //ViewBag.result = CalculateCashWithdrawalCurrency(Request["txt"]);
                //ViewBag.flag = 1;
                ViewBag.Total = Request["txt"];
                List<Currency> lstAllCurrencies = new List<Currency>();
                ViewBag.Model = lstAllCurrencies = CalculateCashWithdrawalCurrency(Request["txt"]);
                ViewBag.Notes = lstAllCurrencies.Where(a => a.CurrencyType == Common.Enums.DemoninationType.Notes);
                ViewBag.BigCoins = lstAllCurrencies.Where(a => a.CurrencyType == Common.Enums.DemoninationType.BigCoins);
                ViewBag.SmallCoins = lstAllCurrencies.Where(a => a.CurrencyType == Common.Enums.DemoninationType.SmallCoins);

                return View("About", ViewBag);

                //}
            }
            return View();


        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.model = new List<Currency>();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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