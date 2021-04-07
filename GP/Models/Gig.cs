using System;
using System.Collections.Generic;

#nullable disable

namespace GP.Models
{
    public partial class Gig
    {
        public int GigId { get; set; }
        public string GigName { get; set; }
        public string Description { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? FreelancerPho { get; set; }

        public virtual Freelancer FreelancerPhoNavigation { get; set; }
    }
}
