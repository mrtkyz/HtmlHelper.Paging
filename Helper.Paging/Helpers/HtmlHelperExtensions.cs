using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Helper.Paging.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString Paging(this HtmlHelper html, int totalCount, int listPageCount, int activePage, string url)
        {
            var style = activePage == 1 ? "class='hide'" : string.Empty;
            bool pointFlag = false;

            var sb = new StringBuilder();
            sb.Append("<ul>");

            sb.Append("<li " + style + "><a href='" + string.Format(url, 1) + "'>İlk</a></li>");
            sb.Append("<li " + style + "><a href='" + string.Format(url, activePage == 1 ? 1 : (activePage - 1)) + "'>Önceki</a></li>");

            var pageCount = (int)Math.Ceiling((double)totalCount / (double)listPageCount);
            for (int i = 1; i <= pageCount; i++)
            {
                style = activePage == i ? "class='active'" : string.Empty;
                if (i == 1 || i == pageCount)
                {
                    sb.Append("<li " + style + "><a href='" + string.Format(url, i) + "'>" + i + "</a></li>");
                }
                else
                {
                    if (i >= activePage - 2 && i <= activePage + 2)
                    {
                        sb.Append("<li " + style + "><a href='" + string.Format(url, i) + "'>" + i + "</a></li>");
                        pointFlag = false;
                    }
                    else
                    {
                        if(!pointFlag)
                            sb.Append("<li class='point'> ... </li>");
                        pointFlag = true;
                    }
                }
            }

            style = activePage == pageCount ? "class='hide'" : string.Empty;

            sb.Append("<li " + style + "><a href='" + string.Format(url, activePage == pageCount ? pageCount : (activePage + 1)) + "'>Sonraki</a></li>");
            sb.Append("<li " + style + "><a href='" + string.Format(url, pageCount) + "'>Son</a></li>");

            sb.Append("</ul>");
            return html.Raw(sb.ToString());
        }
    }
}