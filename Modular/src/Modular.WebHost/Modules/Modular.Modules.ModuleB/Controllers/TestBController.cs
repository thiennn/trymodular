using Microsoft.AspNetCore.Mvc;
using Modular.Core.Domain;
using Modular.Modules.ModuleB.Models;

namespace Modular.Modules.ModuleB.Controllers
{
    public class TestBController : Controller
    {
        private IRepository<Sample> _sampleRepository;

        public TestBController(IRepository<Sample> sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public IActionResult Index()
        {
            var sample = new Sample { Name = "Text" };
            _sampleRepository.Add(sample);
            _sampleRepository.SaveChange();
            return View();
        }
    }
}
