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
         .NotEmpty().WithMessage("Date cannot be empty.");
        }

        

     
    }
}
