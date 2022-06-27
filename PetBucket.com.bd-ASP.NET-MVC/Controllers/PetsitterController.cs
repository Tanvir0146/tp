using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetBucket.com.bd_ASP.NET_MVC.Controllers
{
    public class PetsitterController : Controller
    {
        // GET: Petsitter
        public ActionResult PetsitterDashboard()
        {
            return View();
        }
    }
}