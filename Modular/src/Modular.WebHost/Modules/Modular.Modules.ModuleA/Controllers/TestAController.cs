using Microsoft.AspNetCore.Mvc;
using Modular.Modules.ModuleA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modular.Modules.ModuleA.Controllers
{
    public class TestAController : Controller
    {
        private ITestService _testService;

        public TestAController(ITestService testService)
        {
            _testService = testService;
        }

        public IActionResult Index()
        {
            ViewBag.TestData = _testService.Test();
            return View();
        }
    }
}
