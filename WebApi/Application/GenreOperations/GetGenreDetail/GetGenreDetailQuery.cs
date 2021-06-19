using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
      public int GenreId { get; set; }
      private readonly BookStoreDBContext _dbContext;
      private readonly IMapper _mapper;

    public GetGenreDetailQuery(BookStoreDBContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public GenreDetailViewModel Handle()
      {
        var genre = _dbContext.Genres.Where(x => x.Id == GenreId).SingleOrDefault();
        if(genre is null)
          throw new InvalidOperationException("Genre couldn't found");
        
        GenreDetailViewModel vm = _mapper.Map<GenreDetailViewModel>(genre);
        return vm;
      }
    }

    public class GenreDetailViewModel
    {
      public string Name { get; set; }
      public bool isActive { get; set; }
    }
}