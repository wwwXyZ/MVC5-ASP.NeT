using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataAccess;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        private List<Models.BookModels> bookList = BookContext.getInstance();

        public ActionResult BookList()
        {
            return View(bookList);
        }

        [HttpGet]
        public ActionResult EditBook(int? bookId)
        {
            Models.BookModels bookModel = bookList.FirstOrDefault(book => book.id == bookId);
            return View("EditBook", bookModel);
        }

        [HttpPost]
        public ActionResult EditBook(Models.BookModels model)
        {
            foreach(Models.BookModels bookModel in bookList)
            {
                if(model.id == bookModel.id)
                {
                    bookModel.author = model.author;
                    bookModel.bookName = model.bookName;
                    bookModel.price = convertToFloat(model.price).ToString();
                    return RedirectToAction("BookList");
                }
            }
            return View(bookList);
        }

        private float convertToFloat(string str)
        {
            float tmp = 0;
            float.TryParse(str.Replace('.', ','), out tmp);
            return tmp;
        }

        [HttpGet]
        public ActionResult DeleteBook(int? bookId)
        {
            bookList.Remove(bookList.FirstOrDefault(x => x.id == bookId));
            return RedirectToAction("BookList");
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Models.BookModels Book)
        {
            bookList.Add(Book);
            return RedirectToAction("BookList");
        }

        [HttpPost]
        public ActionResult SearchBook(String bookName)
        {
            return Json(bookList.Where(x => x.bookName.Contains(bookName)));
        }

    }
}