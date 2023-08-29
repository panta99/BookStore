using BookStore.Application.UseCases.Commands.OrderC;
using BookStore.Application.UseCases.Exceptions;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.OrderC
{
    public class EfDeleteOrderCommand : EfUseCase, IDeleteOrderCommand
    {
        public EfDeleteOrderCommand(BookStoreContext context) : base(context)
        {
        }

        public int Id => 41;

        public string Name => "Delete order";

        public string Description => "Delete order by id";

        public void Execute(int id)
        {
            var forDelete = Context.Orders
                                   .FirstOrDefault(x => x.Id == id && !x.DeletedAt.HasValue && x.OrderStatus == Domain.Entites.StatusOfOrder.Delivered);
            if(forDelete == null)
            {
                throw new EntityNotFoundException(id, nameof(Order));
            }
            forDelete.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
