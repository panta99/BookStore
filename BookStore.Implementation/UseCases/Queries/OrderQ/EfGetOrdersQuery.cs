using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.DTO.OrderDTOs;
using BookStore.Application.UseCases.Queries.OrderQ;
using BookStore.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Queries.OrderQ
{
    public class EfGetOrdersQuery : EfUseCase, IGetOrderQuery
    {
        public EfGetOrdersQuery(BookStoreContext context) 
            : base(context)
        {
        }

        public int Id => 39;

        public string Name => "Get orders";

        public string Description => "Get orders or order";

        public IEnumerable<GetOrderDto> Execute(GetOrderQuery dto)
        {
            var validUser = Context.Users.Any(x => x.Id == dto.UserId);
            if (!validUser)
            {
                throw new HttpStatusCodeException(400, "User doesn't exist");
            }
            if (dto.OrderId.HasValue && Context.Orders.Any(x=> x.Id ==dto.OrderId && !x.DeletedAt.HasValue))
            {
                var order = Context.Orders.Where(x => x.Id == dto.OrderId && !x.DeletedAt.HasValue).Include(x => x.OrderBooks).ToList() ;
                return order.Select(x => new GetOrderDto
                {
                    OrderId = x.Id,
                    Address = x.Address,
                    UserId = x.UserId,
                    OrderStatus = x.OrderStatus.ToString(),
                    OrderedBooks = x.OrderBooks.Select(y=> new OrderedBooksDto
                    {
                         BookName = y.BookName,
                          Quantity = y.Quantity,
                           Price = y.Price
                    }),
                     TotalPrice = x.OrderBooks.Sum(x=> x.Price*x.Quantity)
                });
            }
            var orders = Context.Orders.Where(x => x.UserId == dto.UserId && !x.DeletedAt.HasValue);
            return orders.Select(x => new GetOrderDto
            {
                OrderId = x.Id,
                Address = x.Address,
                UserId = x.UserId,
                OrderStatus = x.OrderStatus.ToString(),
                OrderedBooks = x.OrderBooks.Select(y => new OrderedBooksDto
                {
                    BookName = y.BookName,
                    Quantity = y.Quantity,
                    Price = y.Price
                }),
                TotalPrice = x.OrderBooks.Sum(x => x.Price * x.Quantity)
            });
        }
    }
}
