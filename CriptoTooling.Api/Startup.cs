using CriptoTooling.Api.Interfaces;
using CriptoTooling.Api.Services;
using CriptoTooling.Api.Services.Clients;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace CriptoTooling.Api
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
            services.AddTransient<ITrackerService, TrackerService>();

            services.AddControllers();

            services.AddHttpClient<CoinStatClient>(client =>
                client.BaseAddress = new Uri(Configuration.GetValue<string>("Coinstat")));

            services.AddHttpClient<CoinMarketCapClient>(client =>
            {
                client.BaseAddress = new Uri(Configuration.GetValue<string>("CoinMarketCap"));
                client.DefaultRequestHeaders.Add("CMC_PRO_API_KEY", "ab44c081-2555-4c67-962d-2169b4ccc7d9");
                client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.71 Safari/537.36");
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CriptoTooling.Api", Version = "v1" });
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CriptoTooling.Api v1");
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.EnableFilter();
                //c.UseRequestInterceptor("(request) => { return requestInterceptor(request); }");
                //c.UseResponseInterceptor("(response) => { return responseInterceptor(response); }");
            });

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
