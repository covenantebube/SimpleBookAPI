using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleBookAPI.Model;
using System;
using System. Collections.Generic;
using System.Data;
using System.Linq;

namespace SimpleBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public BooksController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Books
        [HttpGet("all")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GetBooks()
        {
            List<Book> books = _dbContext.Books.ToList();
            return Ok(books);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GetBook(int id)
        {
            Book book = _dbContext.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            Book book = _dbContext.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.PublicationDate = updatedBook.PublicationDate;
            book.Isbn = updatedBook.Isbn;
            book.Genre = updatedBook.Genre;

            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            Book book = _dbContext.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
