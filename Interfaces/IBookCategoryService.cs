using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Dtos.BookCategoryDtos;
using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IBookCategoryService
    {
         Task<List<BookCategory>> GetAllAsync();

        Task<BookCategory?> GetByIdAsync(int id);

        Task<BookCategory> CreateAsync(BookCategory bookCategoryModel);

        Task<BookCategory?> UpdateAsync(int id, UpdateBookCategoryDto updateDto);

        Task<BookCategory?> DeleteAsync(int id);

        Task<bool> BookCategoryExists(int id);
    }
}