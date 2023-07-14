using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string Name, string reason)
            :base($"Operation {Name} can't be executed. Reason: {reason}")
        {
        }
    }
}
