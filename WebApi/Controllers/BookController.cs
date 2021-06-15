using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.DeleteBook;

namespace WebApi.AddControllers{

  [ApiController]
  [Route("[controller]s")]
  public class BookController : ControllerBase
  {

    private readonly BookStoreDBContext _context;

    public BookController(BookStoreDBContext context)
    {
      _context = context;
    }
    // private static List<Book> BookList = new List<Book>()
    // {
    //   new Book{
    //     Id = 1,
    //     Title = "Lean Startup",
    //     GenreId = 1,   // Personal Growth
    //     PageCount = 200,
    //     PublishDate = new DateTime(2001, 09, 12)
    //   },
    //   new Book{
    //     Id = 2,
    //     Title = "Herland",
    //     GenreId = 2,   // Science Fiction
    //     PageCount = 240,
    //     PublishDate = new DateTime(2010, 12, 25)
    //   },
    //   new Book{
    //     Id = 3,
    //     Title = "Dune",
    //     GenreId = 2,   // Science Fiction
    //     PageCount = 500,
    //     PublishDate = new DateTime(2001, 09, 12)
    //   }
    // };

    [HttpGet]
    public IActionResult GetBooks()
    {
      //var bookList = BookList.OrderBy(x => x.Id).ToList();
      GetBooksQuery query = new GetBooksQuery(_context);
      var result = query.Handle();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) //from root
    {
      BookDetailViewModel result;
      try
      {
        GetBookDetailQuery query = new GetBookDetailQuery(_context);
        query.BookId = id;
        result = query.Handle();
      }
      catch(Exception ex)
      {
        return BadRequest(ex.Message);
      }
      return Ok(result); 
    }

    // [HttpGet]
    // public Book Get([FromQuery] string id)   //from query
    // {
    //   var book = BookList.Where(x => x.Id == Convert.ToInt32(id)).SingleOrDefault();
    //   return book; 
    // }

    //Post
    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel newBook)
    {
      CreateBookCommand command = new CreateBookCommand(_context);
      try
      {
        command.Model = newBook;
        command.Handle();
      }
      catch(Exception ex){
        return BadRequest(ex.Message);
      }

      return Ok();
    }

    //Put
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
    {
      UpdateBookCommand command = new UpdateBookCommand(_context);
      try
      {
        command.Model = updatedBook;
        command.BookId = id;
        command.Handle();
      }
      catch(Exception ex){
        return BadRequest(ex.Message);
      }
      return Ok();
    }

    //Delete
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
      try
      {
        DeleteBookCommand command = new DeleteBookCommand(_context);
        command.BookId = id;
        command.Handle();
      }
      catch(Exception ex)
      {
        return BadRequest(ex.Message);
      }
      return Ok();
    }
  }
}