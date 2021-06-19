using System;
using FluentValidation;
using WebApi.Application.AuthorOperations.UpdateAuthor;

namespace WebApi.Application.AuthorOperationss.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
      public UpdateAuthorCommandValidator()
      {
        RuleFor(command => command.AuthorId).GreaterThan(0);
        RuleFor(command => command.Model.FirstName).NotEmpty();
        RuleFor(command => command.Model.LastName).NotEmpty();
        RuleFor(command => command.Model.Birthday.Date).NotEmpty().LessThan(DateTime.Now.Date);
      }
    }
}