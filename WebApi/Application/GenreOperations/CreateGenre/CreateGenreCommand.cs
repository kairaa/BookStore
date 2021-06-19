using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
      public CreateGenreModel Model { get; set; }

      private readonly BookStoreDBContext _dbContext;
      private readonly IMapper _mapper;

    public CreateGenreCommand(BookStoreDBContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public void Handle()
    {
      var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == Model.Name);
      if (genre is not null)
        throw new InvalidOperationException("Genre has already exist");
      
      genre = _mapper.Map<Genre>(Model);

      _dbContext.Genres.Add(genre);
      _dbContext.SaveChanges();      
    }
  }

  public class CreateGenreModel
  {
    public string Name { get; set; }
  }
}