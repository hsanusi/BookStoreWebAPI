using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Data;
using BookStore.API.Dtos.BookCategoryDtos;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly ApplicationDBContext _context;

        public BookCategoryService(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> BookCategoryExists(int id)
        {
            return _context.BookCategories.AnyAsync(s => s.Id == id);
        }

        public async Task<BookCategory> CreateAsync(BookCategory bookCategoryModel)
        {
            await _context.BookCategories.AddAsync(bookCategoryModel);
            await _context.SaveChangesAsync();
            return bookCategoryModel;   
        }

        public async Task<BookCategory?> DeleteAsync(int id)
        {
            var bookCategoryModel = await _context.BookCategories.FirstOrDefaultAsync(x => x.Id == id);

            if(bookCategoryModel == null)
            {
                return null;
            }

            _context.BookCategories.Remove(bookCategoryModel);
            await _context.SaveChangesAsync();
            return bookCategoryModel;
        }

        public async Task<List<BookCategory>> GetAllAsync()
        {
           return await _context.BookCategories.Include(b => b.Books).ToListAsync();
        }

        public async Task<BookCategory?> GetByIdAsync(int id)
        {
            return await _context.BookCategories.Include(b => b.Books).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BookCategory?> UpdateAsync(int id, UpdateBookCategoryDto updateDto)
        {
            var existingCategory = await _context.BookCategories.FirstOrDefaultAsync(x => x.Id == id);

            if(existingCategory == null)
            {
                return null;
            }

            existingCategory.CategoryName = updateDto.CategoryName;
            existingCategory.CategoryDescription = updateDto.CategoryDescription;
            await _context.SaveChangesAsync();
            return existingCategory;
        }
    }
}