using BookStore.Application.UseCases.Commands.AuthorC;
using BookStore.Application.UseCases.DTO;
using BookStore.Application.UseCases.DTO.AuthorDTOs;
using BookStore.Application.UseCases.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.AuthorC
{
    public class EfUpdateAuthorCommand : EfUseCase, IUpdateAuthorCommand
    {
        private UpdateAuthorValidator _validator;
        public EfUpdateAuthorCommand(BookStoreContext context, UpdateAuthorValidator validator)
            : base(context)
        {
            _validator = validator;
        }
        public int Id => 3;

        public string Name => "Update author";

        public string Description => "Updating author first name and last name";

        public void Execute(UpdateAuthorDto request)
        {
            var query = Context.Authors.FirstOrDefault(x => x.Id == request.Id);
            if(query == null)
            {
                throw new EntityNotFoundException(request.Id, nameof(Author));
            }
            _validator.ValidateAndThrow(request);
            query.FirstName = request.FirstName;
            query.LastName = request.LastName;
            query.ModifiedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
