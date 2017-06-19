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
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="valueKey"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsDestinationViewExists(RouteValueDictionary values, string valueKey, string path)
        {
            if (values[valueKey] == null) return false;

            List<string> destinationViewList = Directory.GetFiles(
                System.Web.Hosting.HostingEnvironment.MapPath(path), "*.cshtml")
                .ToList();

            foreach (string destinationPath in destinationViewList)
            {
                FileInfo destinationInfo = new FileInfo(destinationPath);
                string destination = destinationInfo.Name
                                        .Replace(destinationInfo.Extension, "");
                if (destination.ToLower() == values[valueKey].ToString().ToLower())
                    return true;
            }

            return false;
        }
    }
}
