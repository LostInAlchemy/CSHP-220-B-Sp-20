using System;

namespace DeviceApp.Models
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
        public DateTime AddedDate { get; set; }

        public DeviceRepository.DeviceModel ToRepositoryModel()
        {
            var repositoryModel = new DeviceRepository.DeviceModel
            {
                InventoryId = InventoryId,
                PartNumber = PartNumber,
                MfgName = MfgName,
                DeviceName = DeviceName,
                Type = Type,
                Desc = Desc,
                Cost = Cost,
                Attributes = Attributes,
                AddedDate = AddedDate
            };

            return repositoryModel;
        }

        public static DeviceModel ToModel(DeviceRepository.DeviceModel respositoryModel)
        {
            var deviceModel = new DeviceModel
            {
                InventoryId = respositoryModel.InventoryId,
                PartNumber = respositoryModel.PartNumber,
                MfgName = respositoryModel.MfgName,
                DeviceName = respositoryModel.DeviceName,
                Type = respositoryModel.Type,
                Desc = respositoryModel.Desc,
                Cost = respositoryModel.Cost,
                Attributes = respositoryModel.Attributes,
                AddedDate = respositoryModel.AddedDate
            };

            return deviceModel;
        }
    }
}