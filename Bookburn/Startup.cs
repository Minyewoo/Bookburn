using System.Text.Json.Serialization;
using Bookburn.Backoffice.Controllers;
using Bookburn.Core.Repositories;
using Bookburn.Mobile.Controllers;
using Bookburn.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Bookburn
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
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(x => x.FullName);
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "API", Version = "v1"});
            });

            services.AddControllers()
                .AddJsonOptions(opts => { opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

            
            services.AddMediatR(typeof(Startup).Assembly, typeof(MobileBaseController).Assembly
                , typeof(BackofficeBaseController).Assembly);

            services.AddScoped<IUserRepository, DatabaseUserRepository>();
            services.AddScoped<IBookRepository, DatabaseBookRepository>();
            services.AddScoped<IAuthorRepository, DatabaseAuthorRepository>();
            services.AddScoped<IGenreRepository, DatabaseGenreRepository>();
            services.AddScoped<IRoleRepository, DatabaseRoleRepository>();
            services.AddScoped<IUserBookActionRepository, DatabaseUserBookActionRepository>();
            services.AddScoped<BookburnDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"));
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
