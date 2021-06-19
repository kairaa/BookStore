using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.DeleteGenre
{
  public class DeleteGenreCommand
  {
    public int GenreId { get; set; }
    private readonly BookStoreDBContext _dbContext;

    public DeleteGenreCommand(BookStoreDBContext dbContext)
    {
      _dbContext = dbContext;
    }

    public void Handle()
    {
      var genre = _dbContext.Genres.Where(x => x.Id == GenreId).SingleOrDefault();
      if(genre is null)
        throw new InvalidOperationException("Genre couldn't found");
      
      _dbContext.Genres.Remove(genre);
      _dbContext.SaveChanges();
    }
  }
}