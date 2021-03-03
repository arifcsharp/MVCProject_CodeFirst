using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcCodeFirst
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            //Custom Routing

            // Enable Attribute Routing
            routes.MapMvcAttributeRoutes();

            // Specific Route - EmployeeController
            routes.MapRoute(
                name: "Route02",
                url: "Employee/{action}/{id}",
                defaults: new { controller = "Employee", action = "Details", id = UrlParameter.Optional }
             );


            // Specific Route - EmployeeController
            routes.MapRoute(
                name: "Route01",
                url: "Employee/{action}",
                defaults: new { controller = "Employee", action = "Index" }
             );


        }
    }
}
