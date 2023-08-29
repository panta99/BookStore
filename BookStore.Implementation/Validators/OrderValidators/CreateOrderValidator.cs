using BookStore.Application.UseCases.DTO.OrderDTOs;
using BookStore.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.Validators.OrderValidators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
    {
        private readonly BookStoreContext _context;
        private IEnumerable<int> InvalidIds { get; set; }
        private IEnumerable<BookQuantity> QuantitiesByBook { get; set; }
        public CreateOrderValidator(BookStoreContext context)
        {
            _context = context;
            RuleFor(x => x.Address).NotEmpty()
                                  .WithMessage("Address is required");
            RuleFor(x => x.UserId).NotEmpty()
                                 .WithMessage("UserId is required")
                                 .Must(y => context.Users.Any(x => x.Id == y && !x.DeletedAt.HasValue))
                                 .WithMessage("Invalid user");
            RuleFor(dto => dto).NotEmpty()
                              .WithMessage("You can't create empty order")
                              .Must((dto) => !areValid(dto).Any())
                              .WithMessage((dto) =>
                              {
                                  string message = "";
                                  foreach (var id in InvalidIds)
                                  {
                                      message += ($"Book with id={id} doesn't exist" + Environment.NewLine);
                                  }
                                  return message;
                              })
                              .OverridePropertyName("BooksForBuy");
            RuleFor(dto => dto)
                             .NotEmpty()
                             .WithMessage("You can't create empty order")
                             .Must((dto) => allowedQuantity(dto))
                             .WithMessage((dto)=> 
                             {
                                 string message = "";
                                 foreach(var qb in QuantitiesByBook)
                                 {
                                     message += $"You can order {qb.Quantity} books with id={qb.BookId}" + Environment.NewLine;
                                 }
                                 return message;
                             })
                             .OverridePropertyName("Specific Quantity");
        }
        private bool allowedQuantity(CreateOrderDto dto)
        {
            var bookIdsForBuy = dto.BooksForBuy.Select(x => x.BookId).ToList();
            var books = _context.Books
                                        .Where(x => bookIdsForBuy.Contains(x.Id)).ToList();
            var quanByBook = books.Select(x => new BookQuantity
            {
                BookId = x.Id,
                Quantity = x.QuantityInStock
            }).Where(y=> y.Quantity < dto.BooksForBuy.FirstOrDefault(z=> z.BookId == y.BookId).Quantity);
            QuantitiesByBook = quanByBook;
            return !QuantitiesByBook.Any();
        }
        private IEnumerable<int> areValid(CreateOrderDto dto)
        {
            InvalidIds = dto.BooksForBuy.Select(x=> x.BookId).Except(_context.Books.Select(b => b.Id).ToList());
            if (InvalidIds.Any())
            {
                return InvalidIds;
            }
            return InvalidIds;
        }
        private class BookQuantity
        {
            public int BookId { get; set; }
            public int Quantity { get; set; }
        }
    }
}
