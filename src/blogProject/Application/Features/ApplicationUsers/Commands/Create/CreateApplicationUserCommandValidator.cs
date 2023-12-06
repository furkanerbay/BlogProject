using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ApplicationUsers.Commands.Create;

public class CreateApplicationUserCommandValidator : AbstractValidator<CreateApplicationUserCommand>
{
    public CreateApplicationUserCommandValidator()
    {
        RuleFor(c => c.UserId).GreaterThan(0);
    }
}