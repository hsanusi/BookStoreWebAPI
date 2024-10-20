using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Data;
using BookStore.API.Helpers;
using BookStore.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BookStore.API.Dtos.BookDtos;
using BookStore.API.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.API.Controller
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBookService _bookService;

        public BookController(ApplicationDBContext context, IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var books = await _bookService.GetAllAsync();
            var bookDto = books.Select(s=> s.ToBookDto()).ToList();
            return Ok(bookDto);
        }

        
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromForm] CreateBookDto bookDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
        
            var bookModel = bookDto.ToBookFromCreateDto();
            await _bookService.CreateAsync(bookModel);
            return CreatedAtAction(nameof(GetById),new { id = bookModel.Id }, bookModel.ToBookDto());
        } 

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {      
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var book = await _bookService.GetByIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book.ToBookDto());
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateBookDto updateDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
           var bookModel = await _bookService.UpdateAsync(id,updateDto);
           if(bookModel == null)
           {
            return NotFound();
           }
            return Ok(bookModel.ToBookDto());
        }

        [HttpDelete]
        [Route("delete/{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
             var bookModel = await _bookService.DeleteAsync(id);
             if(bookModel ==null)
             {
                return NotFound();
             }
             _context.Books.Remove(bookModel);
             await _context.SaveChangesAsync();
             return NoContent();
        }
        
    }
}