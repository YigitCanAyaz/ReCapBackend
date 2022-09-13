using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            // RuleFor().();
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.RentDate).NotEmpty();
            RuleFor(r => r.ReturnDate).Null();
        }
    }
}
