using Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Request
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(log => log.Email).NotNull().NotEmpty();
            RuleFor(log => log.Password).NotNull().NotEmpty();
        }
    }
}
