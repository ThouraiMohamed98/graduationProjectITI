using GP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.Reprository
{
    public class GigReprository
    {
        GPContext db;
        public GigReprository(GPContext db)
        {
            this.db = db;
        }

        public List<Gig> getall()
        {
            return db.Gigs.ToList();
        }
        public Gig getByid(int id)
        {
            return db.Gigs.Find(id);
        }

        public void add(Gig g)
        {
            db.Gigs.Add(g);
            db.SaveChanges();
        }



        public void update(Gig g)
        {
            db.Entry(g).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void delete(int id)
        {
            Gig g = db.Gigs.Where(n => n.GigId == id).FirstOrDefault();
            db.Gigs.Remove(g);
            db.SaveChanges();
        }
    }
}
