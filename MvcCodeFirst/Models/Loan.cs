using MvcCodeFirst.CustomValidation;
using MVCProject_Arif.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    public class Loan
    {
        public int LoanId { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [Display(Name = "Customer Name")]
        [MyAttribute]
        public string CustomerName { get; set; }
        
        [DataType(DataType.Date)]
        
        [CustomHireDate(ErrorMessage = "Hire Date must be less than or equal to Today's Date")]
        [Display(Name = "Issue Date")]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [Display(Name = "Principle Amount")]
        public int PrincipleAmount { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public int Interest { get; set; }

        [NotMapped]
        public int Total { get { return (PrincipleAmount + Interest); } }

        public int BranchID { get; set; }
        public virtual Branch Branch { get; set; }
    }
}