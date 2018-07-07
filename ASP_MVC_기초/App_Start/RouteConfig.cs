using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using ASP_MVC_기초.Models;

namespace ASP_MVC_기초
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            CInstance.Initailize();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
