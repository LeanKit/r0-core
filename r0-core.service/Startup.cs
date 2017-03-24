using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using App.Metrics;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;

namespace r0_core.service
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .WriteTo.Console(new CompactJsonFormatter())
                //.WriteTo.LiterateConsole()
                .CreateLogger();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(options => options.AddMetricsResourceFilter());
            services.AddApiVersioning(options =>
            {
                options.ApiVersionReader = new QueryStringOrHeaderApiVersionReader("X-LK-API-VERSION");
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(0, 0);
                options.ReportApiVersions = true;
            });

            services.AddMetrics()
                .AddJsonSerialization()
                .AddHealthChecks()
                .AddMetricsMiddleware(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            loggerFactory.AddSerilog();

            app.UseMetrics();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
