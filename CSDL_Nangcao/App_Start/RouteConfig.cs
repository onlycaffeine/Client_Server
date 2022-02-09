using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CSDL_Nangcao
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
              name: "Cart",
              url: "gio-hang",
              defaults: new { controller = "Nhaptuncc", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "CSDL_Nangcao.Controllers" }
            );

            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan",
                defaults: new { controller = "Nhaptuncc", action = "Payment", id = UrlParameter.Optional },
               namespaces: new[] { "CSDL_Nangcao.Controllers" }
            );

            routes.MapRoute(
               name: "Add Cart",
               url: "them-gio-hang",
               defaults: new { controller = "Nhaptuncc", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new[] { "CSDL_Nangcao.Controllers" }
           );


            routes.MapRoute(
               name: "Payment Success",
               url: "hoan-thanh",
               defaults: new { controller = "Nhaptuncc", action = "Success", id = UrlParameter.Optional },
              namespaces: new[] { "CSDL_Nangcao.Controllers" }
            );

            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "CSDL_Nangcao.Controllers" }
            );
        }
    }
}
