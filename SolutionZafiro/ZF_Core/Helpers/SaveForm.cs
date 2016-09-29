using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace ZF_Core.Helper
{
     public static class SaveForm
    {
        public static MvcForm BeginSecureForm(this HtmlHelper htmlHelper,
string actionName, string controllerName)
        {
            TagBuilder tagBuilder = new TagBuilder("form");

            tagBuilder.MergeAttribute("action",
            UrlHelper.GenerateUrl(null, actionName, controllerName, new RouteValueDictionary(),
            htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, true));
            tagBuilder.MergeAttribute("method", "POST", true);

            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
            htmlHelper.ViewContext.Writer.Write(htmlHelper.AntiForgeryToken().ToHtmlString());
            var theForm = new MvcForm(htmlHelper.ViewContext);

            return theForm;
        }
    }
}