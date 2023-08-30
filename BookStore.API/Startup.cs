using BookStore.API.Core;
using BookStore.API.DTO;
using BookStore.API.Extensions;
using BookStore.API.Jwt;
using BookStore.API.Jwt.TokenStorage;
using BookStore.Application;
using BookStore.Application.Logging;
using BookStore.Application.Uploads;
using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands;
using BookStore.Application.UseCases.Queries;
using BookStore.DataAccess;
using BookStore.Implementation.Logging;
using BookStore.Implementation.Uploads;
using BookStore.Implementation.UseCases.Commands.Author1;
using BookStore.Implementation.UseCases.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings();
            Configuration.Bind(appSettings);
            services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<BookStoreContext>();
                var tokenStorage = x.GetService<ITokenStorage>();
                return new JwtManager(context, appSettings.Jwt.Issuer, appSettings.Jwt.SecretKey, appSettings.Jwt.DurationSeconds, tokenStorage);
            });
            services.AddLogger();
            services.AddTransient<BookStoreContext>(x =>
            {
                DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
                builder.UseSqlServer(@"Data Source=DESKTOP-LG5BUTB\SQLEXPRESS2;Initial Catalog=BookStore;Integrated Security=True");
                return new BookStoreContext(builder.Options);
            });

            services.AddTransient<QueryHandler>();

            services.AddHttpContextAccessor();

            services.AddScoped<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];
                var user = accessor.HttpContext.User;
                var data = header.ToString().Split("Bearer ");

                if (data.Length < 2)
                {
                    return new UnauthorizedActor();
                }

                var handler = new JwtSecurityTokenHandler();

                var tokenObj = handler.ReadJwtToken(data[1].ToString());

                var claims = tokenObj.Claims;

                var email = claims.First(x => x.Type == "Email").Value;
                var id = claims.First(x => x.Type == "Id").Value;
                var username = claims.First(x => x.Type == "Username").Value;
                var useCases = claims.First(x => x.Type == "UseCases").Value;

                List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

                return new JwtActor
                {
                    Email = email,
                    AllowedUseCases = useCaseIds,
                    Id = int.Parse(id),
                    Username = username,
                };
            });

            services.AddTransient<IQueryHandler>(x =>
            {
                var queryHandler = new QueryHandler();
                return queryHandler;
            });
            services.AddTransient<IBase64FileUploader, Base64FileUploader>();
            services.AddAuthorCommandsAndQueries();
            services.AddGenreCommandsAndQueries();
            services.AddPublisherCommandsAndQueries();
            services.AddYearPublishedCommandsAndQueries();
            services.AddCoverCommandsAndQueries();
            services.AddBookCommandsAndQueries();
            services.AddUserCommandsAndQueries();
            services.AddRoleUseCasesCommandsAndQueries();
            services.AddCartCommandsAndQueries();
            services.AddOrderCommandsAndQueries();
            services.AddValidators();
            services.AddTransient<ISearchLogQuery, EfSearchLogQuery>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
            services.AddTransient<ICommandHandler, CommandHandler>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore.API", Version = "v1" });
            });

            services.AddJwt(appSettings);
            services.AddTransient<IQueryHandler>(x =>
            {
                var actor = x.GetService<IApplicationActor>();
                var logger = x.GetService<IUseCaseLogger>();
                var queryHandler = new QueryHandler();
                var timeTrackingHandler = new TimeTrackingQueryHandler(queryHandler);
                var loggingHandler = new LoggingQueryHandler(timeTrackingHandler, actor, logger);
                var decoration = new AuthorizationQueryHandler(actor, loggingHandler);

                return decoration;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
