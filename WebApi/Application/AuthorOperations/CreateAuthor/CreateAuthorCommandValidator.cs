using FluentValidation;
using System;

namespace WebApi.Application.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.FirstName).NotNull();
            RuleFor(command => command.Model.LastName).NotNull();
            RuleFor(command => command.Model.Birthday.Date).NotEmpty().NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}