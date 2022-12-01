using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class DeviceData : IDeviceData
    {
        private readonly ISqlDataAccess _db;

        public DeviceData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<DeviceModel>> GetDevices()
        {
            string sql = "select * from dbo.Devices";

            return _db.LoadData<DeviceModel, dynamic>(sql, new { });
        }

        public Task InsertDevice(DeviceModel device)
        {
            string sql = @"insert into dbo.Devices (SerialNumber, Name, Status, LastTested)
                           values (@SerialNumber, @Name, @Status, @LastTested);";
            return _db.SaveData(sql, device);
        }
    }
}
