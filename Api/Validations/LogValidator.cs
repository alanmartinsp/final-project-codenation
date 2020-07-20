using Business.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Request
{
    public class LogValidator : AbstractValidator<Log>
    {
        public LogValidator()
        {
            RuleFor(log => log.Level).NotNull();
            RuleFor(log => log.Event).NotNull();
            RuleFor(log => log.Title).NotNull();
            RuleFor(log => log.Origin).NotNull();
            RuleFor(log => log.Details).NotNull();
        }
    }
}
