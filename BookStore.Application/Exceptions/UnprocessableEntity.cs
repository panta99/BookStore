﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Exceptions
{
    public class UnprocessableEntity : Exception
    {
        public UnprocessableEntity(string message)
            :base(message)
        {
        }
    }
}
