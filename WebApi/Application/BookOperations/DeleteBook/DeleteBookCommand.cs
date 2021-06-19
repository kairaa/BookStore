using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using System;

namespace WebApi.Application.BookOperations.DeleteBook
{
  public class DeleteBookCommand
  {
    public int BookId { get; set; }

    private readonly BookStoreDBContext _dbContext;

    public DeleteBookCommand(BookStoreDBContext dBContext)
    {
      _dbContext = dBContext;
    }
    public void Handle()
    {
      var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
      if (book is null)
        throw new InvalidOperationException("Book couldn't found");
      
      _dbContext.Books.Remove(book);
      _dbContext.SaveChanges();
    }
  }
}