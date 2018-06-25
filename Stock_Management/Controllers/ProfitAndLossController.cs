using Stock_Management.Models.Data;
using Stock_Management.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stock_Management.Controllers
{
    public class ProfitAndLossController : Controller
    {
        // GET: ProfitAndLoss
        public ActionResult Index()
        {
            List<ProfitAndLossVM> balancelist;
            using (Db db = new Db() )
            {
                /*It checks if any data exist in profit and loss table
                 * If available then shows it to the display board
                 * else 
                 * shows a value that no any value is available.
                */

                if (db.ProfitAndLoss.Count() == 0)
                {
                    balancelist = new List<ProfitAndLossVM>();
                    var templist = new ProfitAndLossVM()
                    {
                        Date = DateTime.Now,
                        ProductName = "No Value sold yet",
                        ProductValue = 0,
                        SoldValue = 0,
                        Profit = 0,
                        NetProfit = 0
                    };
                    balancelist.Add(templist);
                    return View(balancelist);
                }

                balancelist = db.ProfitAndLoss.ToArray().OrderBy(x => x.Id).Select(x => new ProfitAndLossVM(x)).ToList();
            }
            return View(balancelist);
        }
    }
}