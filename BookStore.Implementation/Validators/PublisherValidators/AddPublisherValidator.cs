using BookStore.Application.UseCases.DTO.PublisherDTOs;
using BookStore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Validators.PublisherValidators
{
    public class AddPublisherValidator : AbstractValidator<AddPublisherDto>
    {
        public AddPublisherValidator(BookStoreContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                               .WithMessage("Publisher name is required");
            RuleFor(x => x.Name).Must(y => !context.Publishers.Any(x => x.Name == y))
                               .WithMessage("Publisher with this name already exists");
        }
    }
}
