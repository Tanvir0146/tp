using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetBucket.com.bd_ASP.NET_MVC.Models
{
    public class MultiModelData
    {
        public List<Admin> petbucket_admin { get; set; }
        public List<Customer> petbucket_customer { get; set; }
        public List<Petsitter> petbucket_petsitter { get; set; }
        public List<Agency> petbucket_agency { get; set; }
        public List<RequestTable> petbucket_request_details { get; set; }
    }
}