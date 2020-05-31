using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ClientAppProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static DeviceRepository.DeviceRepository deviceRepository;

        static App()
        {
            deviceRepository = new DeviceRepository.DeviceRepository();
        }

        public static DeviceRepository.DeviceRepository DeviceRepository
        {
            get
            {
                return deviceRepository;
            }
        }
    }
}
