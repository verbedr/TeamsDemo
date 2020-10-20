using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System.Linq;
using TeamsDemo.Server.Plugins;

namespace TeamsDemo.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TeamsDemoOption>(Configuration.GetSection("TeamsDemo"));

            services.AddScoped(provider =>
            {
                var options = provider.GetService<IOptions<TeamsDemoOption>>();
                return new ClientCredentialProvider(ConfidentialClientApplicationBuilder
                    // AzureAD configuration has no notion of audience so we need to get the real ClientId
                    .Create(options.Value.ClientId)
                    .WithTenantId(options.Value.TenantId)
                    .WithClientSecret(options.Value.ClientSecret)
                    .Build());
            });
            // some scopes require consent then connect with this url
            // https://login.microsoftonline.com/fb21b6c4-5b26-4a17-84ed-d570f529d201/oauth2/v2.0/authorize?response_type=token&client_id=api%3A%2F%2F1a8a2073-761f-443f-8481-22e9c8869574&redirect_uri=https%3A%2F%2Flocalhost%3A44335%2Fswagger%2Fsignin-oidc&state=justastate&scope=chat.read
            // do not forget to change the scope to the permission that requires consent
            services.AddScoped(provider =>
            {
                var options = provider.GetService<IOptions<TeamsDemoOption>>();
                return new UsernamePasswordProvider(PublicClientApplicationBuilder
                    .Create(options.Value.ClientId)
                    .WithTenantId(options.Value.TenantId)
                    .Build(), new[] { "user.read", "onlinemeetings.readwrite", "chat.read" });
            });

            services.AddScoped<GraphClientAgent>();
            services.AddScoped<GraphUserAgent>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSignalR();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Use(async (context, next) =>
            //{
            //    context.Request.EnableBuffering();
            //    await next();
            //});
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHub<SubscriptionHub>("/hubs/subscription");
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
