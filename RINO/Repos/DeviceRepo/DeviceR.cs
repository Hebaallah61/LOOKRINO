using Microsoft.EntityFrameworkCore;
using RINO.Context;
using RINO.Models;
using RINO.Repo.CategoryRepo;

namespace RINO.Repo.DeviceRepo
{
    public class DeviceR:IDevice
    {
        private readonly RinoDbContext _rinoDbContext;
        
        public DeviceR(RinoDbContext rinoDbContext)
        {
            _rinoDbContext = rinoDbContext;
        }


       public IEnumerable<Device> AllDevices
        {
            get{
                return _rinoDbContext.Devices.Include(c=>c.Category);
            }
        }

        public Device GetDeviceById(int id)
        {
            return _rinoDbContext.Devices.FirstOrDefault(d=>d.DeviceId==id);
        }


        public IEnumerable<Device> SearchDevice(string querysearch)
        {
            var filteredDevices = _rinoDbContext.Devices.Where(d => d.Name.Contains(querysearch));

            if (filteredDevices.Any())
            {
                return filteredDevices;
            }
            else
            {
                return Enumerable.Empty<Device>(); 
            }
        }
    }
}
