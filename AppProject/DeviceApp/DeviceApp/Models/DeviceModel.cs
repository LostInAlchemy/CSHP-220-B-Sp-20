using AutoMapper;
using System;

namespace DeviceApp.Models
{
    public class DeviceModel
    {
        private static MapperConfiguration mapperConfiguration = new MapperConfiguration(t => t.CreateMap<DeviceModel, Repository.DeviceModel>().ReverseMap());

        private static IMapper mapper = mapperConfiguration.CreateMapper();

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
        public DateTime DeviceAddedDate { get; set; }

        public Repository.DeviceModel ToRepositoryModel()
        {
            var deviceRepository = mapper.Map<Repository.DeviceModel>(this);

            //var deviceRepository = new Repository.DeviceModel
            //{
            //    DeviceInventoryId = DeviceInventoryId,
            //    DevicePartNumber = DevicePartNumber,
            //    DeviceSerialNumber = DeviceSerialNumber,
            //    DeviceMfgname = DeviceMfgname,
            //    DeviceDeviceName = DeviceDeviceName,
            //    DeviceType = DeviceType,
            //    DeviceCost = DeviceCost,
            //    DeviceAttributes = DeviceAttributes,
            //    DeviceStatus = DeviceStatus,
            //    DeviceProtocol = DeviceProtocol,
            //    DeviceControlledBy = DeviceControlledBy,
            //    DevicePowerType = DevicePowerType,
            //    DeviceLocation = DeviceLocation,
            //    DeviceMfgdesc = DeviceMfgdesc,
            //    DeviceAddedDate = DeviceAddedDate
            //};

            return deviceRepository;
        }

        public static DeviceModel ToModel(Repository.DeviceModel deviceRepository)
        {
            var deviceModel = mapper.Map<DeviceModel>(deviceRepository);

            //var deviceModel = new DeviceModel
            //{
            //    DeviceInventoryId = deviceRepository.DeviceInventoryId,
            //    DevicePartNumber = deviceRepository.DevicePartNumber,
            //    DeviceSerialNumber = deviceRepository.DeviceSerialNumber,
            //    DeviceMfgname = deviceRepository.DeviceMfgname,
            //    DeviceDeviceName = deviceRepository.DeviceDeviceName,
            //    DeviceType = deviceRepository.DeviceType,
            //    DeviceCost = deviceRepository.DeviceCost,
            //    DeviceAttributes = deviceRepository.DeviceAttributes,
            //    DeviceStatus = deviceRepository.DeviceStatus,
            //    DeviceProtocol = deviceRepository.DeviceProtocol,
            //    DeviceControlledBy = deviceRepository.DeviceControlledBy,
            //    DevicePowerType = deviceRepository.DevicePowerType,
            //    DeviceLocation = deviceRepository.DeviceLocation,
            //    DeviceMfgdesc = deviceRepository.DeviceMfgdesc,
            //    DeviceAddedDate = deviceRepository.DeviceAddedDate
            //};

            return deviceModel;
        }

        public DeviceModel Clone()
        {
            return (DeviceModel)MemberwiseClone();
        }

        //public static explicit operator DeviceModel(Repository.DeviceModel v)
        //{
        //    DeviceModel helpme = v.;

        //    return helpme;
        //}
    }
}
