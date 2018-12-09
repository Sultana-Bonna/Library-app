using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_app.Models.ViewModels
{
    public class BookViewModel
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [Display(Name = "Book Name")]
        [StringLength(500)]
        public string BookName { get; set; }

        [Required]
        [Display(Name = "Writer Name")]
        [StringLength(50)]
        public string Writer { get; set; }

        [Required]
        [Display(Name = "Publisher Name")]
        public string Publisher { get; set; }
        [Required]
        [Display(Name = "ISBN Number")]
        public int IsbnNo { get; set; }
    }
}