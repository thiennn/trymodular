using ExtraDepenencyTest;
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
        private IAnotherTestService _anotherTestService;

        public TestAController(ITestService testService, IAnotherTestService anotherTestService)
        {
            _testService = testService;
            _anotherTestService = anotherTestService;
        }

        public IActionResult Index()
        {
            ViewBag.TestData = _testService.Test();
            ViewBag.AnotherTestData = _anotherTestService.Test();
            return View();
        }
    }
}
