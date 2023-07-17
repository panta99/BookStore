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
    public class UpdatePublisherValidator : AbstractValidator<UpdatePublisherDto>
    {
        public UpdatePublisherValidator(BookStoreContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                               .WithMessage("Name is required");
            RuleFor(x => x.Name).Must(y => !context.Publishers.Any(x => x.Name == y))
                                .WithMessage("Publisher with this name already exists");
        }
    }
}
