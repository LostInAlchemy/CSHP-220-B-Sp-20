using System;
using System.Collections.Generic;

namespace DeviceDB
{
    public partial class TypeInventory
    {
        public byte TypeInventoryId { get; set; }
        public string TypeType { get; set; }
        public string TypeDesc { get; set; }
        public DateTime TypeAddedDate { get; set; }
    }
}
