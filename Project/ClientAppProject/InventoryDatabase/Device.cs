using System;
using System.Collections.Generic;

namespace InventoryDatabase
{
    public partial class Device
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
    }
}

/*
 * Nuget Packages
 * Install-Package Microsoft.EntityFrameworkCore.Tools
 * Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 3.1.2
 * Scaffold-DbContext 'Data Source=(local);Initial Catalog=ClientApplicationsDatabase;integrated security=True' Microsoft.EntityFrameworkCore.SqlServer 
 */
