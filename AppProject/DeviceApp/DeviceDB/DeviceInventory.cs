using System;
using System.Collections.Generic;

namespace DeviceDB
{
    public partial class DeviceInventory
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
        public DateTime DeviceAddedDate { get; set; }
    }
}
