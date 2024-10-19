using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Dtos.BookCategoryDtos;
using BookStore.API.Models;

namespace BookStore.API.Mappers
{
    public static class BookCategoryMappers
    {
        public static GetBookCategoryDto ToBookCategoryDto(this BookCategory bookCategoryModel)
        {
            return new GetBookCategoryDto
            {
                Id = bookCategoryModel.Id,
                CategoryName = bookCategoryModel.CategoryName,
                CategoryDescription = bookCategoryModel.CategoryDescription,
                Books = bookCategoryModel.Books.Select(b => b.ToBookDto()).ToList()
            };
        }

         public static  BookCategory ToBookCategoryFromCreateDto(this CreateBookCategoryDto bookDto)
        {
    
            return new BookCategory
            {
                CategoryName = bookDto.CategoryName,
                CategoryDescription = bookDto.CategoryDescription
                
            };
        }
    }
}