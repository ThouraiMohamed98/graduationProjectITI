using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.Models;

namespace GP.Repository
{
    
    public class ProfessionRepository
    {
        GPContext db;
        public ProfessionRepository(GPContext db)
        {
            this.db = db;
        }

        public List<Profession> getallprofession()
        {
            return db.Professions.ToList();
        }

        public Profession getbyprofessionid(int id)
        {
            return db.Professions.Find(id);
        }

        public Profession getbyprofessionname(string name)
        {
            return db.Professions.Find(name);
        }

        public void addprofession(Profession p)
        {
            db.Professions.Add(p);
            db.SaveChanges();
        }

        public void updateprofession(int id,Profession p)
        {
            Profession pr = db.Professions.Where(n => n.Id == id).FirstOrDefault();
            pr.Id = p.Id;
            pr.ProfName = p.ProfName;
            db.SaveChanges();
        }
        public void deleteprofession(int id)
        {
            Profession p = db.Professions.Where(n => n.Id == id).FirstOrDefault();
            db.Professions.Remove(p);
            db.SaveChanges();
        }
    }
}
