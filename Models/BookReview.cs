using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Models
{
    public class BookReview
    {
        public int Id { get; set; }    

        public string? ReviewerId { get; set; }

        public string? ReviewNotes { get; set; }

        public DateTime ReviewDate { get; set; }

        public int BookId { get; set; }

        public Book? Book { get; set;}
    }
}