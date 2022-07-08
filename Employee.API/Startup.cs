using Application.Handlers;
using Core.Repositories;
using Core.Repositories.Base;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Employee.API
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

            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employee.API", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(CreateEmployeeHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee.API v1"));
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
