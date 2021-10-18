using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoShop2._0.Config;
using MongoShop2._0.Contexts;
using MongoShop2._0.Data;
using MongoShop2._0.Domain.Entities;
using MongoShop2._0.Domain.Repositories;
using MongoShop2._0.Interfaces;
using MongoShop2._0.Repositories;
using System.Reflection;

namespace MongoShop2._0
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
            services.AddControllers();
            services.Configure<BookstoreDBConfig>(Configuration);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMongoContext, MongoContext>();
            services.AddSingleton<IRepository<Book>, Repository<Book>>();
            services.AddSingleton<IUnitOfWork<Book>, UnitOfWork<Book, IMongoContext>>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MongoShop2._0", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MongoShop2._0 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
