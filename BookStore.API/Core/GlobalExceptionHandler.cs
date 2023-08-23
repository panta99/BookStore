using BookStore.Application.Exceptions;
using BookStore.Application.Logging;
using BookStore.Application.UseCases.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        //private readonly IErrorLogger _errorLogger;
        public GlobalExceptionHandler(RequestDelegate next /*IErrorLogger logger*/)
        {
            _next = next;
            //_errorLogger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(ValidationException ex)
            {
                context.Response.StatusCode = 422;
                var errors = ex.Errors.Select(x => new
                {
                    x.ErrorMessage,
                    x.PropertyName
                });
                await context.Response.WriteAsJsonAsync(errors);
            }
            catch (EntityNotFoundException ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(new
                {
                    message = ex.Message
                });
            }
            catch (ConflictException ex)
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsJsonAsync(new
                {
                    message = ex.Message
                });
            }
            catch (UnprocessableEntityException ex)
            {
                context.Response.StatusCode = 422;
                await context.Response.WriteAsJsonAsync(new
                {
                    message = ex.Message
                });
            }
        }
    }
}
