using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Common;
using System;

namespace WebApi.BookOperations.GetBookDetail
{
  public class GetBookDetailQuery
  {
    public int BookId { get; set; }
    private readonly BookStoreDBContext _dbContext;

    public GetBookDetailQuery(BookStoreDBContext dbContext){
      _dbContext = dbContext;
    }

    public BookDetailViewModel Handle()
    {
      var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
      if(book is null)
        throw new InvalidOperationException("Book couldn't found");
      
      BookDetailViewModel vm = new BookDetailViewModel();
      vm.Title = book.Title;
      vm.PageCount = book.PageCount;
      vm.Genre = ((GenreEnum)book.GenreId).ToString();
      vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
      return vm;
    }
  }

  public class BookDetailViewModel
  {
    public string Title { get; set; }
    public string Genre { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }

    }
}