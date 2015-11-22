using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Paging.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString Paging(this HtmlHelper html, int totalCount, int listPageCount, int activePage, string url)
        {
            var style = activePage == 1 ? "hide" : string.Empty;

            var sb = new StringBuilder();
            sb.Append("<ul>");

            sb.Append("<li class='" + style + "'><a href='" + string.Format(url, 1) + "'>İlk</a></li>");
            sb.Append("<li class='" + style + "'><a href='" + string.Format(url, activePage == 1 ? 1 : (activePage - 1)) + "'>Önceki</a></li>");

            var pageCount = (int) Math.Ceiling((double) totalCount/(double) listPageCount);
            for (int i = 1; i <= pageCount; i++)
            {
                style = activePage == i ? "active" : string.Empty;
                sb.Append("<li class='" + style + "'><a href='" + string.Format(url, i) + "'>" + i + "</a></li>");
            }

            style = activePage == pageCount ? "hide" : string.Empty;

            sb.Append("<li class='" + style + "'><a href='" + string.Format(url, activePage == pageCount ? pageCount : (activePage + 1)) + "'>Sonraki</a></li>");
            sb.Append("<li class='" + style + "'><a href='" + string.Format(url, pageCount) + "'>Son</a></li>");

            sb.Append("</ul>");
            return html.Raw(sb.ToString());
        }
    }
}