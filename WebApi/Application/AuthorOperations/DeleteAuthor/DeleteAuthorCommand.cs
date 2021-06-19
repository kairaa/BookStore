using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using System;

namespace WebApi.Application.AuthorOperations.DeleteAuthor
{
  public class DeleteAuthorCommand
  {
    public int AuthorId { get; set; }

    private readonly BookStoreDBContext _dbContext;

    public DeleteAuthorCommand(BookStoreDBContext dBContext)
    {
      _dbContext = dBContext;
    }
    public void Handle()
    {
      var author = _dbContext.Authors.Where(x => x.Id == AuthorId).SingleOrDefault();
      if (author is null)
        throw new InvalidOperationException("Book couldn't found");
      
      _dbContext.Authors.Remove(author);
      _dbContext.SaveChanges();
    }
  }
}