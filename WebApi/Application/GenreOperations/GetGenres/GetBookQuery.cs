using System;
using System.Collections.Generic;
using AutoMapper;
using WebApi.DBOperations;
using System.Linq;

namespace WebApi.Application.GenreOperations.GetGenres
{
    public class GetGenresQuery
    {
      private readonly BookStoreDBContext _dbContext;
      private readonly IMapper _mapper;

    public GetGenresQuery(BookStoreDBContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public List<GenresViewModel> Handle()
    {
      var genresList = _dbContext.Genres.OrderBy(x => x.Id);
      List<GenresViewModel> vm = _mapper.Map<List<GenresViewModel>>(genresList);
      return vm;
    }
  }

    public class GenresViewModel
    {
      public string Name { get; set; }
      public bool isActive { get; set; }
    }
}