using Microsoft.AspNetCore.Mvc;
using RINO.Repo.DeviceRepo;

namespace RINO.Controllers.HomeController
{
    public class HomeController : Controller

    {
        private readonly IDevice _device;
        public HomeController(IDevice device)
        {
            _device = device;
        }

        public IActionResult Index()
        {
            var devicesInStock = _device.AllDevices.Where(d => d.Instock==true).ToList();
            return View(devicesInStock);
        }
    }
}
