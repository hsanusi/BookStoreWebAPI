using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Models;

namespace BookStore.API.Dtos.BookReview
{
    public class CreateBookReviewDto
    {

        public string? ReviewNotes { get; set; }

        public int BookId { get; set; }

    }
}