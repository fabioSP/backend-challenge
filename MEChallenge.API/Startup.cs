using FluentValidation;
using MEChallenge.Application.Core;
using MEChallenge.Application.Domain.Interfaces;
using MEChallenge.Application.Domain.Models;
using MEChallenge.Application.Persistence;
using MEChallenge.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace MEChallenge.API
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
            AddApplicationServices(services);
            services.AddControllers();
            services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase(databaseName: "inMemory"));
            services.AddScoped<Context>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo()
                    {
                        Title = "API ME",
                        Description = "API Challenge ME",
                        Version = "0.0.1"
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API ME V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            AddMediatr(services);
        }

        private static void AddMediatr(IServiceCollection services)
        {
            const string applicationAssemblyName = "MEChallenge.Application";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            services.AddMediatR(assembly);
        }
    }
}
