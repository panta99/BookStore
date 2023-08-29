using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Commands.OrderC;
using BookStore.Application.UseCases.DTO.OrderDTOs;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Validators.OrderValidators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.OrderC
{
    public class EfCreateOrderCommand : EfUseCase, ICreateOrderCommand
    {
        private readonly CreateOrderValidator _validator;
        public EfCreateOrderCommand(BookStoreContext context, CreateOrderValidator validator) 
            : base(context)
        {
            _validator = validator;
        }

        public int Id => 38;

        public string Name => "Create order";

        public string Description => "Create order";

        public void Execute(CreateOrderDto dto)
        {
            _validator.ValidateAndThrow(dto);
            var userId = dto.UserId;

            var bookIds = dto.BooksForBuy.Select(x => x.BookId);
            var cartIdChk = Context.Cart.FirstOrDefault(x => x.UserId == userId).Id;
            if (cartIdChk == 0)
            {
                throw new HttpStatusCodeException(404, "User cart not found");
            }
            var allItemsFromCart = Context.CartBooks.Where(x => x.CartId == cartIdChk);
            bool allBookInCart = true;
            foreach (var cItem in allItemsFromCart)
            {
                allBookInCart &= bookIds.Any(x => x == cItem.BookId);
            }
            if (!allBookInCart)
            {
                throw new HttpStatusCodeException(400, "Bad request");
            }
            var order = new Order
            {
                UserId = dto.UserId,
                Address = dto.Address,
                CreatedAt = DateTime.UtcNow,
                OrderDate = DateTime.UtcNow.Date,
                OrderStatus = StatusOfOrder.Recived
            };
            Context.Orders.Add(order);
            Context.SaveChanges();
            var orderBooks = dto.BooksForBuy.Select(x => new OrderBook
            {
                BookId = x.BookId,
                Quantity = x.Quantity,
                Price = Context.Books.FirstOrDefault(b => b.Id == x.BookId).Price,
                BookName = Context.Books.FirstOrDefault(b => b.Id == x.BookId).Name,
                CreatedAt = DateTime.UtcNow,
                OrderId = order.Id
            });
            foreach(var ob in orderBooks)
            {
                Context.Books.FirstOrDefault(x => x.Id == ob.BookId).QuantityInStock -= ob.Quantity;
                var cartId = Context.Cart
                    .Where(x => x.UserId == dto.UserId && !x.DeletedAt.HasValue)
                    .Select(x => x.Id)
                    .FirstOrDefault();
                var crtRemove = Context.CartBooks.Where(x => x.BookId == ob.BookId && x.CartId == cartId);
                Context.CartBooks.RemoveRange(crtRemove);
                Context.OrderBooks.Add(ob);
            }
            Context.SaveChanges();
        }
    }
}
