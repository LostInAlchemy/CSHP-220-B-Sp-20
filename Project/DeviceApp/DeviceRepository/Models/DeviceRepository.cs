using AutoMapper;
using DeviceDB;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DeviceModel
    {
        public byte DeviceInventoryId { get; set; }
        public string DeviceMfgname { get; set; }
        public string DevicePartNumber { get; set; }
        public string DeviceSerialNumber { get; set; }
        public string DeviceDeviceName { get; set; }
        public string DeviceType { get; set; }
        public string DevicePowerType { get; set; }
        public string DeviceAttributes { get; set; }
        public string DeviceProtocol { get; set; }
        public decimal? DeviceCost { get; set; }
        public string DeviceMfgdesc { get; set; }
        public string DeviceStatus { get; set; }
        public string DeviceControlledBy { get; set; }
        public string DeviceLocation { get; set; }
        public System.DateTime DeviceAddedDate { get; set; }
    }

    public class DeviceRepository
    {
        private static MapperConfiguration mapperConfiguration = new MapperConfiguration(t => t.CreateMap<DeviceRepository, DeviceModel>().ReverseMap());

        private static IMapper mapper = mapperConfiguration.CreateMapper();

        public DeviceModel Add(DeviceModel deviceModel)
        {
            var deviceDb = ToDbModel(deviceModel);

            DatabaseManager.Instance.DeviceInventory.Add(deviceDb);
            DatabaseManager.Instance.SaveChanges();

            deviceModel = mapper.Map<DeviceModel>(this);

            return deviceModel;
        }

        public List<DeviceModel> GetAll()
        {
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.DeviceInventory
              .Select(t => new DeviceModel
              {
                  DeviceInventoryId     = t.DeviceInventoryId,
                  DevicePartNumber      = t.DevicePartNumber,
                  DeviceSerialNumber    = t.DeviceSerialNumber,
                  DeviceMfgname         = t.DeviceMfgname,
                  DeviceDeviceName      = t.DeviceDeviceName,
                  DeviceType            = t.DeviceType,
                  DevicePowerType       = t.DevicePowerType,
                  DeviceAttributes      = t.DeviceAttributes,
                  DeviceProtocol        = t.DeviceProtocol,
                  DeviceCost            = t.DeviceCost,
                  DeviceMfgdesc         = t.DeviceMfgdesc,
                  DeviceStatus          = t.DeviceStatus,
                  DeviceControlledBy    = t.DeviceControlledBy,
                  DeviceLocation        = t.DeviceLocation,
                  DeviceAddedDate       = t.DeviceAddedDate
              }).ToList();

            return items;
        }

        public bool Update(DeviceModel deviceModel)
        {
            var original = DatabaseManager.Instance.DeviceInventory.Find(deviceModel.DeviceInventoryId);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(deviceModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int deviceInventoryId)
        {
            var items = DatabaseManager.Instance.DeviceInventory
                                .Where(t => t.DeviceInventoryId == deviceInventoryId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.DeviceInventory.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private DeviceInventory ToDbModel(DeviceModel deviceModel)
        {


            //var deviceDb = mapper.Map<DeviceInventory>(deviceModel);


            var deviceDb = new DeviceInventory
            {
                DeviceInventoryId = deviceModel.DeviceInventoryId,
                DevicePartNumber = deviceModel.DevicePartNumber,
                DeviceSerialNumber = deviceModel.DeviceSerialNumber,
                DeviceMfgname = deviceModel.DeviceMfgname,
                DeviceDeviceName = deviceModel.DeviceDeviceName,
                DeviceType = deviceModel.DeviceType,
                DevicePowerType = deviceModel.DevicePowerType,
                DeviceAttributes = deviceModel.DeviceAttributes,
                DeviceProtocol = deviceModel.DeviceProtocol,
                DeviceCost = deviceModel.DeviceCost,
                DeviceMfgdesc = deviceModel.DeviceMfgdesc,
                DeviceStatus = deviceModel.DeviceStatus,
                DeviceControlledBy = deviceModel.DeviceControlledBy,
                DeviceLocation = deviceModel.DeviceLocation,
                DeviceAddedDate = deviceModel.DeviceAddedDate
            };

            return deviceDb;
        }
    }
}
