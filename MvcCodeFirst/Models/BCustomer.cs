using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    public class BCustomer
    {
        public Guid BCustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime OpeningDate { get; set; }

        public virtual ICollection<FDR> FDRs { get; set; }
             
    }
}