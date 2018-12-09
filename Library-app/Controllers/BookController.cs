using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library_app.Models;
using Library_app.Models.ViewModels;

namespace Library_app.Controllers
{
    public class BookController : Controller
    {
        private LibraryContext _context = new LibraryContext();
        // GET: Book
        public ActionResult Index()
        {
            var library = _context.Books.ToList();
            List<BookViewModel> viewModel = new List<BookViewModel>();

            foreach (var book in library)
            {
                BookViewModel bookViewModel = new BookViewModel();
                bookViewModel.BookId = book.BookId;
                bookViewModel.BookName = book.BookName;
                bookViewModel.Writer = book.Writer;
                bookViewModel.Publisher = book.Publisher;
                bookViewModel.IsbnNo = book.IsbnNo;
                viewModel.Add(bookViewModel);
            }

            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookViewModel bookViewModel)
        {
            Library book = new Library();

            book.BookName = bookViewModel.BookName;
            book.Writer = bookViewModel.Writer;
            book.Publisher = bookViewModel.Writer;
            book.IsbnNo = bookViewModel.IsbnNo;

            _context.Books.Add(book);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return RedirectToAction("Edit", new { @id = book.BookId });
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Library book = _context.Books.FirstOrDefault(x => x.BookId == id);
            BookViewModel bookViewModel = new BookViewModel();

            bookViewModel.BookId = book.BookId;
            bookViewModel.BookName = book.BookName;
            bookViewModel. Writer = book.Writer;
            bookViewModel.Publisher = book.Publisher;
            bookViewModel.IsbnNo = book.IsbnNo;

            return View(bookViewModel);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel bookViewModel)
        {
            Library book = _context.Books.FirstOrDefault(x => x.BookId == bookViewModel.BookId);
            book.BookId = bookViewModel.BookId;
            book.BookName = bookViewModel.BookName;
            book.Writer = bookViewModel.Writer;
            book.Publisher = bookViewModel.Publisher;

            _context.Entry(book).State = EntityState.Modified;
            var result = _context.SaveChanges();

            if (result > 0)
            {
                return RedirectToAction("Edit", new { @id = bookViewModel.BookId });
            }
            return View();
        }

    }
}