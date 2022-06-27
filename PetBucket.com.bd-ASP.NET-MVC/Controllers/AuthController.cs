
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PetBucket.com.bd_ASP.NET_MVC.Models;

namespace PetBucket.com.bd_ASP.NET_MVC.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {
            Login l = new Login();
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login l)
        {
            AdminPetbucketEntities db = new AdminPetbucketEntities();
            if (db.Logins.Where(x => x.Email == l.Email && x.Password == l.Password).FirstOrDefault() == null)
            {
                ViewBag.LoginErrorMessage = "Invalid Username or Password";
                return View();
            }
            else
            {
                
                FormsAuthentication.SetAuthCookie(l.Email, true);
                Session["email"] = l.Email;
                
                return RedirectToAction("AdminDashboard", "Admin");
                
               
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return View("LandingPage");
        }
        public ActionResult LandingPage()
        {
           
            return View();
        }

        public ActionResult CustomerRegistration()
        {
            return View();
        }
        public ActionResult CustomerRegister()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerRegister( Customer c)
        {
            
            using(AdminPetbucketEntities db =new AdminPetbucketEntities())
            {
                if (db.Logins.Any(x => x.Email == c.email))
                {
                    ViewBag.RegisterErrorMessage = "email already exist";
                    return View("CustomerRegister", c);
                }
                Login l = new Login();
                l.Email = c.email;
                l.Password = c.password;
                l.Name = c.name;
                l.type = "customer";
                db.Logins.Add(l);
                db.Customers.Add(c);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.RegisterSuccessMessage = "Registration Successfull";
            return View("CustomerRegister", new Customer());
        }
    }
}
