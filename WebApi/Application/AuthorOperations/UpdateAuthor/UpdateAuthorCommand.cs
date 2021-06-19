using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using System;

namespace WebApi.Application.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
      public UpdateAuthorModel Model { get; set; }
      public int AuthorId { get; set; }
      private readonly AuthorDBContext _dbContext;

    public UpdateAuthorCommand(AuthorDBContext dbContext)
    {
      _dbContext = dbContext;
    }

    public void Handle()
    {
      var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);
      if(author is null)
        throw new InvalidOperationException("Author couldn't found");
      
      author.FirstName = Model.FirstName != default ? Model.FirstName : author.FirstName;
      author.LastName = Model.LastName != default ? Model.LastName : author.LastName;
      author.Birthday = Model.Birthday != default ? Model.Birthday : author.Birthday;

      _dbContext.SaveChanges();
    }
  }

  public class UpdateAuthorModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
  }
}