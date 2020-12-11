using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASPNetCoreMentoringEpam.Helpers
{
    public class NorthwindTagHelper : TagHelper
    {
        public string Id { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("href", $"/images/{Id}");
            output.Content.SetContent("Tag Helper");
        }
    }
}
