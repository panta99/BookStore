using BookStore.Application.UseCases.Commands.PublisherC;
using BookStore.Application.UseCases.DTO.PublisherDTOs;
using BookStore.Application.UseCases.Exceptions;
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
    public class EfUpdatePublisherCommand : EfUseCase, IUpdatePublisherCommand
    {
        private UpdatePublisherValidator _validator;
        public  EfUpdatePublisherCommand(BookStoreContext context, UpdatePublisherValidator validator) 
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Update publisher";

        public string Description => "Update publisher name by id";

        public void Execute(UpdatePublisherDto request)
        {
            var publisher = Context.Publishers.Find(request.Id);
            if(publisher == null)
            {
                throw new EntityNotFoundException(request.Id, nameof(Publisher));
            }
            _validator.ValidateAndThrow(request);
            publisher.Name = request.Name;
            publisher.ModifiedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
