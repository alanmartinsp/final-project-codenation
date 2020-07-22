using Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Request
{
    public class LogValidator : AbstractValidator<LogRequest>
    {
        public LogValidator()
        {
            RuleFor(log => log.Level).NotNull().NotEmpty();
            RuleFor(log => log.Event).NotNull().NotEmpty();
            RuleFor(log => log.Title).NotNull().NotEmpty();
            RuleFor(log => log.Origin).NotNull().NotEmpty();
            RuleFor(log => log.Details).NotNull().NotEmpty();
            RuleFor(log => log.Enviroment).NotNull().NotEmpty();
        }
    }
}
