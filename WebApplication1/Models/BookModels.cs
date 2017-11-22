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
        public double price { get; set; }
        [Required(ErrorMessage = "Fill it.")]
        [Display(Name = "Author")]
        [MinLength(5)]
        [MaxLength(255)]
        public string author { get; set; }

        public BookModels build()
        {
            Random rand = new Random();
            BookModels bookModel = new BookModels()
            {
                id = rand.Next(0, 10000),
                bookName = "book_" + rand.Next(0, 10000).ToString(),
                price = (rand.Next(1, 10000) * 0.21),
                author = "Author"
            };
            return bookModel;
        }
    }
}