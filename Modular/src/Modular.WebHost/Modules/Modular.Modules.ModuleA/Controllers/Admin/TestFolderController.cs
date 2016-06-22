using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modular.Modules.ModuleA.Controllers.Admin
{
    public class TestFolderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
