using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library_app.Models;
using Library_app.Models.ViewModels;

namespace Library_app.Controllers
{
    public class BookViewModelsController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: BookViewModels
        public ActionResult Index()
        {
            return View(db.BookViewModels.ToList());
        }

        // GET: BookViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookViewModel bookViewModel = db.BookViewModels.Find(id);
            if (bookViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bookViewModel);
        }

        // GET: BookViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,BookName,Writer,Publisher,IsbnNo")] BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                db.BookViewModels.Add(bookViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookViewModel);
        }

        // GET: BookViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookViewModel bookViewModel = db.BookViewModels.Find(id);
            if (bookViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bookViewModel);
        }

        // POST: BookViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,BookName,Writer,Publisher,IsbnNo")] BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookViewModel);
        }

        // GET: BookViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookViewModel bookViewModel = db.BookViewModels.Find(id);
            if (bookViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bookViewModel);
        }

        // POST: BookViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookViewModel bookViewModel = db.BookViewModels.Find(id);
            db.BookViewModels.Remove(bookViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
