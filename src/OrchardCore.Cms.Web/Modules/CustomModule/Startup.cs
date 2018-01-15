using CustomModule.Drivers;
using CustomModule.Models;
using Fluid;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace CustomModule
{
    public class Startup : StartupBase
    {
        static Startup()
        {
            TemplateContext.GlobalMemberAccessStrategy.Register<ProductPart>();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IContentPartDisplayDriver, ProductPartDisplayDriver>();
            services.AddSingleton<ContentPart, ProductPart>();
            services.AddScoped<IDataMigration, Migrations>();
        }
    }
}