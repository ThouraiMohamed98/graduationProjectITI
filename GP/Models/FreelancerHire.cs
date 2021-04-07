using System;
using System.Collections.Generic;

#nullable disable

namespace GP.Models
{
    public partial class FreelancerHire
    {
        public int ClientPho { get; set; }
        public int FreelancerPho { get; set; }
        public DateTime HireDate { get; set; }

        public virtual Client ClientPhoNavigation { get; set; }
        public virtual Freelancer FreelancerPhoNavigation { get; set; }
    }
}
