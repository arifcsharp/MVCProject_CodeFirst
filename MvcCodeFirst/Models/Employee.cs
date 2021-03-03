using MvcCodeFirst.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "This Field is required")]
      
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [Display(Name = "Cell Phone")]
        
        public string CellPhone { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public string Address { get; set; }

    }
}