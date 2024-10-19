using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Dtos.BookDtos;
using BookStore.API.Models;


namespace BookStore.API.Mappers
{
    public static class BookMappers
    {
        public static GetBookDto ToBookDto(this Book bookModel)
        {
            return new GetBookDto
            {
                Id = bookModel.Id,
                BookName = bookModel.BookName,
                BookSsn = bookModel.BookSsn,
                BookAuthor = bookModel.BookAuthor,
                CreatedBy = bookModel.CreatedBy,
                CreatedOn = bookModel.CreatedOn,
                IsBookOfTheMonth = bookModel.IsBookOfTheMonth,
                BookCategoryId = bookModel.BookCategoryId,
                PictureFileName = bookModel.PictureFileName
            };
        }

        public static  Book ToBookFromCreateDto(this CreateBookDto bookDto)
        {
            string picturefile = "";
            if(bookDto.BookPicture != null)
            {
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(),"uploads");
                if(!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }
               
                picturefile = bookDto.BookPicture.FileName;
                var filepath = Path.Combine(uploadsFolderPath,picturefile);
                using (var stream = new FileStream(filepath,FileMode.Create))
                {
                     bookDto.BookPicture.CopyToAsync(stream);
                }
            }
            return new Book
            {
                BookName = bookDto.BookName,
                BookSsn = bookDto.BookSsn,
                BookAuthor = bookDto.BookAuthor,
                CreatedBy = "Hammed",
                CreatedOn = DateTime.Now,
                IsBookOfTheMonth = bookDto.IsBookOfTheMonth,
                BookCategoryId = bookDto.BookCategoryId,
                PictureFileName = picturefile
            };
        }

    }
}