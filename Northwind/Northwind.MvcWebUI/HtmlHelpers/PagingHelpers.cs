using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Northwind.MvcWebUI;
using Northwind.MvcWebUI.Models;


namespace Northwind.MvcWebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
       public static MvcHtmlString Pager(this HtmlHelper html, PagingInfo pagingInfo)
        {
            int totalPage = (int)Math.Ceiling((decimal)pagingInfo.TotalItems / pagingInfo.ItemsPerPage); //Sayfa sayısını buluyoruz
            var stringBluider = new StringBuilder();

            for (int i = 1; i < totalPage; i++)
            {
                var tagBluider = new TagBuilder("a");
                tagBluider.MergeAttribute("href", String.Format("/Product/Index/?page={0}", i,pagingInfo.CurrentCategory));
                tagBluider.InnerHtml = i.ToString();
                if (pagingInfo.CurrentPage == i)
                {
                    tagBluider.AddCssClass("selected");
                }
                stringBluider.Append(tagBluider);
            }

            return MvcHtmlString.Create(stringBluider.ToString());

        }
    }
}