using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using System;

namespace WebApi.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
      public UpdateGenreModel Model { get; set; }
      public int GenreId { get; set; }
      private readonly BookStoreDBContext _dbContext;

      public UpdateGenreCommand(BookStoreDBContext dbContext)
      {
        _dbContext = dbContext;
      }

      public void Handle()
      {
        var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);
        if(genre is null)
          throw new InvalidOperationException("Genre couldn't found");
        genre.Name = Model.Name != default ? Model.Name : genre.Name;
        _dbContext.SaveChanges();
      }
  }

  public class UpdateGenreModel
  {
    public string Name { get; set; }
  }
}