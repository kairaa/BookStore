using AutoMapper;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;

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
      }
    }
}