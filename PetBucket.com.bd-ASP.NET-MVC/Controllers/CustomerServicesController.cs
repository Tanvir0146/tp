using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetBucket.com.bd_ASP.NET_MVC.Controllers
{
    public class CustomerServicesController : Controller
    {
        // GET: CustomerServices
        public ActionResult DogWalking()
        {
            return View();
        }
        public ActionResult PetDayCare()
        {
            return View();
        }
    }
}