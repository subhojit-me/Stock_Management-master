using Stock_Management.Models.Data;
using Stock_Management.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stock_Management.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Index()
        {
            List<SaleViewVM> table = new List<SaleViewVM>();

            using (Db db = new Db() )
            {
                var bills = db.Sales.ToList();

                SaleViewVM row;
                
                foreach (var model in bills)
                {
                    row = new SaleViewVM(model);
                    table.Add(row);
                }
            }
            return View(table);
        }

        [HttpGet]
        public ActionResult CreateSaleInvoice()
        {
            using (Db db = new Db())
            {
                //Get all products to generate id and name pair for dropdown list in view
                var res = db.Products.ToList();

                //Create a list of SelectListItem which will be add to viewdata for transfering to the view.
                List<SelectListItem> list = new List<SelectListItem>();

                foreach(var model in res)
                {
                    //If any quantity is available then add to view rop down list
                    if(model.Quantity > 0)
                        list.Add(new SelectListItem()
                        {
                            //for every product id and name create a <SelectListItem> and add it to the list of <SelectListItem>
                            Text = model.Id.ToString(),
                            Value = model.Name
                        });
                }
                //Select list will be the dropdown list on view and it takes a list<SelectListItem> as parameter
                SelectList selectList = new SelectList(list);

                ViewBag.Productlist = new SelectList(list, "Text", "Value");
            }
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateSaleInvoice(StockVm model)
        {
            //Check if requested quantity is available in the stock
            using (Db db = new Db())
            {
                var avl = db.Products.Find(model.Id);
                if (avl.Quantity < model.Quantity)
                {
                    TempData["error"] = "Expected quantity s not available in stock";
                    return RedirectToAction("CreateSaleInvoice");
                }
            }

            using (Db db = new Db())
            {
                //Get the product from the product_Id received
                var product = db.Products.Find(model.Id);
                //Decrease the quantity of that product
                product.Quantity -= model.Quantity;

                    //Create the SaleDto model to add to database
                    SaleDTO saleModel = new SaleDTO()
                    {
                        //ProductName = model.Name,
                        Quantity = model.Quantity,
                        Price = model.Price,
                        Total = model.Price * model.Quantity,
                        date = DateTime.Now,
                        ProductName = product.Name
                    };
                    //saleModel.ProductName = product.Name;
                    db.Sales.Add(saleModel);

                //create the ProfitAndLossDTO mode to add data into profit and loss table
                //Net profit of the 
                ProfitAndLossDTO profitAndLossDTO = new ProfitAndLossDTO()
                {
                    Date = saleModel.date,
                    ProductName = saleModel.ProductName,
                    ProductValue = product.Price * saleModel.Quantity,
                    SoldValue = saleModel.Total,
                };
                profitAndLossDTO.Profit = profitAndLossDTO.SoldValue - profitAndLossDTO.ProductValue;
                //var p = db.ProfitAndLoss.Last();
                var p = db.ProfitAndLoss.OrderByDescending(x => x.Id).FirstOrDefault();
                profitAndLossDTO.NetProfit = profitAndLossDTO.Profit + p.NetProfit;
                db.ProfitAndLoss.Add(profitAndLossDTO);

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public int CheckAvailablity(int id)
        {
            using (Db db = new Db())
            {
                var prod = db.Products.Find(id);
                return prod.Quantity;
            }
        }
    }

}