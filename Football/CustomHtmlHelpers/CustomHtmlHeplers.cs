using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Football.CustomHtmlHelpers
{
    public static  class CustomHtmlHeplers
    {
 
     
            public static IHtmlString Image(this HtmlHelper helper, string src, string alt)
            {
                // Build <img> tag
                TagBuilder tb = new TagBuilder("img");
               
                tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
                tb.Attributes.Add("alt", alt);
                // return MvcHtmlString. This class implements IHtmlString
                // interface. IHtmlStrings will not be html encoded.
                return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
            }
        
    }
}
