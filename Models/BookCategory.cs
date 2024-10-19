using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Models
{
    public class BookCategory
    {
        public int Id { get; set; }
        
        public string? CategoryName { get; set; }

        public string? CategoryDescription { get; set; }

        public  List<Book> Books { get; } = new List<Book>();

       
    }
}