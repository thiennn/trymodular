using ExtraDepenencyTest;
using Microsoft.AspNetCore.Mvc;
using Modular.Core.Domain;
using Modular.Modules.ModuleA.Models;
using Modular.Modules.ModuleA.Services;
using Modular.Modules.ModuleA.ViewModels;
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
        private IRepository<Sample> _sampleRepository;

        public TestAController(ITestService testService, IAnotherTestService anotherTestService, IRepository<Sample> sampleRepository)
        {
            _testService = testService;
            _anotherTestService = anotherTestService;
            _sampleRepository = sampleRepository;
        }

        public IActionResult Index()
        {
            ViewBag.TestData = _testService.Test();
            ViewBag.AnotherTestData = _anotherTestService.Test();

            var sample = new Sample { Name = "Name test", Description = "Decription Test" };
            _sampleRepository.Add(sample);
            _sampleRepository.SaveChange();

            var model = new TestViewModel { Name = sample.Name, Description = sample.Description };

            return View(model);
        }
    }
}
