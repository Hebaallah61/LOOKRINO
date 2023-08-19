using Microsoft.AspNetCore.Mvc;
using RINO.Models;
using RINO.Repo.CategoryRepo;
using RINO.Repo.DeviceRepo;
using RINO.ViewModels;

namespace RINO.Controllers.DeviceCont
{
    public class DeviceController : Controller
    {
        private readonly ICategory _category;
        private readonly IDevice _device;
        public DeviceController(ICategory category, IDevice device)
        {
            _category = category;
            _device = device;
        }
        //public IActionResult DeviceList()
        //{
        //    ViewBag.Device = "okauuuuuuuuuuu";

        //    return View(_device.AllDevices.ToList());
        //}


        public IActionResult DeviceList(string category)
        {
            IEnumerable<Device> device;
            string? currentcat;
            if(string.IsNullOrEmpty(category)) { 
                device=_device.AllDevices.OrderBy(d=>d.DeviceId);
                currentcat = "All Devices";
            
            }
            else
            {
                device=_device.AllDevices.Where(d => d.Category.CategoryName == category).OrderBy(d=>d.DeviceId);
                currentcat=_category.Allcategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;

            }

            return View(new DeviceViewModel(device,currentcat));
        }

        public IActionResult Details(int id)
        {
            var Device = _device.GetDeviceById(id);
            if (Device == null) { return NotFound(); }
            return View(Device);
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
