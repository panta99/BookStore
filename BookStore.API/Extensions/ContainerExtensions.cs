using BookStore.Application.UseCases.Commands;
using BookStore.Application.UseCases.Commands.AuthorC;
using BookStore.Application.UseCases.Queries;
using BookStore.Implementation.UseCases.Commands.Author1;
using BookStore.Implementation.UseCases.Commands.AuthorC;
using BookStore.Implementation.UseCases.Queries;
using BookStore.Implementation.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<AddAuthorValidator>();
            services.AddTransient<UpdateAuthorValidator>();
        }
        public static void AddAuthorCommandsAndQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetAuthorsQuery, EfGetAuthorsQuery>();
            services.AddTransient<IAddAuthorCommand, EfAddAuthorCommand>();
            services.AddTransient<IUpdateAuthorCommand, EfUpdateAuthorCommand>();
        }
    }
}
