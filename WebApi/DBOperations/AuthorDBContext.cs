using Microsoft.EntityFrameworkCore;

namespace WebApi.DBOperations
{
  public class AuthorDBContext : DbContext
  {
    public AuthorDBContext(DbContextOptions<AuthorDBContext> options) : base(options){

    }

    public DbSet<Author> Authors { get; set; }
  }    
}