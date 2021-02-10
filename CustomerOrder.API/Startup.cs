using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerOrder.Core.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
 
using CustomerOrder.Core.Interface.Base;
using CustomerOrder.Infrastructure.Base;
using CustomerOrder.Core.Helpers;
using CustomerOrder.Core.Services;

namespace CustomerOrder.API
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
            services.AddDbContext<BaseDbContext>(options =>
          options.UseSqlServer(
      Configuration.GetConnectionString("DefaultConnection"),
      sqlServerOptions => sqlServerOptions.CommandTimeout(32767)));

            AddScopService(services);
       
            AddSingletonService(services);
        
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen();
          
        }

        private void AddSingletonService(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
         
        }

       

        private void AddScopService(IServiceCollection services)
        {
          
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped(typeof(IBaseGenericRepository<,,>), typeof(BaseGenericRepository<,,>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerOrdersRepository, CustomerOrdersRepository>();
            services.AddScoped<ICustomerOrderDetailRepository, CustomerOrderDetailRepository>();

            services.AddScoped<CustomerService>();
            services.AddScoped<CustomerOrderService>();
            services.AddScoped<CustomerOrderDetailService>();
            services.AddScoped<ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            ServiceGetter.SetAccessor(httpContextAccessor);
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();

        
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
 


        }
    }
}
