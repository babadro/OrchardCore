using System;
using CustomModule.Models;
using OrchardCore.Data.Migration;

namespace CustomModule
{
    public class Migrations : DataMigration
    {
        public int Create()
        {
            SchemaBuilder.CreateTable(nameof(ProductPart), table => table
                .Column<int>("Id", col => col.PrimaryKey().Identity())
                .Column<decimal>(nameof(ProductPart.UnitPrice))
                .Column<string>(nameof(ProductPart.Sku), column => column.WithLength(50))
            );

            /*
            SchemaBuilder.AlterTable(nameof(IndexingTask), table => table
                .CreateIndex("IDX_IndexingTask_ContentItemId", "ContentItemId")
            );
            */

            return 1;
        }
    }
}
