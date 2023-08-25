using BookStore.Application.UseCases.DTO.BookDTOs;
using BookStore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Validators.BookValidators
{
    public class AddQuantityValidator : AbstractValidator<UpdateBookQuantityDto>
    {
        public AddQuantityValidator(BookStoreContext context)
        {
            RuleFor(x => x.Quantity).NotEmpty()
                                   .WithMessage("Quantity is required")
                                   .Must(x => x > 0)
                                   .WithMessage("Quantity can't be negative");
        }
    }
}
