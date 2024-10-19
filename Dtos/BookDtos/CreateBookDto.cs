using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Dtos.BookDtos
{
    public class CreateBookDto
    {
        [Required]
        [MinLength(10,ErrorMessage="Book Name cannot be less than 10 characters")]
        [MaxLength(70,ErrorMessage ="Book Name cannot be more than 70 characters")]
        public string BookName { get; set; } = string.Empty;

        [Required]
        [MinLength(5,ErrorMessage="Book SSN cannot be less than 5 characters")]
        [MaxLength(15,ErrorMessage ="Book SSN cannot be more than 15 characters")]
        public string BookSsn { get; set; } = string.Empty;

        [Required]
        [MinLength(3,ErrorMessage="Author cannot be less than 3 characters")]
        [MaxLength(70,ErrorMessage ="Author cannot be more than 70 characters")]
        public string BookAuthor { get; set; } = "";

        // public string CreatedBy {get; set; } = string.Empty;

        // public DateTime CreatedOn { get; set; }

        public bool IsBookOfTheMonth { get; set; }

        public int? BookCategoryId { get; set; }

        // public string? PictureFileName {get; set; }

        public IFormFile? BookPicture { get; set; }
    }
}