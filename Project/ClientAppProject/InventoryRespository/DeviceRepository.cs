using AutoMapper;
using InventoryDatabase;
using InventoryRespository;
using System.Collections.Generic;
using System.Linq;

namespace DeviceRepository
{
    public class DeviceModel
    {
        public byte InventoryId { get; set; }
        public string PartNumber { get; set; }
        public string MfgName { get; set; }
        public string DeviceName { get; set; }
        public string Type { get; set; }
        public string Desc { get; set; }
        public decimal? Cost { get; set; }
        public string Attributes { get; set; }
        public System.DateTime AddedDate { get; set; }
    }

    public class DeviceRepository
    {
        //private static MapperConfiguration mapperConfiguration = new MapperConfiguration(t => t.CreateMap<DeviceModel, DeviceRepository>().ReverseMap());

        //private static IMapper mapper = mapperConfiguration.CreateMapper();

        public DeviceModel Add(DeviceModel deviceModel)
        {
            var deviceDb = ToDbModel(deviceModel);

            DatabaseManager.Instance.Device.Add(deviceDb);
            DatabaseManager.Instance.SaveChanges();

            //deviceModel = mapper.Map<DeviceModel>(InventoryDatabase.Device);



            deviceModel = new DeviceModel
            {
                InventoryId = deviceDb.InventoryId,
                PartNumber = deviceDb.PartNumber,
                MfgName = deviceDb.MfgName,
                DeviceName = deviceDb.DeviceName,
                Type = deviceDb.Type,
                Desc = deviceDb.Desc,
                Cost = deviceDb.Cost,
                Attributes = deviceDb.Attributes,
                AddedDate = deviceDb.AddedDate
            };
            return deviceModel;
        }

        public List<DeviceModel> GetAll()
        {
            // Use .Select() to map the database contacts to ContactModel


            //var items = mapper.Map<Device>(Models.DeviceRepository);


            var items = DatabaseManager.Instance.Device
              .Select(t => new DeviceModel
              {
                  InventoryId = t.InventoryId,
                  PartNumber = t.PartNumber,
                  MfgName = t.MfgName,
                  DeviceName = t.DeviceName,
                  Type = t.Type,
                  Desc = t.Desc,
                  Cost = t.Cost,
                  Attributes = t.Attributes,
                  AddedDate = t.AddedDate,
              }).ToList();

            return items;
        }

        public bool Update(DeviceModel deviceModel)
        {
            var original = DatabaseManager.Instance.Device.Find(deviceModel.InventoryId);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(deviceModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int inventoryId)
        {
            var items = DatabaseManager.Instance.Device
                                .Where(t => t.InventoryId == inventoryId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Device.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Device ToDbModel(DeviceModel deviceModel)
        {

            //var deviceDb = mapper.Map<DeviceModel>(InventoryDatabase.Device);

            var deviceDb = new Device
            {
                InventoryId = deviceModel.InventoryId,
                PartNumber = deviceModel.PartNumber,
                MfgName = deviceModel.MfgName,
                DeviceName = deviceModel.DeviceName,
                Type = deviceModel.Type,
                Desc = deviceModel.Desc,
                Cost = deviceModel.Cost,
                Attributes = deviceModel.Attributes,
                AddedDate = deviceModel.AddedDate,
            };

            return deviceDb;
        }
    }
}






/*
 * Nuget Packages
 * Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection -Version 7.0.0
 */
