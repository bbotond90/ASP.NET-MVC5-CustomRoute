using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace CustomRoute
{
    /**
     * 
     * <example>
     *  // In RouteConfig.cs
        routes.MapRoute(
            name: "StaticPages",
            url: "content/{staticPageName}",
            defaults: new { action = "Index", controller = "StaticPages" },
            constraints: new { isStaticPlace = new StaticPagesConstraint() }
        );
     * </example>
     */

    public class StaticPagesConstraint : IRouteConstraint
    {
        public bool Match
            (
                HttpContextBase httpContext,
                Route route,
                string parameterName,
                RouteValueDictionary values,
                RouteDirection routeDirection
            )
        {

            return RouteHelper.IsDestinationViewExists(values, "staticPageName", "~/Views/StaticPages");

        }
    }
}
