using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string BookName { get; set; } = string.Empty;

        public string BookSsn { get; set; } = string.Empty;

        public string BookAuthor { get; set; } = "";

        public string CreatedBy {get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public bool IsBookOfTheMonth { get; set; }

        public string? PictureFileName {get; set; }

        public int? BookCategoryId { get; set; }

        public BookCategory? BookCategory { get; set; }

        public List<BookReview> BookReviews { get; } = new List<BookReview>();

        //public IFormFile? BookPicture { get; set; }

    }
}