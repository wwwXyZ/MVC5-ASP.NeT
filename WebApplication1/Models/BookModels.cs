using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BookModels
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Fill it.")]
        [Display(Name = "Name")]
        [MinLength(5)]
        [MaxLength(255)]
        public string bookName { get; set; }
        [Required(ErrorMessage = "Fill it.")]
        [Display(Name = "price")]
//        [MinLength(5)]
//        [MaxLength(255)]
//        [Range(0.0, Double.MaxValue)]
        public string price { get; set; }
        [Required(ErrorMessage = "Fill it.")]
        [Display(Name = "Author")]
        [MinLength(5)]
        [MaxLength(255)]
        public string author { get; set; }

        public BookModels build()
        {
            BookModels bookModel = new BookModels()
            {
                id = BookModels.RandomNumber(0, 10000),
                bookName = "book_" + BookModels.RandomNumber(0, 10000).ToString(),
                price = (BookModels.RandomNumber(1, 10000) * 0.21).ToString(),
                author = "Author"
            };
            return bookModel;
        }




        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }
}