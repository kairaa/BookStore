using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations
{
  public class DataGenerator
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using(var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
      {
        if(context.Books.Any())
        {
          return;
        }

        context.Books.AddRange(
          new Book{
            //Id = 1,
            Title = "Lean Startup",
            GenreId = 1,   // Personal Growth
            PageCount = 200,
            PublishDate = new DateTime(2001, 09, 12)
          },
          new Book{
            //Id = 2,
            Title = "Herland",
            GenreId = 2,   // Science Fiction
            PageCount = 240,
            PublishDate = new DateTime(2010, 12, 25)
          },
          new Book{
            //Id = 3,
            Title = "Dune",
            GenreId = 2,   // Science Fiction
            PageCount = 500,
            PublishDate = new DateTime(2001, 09, 12)
          }
        );
        context.SaveChanges();
      }

      using(var context = new AuthorDBContext(serviceProvider.GetRequiredService<DbContextOptions<AuthorDBContext>>()))
      {
        if(context.Authors.Any())
        {
          return;
        }

        context.Authors.AddRange(
          new Author{
            FirstName = "Kayra",
            LastName = "Çakıroğlu",
            Birthday = new DateTime(1999, 08, 09)
          },
          new Author{
            FirstName = "Ulaş",
            LastName = "Çakıroğlu",
            Birthday = new DateTime(1997, 07, 02),
          }
        );
        context.SaveChanges();
      }
    }
  }
}