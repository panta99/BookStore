using BookStore.Application.UseCases.Commands.BookC;
using BookStore.Application.UseCases.DTO.BookDTOs;
using BookStore.Application.UseCases.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Validators.BookValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.BookC
{
    public class EfAddQuantityCommand : EfUseCase, IAddQuantityCommand
    {
        private readonly AddQuantityValidator _validator;
        public EfAddQuantityCommand(BookStoreContext context, AddQuantityValidator validator) 
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 23;

        public string Name => "Add quantity to specific book";

        public string Description => "Adding a quantity to the current quantity";

        public void Execute(UpdateBookQuantityDto request)
        {
            var book = Context.Books.FirstOrDefault(x => x.Id == request.BookId);
            if(book == null)
            {
                throw new EntityNotFoundException(request.BookId, nameof(Book));
            }
            _validator.ValidateAndThrow(request);
            book.QuantityInStock += request.Quantity;
            Context.SaveChanges();
        }
    }
}
