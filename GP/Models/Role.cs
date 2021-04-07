using System;
using System.Collections.Generic;

#nullable disable

namespace GP.Models
{
    public partial class Role
    {
        public Role()
        {
            ClientRoles = new HashSet<ClientRole>();
            FreelancerRoles = new HashSet<FreelancerRole>();
        }

        public string RoleName { get; set; }
        public int RoleId { get; set; }

        public virtual ICollection<ClientRole> ClientRoles { get; set; }
        public virtual ICollection<FreelancerRole> FreelancerRoles { get; set; }
    }
}
