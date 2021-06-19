using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using System;
using AutoMapper;

namespace WebApi.Application.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
      public int AuthorId { get; set; }
      private readonly AuthorDBContext _dbContext;
      private readonly IMapper _mapper;

      public GetAuthorDetailQuery(AuthorDBContext dbContext, IMapper mapper)
      {
        _dbContext = dbContext;
        _mapper = mapper;
      }

      public AuthorDetailViewModel Handle()
      {
        var author = _dbContext.Authors.Where(x => x.Id == AuthorId).SingleOrDefault();
        if (author is null)
          throw new InvalidOperationException("Author couldn't found");
        
        AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(author);
        return vm;
      }
    }

    public class AuthorDetailViewModel
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public DateTime Birthday { get; set; }
    }
}