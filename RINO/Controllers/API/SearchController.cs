using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RINO.Models;
using RINO.Repo.DeviceRepo;

namespace RINO.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IDevice _device;
        public SearchController(IDevice device) {
            _device = device;
        }

        [HttpGet]
        public IActionResult GetAll() { 
        
            var allDevices=_device.AllDevices;
            return Ok(allDevices);
        
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id) { 
            
            var device=_device.GetDeviceById(id);
            if(device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }

        [HttpPost]
        public IActionResult Search([FromBody]string q) {
            IEnumerable<Device> devices=new List<Device>();
            if (!string.IsNullOrEmpty(q))
            {
                devices=_device.SearchDevice(q);
            }
            return new JsonResult(devices);
        
        }
    }
}
