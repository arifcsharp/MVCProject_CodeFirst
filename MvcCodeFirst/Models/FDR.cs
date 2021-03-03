using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    public class FDR
    {
        public Guid FDRID { get; set; }
        public string AccountName { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid BCustomerID { get; set; }

        public virtual BCustomer BCustomer { get; set; }
    }
}