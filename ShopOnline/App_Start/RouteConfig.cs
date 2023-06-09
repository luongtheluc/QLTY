﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
               name: "Register",
               url: "dang-ky",
               new { controller = "User", action = "Register", id = UrlParameter.Optional },
               namespaces: new[] { "ShopOnline.Controllers" }
           );

            routes.MapRoute(
               name: "Login",
               url: "dang-nhap",
               new { controller = "User", action = "Login", id = UrlParameter.Optional },
               namespaces: new[] { "ShopOnline.Controllers" }
           );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopOnline.Controllers" }
            );           
        }
    }
}
