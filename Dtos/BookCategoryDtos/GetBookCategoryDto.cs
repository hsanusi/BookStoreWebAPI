using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Dtos.BookDtos;

namespace BookStore.API.Dtos.BookCategoryDtos
{
    public class GetBookCategoryDto
    {
        public int Id { get; set; }

        public string? CategoryName { get; set; } 

        public string? CategoryDescription { get; set; } 

        public  List<GetBookDto>? Books { get; set; }
    }
}