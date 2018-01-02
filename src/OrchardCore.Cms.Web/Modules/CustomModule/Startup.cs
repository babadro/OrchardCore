using CustomModule.Models;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace CustomModule
{
    public class Startup : StartupBase
    {
        static Startup()
        {

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ContentPart, ProductPart>();
            services.AddScoped<IDataMigration, Migrations>();
        }
    }
}