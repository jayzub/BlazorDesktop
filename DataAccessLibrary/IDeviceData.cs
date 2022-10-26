using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface IDeviceData
    {
        Task<List<DeviceModel>> GetDevices();
        Task InsertDevice(DeviceModel device);
    }
}