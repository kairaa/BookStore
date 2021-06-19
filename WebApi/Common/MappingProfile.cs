using AutoMapper;
using WebApi.Application.AuthorOperations.CreateAuthor;
using WebApi.Application.AuthorOperations.GetAuthorDetail;
using WebApi.Application.AuthorOperations.GetAuthors;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.Application.BookOperations.GetBooks;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
      public MappingProfile()
      {
        CreateMap<CreateBookModel, Book>();   //ilk parametre source, ikinci parametre target
        CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        //genreId'yi genre'ye çevirmeyi getbookdetailquery'de çevirmek yerine automapper'ladığımız yerde çevirdik
        CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        
        CreateMap<CreateAuthorModel, Author>();
        CreateMap<Author, AuthorDetailViewModel>();
        CreateMap<Author, AuthorsViewModel>();
      }
    }
}