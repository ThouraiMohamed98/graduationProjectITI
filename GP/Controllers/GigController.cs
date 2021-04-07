using GP.Models;
using GP.Reprository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GigController : Controller
    {
        GigReprository db;
        public GigController(GigReprository db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<List<Gig>> get()
        {
            List<Gig> gl = db.getall();
            if (gl.Count == 0)
            {
                return NotFound();

            }
            else
            {
                return gl;
            }
        }

        [HttpGet("{id}")]
        public ActionResult getbyid(int id)
        {
            Gig g = db.getByid(id);
            if (g == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(g);
            }
        }

        [HttpPost]
        public ActionResult post(Gig g)
        {
            db.add(g);
            return Created("done", g);
        }

        [HttpPut("{id}")]
        public ActionResult put(int id, Gig g)
        {
            db.update(g);
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
