using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Models;

namespace BookStore.API.Dtos.BookReview
{
    public class GetBookReviewDto
    {
        public int Id { get; set; }    

        public string? ReviewerId { get; set; }

        public string? ReviewNotes { get; set; }

        public DateTime ReviewDate { get; set; }

        public int BookId { get; set; }

    }
}