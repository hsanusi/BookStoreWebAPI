using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Data;
using BookStore.API.Dtos.BookReview;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Services
{
    public class BookReviewService : IBookReviewService
    {
        private readonly ApplicationDBContext _context;

        public BookReviewService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<bool> BookReviewExists(int id)
        {
             return await _context.bookReviews.AnyAsync(s => s.Id == id);
        }

        public async Task<BookReview> CreateAsync(BookReview bookReviewModel)
        {
                await _context.bookReviews.AddAsync(bookReviewModel);
                await _context.SaveChangesAsync();
                return bookReviewModel;   
        }

    

        public async Task<BookReview?> DeleteAsync(int id)
        {
            var bookReviewModel = await _context.bookReviews.FirstOrDefaultAsync(x => x.Id == id);

            if(bookReviewModel == null)
            {
                return null;
            }

            _context.bookReviews.Remove(bookReviewModel);
            await _context.SaveChangesAsync();
            return bookReviewModel;
        }

        public async Task<List<BookReview>> GetAllAsync()
        {
            return await _context.bookReviews.ToListAsync();
        }

        public async Task<BookReview?> GetByIdAsync(int id)
        {
            return await _context.bookReviews.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BookReview?> UpdateAsync(int id, UpdateBookReviewDto updateDto)
        {
            var existingReview = await _context.bookReviews.FirstOrDefaultAsync(x => x.Id == id);

            if(existingReview == null) return null;
            
                existingReview.ReviewDate = DateTime.Now;
                existingReview.ReviewNotes = updateDto.ReviewNotes;
      
            await _context.SaveChangesAsync();

            return existingReview;
        }

        
    }
}