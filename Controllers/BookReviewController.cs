using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Data;
using BookStore.API.Dtos.BookReview;
using BookStore.API.Interfaces;
using BookStore.API.Mappers;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/book-reviews")]
    [ApiController]
    public class BookReviewController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBookReviewService _bookReviewService;

        private readonly UserManager<AppUser> _userManager;

        public BookReviewController(ApplicationDBContext context, IBookReviewService bookReviewService,UserManager<AppUser> userManager)
        {
            _context = context;
            _bookReviewService = bookReviewService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var bookReviews = await _bookReviewService.GetAllAsync();
            var bookReviewDto = bookReviews.Select(s=> s.ToBookReviewDto()).ToList();
            return Ok(bookReviewDto);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromForm] CreateBookReviewDto bookReviewDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            
            var bookReviewModel = bookReviewDto.ToBookReviewFromCreateDto();
            await _bookReviewService.CreateAsync(bookReviewModel);
            return CreatedAtAction(nameof(GetById),new { id = bookReviewModel.Id }, bookReviewModel.ToBookReviewDto());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {      
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var bookReview = await _bookReviewService.GetByIdAsync(id);
            if(bookReview == null)
            {
                return NotFound();
            }
            return Ok(bookReview.ToBookReviewDto());
        }

    }
}