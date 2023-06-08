using BookStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Implementation.UseCases
{
    public class EfUseCase
    {
        protected BookStoreContext Context { get; }
        protected EfUseCase(BookStoreContext context)
        {
            Context = context;
        }
    }
}
