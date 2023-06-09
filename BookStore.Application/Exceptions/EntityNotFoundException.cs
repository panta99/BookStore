﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCases.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, string type)
            : base($"Entity of type {type} with and id of {id} was not found.")
        {
        }
    }
}
