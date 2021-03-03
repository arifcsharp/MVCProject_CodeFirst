using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    [Table("AccountType")]
    public class AccountType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required, Display(Name = "Account Type")]
        public string Name { get; set; }

        //[ForeignKey("AccountID")] -- You can reference foreign key here
        public virtual IList<Client> Clients { get; set; }
    }
}