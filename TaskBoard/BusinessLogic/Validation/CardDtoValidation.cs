using BusinessLogic.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
     
    public class CardDtoValidation : AbstractValidator<CardDto>
    {
        public CardDtoValidation()
        {
            RuleFor(x => x.Date)
         .Cascade(CascadeMode.Stop)
         .NotNull().WithMessage("Date cannot be null.")
         .NotEmpty().WithMessage("Date cannot be empty.")
         .Must(BeValidDate).WithMessage("Date must be in the format 'ddd, d MMMM'.");

            RuleFor(x => x.Priority)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("Priority cannot be null.")
            .NotEmpty().WithMessage("Priority cannot be empty.")
            .Must(BeValidPriority).WithMessage("Priority must be 'Low', 'Medium', or 'High'.");
        }

        private bool BeValidDate(string date)
        {
            return DateTime.TryParseExact(date, "ddd, d MMMM", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        private bool BeValidPriority(string priority)
        {
            return priority == "Low" || priority == "Medium" || priority == "High";
        }
    }
}
