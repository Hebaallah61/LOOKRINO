using RINO.Models;

namespace RINO.Repo.DeviceRepo
{
    public interface IDevice
    {
        IEnumerable<Device> AllDevices { get; }
        Device? GetDeviceById(int id);
        IEnumerable<Device> SearchDevice(string querysearch);

    }
}
