using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Commands.CartC;
using BookStore.Application.UseCases.DTO.CartDTOs;
using BookStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.CartC
{
    public class EfUpdateCartQuantityCommand : EfUseCase, IUpdateCartQuantityCommand
    {
        public EfUpdateCartQuantityCommand(BookStoreContext context) : base(context)
        {
        }

        public int Id => 37;

        public string Name => "Update cart quantity";

        public string Description => "Update quantity of specific book in cart";

        public void Execute(UpdateCartDto dto)
        {
            var hasActiveCart = Context.Cart
                                       .Where(x => x.UserId == dto.UserId && !x.DeletedAt.HasValue)
                                       .Any();
            var checkUser = Context.Users.Any(x => x.Id == dto.UserId && !x.DeletedAt.HasValue);
            if(checkUser)
            {
                throw new HttpStatusCodeException(401, "This user doesn't exist");
            }
            if (hasActiveCart)
            {
                var cartId = Context.Cart
                    .Where(x => x.UserId == dto.UserId && !x.DeletedAt.HasValue)
                    .Select(x => x.Id)
                    .FirstOrDefault();
                var isBookInCart = Context.CartBooks.Where(x => x.CartId == cartId && x.BookId == dto.BookId).Any();
                if (isBookInCart) 
                {
                    var selected = Context.CartBooks.Where(x => x.CartId == cartId && x.BookId == dto.BookId).FirstOrDefault();
                    selected.Quantity = dto.Quantity;
                    Context.SaveChanges();
                    return;
                }
                else
                {
                    throw new HttpStatusCodeException(404, "Book isn't in cart");
                }
            }
            throw new HttpStatusCodeException(404, "Book isn't in cart");
        }
    }
}
