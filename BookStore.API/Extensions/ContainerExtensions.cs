using BookStore.Application.UseCases.Commands;
using BookStore.Application.UseCases.Commands.AuthorC;
using BookStore.Application.UseCases.Commands.GenreC;
using BookStore.Application.UseCases.Commands.PublisherC;
using BookStore.Application.UseCases.Commands.YearPublishedC;
using BookStore.Application.UseCases.Queries;
using BookStore.Application.UseCases.Queries.GenreQ;
using BookStore.Application.UseCases.Queries.PublisherQ;
using BookStore.Application.UseCases.Queries.YearPublishedQ;
using BookStore.Implementation.UseCases.Commands.Author1;
using BookStore.Implementation.UseCases.Commands.AuthorC;
using BookStore.Implementation.UseCases.Commands.GenreC;
using BookStore.Implementation.UseCases.Commands.PublisherC;
using BookStore.Implementation.UseCases.Commands.YearPublishedC;
using BookStore.Implementation.UseCases.Queries;
using BookStore.Implementation.UseCases.Queries.GenreQ;
using BookStore.Implementation.UseCases.Queries.PublisherC;
using BookStore.Implementation.UseCases.Queries.YearPublishedQ;
using BookStore.Implementation.Validators;
using BookStore.Implementation.Validators.GenreValidators;
using BookStore.Implementation.Validators.PublisherValidators;
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
            //Author validators
            services.AddTransient<AddAuthorValidator>();
            services.AddTransient<UpdateAuthorValidator>();
            //Genre Validators
            services.AddTransient<AddGenreValidator>();
            services.AddTransient<UpdateGenreValidator>();
            //Publisher Validators
            services.AddTransient<AddPublisherValidator>();
            services.AddTransient<UpdatePublisherValidator>();

        }
        public static void AddAuthorCommandsAndQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetAuthorsQuery, EfGetAuthorsQuery>();
            services.AddTransient<IAddAuthorCommand, EfAddAuthorCommand>();
            services.AddTransient<IUpdateAuthorCommand, EfUpdateAuthorCommand>();
            services.AddTransient<IDeleteAuthorCommand, EfDeleteAuthorCommand>();
        }
        public static void AddGenreCommandsAndQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetGenresQuery, EfGetGenresQuery>();
            services.AddTransient<IAddGenreCommand, EfAddGenreCommand>();
            services.AddTransient<IUpdateGenreCommand, EfUpdateGenreCommand>();
            services.AddTransient<IDeleteGenreCommand, EfDeleteGenreCommand>();
        }
        public static void AddPublisherCommandsAndQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetPublisherQuery, EfGetPublisherQuery>();
            services.AddTransient<IAddPublisherCommand, EfAddPublisherCommand>();
            services.AddTransient<IUpdatePublisherCommand, EfUpdatePublisherCommand>();
            services.AddTransient<IDeletePublisherCommand, EfDeletePublisherCommand>();
        }
        public static void AddYearPublishedCommandsAndQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetYearPublishedQuery, EfGetYearPublishedQuery>();
            services.AddTransient<IAddYearPublishedCommand, EfAddYearPublishedCommand>();
        }
    }
}
