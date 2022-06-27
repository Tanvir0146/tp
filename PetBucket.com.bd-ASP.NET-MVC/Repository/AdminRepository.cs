using PetBucket.com.bd_ASP.NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetBucket.com.bd_ASP.NET_MVC.Repository
{
    public class AdminRepository
    {
        static PetsitterPetbucketEntities db;
        static AdminRepository()
        {
            db = new PetsitterPetbucketEntities();
        }

        public Admin Get(int id)
        {
            var ad = (from e in db.Admins
                      where e.id == id
                      select e).FirstOrDefault();
            var a = db.Admins.FirstOrDefault(e => e.id == id);
            return a;
        }


        public static List<Admin> getAdmins()
        {
            var admins = db.Admins.ToList();
            return admins;
        }
        public static List<Customer> getCustomers()
        {
            var customers = db.Customers.ToList();
            return customers;
        }
        public static List<Petsitter> getPetsitters()
        {
            var petsitters = db.Petsitters.ToList();
            return petsitters;
        }
        public static List<Agency> getAgencies()
        {
            var agencies = db.Agencies.ToList();
            return agencies;
        }
        public static List<RequestTable> getRequestTables()
        {
            var requestTables = db.RequestTables.ToList();
            return requestTables;
        }

    }
}