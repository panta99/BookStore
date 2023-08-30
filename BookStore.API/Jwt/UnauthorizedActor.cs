using BookStore.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Jwt
{
    public class UnauthorizedActor : IApplicationActor
    {
        public int Id => 0;

        public string Email => "";

        public string Username => "unauthorize";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 20, 19, 15, 5, 9, 13, 26 };
    }
}
