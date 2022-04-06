using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TestProject.Models;
using System.Web.Security;

namespace TestProject.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public MVCTestEntities2 db = new MVCTestEntities2();
        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUP(User_SignUp_Table model)
        {
            if(ModelState.IsValid)
            {
                db.User_SignUp_Table.Add(model);
                db.SaveChanges();   
                return RedirectToAction("Login");
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            bool isvalid = db.User_SignUp_Table.Any(x => x.UserMail==model.UserMail && x.Password == model.Password);
            if (isvalid == true)
            {
                FormsAuthentication.SetAuthCookie(model.UserMail, true);
                return RedirectToAction("Dashboard", "Organization");
            }
            else
            {
                TempData["Message"] = "Invalid UserName and Password...!!";
            }
            
            //ModelState.AddModelError("", "Invalid Username and PAssword...!!");
            return View();
            //return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}