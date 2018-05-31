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
                balancelist = db.ProfitAndLoss.ToArray().OrderBy(x => x.Id).Select(x => new ProfitAndLossVM(x)).ToList();
            }

            return View(balancelist);
        }
    }
}