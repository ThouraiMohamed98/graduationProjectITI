using System;
using System.Collections.Generic;

#nullable disable

namespace GP.Models
{
    public partial class ClientRole
    {
        public int RoleId { get; set; }
        public int ClientPho { get; set; }

        public virtual Client ClientPhoNavigation { get; set; }
        public virtual Role Role { get; set; }
    }
}
