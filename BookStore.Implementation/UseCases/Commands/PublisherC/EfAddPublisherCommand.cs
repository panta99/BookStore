using BookStore.Application.UseCases.Commands.PublisherC;
using BookStore.Application.UseCases.DTO.PublisherDTOs;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Validators.PublisherValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.PublisherC
{
    public class EfAddPublisherCommand : EfUseCase, IAddPublisherCommand
    {
        private AddPublisherValidator _validator;
        public EfAddPublisherCommand(BookStoreContext context, AddPublisherValidator validator) 
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "Add publisher";

        public string Description => "Adding publisher";

        public void Execute(AddPublisherDto request)
        {
            _validator.ValidateAndThrow(request);
            var publisher = new Publisher
            {
                Name = request.Name,
                CreatedAt = DateTime.UtcNow
            };
            Context.Publishers.Add(publisher);
            Context.SaveChanges();
        }
    }
}
