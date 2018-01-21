using CustomModule.Indexes;
using CustomModule.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace CustomModule
{
    public class Migrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinition("ProductPart", part => part
                .Attachable());
            
            SchemaBuilder.CreateMapIndexTable(nameof(ProductPartIndex), table => table
                .Column<string>("ContentItemId", c => c.WithLength(26))
                .Column<decimal>(nameof(ProductPart.UnitPrice))
                .Column<string>(nameof(ProductPart.Sku), column => column.WithLength(50))
            );

            SchemaBuilder.AlterTable(nameof(ProductPartIndex), table => table
                .CreateIndex("IDX_ProductPartIndex_ContentItemId", "ContentItemId")
            );

            return 1;
        }
    }
}
