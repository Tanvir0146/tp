using PetBucket.com.bd_ASP.NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetBucket.com.bd_ASP.NET_MVC.Repository
{
    public class PetsitterRepository
    {
            static PetsitterPetbucketEntities db;
            static PetsitterRepository()
            {
                db = new PetsitterPetbucketEntities();
            }

            public Petsitter Get(string id)
            {
                var pe = (from e in db.Petsitters
                          where e.id == id
                          select e).FirstOrDefault();
                var p = db.Petsitters.FirstOrDefault(e => e.id == id);
                return p;
            }


            public static List<Petsitter> getPetsitters()
            {
                var petsitters = db.Petsitters.ToList();
                return petsitters;
            }
            

        }
    }
