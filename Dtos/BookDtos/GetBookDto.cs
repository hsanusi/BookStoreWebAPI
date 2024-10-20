using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Dtos.BookReview;

namespace BookStore.API.Dtos.BookDtos
{
    public class GetBookDto
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

        public  List<GetBookReviewDto>? BookReviews { get; set; }
    }
}