using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    public class Branch
    {
        public int BranchID { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }

        [Required(ErrorMessage = "This Field Is Required")]
        public string City { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }

    }
}