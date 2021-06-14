using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
  public class BookStoreDBContext : DbContext
  {
    public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
    {

    }

    public DbSet<Book> Books{ get; set; }  //Book database tarafında Books tablosuna karşılık gelir 
  }
}