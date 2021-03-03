using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    [Table("Client")]
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required, Display(Name = "Client Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        [Required,  DataType(DataType.Date), Column(TypeName = "date"), Display(Name = "Issue Date")]
        public DateTime IssueDate { get; set; }

        [Required]
        public long Amount { get; set; }

        [ForeignKey("AccountType")]
        public long AccountTypeID { get; set; }

        //[ForeignKey("CategoryID")] -- You can reference foreign key here
        public virtual AccountType AccountType { get; set; }
    }
}