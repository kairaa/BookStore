using System;
using FluentValidation;

namespace WebApi.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
      public UpdateAuthorCommandValidator()
      {
        RuleFor(command => command.AuthorId).GreaterThan(0);
        RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(4);
        RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(4);
        RuleFor(command => command.Model.Birthday.Date).NotEmpty().LessThan(DateTime.Now.Date);
      }
    }
}