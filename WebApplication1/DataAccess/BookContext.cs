using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DataAccess
{
    public class BookContext
    {
        private static List<Models.BookModels> books;

        public static List<Models.BookModels> getInstance()
        {
            if(books == null)
            {
                books = initAllBooks();
            }
            return books;
        }
        private static List<Models.BookModels> initAllBooks()
        {
            List<Models.BookModels> bookList = new List<Models.BookModels>();
            for(int i = 0; i < 10; i++)
            {
                bookList.Add(new Models.BookModels().build());
            }
            return bookList;
        }
    }
}