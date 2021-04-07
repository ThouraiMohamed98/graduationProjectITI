using System;
using System.Collections.Generic;

#nullable disable

namespace GP.Models
{
    public partial class FreelancerRole
    {
        public int RoleId { get; set; }
        public int FreelancerPho { get; set; }

        public virtual Freelancer FreelancerPhoNavigation { get; set; }
        public virtual Role Role { get; set; }
    }
}
