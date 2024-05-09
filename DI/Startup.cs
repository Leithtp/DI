using DI.Services.Counter;
using DI.Services.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using static DI.Services.Logger.ConsoleLogger;

namespace DI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<ITransientLogger, ConsoleLogger>();
            services.AddScoped<IScopedLogger, ConsoleLogger>();
            services.AddSingleton<ISingletonLogger, ConsoleLogger>();

            services.AddSingleton<ICounter, Counter>();

            services.AddSingleton<Func<int, string>>(serviceProvider =>
            {
                var counter = serviceProvider.GetRequiredService<ICounter>();
                return counter.Add;
            });
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
