using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASPMVCListBoxForOptGroup.Helpers
{
    public static class HtmlExtensions
    {
        public static IHtmlString ListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
            Dictionary<string, IEnumerable<SelectListItem>> selectList, object htmlAttributes = null)
        {
            var select = new TagBuilder("select");
            select.Attributes.Add("name", ExpressionHelper.GetExpressionText(expression));

            if (htmlAttributes != null)
            {
                RouteValueDictionary routeValues = new RouteValueDictionary(htmlAttributes);
                if(!routeValues.ContainsKey(("size").ToLower()))
                {
                    select.Attributes.Add("size", selectList.Sum(x=> x.Value.Count()).ToString());
                }

                foreach (var item in routeValues)
                {
                    select.Attributes.Add(item.Key, item.Value.ToString());
                }
            }
            else
                select.Attributes.Add("size", selectList.Sum(x => x.Value.Count()).ToString());

            var optgroups = new StringBuilder();

            foreach (var kvp in selectList)
            {
                var optgroup = new TagBuilder("optgroup");
                optgroup.Attributes.Add("label", kvp.Key);

                var options = new StringBuilder();

                foreach (var item in kvp.Value)
                {
                    var option = new TagBuilder("option");

                    option.Attributes.Add("value", item.Value);
                    option.SetInnerText(item.Text);

                    if (item.Selected)
                    {
                        option.Attributes.Add("selected", "selected");
                    }

                    options.Append(option.ToString(TagRenderMode.Normal));
                }

                optgroup.InnerHtml = options.ToString();

                optgroups.Append(optgroup.ToString(TagRenderMode.Normal));
            }

            select.InnerHtml = optgroups.ToString();

            return MvcHtmlString.Create(select.ToString(TagRenderMode.Normal));
        }
    }
}