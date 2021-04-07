using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GP.Controllers.Repository;
using GP.Models;
using System.Net;

namespace GP.Controllers
{
    [Route ("api/[Controller]/[action]")]
    public class freelancerController : Controller
    {
        // GET: freelancerController
        FreelancerRep freelancer;
        public freelancerController(FreelancerRep freelancer)
        {
            this.freelancer = freelancer;
                
        }
       
        
        [HttpGet]//done
        public IActionResult GetFreelancers()
        {
            List<Freelancer> freelancers = freelancer.GetFreelancers();
            if (freelancers != null)
            {
                return Ok(freelancers);
            }
          return NotFound();

         }
        
        // GET: freelancerController/Details/5
        [HttpGet]//done
        public IActionResult GetFreelancer(int phone)
        {
           Freelancer f = freelancer.GetFreelancer(phone);
            if (f != null)
                return Ok(f);
            // else if phone == null
            else
                return NotFound();
        }
  
        // POST: freelancerController/Create
        [HttpPost]//done
        //[ValidateAntiForgeryToken]
        public IActionResult Post(Freelancer f)
        {
            if (f == null)
            {
                return BadRequest();
            }
            else if (freelancer.GetFreelancer(f.Phone) != null)
            {
                return BadRequest();

            }

            else
            {
                freelancer.addFreelancer(f);
                return Created("done", freelancer.GetFreelancers());

            }
        }

        
        // put: freelancerController/Edit/5
        [HttpPut]//done
      //  [ValidateAntiForgeryToken]
        public IActionResult Edit(int phone, Freelancer f)
        {
            if (freelancer.GetFreelancer(phone) != null)
            {
                if (phone!= f.Phone)
                {
                    return BadRequest();
                }
                freelancer.editFreelancer(phone, f);
                return Ok("done");
               // return StatusCode(HttpStatusCode.NoContent ,freelancer.GetFreelancers());
               
            }

            return NotFound();

        }


        // POST: freelancerController/Delete/5
        [HttpDelete] // done
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int phone)
        {
            Freelancer f = freelancer.GetFreelancer(phone);
            if (f != null)
            {
                freelancer.deleteFreelancer(phone);
                return Ok();
            }
            else 
                return NotFound();
                
        }


    }
}
