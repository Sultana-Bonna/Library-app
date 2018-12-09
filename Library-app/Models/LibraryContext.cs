using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library_app.Models
{
    public class LibraryContext:DbContext
    {
        public LibraryContext()
            : base("name=LibraryContext")
        {

        }

        public virtual DbSet<Library> Books { get; set; }

        public System.Data.Entity.DbSet<Library_app.Models.ViewModels.BookViewModel> BookViewModels { get; set; }
    }
}