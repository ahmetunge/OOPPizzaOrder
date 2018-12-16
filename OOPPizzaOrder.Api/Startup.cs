using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OOPPizzaOrder.Api.Helpers;
using OOPPizzaOrder.Api.Repository.Abstract;
using OOPPizzaOrder.Api.Repository.Concrete;
using OOPPizzaOrder.Api.Services.Abstract;
using OOPPizzaOrder.Api.Services.Concrete;

namespace OOPPizzaOrder.Api
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
            services.AddScoped<IPizzaTypeRepository, PizzaTypeRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IToppingRepository, ToppingRepository>();
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IPizzaPriceCalculater, PizzaPriceCalculater>();
            services.AddSession();
            services.AddMemoryCache();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseMvc();
        }
    }
}
