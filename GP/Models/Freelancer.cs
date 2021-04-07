using System;
using System.Collections.Generic;

#nullable disable

namespace GP.Models
{
    public partial class Freelancer
    {
        public Freelancer()
        {
            FreelancerHires = new HashSet<FreelancerHire>();
            FreelancerRoles = new HashSet<FreelancerRole>();
            Gigs = new HashSet<Gig>();
        }

        public int Phone { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string WorkCountry { get; set; }
        public string WorkCity { get; set; }
        public string WorkDistrict { get; set; }
        public int? Rate { get; set; }
        public int ProfId { get; set; }

        public virtual Profession Prof { get; set; }
        public virtual ICollection<FreelancerHire> FreelancerHires { get; set; }
        public virtual ICollection<FreelancerRole> FreelancerRoles { get; set; }
        public virtual ICollection<Gig> Gigs { get; set; }
    }
}
