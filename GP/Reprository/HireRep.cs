using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.Models;


namespace GP.Controllers.Repository
{
    public class HireRep
    {
        GPContext db;

        public HireRep(GPContext db)
        {
            this.db = db;
        }
        public List<FreelancerHire> dealsWithFreelancer(int phone)
        {
            List<FreelancerHire> freelancerDeals = db.FreelancerHires.Where(i=> i.FreelancerPho == phone).ToList();

            return freelancerDeals;
        }

        public List<FreelancerHire> dealsWithClient(int phone)
        {
            List<FreelancerHire> clientDeals = db.FreelancerHires.Where(i => i.ClientPho == phone).ToList();

            return clientDeals;
        }

        //to knwo deals spacific client and freelancer 
        public List<FreelancerHire> dealsClientFreelancer(int clientPho , int freelanerPho)
        {
            List<FreelancerHire> clientFreelancerDeals = db.FreelancerHires.Where(i => i.ClientPho == clientPho && i.FreelancerPho == freelanerPho).ToList();
            return clientFreelancerDeals;
        }

        //Get Deals with spacific date 
        public List<FreelancerHire> dealsWithDate(DateTime date)
        {
            List<FreelancerHire> deals = db.FreelancerHires.Where(i => i.HireDate == date).ToList();
            return deals;
        }

        //get Deals with spacific date and spacific freelancer 
        public List<FreelancerHire> dealsWithDate(DateTime date , int phone)
        {
            List<FreelancerHire> deals = db.FreelancerHires.Where(i => i.HireDate == date && i.FreelancerPho == phone ).ToList();
            return deals;
        }


        //get Deals with spacific date and spacific Client 
        public List<FreelancerHire> dealsClientWithDate(DateTime date, int phone)
        {
            List<FreelancerHire> deals = db.FreelancerHires.Where(i => i.HireDate == date && i.ClientPho == phone).ToList();
            return deals;
        }


    }
}
