using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Identity.Client;

namespace pokenae_WebApp.Components
{
    [HtmlTargetElement("pokenaeitem")]
    public class PokenaeItem : TagHelper
    {
        public string Href { get; set; }
        public string ImageSrc { get; set; }
        public string ImageAlt { get; set; }
        public string Tag { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Date { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "pokenaeitem");
            output.Content.SetHtmlContent($@"
                <li class=""pokenae_items_block"">
                               
                    <span class=""new-label""></span>
                                        
                    <a href=""{Href}"" class=""pokenae_items_link"">
                        <div class=""pokenae_items_img"">
                            <img src=""{ImageSrc}"" alt=""{ImageAlt}"">
                        </div>
                        <div class=""pokenae_items_contents"">
                                <span class=""pokenae_items_tag"">{Tag}</span>
                                <div class=""pokenae_items_title"">{Title}</div>
                                <div class=""pokenae_items_summary"">{Summary}</div>
                                <span class=""pokenae_items_date"">{Date}</span>

                        </div>
                    </a>
                </li>
            ");
        }
    }
}
