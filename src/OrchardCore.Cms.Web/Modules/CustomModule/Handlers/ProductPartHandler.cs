using System;
using System.Collections.Generic;
using System.Text;
using CustomModule.Models;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Handlers;

namespace CustomModule.Handlers
{
    public class ProductPartHandler : ContentPartHandler<ProductPart>
    {
        public override void GetContentItemAspect(ContentItemAspectContext context, ProductPart part)
        {
            context.For<ContentItemMetadata>(ContentItemMetadata =>
            {
                ContentItemMetadata.DisplayText = part.Sku;
            });
        }
    }
}
