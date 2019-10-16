using Autofac;
using Autofac.Extensions.DependencyInjection;
using Catalyst.Modules.Server.Blazor.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Catalyst.Modules.Server.Blazor
{
    public class BlazorServerModule : Module
    {
        private IHostBuilder _hostBuilder;
        private IHost _host;
        private IContainer _container;
        private ContainerBuilder _builder;

        protected override void Load(ContainerBuilder builder)
        {
            _builder = builder;
            _hostBuilder = CreateHostBuilder();
            _host = _hostBuilder.Build();
            builder.RegisterBuildCallback(Start);

        }

        private void Start(IContainer container)
        {
            _container = container;
            _ = _host.RunAsync();
        }

        public IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder(null)
                .ConfigureServices(ConfigureServices)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.Configure(Configure);
                });

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.ApplicationServices = new AutofacServiceProvider(_container);
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            _builder.Populate(services);
        }
    }
}
