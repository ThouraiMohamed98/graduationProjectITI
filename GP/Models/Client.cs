using System;
using System.Collections.Generic;

#nullable disable

namespace GP.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientRoles = new HashSet<ClientRole>();
            FreelancerHires = new HashSet<FreelancerHire>();
        }

        public int Phone { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public virtual ICollection<ClientRole> ClientRoles { get; set; }
        public virtual ICollection<FreelancerHire> FreelancerHires { get; set; }
    }
}
