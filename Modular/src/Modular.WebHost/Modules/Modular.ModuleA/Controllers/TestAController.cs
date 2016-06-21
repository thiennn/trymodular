using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modular.ModuleA.Controllers
{
    public class TestAController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
