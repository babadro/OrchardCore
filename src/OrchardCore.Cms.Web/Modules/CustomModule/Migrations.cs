using System;
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
            SchemaBuilder.CreateTable(nameof(ProductPart), table => table
                .Column<int>("Id", col => col.PrimaryKey().Identity())
                .Column<decimal>(nameof(ProductPart.UnitPrice))
                .Column<string>(nameof(ProductPart.Sku), column => column.WithLength(50))
            );


            //SchemaBuilder.AlterTable(nameof(IndexingTask), table => table
            //    .CreateIndex("IDX_IndexingTask_ContentItemId", "ContentItemId")
            //);


            return 1;
        }

        public int UpdateFrom1()
        {
            // Create (or alter) a part called "ProductPart" and configure it to be "attachable".
            _contentDefinitionManager.AlterPartDefinition("ProductPart", part => part
                .Attachable());

            return 2;
        }
    }
}
