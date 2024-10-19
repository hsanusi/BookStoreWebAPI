using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Dtos.BookReview;
using BookStore.API.Models;

namespace BookStore.API.Interfaces
{
    public interface IBookReviewService
    {
        Task<List<BookReview>> GetAllAsync();

        Task<BookReview?> GetByIdAsync(int id);

        Task<BookReview> CreateAsync(BookReview bookReviewModel);

        Task<BookReview?> UpdateAsync(int id, UpdateBookReviewDto updateDto);

        Task<BookReview?> DeleteAsync(int id);

        Task<bool> BookReviewExists(int id);
    }
}