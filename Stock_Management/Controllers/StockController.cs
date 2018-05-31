using Stock_Management.Models.Data;
using Stock_Management.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Stock_Management.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
            //Declare list of StockVm
            List<StockVm> products;

            //Initilize the list with data from database
            using (Db db = new Db())
            {
                products = db.Products.Include("Category")
                    .ToList()
                    .OrderBy(x => x.Id)
                    .Select(x => new StockVm(x))
                    .ToList();
            }
           
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> slist = new List<SelectListItem>();
            ///get categories from database and send to view as a drop down
            using (Db db = new Db())
            {
                var cat = db.categories.ToList();
                foreach (var item in cat)
                {
                    slist.Add(new SelectListItem()
                    {
                        Text = item.Id.ToString(),
                        Value = item.Categoryname
                    });
                }
            }
            ViewBag.CategoryList = new SelectList(slist, "Text","Value");

            return View();
        }

        [HttpPost]
        public ActionResult Create(StockVm model)
        {
            //check if Model state is valid then return
            if (! ModelState.IsValid)
            {
                return View(model); //this model will af=gain dislay in the input form
            }

            //copy from view model to DTO
            StockDTO dto = new StockDTO()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Quantity = model.Quantity
            };

            using(Db db = new Db())
            {
                db.Products.Add(dto);
                db.SaveChanges();
            }

            TempData["cnf"] = "You have added a new item in stock";
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            StockVm model;
            List<SelectListItem> slist = new List<SelectListItem>();

            using (Db db = new Db())
            {
                //Find the product with the id received
                var product = db.Products.Include("Category").Single(x => x.Id ==id);

                if(product == null)
                {
                    return Content("Requested page dows not exist");
                }
                 model = new StockVm(product);

                var listFromDb = db.categories.ToList();
                foreach(var item in listFromDb)
                {
                    slist.Add(new SelectListItem()
                    {
                        Text = item.Id.ToString(),
                        Value = item.Categoryname
                    });
                }
            }
            ViewBag.categoryDropDown = new SelectList(slist, "Text","Value" );
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProduct(StockVm model)
        {
            if(!ModelState.IsValid)
            {
                return Content("Invalid data received for update");
            }
            
            using (Db db = new Db())
            {
                var product = db.Products.Include("Category").Single(p => p.Id == model.Id);

                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.Quantity = model.Quantity;

                //get foreign key by the of the model parameter add this as a refference of product's category table.
                CategoryDTO cat = db.categories.Single(c => c.Id == model.CategoryId);
                product.Category = cat;

                db.SaveChanges();
            }
            TempData["cnf"] = "Product data successfully edited";
            return RedirectToAction("Index","Stock");
        }

        public ActionResult DeleteProduct(int id)
        {
            using (Db db = new Db() )
            {
                var product = db.Products.Find(id);
                if (product == null)
                    return Content("Product not found for delete");

                db.Products.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}