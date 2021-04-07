using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.Models;

namespace GP.Models.Repository
{
    public class ClientRepository
    {
        GPContext db;
        public ClientRepository(GPContext db)
        {
            this.db = db;
        }

        public List<Client> getall()
        {
            return db.Clients.ToList();
        }
        public Client getByid(int id)
        {
            return db.Clients.Find(id);
        }

        public void add(Client c)
        {
            db.Clients.Add(c);
            db.SaveChanges();
        }

       

        public void update(Client c)
        {
            //Client inClient = db.Clients.Where(n => n.Phone == c.Phone).FirstOrDefault();
            //inClient.Name = c.Name;
            //inClient.Email = c.Email;
            //inClient.Password = c.Password;
            //db.SaveChanges();

            db.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void delete(int phone)
        {
            Client c = db.Clients.Where(n => n.Phone == phone).FirstOrDefault();
            db.Clients.Remove(c);
            db.SaveChanges();
        }

    }
}
