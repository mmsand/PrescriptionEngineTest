﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Intricon.PrescriptionEngine
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }
    }
}
