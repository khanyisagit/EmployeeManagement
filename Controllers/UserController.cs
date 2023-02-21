using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class UserController : Controller
    {
        EmployeeDapperDBEntities db = new EmployeeDapperDBEntities();
        // GET: User
        public ActionResult Index()
        {
            //return View(db.tbl_Registration.ToList());
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]

        public ActionResult SignUp(tbl_Registration TBL_Registration)
        {
            if (db.tbl_Registration.Any(x=>x.User_EmailAddress == TBL_Registration.User_EmailAddress))
            {
                ViewBag.Notification = "This account already exist";
                return View();
            }
            else
            {
                db.tbl_Registration.Add(TBL_Registration);
                db.SaveChanges();

                //Session["User_Id"] = TBL_Registration.User_Id.ToString();
                //Session["User_EmailAddress"] = TBL_Registration.User_EmailAddress.ToString();

                return RedirectToAction("Login", "User");  
            }   

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tbl_Registration TBL_Registration)
        {

            var checkLogin = db.tbl_Registration.Where(x=> x.User_EmailAddress.Equals(TBL_Registration.User_EmailAddress)
            && x.Password.Equals(TBL_Registration.Password));

            if(checkLogin != null)
            {
                Session["User_Id"] = TBL_Registration.User_Id.ToString();
                Session["User_EmailAddress"] = TBL_Registration.User_EmailAddress.ToString();
                return RedirectToAction("Index", "Employee");

            }
            else
            {
                ViewBag.Notification = "Wrong Username or Password!!";
            }

            return View();
        }

        public ActionResult Logout(tbl_Registration TBL_Registration)
        {
            Session.Clear();
            return RedirectToAction("Login", "User");
        }
    }
}