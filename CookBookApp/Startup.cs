using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.Validators.Product;
using CookBookApp.ApplicationServices.Components.PasswordHasher;
using CookBookApp.ApplicationServices.Mappings;
using CookBookApp.Authentication;
using CookBookApp.DataAccess;
using CookBookApp.DataAccess.CQRS;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CookBookApp
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddMvcCore()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddProductRequestValidator>());

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddTransient<ICommandExecutor, CommandExecutor>();
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<IPasswordHasher, PasswordHasher>();

            services.AddAutoMapper(typeof(ProductsProfile).Assembly);

            services.AddMediatR(typeof(ResponseBase<>));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<CookBookAppContext>(
                opt => opt.UseSqlServer(this.Configuration.GetConnectionString("CookBookAppDatabaseConnection")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CookBookApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CookBookApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
