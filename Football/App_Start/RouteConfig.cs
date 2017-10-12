using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Football
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Team1", action = "Index" }
            );
            routes.MapRoute(
              name: "Player",
              url: "{controller}/{action}/{searchBy}/{search}",
              defaults: new { controller = "Player", action = "Index", searchBy = "Name", search="" }
          );
        }
    }
}
