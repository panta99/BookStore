using BookStore.API.Core;
using BookStore.API.Extensions;
using BookStore.Application.UseCaseHandling;
using BookStore.Application.UseCases.Commands;
using BookStore.Application.UseCases.Queries;
using BookStore.DataAccess;
using BookStore.Implementation.UseCases.Commands.Author1;
using BookStore.Implementation.UseCases.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
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
            services.AddTransient<BookStoreContext>(x =>
            {
                DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
                builder.UseSqlServer(@"Data Source=DESKTOP-LG5BUTB\SQLEXPRESS2;Initial Catalog=BookStore;Integrated Security=True");
                return new BookStoreContext(builder.Options);
            });
            services.AddTransient<IQueryHandler>(x =>
            {
                var queryHandler = new QueryHandler();
                return queryHandler;
            });
            services.AddAuthorCommandsAndQueries();
            services.AddGenreCommandsAndQueries();
            services.AddPublisherCommandsAndQueries();
            services.AddYearPublishedCommandsAndQueries();
            services.AddValidators();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<GlobalExceptionHandler>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
