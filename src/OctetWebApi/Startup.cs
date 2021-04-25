using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OctetWebApi.Common.Interfaces;
using OctetWebApi.Data;
using OctetWebApi.ExternalApi;
using OctetWebApi.ExternalApi.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace OctetWebApi
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OctetWebApi", Version = "v1" });
            });

            services.AddRefitClient<IThirdPartyCurrencyExchangeApi>()
                .ConfigureHttpClient(client => {
                    client.BaseAddress = new Uri(Configuration["ThirdPartyCurrencyExchangeApi:BaseAddress"]);
                });

            services.AddSingleton<ThirdPartyCurrencyExchangeApplication>();
            services.AddSingleton<IThirdPartyCurrencyExchangeService, ThirdPartyCurrencyExchangeService>();

            var context = services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(@"Data Source=.;Initial Catalog=Octet;Integrated Security=True;"));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OctetWebApi v1"));
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
