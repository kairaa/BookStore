using FluentValidation;

namespace WebApi.AuthorOperations.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
      public GetAuthorDetailQueryValidator()
      {
        RuleFor(command => command.AuthorId).GreaterThan(0);
      }
    }
}