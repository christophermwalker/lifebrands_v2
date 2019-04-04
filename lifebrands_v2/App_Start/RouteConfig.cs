using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace lifebrands_v2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
           routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Products",
                url: "Products/Products/{id}",
                defaults: new { controller = "Products", action = "GetProducts" }
            );
           
          
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
