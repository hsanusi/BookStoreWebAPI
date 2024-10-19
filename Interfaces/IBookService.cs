using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Helpers;
using BookStore.API.Models;
using BookStore.API.Dtos.BookDtos;

namespace BookStore.API.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();

        Task<Book?> GetByIdAsync(int id);

        Task<Book> CreateAsync(Book bookModel);

        Task<Book?> UpdateAsync(int id, UpdateBookDto updateDto);

        Task<Book?> DeleteAsync(int id);

        Task<bool> BookExists(int id);
        
    }
}