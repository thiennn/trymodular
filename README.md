# Modular Web Application with ASP.NET Core
I am looking for a solution to modularize my simple commerce https://github.com/simplcommerce/SimplCommerce. I have researched for a few days. Some instructions have been found for example:

* https://github.com/aspnet/Mvc/issues/4572
* https://github.com/ExtCore/ExtCore
* http://shazwazza.com/post/custom-assembly-loading-with-aspnet-core/
* https://github.com/OrchardCMS/Orchard2

Some of them are not yet completed or too complicated for me. Struggling for a while, finally I can make it work. To be honest, I not sure this is best solution and I am looking for comments

There are few things we need to address to make our application modularized:

1.	How can MVC find out our controllers when they are in other class libraries and in other folder
2.	How can the ViewEngine pick up the right location for the Views
3.	How to register services used in modules
4.	How to serve static file: js, css, image for modules

Below is general folder structure I have come up with

![](https://github.com/thiennn/trymodular/blob/master/folder-structure.png)

The Modular.WebHost is the hosting project. It will bootstrap the app and load all the modules it found in Modules folder. Each module contains all the stuff for itself to run including Controllers, Services, Views and event static file.
For easy development, in the visual studio solution I create a Modules solution items and add module projects in Modular.WebHost/Modules phycial folder.
To prevent Modular.WebHost to compile stuff in Modules folder, we need to exclude them in the project.json.

In the Startup.cs, we scan all the *.dll in each module and load them ups

```cs
    var moduleRootFolder = _hostingEnvironment.ContentRootFileProvider.GetDirectoryContents("/Modules");
    var moduleAssemblies = new List<Assembly>();
    foreach(var moduleFolder in moduleRootFolder.Where(x => x.IsDirectory))
    {
        modules.Add(new ModuleInfo { Name = moduleFolder.Name, Path = moduleFolder.PhysicalPath });

        var binFolder = new DirectoryInfo(Path.Combine(moduleFolder.PhysicalPath, "bin"));
        if (!binFolder.Exists)
        {
            continue;
        }

        foreach(var file in binFolder.GetFileSystemInfos("*.dll", SearchOption.AllDirectories))
        {
            // If the assemblies are referenced by the Host, then this will throw exception
            try
            {
                moduleAssemblies.Add(AssemblyLoadContext.Default.LoadFromAssemblyPath(file.FullName));
            }
            catch { }
        }
    }
```

1. Assemblies then will be added to MVC by ApplicationPart

```cs
          var mvcBuilder = services.AddMvc();
          foreach(var assembly in moduleAssemblies)
          {
              // Register controller from modules
              mvcBuilder.AddApplicationPart(assembly);
          }
```

2. ModuleViewLocationExpander is used to help the view engine lookup up the right module folder the views

```cs
         services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new ModuleViewLocationExpander());
            });
```
            
3. Each module contains an ModuleInitializer.cs where services for that module is registered.

```cs
     // Register dependency in modules
      var moduleInitializerType = assembly.GetTypes().Where(x => typeof(IModuleInitializer).IsAssignableFrom(x)).FirstOrDefault();
      if(moduleInitializerType != null)
      {
          var moduleInitializer = (IModuleInitializer)Activator.CreateInstance(moduleInitializerType);
          moduleInitializer.Init(services);
      }
```

4. And this is how I serve static files for modules

```cs
      // Serving static file for modules
      foreach(var module in modules)
      {
          var wwwrootDir = new DirectoryInfo(Path.Combine(module.Path, "wwwroot"));
          if (!wwwrootDir.Exists)
          {
              continue;
          }

          app.UseStaticFiles(new StaticFileOptions()
          {
              FileProvider = new PhysicalFileProvider(wwwrootDir.FullName),
              RequestPath = new PathString("/"+ module.SortName)
          });
      }
```
