using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.DTO.CartDTOs;
using BookStore.Application.UseCases.Queries.CartQ;
using BookStore.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Queries.CartQ
{
    public class EfGetCartQuery : EfUseCase, IGetCartQuery
    {
        public EfGetCartQuery(BookStoreContext context) 
            : base(context)
        {
        }

        public int Id => 35;

        public string Name => "Get cart";

        public string Description => "Get cart items";

        public GetCartDto Execute(int userId)
        {
            var user = Context.Users.Where(x => x.Id == userId && !x.DeletedAt.HasValue && x.IsActive).FirstOrDefault();
            if(user == null)
            {
                    throw new HttpStatusCodeException(403, "User is inactive or deleted");
            }
            var doesCartHaveItems = Context.CartBooks
                                            .Include(x => x.Cart)
                                            .Where(x => x.Cart.UserId == userId && !x.Cart.DeletedAt.HasValue)
                                            .Count();

            if(doesCartHaveItems == 0)
            {
                throw new HttpStatusCodeException(404, "Cart is empty");
            }

            var cartItems = Context.CartBooks
                                   .Include(x => x.Book)
                                   .Include(x => x.Cart)
                                   .Where(x => x.Cart.UserId == userId && !x.Cart.DeletedAt.HasValue);
            var cartId = cartItems.Select(x=> x.CartId).FirstOrDefault();

            var allItemsFromCart = cartItems.Select(x => new CartItemDto
            {
                BookId = x.BookId,
                BookName = x.Book.Name,
                Quantity = x.Quantity,
                Price = x.Price,
                TotalPrice = x.Price * x.Quantity
            }).ToList();

            return new GetCartDto
            {
                UserId = userId,
                BooksInCart = allItemsFromCart,
                CartId = cartId,
                   PriceOfWholeCart = allItemsFromCart.Sum(x => x.TotalPrice),
            };
        }
    }
}
