using EventDrivenArchitecture.SSE.SSE;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventDrivenArchitecture.SSE
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
               options.AddPolicy("customPolicy",
                    builder => builder.WithOrigins("http://localhost:4200"));
            });

            services.AddSingleton<SseService>();
            services.AddSingleton<ISseSendService>(factory => factory.GetService<SseService>());
            services.AddSingleton<ISseClentService>(factory => factory.GetService<SseService>());


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("customPolicy");

            app.Map("/sse", branchedApp => branchedApp.UseMiddleware<SseMiddleware>());
            app.UseMvc();
        }
    }
}
