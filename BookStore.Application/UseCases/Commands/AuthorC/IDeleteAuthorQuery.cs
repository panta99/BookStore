using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Commands.AuthorC
{
    public interface IDeleteAuthorQuery : ICommand<int>
    {
    }
}
