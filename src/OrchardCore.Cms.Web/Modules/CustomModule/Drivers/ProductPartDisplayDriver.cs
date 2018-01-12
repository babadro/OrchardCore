using System.Threading.Tasks;
using CustomModule.Models;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;

namespace CustomModule.Drivers
{
    public class ProductPartDisplayDriver : ContentPartDisplayDriver<ProductPart>
    {
        protected new string Prefix => "Product";

        public override IDisplayResult Edit(ProductPart part)
        {
            return Shape("ProductPart_Edit", part).Location("Content:1");
        }

        public override async Task<IDisplayResult> UpdateAsync(ProductPart model, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(model, Prefix);
            return Edit(model);
        }
        /*
        public override IDisplayResult Display(TitlePart titlePart)
        {
            return Shape<TitlePartViewModel>("TitlePart", model =>
            {
                model.Title = titlePart.Title;
                model.TitlePart = titlePart;
            })
            .Location("Detail", "Header:5")
            .Location("Summary", "Header:5");
        }

        public override IDisplayResult Edit(TitlePart titlePart)
        {
            return Shape<TitlePartViewModel>("TitlePart_Edit", model =>
            {
                model.Title = titlePart.Title;
                model.TitlePart = titlePart;

                return Task.CompletedTask;
            });
        }

        public override async Task<IDisplayResult> UpdateAsync(TitlePart model, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(model, Prefix, t => t.Title);

            return Edit(model);
        }
         */
    }
}
