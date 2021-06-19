using FluentValidation;

namespace WebApi.Application.GenreOperations.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
      public GetGenreDetailQueryValidator()
      {
        RuleFor(context => context.GenreId).GreaterThan(0);
      }
    }
}