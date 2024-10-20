using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Data;
using BookStore.API.Dtos.BookCategoryDtos;
using BookStore.API.Interfaces;
using BookStore.API.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/bookCategory")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IBookCategoryService _categoryService;

        public BookCategoryController(ApplicationDBContext context, IBookCategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var bookCategories = await _categoryService.GetAllAsync();
            var bookCategoryDto = bookCategories.Select(s => s.ToBookCategoryDto()).ToList();
            return Ok(bookCategoryDto);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromForm] CreateBookCategoryDto bookCategoryDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
        
            var bookCategoryModel = bookCategoryDto.ToBookCategoryFromCreateDto();
            await _categoryService.CreateAsync(bookCategoryModel);
            return CreatedAtAction(nameof(GetById),new { id = bookCategoryModel.Id }, bookCategoryModel.ToBookCategoryDto());
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {      
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var bookCategory = await _categoryService.GetByIdAsync(id);
            if(bookCategory == null)
            {
                return NotFound();
            }
            return Ok(bookCategory.ToBookCategoryDto());
        }

        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateBookCategoryDto updateDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
           var bookCategoryModel = await _categoryService.UpdateAsync(id,updateDto);
           if(bookCategoryModel == null)
           {
            return NotFound();
           }
            return Ok(bookCategoryModel.ToBookCategoryDto());
        }

        [HttpDelete]
        [Route("delete/{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
             var bookCategoryModel = await _categoryService.DeleteAsync(id);
             if(bookCategoryModel ==null)
             {
                return NotFound();
             }
             _context.BookCategories.Remove(bookCategoryModel);
             await _context.SaveChangesAsync();
             return NoContent();
        }
    }
}