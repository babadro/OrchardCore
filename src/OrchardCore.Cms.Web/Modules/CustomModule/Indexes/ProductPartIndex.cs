using System;
using System.Collections.Generic;
using System.Text;
using CustomModule.Models;
using OrchardCore.ContentManagement;
using YesSql.Indexes;

namespace CustomModule.Indexes
{
    public class ProductPartIndex : MapIndex 
    {
        public string ContentItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Sku { get; set; }
    }

    public class ProductPartIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context)
        {
            context.For<ProductPartIndex>()
                .Map(contentItem =>
                {
                    var productPart = contentItem.As<ProductPart>();
                    if (productPart != null)
                    {
                        var unitPrice = productPart.UnitPrice;
                        var sku = productPart.Sku;

                        if (!string.IsNullOrEmpty(sku) && unitPrice != 0)
                        {
                            return new ProductPartIndex
                            {
                                ContentItemId = contentItem.ContentItemId,
                                Sku = sku,
                                UnitPrice = unitPrice
                            };
                        }
                    }

                    return null;
                });
        }
    }
}
