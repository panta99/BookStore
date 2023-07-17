using BookStore.Application.Exceptions;
using BookStore.Application.UseCases.Commands.YearPublishedC;
using BookStore.DataAccess;
using BookStore.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases.Commands.YearPublishedC
{
    public class EfAddYearPublishedCommand : EfUseCase, IAddYearPublishedCommand
    {
        public EfAddYearPublishedCommand(BookStoreContext context) 
            : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Add year published";

        public string Description => "Adding year published";

        public void Execute(int year)
        {
            var curryear = DateTime.UtcNow.Year;
            if(year<1970 || year > curryear)
            {
                var message = $"Year must be between 1970 - {curryear}";
                throw new UnprocessableEntity(message);
            }
            var check = Context.YearPublished.Any(x => x.Year == year);
            if (check)
            {
                var message = $"Year {year} alredy exists";
                throw new UnprocessableEntity(message);
            }
            var yearforAdd = new YearPublished
            {
                Year = year,
                CreatedAt = DateTime.UtcNow
            };
            Context.YearPublished.Add(yearforAdd);
            Context.SaveChanges();
        }
    }
}
