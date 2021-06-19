using FluentValidation;

namespace WebApi.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
      public UpdateGenreCommandValidator()
      {
        RuleFor(command => command.Model.Name).NotEmpty();
      }
    }
}