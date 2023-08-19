using RINO.Models;

namespace RINO.ViewModels
{
    public class DeviceViewModel
    {
        public IEnumerable<Device> Devices { get;}
        public string Currencategory { get; }
        public DeviceViewModel(IEnumerable<Device> devices, string? currencategory)
        {
            Devices = devices;
            Currencategory = currencategory;
        }
    }
}
