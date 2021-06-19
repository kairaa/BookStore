using System;
using System.Collections.Generic;
using AutoMapper;
using WebApi.DBOperations;
using System.Linq;

namespace WebApi.Application.AuthorOperations.GetAuthors
{
    public class GetAuthorsQuery
    {
      private readonly AuthorDBContext _dbContext;
      private readonly IMapper _mapper;

    public GetAuthorsQuery(AuthorDBContext context, IMapper mapper)
    {
      _dbContext = context;
      _mapper = mapper;
    }

    public List<AuthorsViewModel>Handle()
    {
      var authorList = _dbContext.Authors.OrderBy(x => x.Id);
      List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(authorList);
      return vm;
    }
  }
  public class AuthorsViewModel
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
  }
}