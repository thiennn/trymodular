using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modular.WebHost.Extensions
{
    public class ModuleViewLocationExpander : IViewLocationExpander
    {
        private const string _moduleKey = "module";

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context.Values.ContainsKey(_moduleKey))
            {
                var module = context.Values[_moduleKey];
                if (!string.IsNullOrWhiteSpace(module))
                {
                    var moduleViewLocations = new string[]
                    {
                    "/Modules/Modular." + module + "/Views/{1}/{0}.cshtml",
                    "/Modules/Modular." + module + "/Views/Shared/{0}.cshtml"
                    };

                    viewLocations = moduleViewLocations.Concat(viewLocations);
                }
            }
            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            var controller = context.ActionContext.ActionDescriptor.DisplayName;
            var moduleName = controller.Split('.')[1];
            if(moduleName != "WebHost")
            {
                context.Values[_moduleKey] = moduleName;
            }
        }
    }
}
