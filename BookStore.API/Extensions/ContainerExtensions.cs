using BookStore.API.DTO;
using BookStore.API.ErrorLogging;
using BookStore.API.Jwt;
using BookStore.Application.Logging;
using BookStore.Application.UseCases.Commands;
using BookStore.Application.UseCases.Commands.AuthorC;
using BookStore.Application.UseCases.Commands.BookC;
using BookStore.Application.UseCases.Commands.CartC;
using BookStore.Application.UseCases.Commands.CoverC;
using BookStore.Application.UseCases.Commands.GenreC;
using BookStore.Application.UseCases.Commands.OrderC;
using BookStore.Application.UseCases.Commands.PublisherC;
using BookStore.Application.UseCases.Commands.RoleUseCaseC;
using BookStore.Application.UseCases.Commands.UserQ;
using BookStore.Application.UseCases.Commands.YearPublishedC;
using BookStore.Application.UseCases.Queries;
using BookStore.Application.UseCases.Queries.BookQ;
using BookStore.Application.UseCases.Queries.CartQ;
using BookStore.Application.UseCases.Queries.CoverQ;
using BookStore.Application.UseCases.Queries.GenreQ;
using BookStore.Application.UseCases.Queries.OrderQ;
using BookStore.Application.UseCases.Queries.PublisherQ;
using BookStore.Application.UseCases.Queries.UserQ;
using BookStore.Application.UseCases.Queries.YearPublishedQ;
using BookStore.Implementation.UseCases.Commands.Author1;
using BookStore.Implementation.UseCases.Commands.AuthorC;
using BookStore.Implementation.UseCases.Commands.BookC;
using BookStore.Implementation.UseCases.Commands.CartC;
using BookStore.Implementation.UseCases.Commands.CoverC;
using BookStore.Implementation.UseCases.Commands.GenreC;
using BookStore.Implementation.UseCases.Commands.OrderC;
using BookStore.Implementation.UseCases.Commands.PublisherC;
using BookStore.Implementation.UseCases.Commands.RoleUseCaseC;
using BookStore.Implementation.UseCases.Commands.UserC;
using BookStore.Implementation.UseCases.Commands.YearPublishedC;
using BookStore.Implementation.UseCases.Queries;
using BookStore.Implementation.UseCases.Queries.BookQ;
using BookStore.Implementation.UseCases.Queries.CartQ;
using BookStore.Implementation.UseCases.Queries.CoverQ;
using BookStore.Implementation.UseCases.Queries.GenreQ;
using BookStore.Implementation.UseCases.Queries.OrderQ;
using BookStore.Implementation.UseCases.Queries.PublisherC;
using BookStore.Implementation.UseCases.Queries.UserQ;
using BookStore.Implementation.UseCases.Queries.YearPublishedQ;
using BookStore.Implementation.Validators;
using BookStore.Implementation.Validators.BookValidators;
using BookStore.Implementation.Validators.CartValidators;
using BookStore.Implementation.Validators.CoverValidators;
using BookStore.Implementation.Validators.GenreValidators;
using BookStore.Implementation.Validators.OrderValidators;
using BookStore.Implementation.Validators.PublisherValidators;
using BookStore.Implementation.Validators.UseCaseValidators;
using BookStore.Implementation.Validators.UserValidators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
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
            //Cover Validators
            services.AddTransient<AddCoverValidator>();
            services.AddTransient<UpdateCoverValidator>();
            //Book Validators
            services.AddTransient<AddBookValidator>();
            services.AddTransient<AddQuantityValidator>();
            //User Validators
            services.AddTransient<RegisterUserValidator>();
            //RoleUseCase Validators
            services.AddTransient<AddUseCasesValidator>();
            services.AddTransient<DeleteUseCasesValidator>();
            //Cart Validators
            services.AddTransient<AddBookToCartValidator>();
            services.AddTransient<DeleteBookValidator>();
            //Order validators
            services.AddTransient<CreateOrderValidator>();
            services.AddTransient<UpdateOrderValidator>();

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
            services.AddTransient<IGetPublishersQuery, EfGetPublishersQuery>();
            services.AddTransient<IAddPublisherCommand, EfAddPublisherCommand>();
            services.AddTransient<IUpdatePublisherCommand, EfUpdatePublisherCommand>();
            services.AddTransient<IDeletePublisherCommand, EfDeletePublisherCommand>();
        }
        public static void AddYearPublishedCommandsAndQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetYearPublishedQuery, EfGetYearPublishedQuery>();
            services.AddTransient<IAddYearPublishedCommand, EfAddYearPublishedCommand>();
        }
        public static void AddCoverCommandsAndQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetCoversQuery, EfGetCoversQuery>();
            services.AddTransient<IAddCoverCommand, EfAddCoverCommand>();
            services.AddTransient<IUpdateCoverCommand, EfUpdateCoverCommand>();
            services.AddTransient<IDeleteCoverCommand, EfDeleteCoverCommand>();

        }
        public static void AddBookCommandsAndQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetBooksQuery, EfGetBooksQuery>();
            services.AddTransient<IGetBookByIdQuery, EfGetBookByIdQuery>();
            services.AddTransient<IAddBookCommand, EfAddBookCommand>();
            services.AddTransient<IUpdateBookCommand, EfUpdateBookCommand>();
            services.AddTransient<IAddQuantityCommand, EfAddQuantityCommand>();
            services.AddTransient<IDeleteBookCommand, EfDeleteBookCommand>();
        }
        public static void AddUserCommandsAndQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IDeactivateUserCommand, EfDeactivateUserCommand>();
            services.AddTransient<IActivateUserCommand, EfActivateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IGetSpecificUserQuery, EfGetSpecificUserQuery>();
        }
        public static void AddRoleUseCasesCommandsAndQueries(this IServiceCollection services)
        {
            services.AddTransient<IAddRoleUseCasesCommand, EfAddRoleUseCasesCommand>();
            services.AddTransient<IDeleteRoleUseCasesCommand, EfDeleteRoleUseCasesCommand>();
        }
        public static void AddCartCommandsAndQueries(this IServiceCollection services)
        {
            services.AddTransient<IAddBookToCartCommand,EfAddBookToCartCommand>();
            services.AddTransient<IGetCartQuery, EfGetCartQuery>();
            services.AddTransient<IDeleteBookFromCartCommand, EfDeleteBookFromCartCommand>();
            services.AddTransient<IUpdateCartQuantityCommand, EfUpdateCartQuantityCommand>();
        }
        public static void AddOrderCommandsAndQueries(this IServiceCollection services)
        {
            services.AddTransient<ICreateOrderCommand, EfCreateOrderCommand>();
            services.AddTransient<IGetOrderQuery, EfGetOrdersQuery>();
            services.AddTransient<IUpdateOrderCommand, EfUpdateOrderCommand>();
            services.AddTransient<IDeleteOrderCommand, EfDeleteOrderCommand>();
        }
        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.Jwt.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };

                cfg.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        //Token dohvatamo iz Authorization header-a

                        var header = context.Request.Headers["Authorization"];

                        var token = header.ToString().Split("Bearer ")[1];

                        var handler = new JwtSecurityTokenHandler();

                        var tokenObj = handler.ReadJwtToken(token);

                        string jti = tokenObj.Claims.FirstOrDefault(x => x.Type == "jti").Value;


                        //ITokenStorage

                        ITokenStorage storage = context.HttpContext.RequestServices.GetService<ITokenStorage>();

                        bool isValid = storage.TokenExists(jti);

                        if (!isValid)
                        {
                            context.Fail("Token is not valid.");
                        }

                        return Task.CompletedTask;
                    }
                };
            });
        }

        public static void AddLogger(this IServiceCollection services)
        {
            services.AddTransient<IErrorLogger>(x =>
            {
                var accesor = x.GetService<IHttpContextAccessor>();

                if (accesor == null || accesor.HttpContext == null)
                {
                    return new ConsoleErrorLogger();
                }

                var logger = accesor.HttpContext.Request.Headers["Logger"].FirstOrDefault();

                if(logger == "Console")
                {
                    return new ConsoleErrorLogger();
                }
                return new ConsoleErrorLogger();
            });
        }
    }
}
