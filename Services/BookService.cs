using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Data;
using BookStore.API.Dtos.BookDtos;
using BookStore.API.Helpers;
using BookStore.API.Interfaces;
using BookStore.API.Models;
using BookStore.API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDBContext _context;

        public BookService(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> BookExists(int id)
        {
            return _context.Books.AnyAsync(s => s.Id == id);
        }

        public async Task<Book> CreateAsync(Book bookModel)
        {
             await _context.Books.AddAsync(bookModel);
              await _context.SaveChangesAsync();
              return bookModel;   
        }

        
        public async Task<Book?> DeleteAsync(int id)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if(bookModel == null)
            {
                return null;
            }

            _context.Books.Remove(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<List<Book>> GetAllAsync()
        {
           return await _context.Books.Include(r => r.BookReviews).ToListAsync();
            
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.Include(r => r.BookReviews).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Book?> UpdateAsync(int id, UpdateBookDto updateDto)
        {
           var existingBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if(existingBook == null) return null;

            string picturefile = "";
            if(updateDto.BookPicture != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(),"uploads");
                if(!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }
                picturefile = updateDto.BookPicture.FileName;
                var filepath = Path.Combine(uploadsFolderPath,picturefile);
                using (var stream = new FileStream(filepath,FileMode.Create))
                {
                     updateDto.BookPicture.CopyTo(stream);
                }
            }
            
                existingBook.BookName = updateDto.BookName;
                existingBook.BookSsn = updateDto.BookSsn;
                existingBook.BookAuthor = updateDto.BookAuthor;
                existingBook.CreatedBy = "Hammed";
                existingBook.CreatedOn = DateTime.Now;
                existingBook.IsBookOfTheMonth = updateDto.IsBookOfTheMonth;
                existingBook.BookCategoryId = updateDto.CategoryId;
                if(picturefile != null) existingBook.PictureFileName = picturefile;

            await _context.SaveChangesAsync();

            return existingBook;
        }

        
    }
}