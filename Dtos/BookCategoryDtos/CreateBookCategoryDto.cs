using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Dtos.BookCategoryDtos
{
    public class CreateBookCategoryDto
    {
        [Required]
        [MinLength(12,ErrorMessage="Category cannot be less than 12 characters")]
        [MaxLength(70,ErrorMessage ="Category cannot be more than 70 characters")]
        public string? CategoryName { get; set; }

        [Required]
        [MinLength(10,ErrorMessage="Description cannot be less than 10 characters")]
        [MaxLength(70,ErrorMessage ="Description cannot be more than 70 characters")]
        public string? CategoryDescription { get; set; }
    }
}