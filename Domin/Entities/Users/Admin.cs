using Domin.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities.Users
{
    [Auditable]

    public class Admin
    {
        public int Id { get; set; }    
        public int TotalSiteCommissionAmounts { get; set; }
    }
}
