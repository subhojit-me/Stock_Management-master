using Stock_Management.Models.Data;
using Stock_Management.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stock_Management.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            //confirm user is not logged in
            string uname = User.Identity.Name;

            if (! string.IsNullOrEmpty(uname))
            {
                return RedirectToAction("User-Profile");
            }

            return View();
        }

        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(UserVM model)
        {
            if(! ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error in input detail");
                return View(model);
            }
            using (Db db = new Db())
            {

                //check if username is already taken
                var check = db.users.FirstOrDefault(x => x.UserName == model.UserName);
                //if taken send view with the alert

                if (check != null)
                {
                    ModelState.AddModelError("Error", "username is already taken kindly try another username");
                     TempData.Add("Error", "username is already taken kindly try another username");
                    return View(model);
                }

                //check if mail id is already exist in database
                var check2 = db.users.Where(x => x.Email == model.Email);
                //if exist send error to view
                if (check2 == null)
                {
                    ModelState.AddModelError("error", "Mail id aready exist");
                    TempData.Add("Error", "Mail id aready exist");
                    return View(model);
                }

                //else check if password and confirm password is same
                //if both the password matched then add it to the database
                if (model.Password.Equals(model.ConfirmPassword))
                {
                     UserDTO dto = new UserDTO(){
                        UserName = model.UserName,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = model.Password,
                    };
                    db.users.Add(dto);
                    db.SaveChanges();
                    
                }
                else
                {
                    ModelState.AddModelError("error", "Password and Confirm password do not match");
                    return View(model);
                }
            }


            return View();
        }

        public string CheckNameAvailablity(string name)
        {
            using (Db db = new Db())
            {
                var namesInDb = db.users.ToArray().SelectMany(x => x.FirstName).ToString();

                var check = db.users.Any(x => x.UserName == name);
                var check2 = db.users.FirstOrDefault(x => x.UserName == name);

                if (check2 == null)
                  return "Accepted";
            }

            return "Not Accepted";
        }
    }
}