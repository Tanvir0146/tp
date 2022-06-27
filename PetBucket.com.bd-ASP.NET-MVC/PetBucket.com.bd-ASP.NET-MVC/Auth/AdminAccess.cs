using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetBucket.com.bd_ASP.NET_MVC.Models;

namespace PetBucket.com.bd_ASP.NET_MVC.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAccess : AuthorizeAttribute 
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var flag = base.AuthorizeCore(httpContext);
            if (flag)
            {
                var email = httpContext.User.Identity.Name;
                PetBucketEntities db = new PetBucketEntities();
                var type = db.Logins.Where(x => x.Email == email).FirstOrDefault();
              
                if (type.type == "admin") return true;

            }
            return false;
        }


    }
}