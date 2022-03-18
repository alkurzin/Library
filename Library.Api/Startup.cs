using AutoMapper;
using FluentValidation.AspNetCore;
using Library.Domain.Books.MapperProfiles;
using Library.Domain.Readers.MapperProfiles;
using Library.Domain.Records.MapperProfiles;
using Library.Infrastructure;
using Library.Service.Commands.Books;
using Library.Service.Commands.Books.Validators;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Library.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(AddBookCommand).GetTypeInfo().Assembly);

            services.AddSwaggerGen();

            services.AddDbContext<LibraryDbContext>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BookMapperProfile());
                mc.AddProfile(new ReaderMapperProfile());
                mc.AddProfile(new RecordMapperProfile());

            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddBookCommandValidator>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
