using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RINO.Models;
using RINO.Repo.DeviceRepo;

namespace RINO.Pages
{
    public class InStockModel : PageModel
    {
        private readonly IDevice _device;
        public List<Device> Items { get; set; }
        public InStockModel(IDevice device)
        {
              Items = new List<Device>();
            _device = device;
        }
        public IActionResult OnGet()
        {
            var items = _device.AllDevices.Where(d => d.Instock == true).ToList();
            if (items.Count == 0)
            {
                ModelState.AddModelError("", "Stock Is Empty");
            }
            if (items.Any())

            {
                Items = items;
                
            }
            return Page();
        }

        public IActionResult OnPost()
        {

            var items = _device.AllDevices.Where(d => d.Instock == true).ToList();
            if (items.Count == 0)
            {
                ModelState.AddModelError("", "Stock Is Empty");
            }
            if (items.Any())

            {
                Items = items;
              
            }
            return Page();
        }
    }
}
