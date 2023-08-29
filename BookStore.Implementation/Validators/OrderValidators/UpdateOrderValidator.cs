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
    public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderValidator(BookStoreContext context)
        {
            var lista = new List<int>() {0,1,2,4};
            RuleFor(x => x.OrderId).NotEmpty()
                                  .WithMessage("OrderId is required")
                                  .Must(x => context.Orders.Any(y => y.Id == x && !y.DeletedAt.HasValue))
                                  .WithMessage("Invalid order");
            RuleFor(x => x.UserId).NotEmpty()
                                 .WithMessage("UserId is required")
                                 .Must(x => context.Users.Any(y => y.Id == x && !y.DeletedAt.HasValue))
                                 .WithMessage("Invalid user");
            RuleFor(x => x.OrderStatus).NotEmpty()
                                      .WithMessage("Order status is required")
                                      .Must(x => lista.Contains(x))
                                      .WithMessage("Invalid order status");
        }
    }
}
