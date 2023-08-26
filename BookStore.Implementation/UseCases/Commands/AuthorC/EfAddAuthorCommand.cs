using AutoMapper;
using BookStore.Application.UseCases.Commands;
using BookStore.Application.UseCases.DTO;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.Author1
{
    public class EfAddAuthorCommand : EfUseCase, IAddAuthorCommand
    {
        protected readonly IMapper _mapper;
        private AddAuthorValidator _validator;
        public EfAddAuthorCommand(BookStoreContext context,AddAuthorValidator validator) 
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "Add author";

        public string Description => "Adding author";

        public void Execute(AddAuthorDto request)
        {
            _validator.ValidateAndThrow(request);
            //_mapper.Map<Author>(request);
            var author = new Author
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                CreatedAt = DateTime.UtcNow
            };
            Context.Add(author);
            Context.SaveChanges();
        }
    }
}
