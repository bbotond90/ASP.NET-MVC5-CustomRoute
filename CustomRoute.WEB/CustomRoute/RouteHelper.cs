using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace CustomRoute
{
    static class RouteHelper
    {
        /// <summary>
        /// Case insensitive lookup for a view in a specific folder.
        /// </summary>
        /// <param name="values">IRouteConstraint's RouteValueDictionary</param>
        /// <param name="valueKey">Case insensitive name of the .cshtml view passed from the route</param>
        /// <param name="path">Container folder path like: "~/Views/StaticPages"</param>
        /// <returns></returns>
        public static bool IsDestinationViewExists(RouteValueDictionary values, string valueKey, string path)
        {
            //we have to make sure that we have a view name specified to look for
            if (values[valueKey] == null) return false;

            //get all .cshtml file in the specified path
            List<string> destinationViewList = Directory.GetFiles(
                System.Web.Hosting.HostingEnvironment.MapPath(path), "*.cshtml")
                .ToList();

            foreach (string destinationPath in destinationViewList)
            {
                FileInfo destinationInfo = new FileInfo(destinationPath);
                //remove the extension ".cshtml" from the view name
                string destination = destinationInfo.Name
                                        .Replace(destinationInfo.Extension, "");

                //case insensitive match
                //if the file name matches the requested valueKey/view it returns true
                if (destination.ToLower() == values[valueKey].ToString().ToLower())
                    return true;
            }

            //if we couldn't find a matching view
            return false;
        }
    }
}
