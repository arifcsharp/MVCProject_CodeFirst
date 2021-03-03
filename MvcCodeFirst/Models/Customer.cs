using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [DataType(DataType.Date)]
        public int DOB { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        public string District { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        public string Country { get; set; }
    }



}
