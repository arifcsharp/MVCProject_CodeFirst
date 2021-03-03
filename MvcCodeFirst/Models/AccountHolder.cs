using MvcCodeFirst.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    public class AccountHolder
    {
        public int AccountHolderID { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Enter minimum 2 or maximum 30 character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        
        
        public string ContactNo { get; set; }

        //[Required(ErrorMessage = "This Field is required")]
        //[DataType(DataType.Date)]
        //public DateTime DOB { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [Display(Name = "Upload Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public AccountHolder()
        {
            ImagePath = "~/AppFiles/Images/default.png";
        }
    }
}
