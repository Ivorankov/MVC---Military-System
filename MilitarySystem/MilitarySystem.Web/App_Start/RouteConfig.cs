namespace MilitarySystem.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

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

            //routes.MapRoute(
            //    name: "Administration",
            //    url: "Administration/{action}/{id}/{username}",
            //    defaults: new { controller = "Administration", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
                name: "Troops",
                url: "Troops/{action}/{id}/{username}",
                defaults: new { controller = "Troops", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}
