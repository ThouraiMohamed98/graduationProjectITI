using System;
using System.Collections.Generic;

#nullable disable

namespace GP.Models
{
    public partial class Profession
    {
        public Profession()
        {
            Freelancers = new HashSet<Freelancer>();
        }

        public int Id { get; set; }
        public string ProfName { get; set; }

        public virtual ICollection<Freelancer> Freelancers { get; set; }
    }
}
