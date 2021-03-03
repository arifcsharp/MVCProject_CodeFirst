﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime OpeningDate { get; set; }
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        //[NotMapped]
        //public HttpPostedFileBase ImageFile { get; set; }

    }
}