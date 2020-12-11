using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;

namespace ASPNetCoreMentoringEpam.Helpers
{
    public static class NorthwindImageHelper
    {
        public static HtmlString NorthwindImageLink(this IHtmlHelper html, int id, string linkText)
        {
            TagBuilder a = new TagBuilder("a");
            a.Attributes.Add("href", $"/images/{id}");
            a.InnerHtml.AppendHtml(linkText);

            var writer = new System.IO.StringWriter();
            a.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
