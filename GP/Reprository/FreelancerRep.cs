using System;
using System.Collections.Generic;
using System.Linq;
using GP.Models;


namespace GP.Controllers.Repository
{
    public class FreelancerRep
    {
        GPContext db;

        public FreelancerRep(GPContext db)
        {
            this.db = db;
        }

        public List<Freelancer> GetFreelancers()
        {
            List<Freelancer> freelancers = db.Freelancers.ToList();
        
            return freelancers;
        }

        public  Freelancer GetFreelancer(int phone)
        {
            Freelancer f = db.Freelancers.Where(i => i.Phone == phone).SingleOrDefault();
            return f;
        }

        public void addFreelancer(Freelancer f)
        {
            db.Freelancers.Add(f);
            db.SaveChanges();
        }

        public void deleteFreelancer(int phone)
        {
            Freelancer f = db.Freelancers.Where(i => i.Phone == phone).SingleOrDefault();
            db.Freelancers.Remove(f);
            db.SaveChanges();
        }
        public void editFreelancer(int phone,Freelancer f)
        {
            Freelancer f1 = db.Freelancers.Where(i => i.Phone == phone).SingleOrDefault();
            f1.Phone = phone;
            f1.Name = f.Name;
            f1.Password = f1.Password;
            f1.WorkCity = f.WorkCity;
            f1.WorkCountry = f.WorkCountry;
            f1.WorkDistrict = f.WorkDistrict;
            f1.ProfId = f.ProfId;
            f1.Email = f.Email;
            f1.Rate = f1.Rate;
            db.SaveChanges();
        }


    }
}
