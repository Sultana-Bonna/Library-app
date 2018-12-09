using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_app.Models
{
    public partial class Library
    {
        [StringLength(500) ]
        public string BookName { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public int IsbnNo { get; set; }
        [Key]
        public int BookId { get; set; }

    }
}