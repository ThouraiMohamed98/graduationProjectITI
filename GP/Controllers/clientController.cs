using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.Models;
using GP.Models.Repository;

namespace GP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientController : ControllerBase
    {
        ClientRepository db;
        public clientController(ClientRepository db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<List<Client>> get()
        {
            List<Client> cl = db.getall();
            if (cl.Count == 0)
            {
                return NotFound();

            }
            else
            {
                return cl;
            }
        }  

        [HttpGet("{id}")]
        public ActionResult getbyid(int id)
        {
            Client c = db.getByid(id);
            if (c == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(c);
            }
        }

        [HttpPost]
        public ActionResult post (Client c)
        {
            db.add(c);
            return Created("done", c);
        }

        [HttpPut("{id}")]
        public ActionResult put (int id , Client c)
        {
            db.update(c);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            db.delete(id);
            return NoContent();
        }



    }
}
