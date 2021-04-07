using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.Models;
using GP.Repository;

namespace GP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfessionController : ControllerBase
    {
        ProfessionRepository profession;
        public ProfessionController(ProfessionRepository profession)
        {
            this.profession = profession;
        }
        [HttpGet]
        public IActionResult getall()
        {
            if(profession.getallprofession()!=null)
            {
                return Ok(profession.getallprofession());
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult getbyid(int id)
        {
            Profession p = profession.getbyprofessionid(id);
            if ( p != null)
            {
                return Ok(p);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("api/pr/{name}")]
        public IActionResult getbyname(string name)
        {
            Profession p = profession.getbyprofessionname(name);
            if (p != null)
            {
                return Ok(p);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Add(Profession p)
        {
            
            if (p != null)
            {
                if(profession.getbyprofessionid(p.Id)==null && profession.getbyprofessionname(p.ProfName) == null)
                {
                    profession.addprofession(p);
                    return Created("added", profession.getallprofession());
                }
                else
                {
                    return BadRequest();
                }
                
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult update( int id,Profession p)
        {
           
            if (p != null && id==p.Id )
            {
                if (profession.getbyprofessionid(id) != null)
                {
                    profession.updateprofession(id,p);
                    return Ok(profession.getallprofession());
                }
                else
                {
                    return NotFound();
                }

            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult delete(int id)
        {

            if (profession.getbyprofessionid(id) != null)
            {
                profession.deleteprofession(id);
                return Ok(profession.getallprofession());
            }
            else
            {
                return NotFound();
            }
           
        }


    }
}
