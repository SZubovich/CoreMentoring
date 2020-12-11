using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Text;

namespace ASPNetCoreMentoringEpam.Components
{
    public class BreadcrumbsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return GenerateContent(Request.Path);
        }

        private HtmlContentViewComponentResult GenerateContent(PathString pathString)
        {
            var entries = Request.Path.Value.Split('/');
            StringBuilder html = new StringBuilder();
            StringBuilder address = new StringBuilder();

            foreach (var item in entries)
            {
                address.Append(item + "/");

                var linkName = item;
                switch (item)
                {
                    case "": linkName = "Home";
                        break;
                    case "Category":
                        linkName = "Categories";
                        break;
                    case "Product":
                        linkName = "Products";
                        break;
                    case "Create":
                        linkName = "Create New";
                        break;
                    default: linkName = "Edit";
                        break;
                }

                html.Append($"<a href=\"{address}\">{linkName}</a> >");
            }

            return new HtmlContentViewComponentResult(new HtmlString(html.ToString()));
        }
    }
}
