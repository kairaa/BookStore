using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
      public CreateAuthorModel Model { get; set; }
      private readonly AuthorDBContext _dbContext;
      private readonly IMapper _mapper;

    public CreateAuthorCommand(AuthorDBContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public void Handle()
    {
      var author = _dbContext.Authors.SingleOrDefault(x => x.FirstName == Model.FirstName && x.LastName == Model.LastName);
      if(author is not null)
        throw new InvalidOperationException("Author has already exist");
      
      author = _mapper.Map<Author>(Model);

      _dbContext.Authors.Add(author);
      _dbContext.SaveChanges();
    }
  }

    public class CreateAuthorModel
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public DateTime Birthday { get; set; }
    }
}