using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Dtos.BookReview;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Mappers
{
    public static class BookReviewMappers
    {
        
        public static GetBookReviewDto ToBookReviewDto(this BookReview bookReviewModel)
        {
            return new GetBookReviewDto
            {
                ReviewNotes = bookReviewModel.ReviewNotes,
                ReviewDate = bookReviewModel.ReviewDate,
                ReviewerId = bookReviewModel.ReviewerId
              
            };
        }

        // public static  BookReview ToBookReviewFromCreateDto(this CreateBookReviewDto bookDto)
        // {
    
        //     return new BookReview
        //     {
        //         ReviewNotes = bookDto.ReviewNotes,
        //         ReviewDate = DateTime.Now,
        //         ReviewerId = User.Fin
        //     };
        // }
    }
}