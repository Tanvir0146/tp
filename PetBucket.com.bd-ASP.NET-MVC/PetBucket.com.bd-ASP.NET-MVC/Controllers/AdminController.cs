using PetBucket.com.bd_ASP.NET_MVC.Models;
using PetBucket.com.bd_ASP.NET_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using PetBucket.com.bd_ASP.NET_MVC.Models;
//using PetBucket.com.bd_ASP.NET_MVC.ViewModel;

namespace PetBucket.com.bd_ASP.NET_MVC.Controllers
{
    public class AdminController : Controller
    {
        

        // GET: AdminDashboard
        public ActionResult AdminDashboard()
        {
            var admins = AdminRepository.getAdmins();
            var customer = AdminRepository.getCustomers();
            var petsitter = AdminRepository.getPetsitters();
            var agencey = AdminRepository.getAgencies();
            var request_details = AdminRepository.getRequestTables();



            MultiModelData data = new MultiModelData();
            data.petbucket_admin = admins;
            data.petbucket_customer = customer;
            data.petbucket_petsitter = petsitter;
            data.petbucket_agency = agencey;
            data.petbucket_request_details = request_details;


            int customercount = data.petbucket_customer.Count();
            int petsittercount = data.petbucket_petsitter.Count();
            int agencycount = data.petbucket_agency.Count();
            int request_detailscount = data.petbucket_request_details.Count();

            int tcount = customercount + petsittercount + agencycount;
            int trcount = request_detailscount;

            ViewBag.Ccount = customercount;
            ViewBag.Pcount = petsittercount;
            ViewBag.Acount = agencycount;
            ViewBag.Tcount = tcount;
            ViewBag.TRcount = trcount;

            ViewBag.Rcount = request_detailscount;


            return View(data);

            
        }
        public ActionResult CustomerList()
        {
            var admins = AdminRepository.getAdmins();
            var customer = AdminRepository.getCustomers();
            var petsitter = AdminRepository.getPetsitters();
            var agencey = AdminRepository.getAgencies();
            var request_details = AdminRepository.getRequestTables();

            MultiModelData data = new MultiModelData();
            data.petbucket_customer = customer;
            data.petbucket_admin = admins;
            data.petbucket_petsitter = petsitter;
            data.petbucket_agency = agencey;
            data.petbucket_request_details = request_details;

            int customercount = data.petbucket_customer.Count();
            int petsittercount = data.petbucket_petsitter.Count();
            int agencycount = data.petbucket_agency.Count();
            int request_detailscount = data.petbucket_request_details.Count();

            int tcount = customercount + petsittercount + agencycount;
            int trcount = request_detailscount;

            ViewBag.Ccount = customercount;
            ViewBag.Pcount = petsittercount;
            ViewBag.Acount = agencycount;
            ViewBag.Tcount = tcount;
            ViewBag.TRcount = trcount;
            ViewBag.Rcount = request_detailscount;

            return View(data);
        }
        public ActionResult RequestDetails()
        {
            var admins = AdminRepository.getAdmins();
            var customer = AdminRepository.getCustomers();
            var petsitter = AdminRepository.getPetsitters();
            var agencey = AdminRepository.getAgencies();
            var request_details = AdminRepository.getRequestTables();

            MultiModelData data = new MultiModelData();
            data.petbucket_customer = customer;
            data.petbucket_admin = admins;
            data.petbucket_petsitter = petsitter;
            data.petbucket_agency = agencey;
            data.petbucket_request_details = request_details;

            int customercount = data.petbucket_customer.Count();
            int petsittercount = data.petbucket_petsitter.Count();
            int agencycount = data.petbucket_agency.Count();
            int request_detailscount = data.petbucket_request_details.Count();

            int tcount = customercount + petsittercount + agencycount;
            int trcount = request_detailscount;

            ViewBag.Ccount = customercount;
            ViewBag.Pcount = petsittercount;
            ViewBag.Acount = agencycount;
            ViewBag.Tcount = tcount;
            ViewBag.TRcount = trcount;
            ViewBag.Rcount = request_detailscount;

            return View(data);
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer c)
        {
            try {
                using (PetsitterPetbucketEntities db = new PetsitterPetbucketEntities())
                {
                    if (db.Logins.Any(x => x.Email == c.email))
                    {
                        ViewBag.RegisterErrorMessage = "This Email Is Already Exist In Our Database.";
                        ViewBag.RegisterErrorMessage = "Please Try Another Email.";
                        return View("AddCustomer", c);
                    }
                    Login l = new Login();
                    l.Email = c.email;
                    l.Password = c.password;
                    l.Name = c.name;
                    l.type = "customer";
                    db.Logins.Add(l);
                    c.balance = 100;
                    db.Customers.Add(c);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.RegisterSuccessMessage = "Registration Successfull";
                return View("AddCustomer", new Customer());
            } 
            catch {
                ViewBag.RegisterSuccessMessage = "Server ERROR! Please Enter Valid Information.";
                return View("AddCustomer", new Customer());
            }
            
        }

        public ActionResult CustomerDetails(int Id)
        {
            PetsitterPetbucketEntities db = new PetsitterPetbucketEntities();
            var customer = (from cu in db.Customers
                           where cu.id == Id
                           select cu).First();
            return View(customer);
        }
        public ActionResult DeleteCustomer(int Id)
        {
            using (PetsitterPetbucketEntities db = new PetsitterPetbucketEntities())
            {
                Customer c = (from cu in db.Customers
                             where cu.id == Id
                             select cu).FirstOrDefault();
                return View(c);
            }
        }
        [HttpPost]
        public ActionResult DeleteCustomer(Customer c)
        {
            using (PetsitterPetbucketEntities db = new PetsitterPetbucketEntities())
            {
                Customer entity = (from cu in db.Customers
                                  where cu.id == c.id
                                  select cu).FirstOrDefault();
                Login Lentity = (from L in db.Logins
                                   where L.Email == L.Email
                                   select L).FirstOrDefault();
                db.Customers.Remove(entity);
                db.Logins.Remove(Lentity);
                db.SaveChanges();
                return RedirectToAction("CustomerList","Admin");
            }
        }

        public ActionResult EditCustomer(int Id)
        {
            PetsitterPetbucketEntities db = new PetsitterPetbucketEntities();
            var customer = (from cu in db.Customers
                           where cu.id == Id
                           select cu).First();
            return View(customer);
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer c)
        {
            using (PetsitterPetbucketEntities db = new PetsitterPetbucketEntities())
            {
                Customer entity = (from cu in db.Customers
                                   where cu.id == c.id
                                  select cu).FirstOrDefault();
                entity.name = c.name;
                entity.email = c.email;
                entity.password = c.password;
                entity.address = c.address;
                entity.nid = c.nid;
                entity.phone = c.phone;
                entity.balance = c.balance;

                //db.Entry(entity).CurrentValues.SetValues(c);
                db.SaveChanges();
                return RedirectToAction("CustomerList", "Admin");
            }

        }
        public ActionResult AdminDetails(int Id)
        {
            PetsitterPetbucketEntities db = new PetsitterPetbucketEntities();
            var admin = (from ad in db.Admins
                            where ad.id == Id
                            select ad).First();
            return View(admin);
        }
    }
}