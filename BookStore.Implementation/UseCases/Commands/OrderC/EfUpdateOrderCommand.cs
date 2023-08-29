using BookStore.Application.UseCases.Commands.OrderC;
using BookStore.Application.UseCases.DTO.OrderDTOs;
using BookStore.Application.UseCases.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using BookStore.Implementation.Validators.OrderValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.OrderC
{
    public class EfUpdateOrderCommand : EfUseCase, IUpdateOrderCommand
    {
        private readonly UpdateOrderValidator _validator;
        public EfUpdateOrderCommand(BookStoreContext context, UpdateOrderValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 40;

        public string Name => "Update order status";

        public string Description => "Update order status";

        public void Execute(UpdateOrderDto dto)
        {
            _validator.ValidateAndThrow(dto);
            var order = Context.Orders
                               .FirstOrDefault(x => x.Id == dto.OrderId && x.UserId == dto.UserId && !x.DeletedAt.HasValue);
            if(order == null)
            {
                throw new EntityNotFoundException(dto.OrderId, nameof(Order));
            }
            order.OrderStatus = (StatusOfOrder)dto.OrderStatus;
            Context.SaveChanges();
        }
    }
}
