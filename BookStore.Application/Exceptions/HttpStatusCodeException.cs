﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Exceptions
{
    public class HttpStatusCodeException : Exception
    {
        public int StatusCode { get; set; }
        public HttpStatusCodeException(int statusCode, string message)
            :base(message)
        {
            StatusCode = statusCode;
        }
    }
}
