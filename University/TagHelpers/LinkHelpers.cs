using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.TagHelpers
{
    [HtmlTargetElement("links")]
    public class LinkHelpers : TagHelper
    {
        public int Key { get; set; }
        public string Controller { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent(
               $@"<a asp-action =""Edit""  href=""../{Controller}/Edit/{Key}"">Edit</a> |
                <a asp-action =""Details"" href=""../{Controller}/Details/{Key}"">Details</a> |
                <a asp-action =""Delete""  href=""../{Controller}/Delete/{Key}"">Delete</a> "
                );
        }
    }
}
