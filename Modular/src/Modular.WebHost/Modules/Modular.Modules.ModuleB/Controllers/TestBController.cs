using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modular.Modules.ModuleB.Controllers
{
    public class TestBController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
